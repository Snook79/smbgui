using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SMBGUI.frmGui;

namespace SMBGUI.SMBLibrary
{
    public partial class frmArchivio : Form
    {
        private DataTable originalDataTable;

        private void LoadConfig()
        {
            // Leggi il contenuto del file config.json (se presente)
            string json = File.Exists("config_deleted.json") ? File.ReadAllText("config_deleted.json") : "";

            // Deserializza il contenuto del file JSON in un DataTable
            originalDataTable = JsonConvert.DeserializeObject<DataTable>(json);

            // Imposta il DataSource della lista con il DataTable
            lstDeletedServer.DataSource = originalDataTable;
            lstDeletedServer.DisplayMember = "nomeConnessione";
        }
        public frmArchivio()
        {
            InitializeComponent();
            LoadConfig();

            this.lstDeletedServer.SelectedIndexChanged += new EventHandler(lstServer_SelectedIndexChanged);

        }
        private void frmArchivio_Load(object sender, EventArgs e)
        {
            // Leggi il contenuto del file config.json (se presente)
            string json = File.Exists("config_deleted.json") ? File.ReadAllText("config_deleted.json") : "";

            // Deserializza il contenuto del file JSON in un DataTable
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

            // Imposta il DataSource della lista con il DataTable
            lstDeletedServer.DataSource = dt;
            lstDeletedServer.DisplayMember = "nomeConnessione";

            // Imposta il DataSource della ComboBox con tutte le lettere disponibili da F a Z
            char[] driveLetters = Enumerable.Range('F', 21)
                .Select(x => (char)x)
                .Where(c => !Path.GetInvalidPathChars().Contains(c))
                .ToArray();
            cmbDriveLetter.DataSource = driveLetters;
            cmbDriveLetter.SelectedIndex = -1; // Imposta l'indice selezionato su nessuno
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Leggi il contenuto del file config.json (se presente)
                string json = File.Exists("config_deleted.json") ? File.ReadAllText("config_deleted.json") : "";

                // Deserializza il contenuto del file JSON in un DataTable
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);

                // Imposta il DataSource della lista con il DataTable
                lstDeletedServer.DataSource = dt;
                lstDeletedServer.DisplayMember = "nomeConnessione";
            }
            else
            {
                // Crea una vista filtrata del DataTable originale
                DataView dv = originalDataTable.DefaultView;
                dv.RowFilter = $"nomeConnessione LIKE '%{searchTerm}%'";

                // Imposta il DataSource della lista con la vista filtrata
                lstDeletedServer.DataSource = dv.ToTable();
            }
        }

        private void ClearInputFields()
        {
            txtNomeSMB.Text = "";
            txtServer.Text = "";
            txtDomain.Text = "";
            txtUser.Text = "";
            txtPassword.Text = "";
            txtUUID.Text = "";
            chkPersist.Checked = false;
            cmbDriveLetter.Text = "";
        }
        private void lstServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDeletedServer.SelectedItem != null)
            {
                // Ottieni l'elemento selezionato come DataRowView
                DataRowView selectedRow = lstDeletedServer.SelectedItem as DataRowView;

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
            if (lstDeletedServer.SelectedItem != null) // Controlla che un elemento sia stato selezionato
            {
                // Chiamata alla funzione btnCarica
                btnCarica_Click(sender, e);
            }
        }
        public void btnCarica_Click(object sender, EventArgs e)
        {
            string jsonFilePath = "config_deleted.json"; // imposta il percorso del file JSON
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                // deserializza il contenuto JSON in oggetti ServerSMB
                List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(jsonData);

                // visualizza i dati come desiderato
                if (servers.Count > 0) // controlla se l'elenco non è vuoto
                {
                    var firstServer = servers[lstDeletedServer.SelectedIndex];
                    txtNomeSMB.Text = firstServer.nomeConnessione;
                    txtServer.Text = firstServer.server;
                    txtDomain.Text = firstServer.dominio;
                    txtUser.Text = firstServer.utente;
                    txtPassword.Text = firstServer.password;
                    cmbDriveLetter.Text = firstServer.drive;
                    txtUUID.Text = firstServer.uuid;
                }
            }
            else
            {
                Console.WriteLine("Il file JSON non esiste.");
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Questa operazione non è reversibile!\n \nConfermi l'Eliminazione?", "Elimina", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                // Ottiene l'indice dell'elemento selezionato nella lista
                int selectedIndex = lstDeletedServer.SelectedIndex;

                if (selectedIndex >= 0)
                {
                    // Leggi il contenuto del file JSON esistente
                    string existingJson = File.Exists("config_deleted.json") ? File.ReadAllText("config_deleted.json") : "";

                    // Deserializza il contenuto del file JSON in una lista di oggetti ServerSMB
                    List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(existingJson);

                    // Rimuovi l'elemento selezionato dalla lista
                    servers.RemoveAt(selectedIndex);

                    // Serializza la lista di oggetti ServerSMB e scrivi il contenuto nel file JSON
                    string json = JsonConvert.SerializeObject(servers, Formatting.Indented);
                    File.WriteAllText("config_deleted.json", json);

                    // Aggiorna il DataSource della lista con la nuova lista di oggetti ServerSMB
                    lstDeletedServer.DataSource = servers;
                    lstDeletedServer.DisplayMember = "nomeConnessione";

                    LoadConfig();

                    // Controlla se lstServer è vuota e svuota i campi se necessario
                    if (lstDeletedServer.Items.Count == 0)
                    {
                        // Svuota i Campi
                        ClearInputFields();
                    }
                }
            }
            else
            {
                // Do nothing
            }
        }
        private void btnRipristina_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confermi il Ripristino?", "Ripristina", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                // Ottiene l'indice dell'elemento selezionato nella lista
                int selectedIndex = lstDeletedServer.SelectedIndex;

                if (selectedIndex >= 0)
                {
                    // Leggi il contenuto del file JSON di backup esistente
                    string existingJsonBackup = File.Exists("config_deleted.json") ? File.ReadAllText("config_deleted.json") : "[]";

                    // Deserializza il contenuto del file JSON in una lista di oggetti ServerSMB
                    List<ServerSMB> deletedServers = JsonConvert.DeserializeObject<List<ServerSMB>>(existingJsonBackup);

                    // Copia l'elemento selezionato dalla lista di backup nel file originale
                    ServerSMB serverRestored = deletedServers[selectedIndex];

                    // Leggi il contenuto del file JSON originale esistente
                    string existingJson = File.Exists("config.json") ? File.ReadAllText("config.json") : "[]";

                    // Deserializza il contenuto del file JSON in una lista di oggetti ServerSMB
                    List<ServerSMB> servers = JsonConvert.DeserializeObject<List<ServerSMB>>(existingJson);

                    // Aggiungi l'elemento ripristinato alla lista originale
                    servers.Add(serverRestored);

                    // Rimuovi l'elemento selezionato dalla lista di backup
                    deletedServers.RemoveAt(selectedIndex);

                    // Serializza la lista di oggetti ServerSMB ripristinati e scrivi il contenuto nel file JSON originale
                    string json = JsonConvert.SerializeObject(servers, Formatting.Indented);
                    File.WriteAllText("config.json", json);

                    // Serializza la lista di oggetti ServerSMB di backup modificata e scrivi il contenuto nel file di backup
                    string jsonBackup = JsonConvert.SerializeObject(deletedServers, Formatting.Indented);
                    File.WriteAllText("config_deleted.json", jsonBackup);

                    // Aggiorna il DataSource della lista di backup con la nuova lista di oggetti ServerSMB di backup modificata
                    lstDeletedServer.DataSource = deletedServers;
                    lstDeletedServer.DisplayMember = "nomeConnessione";


                    // Controlla se lstServer è vuota e svuota i campi se necessario
                    if (lstDeletedServer.Items.Count == 0)
                    {
                        // Svuota i Campi
                        ClearInputFields();
                    }
                }
            }
            else
            {
                // Do nothing
            }
        }
        private void btnChiudi_Click(object sender, EventArgs e)
        {
            // Chiudere la form
            this.Close();
        }
    }
}
