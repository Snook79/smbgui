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

namespace SMBGUI.SMBLibrary
{
    public partial class DuplicaConfigurazioneForm : Form
    {
        public DuplicaConfigurazioneForm()
        {
            InitializeComponent();
        }

        private void frmGui_Load(object sender, EventArgs e)
        {

            
        }
        private JObject jsonToDuplicate;

        public DuplicaConfigurazioneForm(JObject json)
        {
            InitializeComponent();
            jsonToDuplicate = json;
            txtNomeSMB.Text = json["nomeConnessione"].ToString();
            txtServer.Text = json["server"].ToString();
            txtDomain.Text = json["dominio"].ToString();
            txtUser.Text = json["utente"].ToString();
            txtPassword.Text = json["password"].ToString();
            txtUUID.Text = json["uuid"].ToString();
            cmbDriveLetter.Text = json["drive"].ToString();
            if (json.GetValue("persistent").ToString() == "true")
            {
                chkPersist.Checked = true;
            }
            else
            {
                chkPersist.Checked = false;
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUUID.Text))
            {
                MessageBox.Show("Seleziona una configurazione da duplicare.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Genera un nuovo UUID per la connessione duplicata
                Guid newUuid = Guid.NewGuid();

                // Crea una copia dell'oggetto JSON da duplicare
                JObject duplicatedJson = new JObject(jsonToDuplicate);

                // Aggiorna il valore dell'UUID nella copia
                duplicatedJson["uuid"] = newUuid.ToString();

                duplicatedJson["nomeConnessione"] = txtNomeSMB.Text;
                duplicatedJson["server"] = txtServer.Text;
                duplicatedJson["dominio"] = txtDomain.Text;
                duplicatedJson["utente"] = txtUser.Text;
                duplicatedJson["password"] = txtPassword.Text;
                duplicatedJson["drive"] = cmbDriveLetter.Text;
                duplicatedJson["persistent"] = chkPersist.Checked;

                // Continuare a popolare l'oggetto JSON.

                if (jsonArray != null)
                {
                    // Aggiungi la copia all'array di oggetti JSON
                    jsonArray.Add(duplicatedJson);

                    // Scrivi l'array di oggetti JSON aggiornato nel file JSON
                    File.WriteAllText("config.json", jsonArray.ToString());

                    // Ricarica il contenuto del file JSON e aggiorna la lista lstServer
                    frmGui_Load(sender, e);

                    // Chiudere la form
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Il file di configurazione non è stato trovato o non è accessibile.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Configurazione non trovata.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
            private void btnAnnulla_Click(object sender, EventArgs e)
        {
            // Chiudere la form
            this.Close();
        }

        private void DuplicaConfigurazioneForm_Load(object sender, EventArgs e)
        {
            // Imposta il DataSource della ComboBox con tutte le lettere disponibili da M a Z
            char[] driveLetters = Enumerable.Range('F', 21)
                .Select(x => (char)x)
                .Where(c => !Path.GetInvalidPathChars().Contains(c))
                .ToArray();
            cmbDriveLetter.DataSource = driveLetters;
            cmbDriveLetter.SelectedIndex = -1; // Imposta l'indice selezionato su nessuno
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
    }
}
