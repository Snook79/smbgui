
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SMBGUI.SMBLibrary
{
    public partial class DuplicaConfigurazioneForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNomeSMB = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.lblNomeConnessione = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblUtente = new System.Windows.Forms.Label();
            this.lblDominio = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbDriveLetter = new System.Windows.Forms.ComboBox();
            this.lblDrive = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.chkPersist = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeSMB
            // 
            this.txtNomeSMB.Location = new System.Drawing.Point(31, 68);
            this.txtNomeSMB.Name = "txtNomeSMB";
            this.txtNomeSMB.Size = new System.Drawing.Size(352, 26);
            this.txtNomeSMB.TabIndex = 0;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(31, 131);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(352, 26);
            this.txtServer.TabIndex = 1;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(12, 494);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(99, 47);
            this.btnSalva.TabIndex = 2;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // lblNomeConnessione
            // 
            this.lblNomeConnessione.AutoSize = true;
            this.lblNomeConnessione.Location = new System.Drawing.Point(31, 45);
            this.lblNomeConnessione.Name = "lblNomeConnessione";
            this.lblNomeConnessione.Size = new System.Drawing.Size(148, 20);
            this.lblNomeConnessione.TabIndex = 3;
            this.lblNomeConnessione.Text = "Nome Connessione";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(31, 108);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(94, 20);
            this.lblServer.TabIndex = 4;
            this.lblServer.Text = "SMB Server";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(32, 325);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(355, 26);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(31, 261);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(356, 26);
            this.txtUser.TabIndex = 6;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(31, 193);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(352, 26);
            this.txtDomain.TabIndex = 7;
            // 
            // lblUtente
            // 
            this.lblUtente.AutoSize = true;
            this.lblUtente.Location = new System.Drawing.Point(31, 229);
            this.lblUtente.Name = "lblUtente";
            this.lblUtente.Size = new System.Drawing.Size(58, 20);
            this.lblUtente.TabIndex = 8;
            this.lblUtente.Text = "Utente";
            // 
            // lblDominio
            // 
            this.lblDominio.AutoSize = true;
            this.lblDominio.Location = new System.Drawing.Point(31, 165);
            this.lblDominio.Name = "lblDominio";
            this.lblDominio.Size = new System.Drawing.Size(67, 20);
            this.lblDominio.TabIndex = 9;
            this.lblDominio.Text = "Dominio";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(31, 297);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password";
            // 
            // cmbDriveLetter
            // 
            this.cmbDriveLetter.FormattingEnabled = true;
            this.cmbDriveLetter.Location = new System.Drawing.Point(31, 428);
            this.cmbDriveLetter.Name = "cmbDriveLetter";
            this.cmbDriveLetter.Size = new System.Drawing.Size(121, 28);
            this.cmbDriveLetter.TabIndex = 12;
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(35, 396);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(47, 20);
            this.lblDrive.TabIndex = 13;
            this.lblDrive.Text = "Unità";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Location = new System.Drawing.Point(128, 494);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(99, 47);
            this.btnAnnulla.TabIndex = 14;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.UseVisualStyleBackColor = true;
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // picLogo
            // 
            this.picLogo.ErrorImage = global::SMBGUI.Properties.Resources.editsmb200;
            this.picLogo.Image = global::SMBGUI.Properties.Resources.editsmb200;
            this.picLogo.Location = new System.Drawing.Point(406, 45);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 162);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 15;
            this.picLogo.TabStop = false;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(32, 357);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(157, 24);
            this.chkShowPassword.TabIndex = 18;
            this.chkShowPassword.Text = "Mostra Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(31, 12);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(352, 26);
            this.txtUUID.TabIndex = 19;
            // 
            // chkPersist
            // 
            this.chkPersist.AutoSize = true;
            this.chkPersist.Location = new System.Drawing.Point(406, 229);
            this.chkPersist.Name = "chkPersist";
            this.chkPersist.Size = new System.Drawing.Size(162, 24);
            this.chkPersist.TabIndex = 26;
            this.chkPersist.Text = "Persistente SI/NO";
            this.chkPersist.UseVisualStyleBackColor = true;
            // 
            // DuplicaConfigurazioneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 548);
            this.Controls.Add(this.chkPersist);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.cmbDriveLetter);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblDominio);
            this.Controls.Add(this.lblUtente);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.lblNomeConnessione);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtNomeSMB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DuplicaConfigurazioneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Duplica";
            this.Load += new System.EventHandler(this.DuplicaConfigurazioneForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    
        #endregion

        private System.Windows.Forms.TextBox txtNomeSMB;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Label lblNomeConnessione;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label lblUtente;
        private System.Windows.Forms.Label lblDominio;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmbDriveLetter;
        private System.Windows.Forms.Label lblDrive;
        private Button btnAnnulla;
        private PictureBox picLogo;
        private CheckBox chkShowPassword;
        private TextBox txtUUID;
        private CheckBox chkPersist;
    }
}
