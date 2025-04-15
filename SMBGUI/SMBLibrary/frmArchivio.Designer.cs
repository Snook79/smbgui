
namespace SMBGUI.SMBLibrary
{
    partial class frmArchivio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivio));
            this.lblDomain = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.cmbDriveLetter = new System.Windows.Forms.ComboBox();
            this.lblDrive = new System.Windows.Forms.Label();
            this.txtNomeSMB = new System.Windows.Forms.TextBox();
            this.lblNomeSMB = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblCerca = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRipristina = new System.Windows.Forms.Button();
            this.lblListaServer = new System.Windows.Forms.Label();
            this.lstDeletedServer = new System.Windows.Forms.ListBox();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkPersist = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(12, 136);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(67, 20);
            this.lblDomain.TabIndex = 17;
            this.lblDomain.Text = "Dominio";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(12, 159);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(361, 26);
            this.txtDomain.TabIndex = 18;
            // 
            // cmbDriveLetter
            // 
            this.cmbDriveLetter.FormattingEnabled = true;
            this.cmbDriveLetter.Location = new System.Drawing.Point(16, 389);
            this.cmbDriveLetter.Name = "cmbDriveLetter";
            this.cmbDriveLetter.Size = new System.Drawing.Size(121, 28);
            this.cmbDriveLetter.TabIndex = 24;
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(12, 366);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(47, 20);
            this.lblDrive.TabIndex = 23;
            this.lblDrive.Text = "Unità";
            // 
            // txtNomeSMB
            // 
            this.txtNomeSMB.Location = new System.Drawing.Point(12, 40);
            this.txtNomeSMB.Name = "txtNomeSMB";
            this.txtNomeSMB.Size = new System.Drawing.Size(361, 26);
            this.txtNomeSMB.TabIndex = 14;
            // 
            // lblNomeSMB
            // 
            this.lblNomeSMB.AutoSize = true;
            this.lblNomeSMB.Location = new System.Drawing.Point(12, 17);
            this.lblNomeSMB.Name = "lblNomeSMB";
            this.lblNomeSMB.Size = new System.Drawing.Size(148, 20);
            this.lblNomeSMB.TabIndex = 13;
            this.lblNomeSMB.Text = "Nome Connessione";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 278);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(361, 26);
            this.txtPassword.TabIndex = 22;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 255);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 220);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(361, 26);
            this.txtUser.TabIndex = 20;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 197);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 20);
            this.lblUser.TabIndex = 19;
            this.lblUser.Text = "Utente";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 78);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(94, 20);
            this.lblServer.TabIndex = 15;
            this.lblServer.Text = "SMB Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(12, 101);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(361, 26);
            this.txtServer.TabIndex = 16;
            // 
            // lblCerca
            // 
            this.lblCerca.AutoSize = true;
            this.lblCerca.Location = new System.Drawing.Point(477, 444);
            this.lblCerca.Name = "lblCerca";
            this.lblCerca.Size = new System.Drawing.Size(51, 20);
            this.lblCerca.TabIndex = 27;
            this.lblCerca.Text = "Cerca";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(534, 441);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 26);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.WordWrap = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRipristina
            // 
            this.btnRipristina.Location = new System.Drawing.Point(16, 837);
            this.btnRipristina.Name = "btnRipristina";
            this.btnRipristina.Size = new System.Drawing.Size(111, 55);
            this.btnRipristina.TabIndex = 25;
            this.btnRipristina.Text = "Ripristina";
            this.btnRipristina.UseVisualStyleBackColor = true;
            this.btnRipristina.Click += new System.EventHandler(this.btnRipristina_Click);
            // 
            // lblListaServer
            // 
            this.lblListaServer.AutoSize = true;
            this.lblListaServer.Location = new System.Drawing.Point(8, 450);
            this.lblListaServer.Name = "lblListaServer";
            this.lblListaServer.Size = new System.Drawing.Size(195, 20);
            this.lblListaServer.TabIndex = 27;
            this.lblListaServer.Text = "Lista Server SMB Eliminati";
            // 
            // lstDeletedServer
            // 
            this.lstDeletedServer.AllowDrop = true;
            this.lstDeletedServer.FormattingEnabled = true;
            this.lstDeletedServer.ItemHeight = 20;
            this.lstDeletedServer.Location = new System.Drawing.Point(12, 483);
            this.lstDeletedServer.Name = "lstDeletedServer";
            this.lstDeletedServer.Size = new System.Drawing.Size(706, 304);
            this.lstDeletedServer.TabIndex = 29;
            this.lstDeletedServer.SelectedIndexChanged += new System.EventHandler(this.lstServer_SelectedIndexChanged);
            this.lstDeletedServer.DoubleClick += new System.EventHandler(this.lstServer_DoubleClick);
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(12, 794);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(706, 26);
            this.txtUUID.TabIndex = 30;
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(133, 837);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(111, 55);
            this.btnElimina.TabIndex = 26;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Location = new System.Drawing.Point(607, 837);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(111, 54);
            this.btnChiudi.TabIndex = 31;
            this.btnChiudi.Text = "Chiudi";
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMBGUI.Properties.Resources.backup;
            this.pictureBox1.Location = new System.Drawing.Point(470, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // chkPersist
            // 
            this.chkPersist.AutoSize = true;
            this.chkPersist.Location = new System.Drawing.Point(16, 324);
            this.chkPersist.Name = "chkPersist";
            this.chkPersist.Size = new System.Drawing.Size(162, 24);
            this.chkPersist.TabIndex = 33;
            this.chkPersist.Text = "Persistente SI/NO";
            this.chkPersist.UseVisualStyleBackColor = true;
            // 
            // frmArchivio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(728, 903);
            this.Controls.Add(this.chkPersist);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.lblCerca);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRipristina);
            this.Controls.Add(this.lblListaServer);
            this.Controls.Add(this.lstDeletedServer);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.cmbDriveLetter);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.txtNomeSMB);
            this.Controls.Add(this.lblNomeSMB);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArchivio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Archivio";
            this.Load += new System.EventHandler(this.frmArchivio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.ComboBox cmbDriveLetter;
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.TextBox txtNomeSMB;
        private System.Windows.Forms.Label lblNomeSMB;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblCerca;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRipristina;
        private System.Windows.Forms.Label lblListaServer;
        private System.Windows.Forms.ListBox lstDeletedServer;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkPersist;
    }
}