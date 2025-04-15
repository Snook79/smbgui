using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SMBGUI.SMBLibrary;

namespace SMBGUI
{
    #region frmGUI
    public partial class frmGui : Form
    {
        public class ServerSMB
        {
            public string uuid { get; set; }
            public string nomeConnessione { get; set; }
            public string server { get; set; }
            public string utente { get; set; }
            public string password { get; set; }
            public string drive { get; set; }
            public string dominio { get; set; }
            public string persistent { get; set; }
        }

        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(int eventId, uint flags, IntPtr item1, IntPtr item2);

        private Point dragStartPoint;

        private void frmGui_Load(object sender, EventArgs e)
        {
            // Leggi il contenuto del file config.json (se presente)
            string json = File.Exists("config.json") ? File.ReadAllText("config.json") : "";

            // Deserializza il contenuto del file JSON in un DataTable
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

            // Imposta il DataSource della lista con il DataTable
            lstServer.DataSource = dt;
            lstServer.DisplayMember = "nomeConnessione";

            // Imposta il DataSource della ComboBox con tutte le lettere disponibili da F a Z
            char[] driveLetters = Enumerable.Range('F', 21)
                .Select(x => (char)x)
                .Where(c => !Path.GetInvalidPathChars().Contains(c))
                .ToArray();
            cmbDriveLetter.DataSource = driveLetters;
            cmbDriveLetter.SelectedIndex = -1; // Imposta l'indice selezionato su nessuno
        }

        private DataTable originalDataTable;
        #endregion

        #region MAIN
        private void LoadConfig()
        {
            // Leggi il contenuto del file config.json (se presente)
            string json = File.Exists("config.json") ? File.ReadAllText("config.json") : "";

            // Deserializza il contenuto del file JSON in un DataTable
            originalDataTable = JsonConvert.DeserializeObject<DataTable>(json);

            // Imposta il DataSource della lista con il DataTable
            lstServer.DataSource = originalDataTable;
            lstServer.DisplayMember = "nomeConnessione";
        }
        public frmGui()
        {
            InitializeComponent();
            LoadConnectionsFromFile();
            LoadConfig();

            contextMenuLST.Items.Add("Apri in Esplora Risorse", null, openExplorerToolStripMenuItem_Click);
            contextMenuLST.Items.Add("Apri Terminale", null, openTerminalToolStripMenuItem_Click);
            contextMenuLST.Items.Add("Disconnetti", null, disconnectToolStripMenuItem_Click);

            // Configura il drag-and-drop per la ListBox
            lstServer.AllowDrop = true;
            lstServer.MouseDown += lstServer_MouseDown;
            lstServer.MouseMove += lstServer_MouseMove;
            lstServer.DragEnter += lstServer_DragEnter;
            lstServer.DragOver += lstServer_DragOver;
            lstServer.DragDrop += lstServer_DragDrop;

            this.lstServer.SelectedIndexChanged += new EventHandler(lstServer_SelectedIndexChanged);

            this.FormClosing += frmGui_FormClosing;


            if (File.Exists("config.json"))
            {
                string jsonString = File.ReadAllText("config.json");
                if (!string.IsNullOrEmpty(jsonString))
                {
                    // Il file esiste ed ha contenuti validi, analizzalo come un array di oggetti JSON.
                    JArray jsonArray = JArray.Parse(jsonString);
                    if (jsonArray.Count > 0)
                    {
                        JObject json = (JObject)jsonArray[0];
                        txtNomeSMB.Text = json.GetValue("nomeConnessione").ToString();
                        txtServer.Text = json.GetValue("server").ToString();
                        txtDomain.Text = json.GetValue("dominio").ToString();
                        txtUser.Text = json.GetValue("utente").ToString();
                        txtPassword.Text = json.GetValue("password").ToString();
                        cmbDriveLetter.Text = json.GetValue("drive").ToString();

                        if (json.GetValue("persistent").ToString() == "true")
                        {
                            chkPersist.Checked = true;
                        }
                        else
                        {
                            chkPersist.Checked = false;
                        }

                        chkSave.Checked = false;
                    }
                    else
                    {
                        // L'array esiste ma è vuoto, crea un oggetto JSON vuoto e aggiungilo all'array.
                        JObject newJson = new JObject();
                        newJson.Add("uuid", "");
                        newJson.Add("nomeConnessione", "");
                        newJson.Add("server", "");
                        newJson.Add("dominio", "");
                        newJson.Add("utente", "");
                        newJson.Add("password", "");
                        newJson.Add("drive", "");
                        newJson.Add("persistent", "");
                        jsonArray.Add(newJson);
                        using (StreamWriter sw = File.CreateText("config.json"))
                        {
                            sw.Write(jsonArray.ToString());
                        }

                        // Imposta valori di default per i campi del form.
                        ClearInputFields();
                    }
                }
                else
                {
                    // Il file esiste ma è vuoto, crea un array JSON vuoto e salvalo nel file.
                    JArray newJsonArray = new JArray();
                    JObject newJson = new JObject();
                    newJson.Add("nomeConnessione", "");
                    newJson.Add("server", "");
                    newJson.Add("dominio", "");
                    newJson.Add("utente", "");
                    newJson.Add("password", "");
                    newJson.Add("drive", "");
                    newJson.Add("persistent", "");
                    newJsonArray.Add(newJson);
                    using (StreamWriter sw = File.CreateText("config.json"))
                    {
                        sw.Write(newJsonArray.ToString());
                    }

                    // Imposta valori di default per i campi del form.
                    ClearInputFields();
                }
            }
            else
            {
                // Il file non esiste, crea un array JSON vuoto.
                JArray newJsonArray = new JArray();
                JObject newJson = new JObject();
                newJson.Add("uuid", "");
                newJson.Add("nomeConnessione", "");
                newJson.Add("server", "");
                newJson.Add("dominio", "");
                newJson.Add("utente", "");
                newJson.Add("password", "");
                newJson.Add("drive", "");
                newJson.Add("persistent", "");
                newJsonArray.Add(newJson);
                using (StreamWriter sw = File.CreateText("config.json"))
                {
                    sw.Write(newJsonArray.ToString());
                }

                // Imposta valori di default per i campi del form.
                ClearInputFields();
            }
        }
        private void LoadConnectionsFromFile()
        {
            string jsonFilePath = "connections.json";

            if (File.Exists(jsonFilePath))
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                List<ConnectionInfo> connectionList = JsonConvert.DeserializeObject<List<ConnectionInfo>>(jsonContent);

                // Pulisci la ListBox prima di aggiungere nuovi elementi
                lstConnessioni.Items.Clear();

                foreach (ConnectionInfo connection in connectionList)
                {
                    lstConnessioni.Items.Add($"{connection.Name} - {connection.DriveLetter}");
                }

                // Salva l'elenco delle connessioni caricate insieme ai loro indici nel tag della ListBox
                lstConnessioni.Tag = connectionList;
            }
        }

        private void frmGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            CustomDialogForm customDialog = new CustomDialogForm();
            DialogResult result = customDialog.ShowDialog();

            //DialogResult result = MessageBox.Show("La Lista delle Connessioni Aperte verrà reinizializzata. \n Confermi l'Uscita?", "Chiusura Applicazione", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                // Codice per svuotare il file connection.json
                string jsonFilePath = "connections.json";
                System.IO.File.WriteAllText(jsonFilePath, "[]");
            }
            else
            {
                // Annulla la chiusura dell'applicazione
                e.Cancel = true;
            }
        }
        public class ConnectionInfo
        {
            public string Name { get; set; }
            public string DriveLetter { get; set; }
        }

        private void WriteConnectionInfoToFile(string name, string driveLetter)
        {
            List<ConnectionInfo> connectionList;

            string jsonFilePath = "connections.json";
            if (File.Exists(jsonFilePath))
            {
                string existingJson = File.ReadAllText(jsonFilePath);
                connectionList = JsonConvert.DeserializeObject<List<ConnectionInfo>>(existingJson);
            }
            else
            {
                connectionList = new List<ConnectionInfo>();
            }

            ConnectionInfo newConnection = new ConnectionInfo
            {
                Name = name,
                DriveLetter = driveLetter
            };

            connectionList.Add(newConnection);

            string updatedJson = JsonConvert.SerializeObject(connectionList, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);
        }

        
        private bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(txtNomeSMB.Text) ||
                string.IsNullOrWhiteSpace(txtServer.Text) ||
                string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUUID.Text) ||
                string.IsNullOrWhiteSpace(cmbDriveLetter.Text))
            {
                MessageBox.Show("I Campi sono già vuoti", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region Cerca
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Leggi il contenuto del file config.json (se presente)
                string json = File.Exists("config.json") ? File.ReadAllText("config.json") : "";

                // Deserializza il contenuto del file JSON in un DataTable
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                // Imposta il DataSource della lista con il DataTable
                lstServer.DataSource = dt;
                lstServer.DisplayMember = "nomeConnessione";

                // Svuota i campi di input
                ClearInputFields();
            }
            else
            {
                // Crea una vista filtrata del DataTable originale
                DataView dv = originalDataTable.DefaultView;
                dv.RowFilter = $"nomeConnessione LIKE '%{searchTerm}%'";

                // Imposta il DataSource della lista con la vista filtrata
                lstServer.DataSource = dv.ToTable();
            }
        }
        #endregion

        #region List Server Function
        private void lstServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServer.SelectedItem != null)
            {
                // Ottieni l'elemento selezionato come DataRowView
                DataRowView selectedRow = lstServer.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    // Estrai i valori delle colonne e imposta i campi di testo
                    txtNomeSMB.Text = selectedRow["nomeConnessione"].ToString();
                    txtServer.Text = selectedRow["server"].ToString();
                    txtDomain.Text = selectedRow["dominio"].ToString();
                    txtUser.Text = selectedRow["utente"].ToString();
                    txtPassword.Text = selectedRow["password"].ToString();
                    cmbDriveLetter.Text = selectedRow["drive"].ToString();
                    txtUUID.Text = selectedRow["uuid"].ToString();

                    // Tenta di convertire il valore di "persistent" in un booleano
                    if (bool.TryParse(selectedRow["persistent"].ToString(), out bool isPersistent))
                    {
                        chkPersist.Checked = isPersistent;
                    }
                    else
                    {
                        chkPersist.Checked = false; // Imposta un valore predefinito se la conversione fallisce
                    }

                }
            }
        }
        private void lstServer_DoubleClick(object sender, EventArgs e)
        {
            if (lstServer.SelectedItem != null) // Controlla che un elemento sia stato selezionato
            {
                // Chiamata alla funzione btnCarica
                //btnCarica_Click(sender, e);
                btnConnetti_Click(sender, e);
            }
        }
        #endregion

        #region Bottoni
        private void btnSvuota_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                DialogResult result = MessageBox.Show("Confermi lo Svuotamento dei Campi?", "Svuota Campi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    lstServer.SelectedIndex = -1;
                    ClearInputFields();
                }
            }
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            rtbOutput.Text = "";
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
        public void btnCarica_Click(object sender, EventArgs e)
        {
            string jsonFilePath = "config.json"; // imposta il percorso del file JSON
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                // deserializza il contenuto JSON in oggetti ServerSMB
                List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(jsonData);

                // visualizza i dati come desiderato
                if (servers.Count > 0) // controlla se l'elenco non è vuoto
                {
                    var firstServer = servers[lstServer.SelectedIndex];
                    txtNomeSMB.Text = firstServer.nomeConnessione;
                    txtServer.Text = firstServer.server;
                    txtDomain.Text = firstServer.dominio;
                    txtUser.Text = firstServer.utente;
                    txtPassword.Text = firstServer.password;
                    cmbDriveLetter.Text = firstServer.drive;
                    txtUUID.Text = firstServer.uuid;
                    if (bool.TryParse(firstServer.persistent, out bool isPersistent))
                    {
                        chkPersist.Checked = isPersistent;
                    }
                    else
                    {
                        chkPersist.Checked = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Il file JSON non esiste.");
            }
        }
        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lstServer.SelectedIndex == -1)
            {
                MessageBox.Show("Selezionare un elemento dalla lista da eliminare.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Confermi l'Eliminazione?", "Elimina", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                // Ottiene l'indice dell'elemento selezionato nella lista
                int selectedIndex = lstServer.SelectedIndex;

                if (selectedIndex >= 0)
                {
                    // Leggi il contenuto del file JSON esistente
                    string existingJson = File.Exists("config.json") ? File.ReadAllText("config.json") : "[]";

                    // Deserializza il contenuto del file JSON in una lista di oggetti ServerSMB
                    List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(existingJson);

                    // Copia l'elemento selezionato dalla lista nel file di backup
                    ServerSMB serverDeleted = servers[selectedIndex];
                    string backupPath = "config_deleted.json";
                    List<ServerSMB> backupServers;

                    if (File.Exists(backupPath))
                    {
                        // Se il file esiste già, leggi il contenuto e deserializza in una lista di oggetti ServerSMB
                        string existingBackupJson = File.ReadAllText(backupPath);
                        backupServers = JsonConvert.DeserializeObject<List<ServerSMB>>(existingBackupJson);
                    }
                    else
                    {
                        // Altrimenti, crea una nuova lista vuota
                        backupServers = new List<ServerSMB>();
                    }

                    // Aggiungi l'elemento eliminato alla lista di backup
                    backupServers.Add(serverDeleted);

                    // Serializza la lista di oggetti ServerSMB e scrivi il contenuto nel file di backup
                    string jsonBackup = JsonConvert.SerializeObject(backupServers, Formatting.Indented);
                    File.WriteAllText("config_deleted.json", jsonBackup);

                    // Rimuovi l'elemento selezionato dalla lista
                    servers.RemoveAt(selectedIndex);

                    // Serializza la lista di oggetti ServerSMB e scrivi il contenuto nel file JSON originale
                    string json = JsonConvert.SerializeObject(servers, Formatting.Indented);
                    File.WriteAllText("config.json", json);

                    // Aggiorna il DataSource della lista con la nuova lista di oggetti ServerSMB
                    lstServer.DataSource = servers;
                    lstServer.DisplayMember = "nomeConnessione";

                    LoadConfig();

                    //Svuota i Campi
                    ClearInputFields();

                    cmbDriveLetter.SelectedIndex = -1; // Imposta l'indice selezionato su nessuno
                }
            }
            else
            {
                // Do nothing
            }
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeSMB.Text) || string.IsNullOrEmpty(txtServer.Text) || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cmbDriveLetter.Text))
            {
                MessageBox.Show("Per favore compila tutti i campi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Confermi il Salvataggio?", "Salva", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    string nomeConnessione = txtNomeSMB.Text;
                    string server = txtServer.Text;
                    string domain = txtDomain.Text;
                    string utente = txtUser.Text;
                    string password = txtPassword.Text;
                    string drive = cmbDriveLetter.Text;
                    string persistent = chkPersist.Checked ? "true" : "false";

                    // Verifica se è necessario creare un nuovo UUID o utilizzare quello esistente
                    Guid uuid;
                    if (string.IsNullOrEmpty(txtUUID.Text))
                    {
                        uuid = Guid.NewGuid();
                    }
                    else
                    {
                        uuid = Guid.Parse(txtUUID.Text);
                    }

                    // Leggi il contenuto del file JSON esistente
                    string existingJson = File.Exists("config.json") ? File.ReadAllText("config.json") : "";

                    // Crea un array di oggetti JSON vuoto
                    JArray jsonArray = new JArray();

                    // Se il file JSON esistente non è vuoto, deserializzalo in un array di oggetti JSON
                    if (!string.IsNullOrEmpty(existingJson))
                    {
                        jsonArray = JArray.Parse(existingJson);

                        // Cerca l'oggetto JSON con l'UUID corrispondente
                        JObject jsonToUpdate = null;
                        foreach (JObject json in jsonArray)
                        {
                            Guid existingUuid;
                            // Verifichiamo che il valore 'uuid' all'interno del JSON sia una GUID valida prima di tentare la conversione.
                            if (Guid.TryParse(json["uuid"].ToString(), out existingUuid))
                            {
                                if (existingUuid == uuid)
                                {
                                    jsonToUpdate = json;
                                    break;
                                }
                            }
                        }

                        if (jsonToUpdate != null)
                        {
                            // Aggiorna i campi dell'oggetto esistente
                            jsonToUpdate["nomeConnessione"] = nomeConnessione;
                            jsonToUpdate["server"] = server;
                            jsonToUpdate["dominio"] = domain;
                            jsonToUpdate["utente"] = utente;
                            jsonToUpdate["password"] = password;
                            jsonToUpdate["drive"] = drive;
                            jsonToUpdate["persistent"] = persistent;

                            // Scrivi l'array di oggetti JSON aggiornato nel file JSON
                            File.WriteAllText("config.json", jsonArray.ToString());

                            // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                            frmGui_Load(sender, e);

                            // Svuota i campi di input
                            ClearInputFields();
                        }
                        else
                        {
                            // Creazione dell'oggetto JSON per la nuova connessione
                            JObject json = new JObject();
                            json.Add("uuid", uuid.ToString());
                            json.Add("nomeConnessione", nomeConnessione);
                            json.Add("server", server);
                            json.Add("dominio", domain);
                            json.Add("utente", utente);
                            json.Add("password", password);
                            json.Add("drive", drive);
                            json.Add("persistent", persistent);

                            // Aggiungi il nuovo oggetto JSON all'array di oggetti JSON
                            jsonArray.Add(json);

                            // Scrivi l'array di oggetti JSON aggiornato nel file JSON
                            File.WriteAllText("config.json", jsonArray.ToString());

                            // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                            frmGui_Load(sender, e);

                            // Svuota i campi di input
                            ClearInputFields();
                        }
                    }
                    else
                    {
                        // Creazione dell'oggetto JSON per la nuova connessione
                        JObject json = new JObject();
                        json.Add("uuid", uuid.ToString());
                        json.Add("nomeConnessione", nomeConnessione);
                        json.Add("server", server);
                        json.Add("dominio", domain);
                        json.Add("utente", utente);
                        json.Add("password", password);
                        json.Add("drive", drive);
                        json.Add("persistent", persistent);

                        // Aggiungi il nuovo oggetto JSON all'array di oggetti JSON
                        jsonArray.Add(json);

                        // Scrivi l'array di oggetti JSON aggiornato nel file JSON
                        File.WriteAllText("config.json", jsonArray.ToString());

                        // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                        frmGui_Load(sender, e);

                        // Svuota i campi di input
                        ClearInputFields();
                    }
                }
                else
                {
                    // Do nothing
                }
            }
        }
        private void btnConnetti_Click(object sender, EventArgs e)
        {
            if (lstServer.SelectedIndex == -1 || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text)
            || string.IsNullOrEmpty(txtServer.Text) || string.IsNullOrEmpty(cmbDriveLetter.Text))
            {
                MessageBox.Show("Per favore seleziona una connessione dalla Lista e compila tutti i campi.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MessageBox.Show("Confermi la Connessione?", "Connessione...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        FileName = "cmd.exe"
                    };

                    if (string.IsNullOrEmpty(txtDomain.Text))
                    {
                        startInfo.Arguments = $"/C net use {cmbDriveLetter.SelectedItem.ToString()}: {txtServer.Text} {txtPassword.Text} /USER:{txtUser.Text} /{(chkPersist.Checked ? "persistent:yes" : "persistent:no")}";
                    }
                    else
                    {
                        startInfo.Arguments = $"/C net use {cmbDriveLetter.SelectedItem.ToString()}: {txtServer.Text} {txtPassword.Text} /USER:{txtDomain.Text}\\{txtUser.Text} /{(chkPersist.Checked ? "persistent:yes" : "persistent:no")}";
                    }

                    process.StartInfo = startInfo;

                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    string results = $"Connessione SMB \"{txtNomeSMB.Text}\" \"{cmbDriveLetter.SelectedItem}\" avviata{Environment.NewLine}{output}{Environment.NewLine}{error}";
                    rtbOutput.AppendText(results);

                    process.WaitForExit();

                    // Avvia l'applicazione specificata come argomento di net use
                    Process.Start(startInfo);

                    // Controlla il valore restituito dalla proprietà ExitCode per verificare se il comando è stato eseguito correttamente
                    if (process.ExitCode == 0)
                    {
                        // Dopo aver avviato con successo la connessione SMB e ottenuto i valori di nome e lettera
                        WriteConnectionInfoToFile(txtNomeSMB.Text, cmbDriveLetter.SelectedItem.ToString());
                        // Aggiorna la ListBox con le nuove connessioni
                        LoadConnectionsFromFile();
                    }
                    else
                    {
                        // Se c'è stato un errore, visualizza un messaggio di errore
                        MessageBox.Show("Si è verificato un errore durante la connessione al server SMB.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("Connessione Annullata", "Connesione");
                    // Do nothing
                }

                if (chkSave.Checked)
                {
                    btnSalva_Click(sender, e);
                    chkSave.Checked = false;
                }
            }
        }
        private void btnDuplica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUUID.Text))
            {
                MessageBox.Show("Seleziona e Carica una configurazione da duplicare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Leggi il contenuto del file JSON esistente
            string existingJson = File.Exists("config.json") ? File.ReadAllText("config.json") : "";

            // Deserializza l'array di oggetti JSON
            JArray jsonArray = JArray.Parse(existingJson);

            // Cerca l'oggetto JSON con l'UUID corrispondente
            JObject jsonToDuplicate = null;
            foreach (JObject json in jsonArray)
            {
                Guid existingUuid;
                // Verifica che il valore 'uuid' all'interno del JSON sia una GUID valida prima di tentare la conversione.
                if (Guid.TryParse(json["uuid"].ToString(), out existingUuid))
                {
                    if (existingUuid == Guid.Parse(txtUUID.Text))
                    {
                        jsonToDuplicate = json;
                        break;
                    }
                }
            }

            if (jsonToDuplicate != null)
            {

                // Salva il nome della connessione originale
                string originalConnectionName = jsonToDuplicate["nomeConnessione"].ToString();

                string results = $"Duplicazione: {originalConnectionName}{Environment.NewLine}";
                rtbOutput.AppendText(results);

                // Genera un nuovo UUID per la connessione duplicata
                Guid newUuid = Guid.NewGuid();

                // Crea una copia dell'oggetto JSON da duplicare
                JObject duplicatedJson = new JObject(jsonToDuplicate);

                // Aggiorna il valore dell'UUID nella copia
                duplicatedJson["uuid"] = newUuid.ToString();

                // Aggiungi la copia all'array di oggetti JSON
                jsonArray.Add(duplicatedJson);

                // Crea una nuova istanza della form DuplicaConfigurazioneForm
                DuplicaConfigurazioneForm duplicaForm = new DuplicaConfigurazioneForm(jsonToDuplicate);

                // Visualizza la form e attende che l'utente la chiuda
                if (duplicaForm.ShowDialog() == DialogResult.OK)
                {
                    // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                    frmGui_Load(sender, e);
                }

                // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                frmGui_Load(sender, e);

                // Svuota i campi di input
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Configurazione non trovata.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnetti_Click(object sender, EventArgs e)
        {
            string selectedDriveLetter = cmbDriveLetter.SelectedItem.ToString().Substring(0, 1);

            // Rimuovi la connessione corrispondente dal file JSON
            List<ConnectionInfo> connectionList = lstConnessioni.Tag as List<ConnectionInfo>;
            ConnectionInfo connectionToRemove = connectionList.FirstOrDefault(c => c.DriveLetter == selectedDriveLetter);

            if (connectionToRemove != null)
            {
                connectionList.Remove(connectionToRemove);

                string jsonFilePath = "connections.json";
                string updatedJson = JsonConvert.SerializeObject(connectionList, Formatting.Indented);
                File.WriteAllText(jsonFilePath, updatedJson);

                LoadConnectionsFromFile(); // Aggiorna la ListBox
            }

            Process process = new Process();
            ProcessStartInfo disconnectStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                FileName = "cmd.exe",
                Arguments = $"/C net use {cmbDriveLetter.SelectedItem.ToString()}: /delete /y"
            };
            process.StartInfo = disconnectStartInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (string.IsNullOrEmpty(error))
            {
                string results = $"L'unità \"{selectedDriveLetter}\" è stata disconnessa con successo.{Environment.NewLine}{output}";
                rtbOutput.AppendText(results);
            }
            else
            {
                string results = $"Si è verificato un errore durante la disconnessione dell'unità \"{selectedDriveLetter}\"{Environment.NewLine}{error}";
                rtbOutput.AppendText(results);
            }

            // Svuota i campi di input
            ClearInputFields();

            // Esegue il refresh della finestra di Esplora Risorse
            SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        }
        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            // Crea un nuovo oggetto SaveFileDialog
            SaveFileDialog saveDialog = new SaveFileDialog();

            // Imposta le proprietà del dialogo di salvataggio
            saveDialog.Filter = "File di testo (*.txt)|*.txt";
            saveDialog.Title = "Salva il file di testo";
            saveDialog.FileName = "Nuovo file di testo";

            // Controlla se la RichTextBox contiene del testo prima di mostrare la finestra di dialogo di salvataggio
            if (rtbOutput.TextLength > 0)
            {
                // Mostra il dialogo di salvataggio e salva il file se l'utente ha fatto clic su OK
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Salva il contenuto della RichTextBox nel file selezionato dall'utente
                    string filePath = saveDialog.FileName;
                    System.IO.File.WriteAllText(filePath, rtbOutput.Text);
                }
            }
            else
            {
                // Avvisa l'utente che non c'è nulla da salvare
                MessageBox.Show("Il File di LOG risulta ancora vuoto.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region StripMenu
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformazioni informazioniForm = new frmInformazioni();
            informazioniForm.ShowDialog(this);
        }
        private void archivioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea una nuova istanza di frmArchivio
            frmArchivio frmArchivio = new frmArchivio();

            // Visualizza la form e attende che l'utente la chiuda
            if (frmArchivio.ShowDialog() == DialogResult.OK)
            {
                // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                frmGui_Load(sender, e);
            }
            // Scrivi l'array di oggetti JSON aggiornato nel file JSON
            //File.WriteAllText("config.json", jsonArray.ToString());

            // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
            frmGui_Load(sender, e);
        }
        private void esportaConnessioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("config.json");
            List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(json);

            // crea una finestra di dialogo SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // visualizza la finestra di dialogo e se l'utente conferma, scrivi i dati su file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // serializza l'oggetto Config in formato JSON e lo scrive su file
                string nuovoJson = JsonConvert.SerializeObject(servers, Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, nuovoJson);
            }
        }
        private void importaConnessioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // crea una finestra di dialogo OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // visualizza la finestra di dialogo e se l'utente conferma, carica il file JSON selezionato
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);

                // deserializza il JSON in una lista di oggetti ServerSMB
                List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(json);

                // aggiungi un nuovo uuid a qualsiasi oggetto che non ne ha uno
                foreach (var server in servers)
                {
                    if (string.IsNullOrEmpty(server.uuid))
                    {
                        server.uuid = Guid.NewGuid().ToString();
                    }
                }

                // chiede all'utente se vuole sovrascrivere le connessioni esistenti o aggiungere quelle nuove
                DialogResult dialogResult = MessageBox.Show("Vuoi sovrascrivere le connessioni esistenti?", "Importazione connessioni", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) // sovrascrive le connessioni esistenti con quelle importate
                {
                    // serializza la lista di oggetti ServerSMB in formato JSON e la scrive sul file config.json
                    string nuovoJson = JsonConvert.SerializeObject(servers, Formatting.Indented);
                    File.WriteAllText("config.json", nuovoJson);

                    // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                    frmGui_Load(sender, e);
                }
                else if (dialogResult == DialogResult.No) // aggiunge le nuove connessioni a quelle esistenti
                {
                    // legge il contenuto del file config.json e deserializza l'oggetto Config in una lista di oggetti ServerSMB
                    string configJson = File.ReadAllText("config.json");
                    List<ServerSMB> existingServers = JsonConvert.DeserializeObject<List<ServerSMB>>(configJson);

                    // unisce la lista di oggetti ServerSMB del file importato con quella esistente e la serializza in formato JSON
                    existingServers.AddRange(servers);
                    string nuovoJson = JsonConvert.SerializeObject(existingServers, Formatting.Indented);

                    // scrive il nuovo contenuto sul file config.json
                    File.WriteAllText("config.json", nuovoJson);

                    // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                    frmGui_Load(sender, e);
                }
            }
        }
        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the custom exit form
            CustomDialogForm customDialog = new CustomDialogForm();
            customDialog.StartPosition = FormStartPosition.CenterParent; // Center the form relative to the main form
            DialogResult result = customDialog.ShowDialog(this);

            if (result == DialogResult.Yes)
            {
                // Codice per svuotare il file connection.json
                string jsonFilePath = "connections.json";
                System.IO.File.WriteAllText(jsonFilePath, "[]");

                // Uscita
                Application.ExitThread();
            }
            else
            {
                // Do nothing, user canceled the exit
            }
        }
        #endregion

        #region Context Menu Lista Connessioni Attive
        private void lstConnessioni_DoubleClick(object sender, EventArgs e)
        {
            if (lstConnessioni.SelectedItem != null)
            {
                // Mostra il menu contestuale al doppio clic
                contextMenuLST.Show(lstConnessioni, lstConnessioni.PointToClient(Cursor.Position));
            }
        }
        private void OpenTerminal(string driveLetter)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "wt.exe",
                Arguments = $"-d {driveLetter}:",
                CreateNoWindow = false,
                UseShellExecute = true
            };

            try
            {
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'apertura del terminale: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void openTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstConnessioni.SelectedItem != null)
            {
                var selectedConnection = lstConnessioni.SelectedItem.ToString();
                var driveLetter = selectedConnection.Split('-').Last().Trim(); // Estrai la lettera dell'unità
                OpenTerminal(driveLetter);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstConnessioni.SelectedItem != null)
            {
                var selectedConnection = lstConnessioni.SelectedItem.ToString();
                var driveLetter = selectedConnection.Split('-').Last().Trim(); // Estrai la lettera dell'unità

                // Esegui il comando per disconnettere l'unità
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        FileName = "cmd.exe",
                        Arguments = $"/C net use {driveLetter}: /delete /y"
                    }
                };
                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                // Prepara il messaggio di log
                string logMessage;
                if (string.IsNullOrEmpty(error))
                {
                    logMessage = $"L'unità \"{driveLetter}\" è stata disconnessa con successo.{Environment.NewLine}{output}";

                    // Rimuovi la connessione dalla lista
                    var connectionList = lstConnessioni.Tag as List<ConnectionInfo>;
                    var connectionToRemove = connectionList.FirstOrDefault(c => c.DriveLetter == driveLetter);

                    if (connectionToRemove != null)
                    {
                        connectionList.Remove(connectionToRemove);
                        lstConnessioni.Tag = connectionList; // Aggiorna il tag con la lista modificata

                        // Aggiorna il file JSON
                        string jsonFilePath = "connections.json";
                        string updatedJson = JsonConvert.SerializeObject(connectionList, Formatting.Indented);
                        File.WriteAllText(jsonFilePath, updatedJson);

                        // Ricarica la lista delle connessioni
                        LoadConnectionsFromFile(); // Aggiorna la ListBox
                    }
                }
                else
                {
                    logMessage = $"Si è verificato un errore durante la disconnessione dell'unità \"{driveLetter}\".{Environment.NewLine}{error}";
                }

                // Scrivi il messaggio di log nella RichTextBox
                rtbOutput.AppendText(logMessage + Environment.NewLine);

                // Mostra un messaggio di dialogo all'utente
                //MessageBox.Show(logMessage, string.IsNullOrEmpty(error) ? "Successo" : "Errore", MessageBoxButtons.OK, string.IsNullOrEmpty(error) ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
        }
        private void openExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstConnessioni.SelectedItem != null)
            {
                var selectedConnection = lstConnessioni.SelectedItem.ToString();
                var driveLetter = selectedConnection.Split('-').Last().Trim(); // Estrai la lettera dell'unità

                OpenExplorer(driveLetter);
            }
        }

        private void OpenExplorer(string driveLetter)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"{driveLetter}:\\",
                CreateNoWindow = true,
                UseShellExecute = true
            };

            Process.Start(processStartInfo);
        }
        #endregion

        #region Ordinamento Lista Connessioni
        private void lstServer_MouseDown(object sender, MouseEventArgs e)
        {
            // Memorizza il punto di inizio del drag
            dragStartPoint = e.Location;
        }

        private void lstServer_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // Calcola la distanza del mouse dal punto di inizio del drag
                var dragDistance = (Size)e.Location - (Size)dragStartPoint;

                // Esegui il drag-and-drop solo se il mouse è stato spostato oltre una certa soglia (per esempio 5 pixel)
                if (Math.Abs(dragDistance.Width) >= SystemInformation.DragSize.Width ||
                    Math.Abs(dragDistance.Height) >= SystemInformation.DragSize.Height)
                {
                    // Ottieni l'elemento selezionato come DataRowView
                    var data = lstServer.SelectedItem as DataRowView;
                    if (data != null)
                    {
                        lstServer.DoDragDrop(data, DragDropEffects.Move);
                    }
                }
            }
        }

        private void lstServer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstServer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstServer_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lstServer.PointToClient(new Point(e.X, e.Y));
            int index = lstServer.IndexFromPoint(point);
            if (index < 0) index = lstServer.Items.Count - 1;

            DataRowView data = (DataRowView)e.Data.GetData(typeof(DataRowView));

            if (data != null)
            {
                // Ottieni l'indice della riga da spostare
                int oldIndex = lstServer.Items.IndexOf(data);

                // Verifica che l'indice sia valido
                if (oldIndex >= 0 && oldIndex < originalDataTable.Rows.Count)
                {
                    DataRow row = originalDataTable.NewRow();
                    row.ItemArray = data.Row.ItemArray;

                    // Rimuovi la riga dalla vecchia posizione e inseriscila nella nuova posizione
                    originalDataTable.Rows.RemoveAt(oldIndex);
                    originalDataTable.Rows.InsertAt(row, index);

                    // Aggiorna il DataSource della ListBox
                    lstServer.DataSource = null;
                    lstServer.DataSource = originalDataTable;
                    lstServer.DisplayMember = "nomeConnessione";

                    // Aggiorna l'ordine nel file JSON
                    UpdateJsonOrder();
                }
            }
        }
        private void UpdateJsonOrder()
        {
            var jsonArray = new JArray();
            foreach (DataRow row in originalDataTable.Rows)
            {
                var jsonObject = new JObject();
                foreach (DataColumn column in originalDataTable.Columns)
                {
                    jsonObject[column.ColumnName] = row[column].ToString();
                }
                jsonArray.Add(jsonObject);
            }

            string updatedJson = JsonConvert.SerializeObject(jsonArray, Formatting.Indented);
            File.WriteAllText("config.json", updatedJson);
        }
        #endregion

        #region Svuota Campi
        private void ClearInputFields()
        {
            txtNomeSMB.Text = "";
            txtServer.Text = "";
            txtDomain.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
            txtUUID.Text = "";
            cmbDriveLetter.Text = "";
            chkSave.Checked = false;
            chkPersist.Checked = false;

            txtSearch.Text = "";

            lstServer.SelectedIndex = -1;
        }
        
       }
    #endregion
}