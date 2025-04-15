
namespace SMBGUI
{
    partial class frmGui
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGui));
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lstServer = new System.Windows.Forms.ListBox();
            this.lblListaServer = new System.Windows.Forms.Label();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnConnetti = new System.Windows.Forms.Button();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.lblNomeSMB = new System.Windows.Forms.Label();
            this.txtNomeSMB = new System.Windows.Forms.TextBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnSvuota = new System.Windows.Forms.Button();
            this.lblDrive = new System.Windows.Forms.Label();
            this.cmbDriveLetter = new System.Windows.Forms.ComboBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.chkPersist = new System.Windows.Forms.CheckBox();
            this.btnDuplica = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCerca = new System.Windows.Forms.Label();
            this.btnDisconnetti = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esportaConnessioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaConnessioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lstConnessioni = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuLST = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(12, 135);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(361, 26);
            this.txtServer.TabIndex = 4;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(12, 112);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(94, 20);
            this.lblServer.TabIndex = 3;
            this.lblServer.Text = "SMB Server";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 231);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 20);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "Utente";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 254);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(361, 26);
            this.txtUser.TabIndex = 8;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 289);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 312);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(361, 26);
            this.txtPassword.TabIndex = 10;
            // 
            // lstServer
            // 
            this.lstServer.AllowDrop = true;
            this.lstServer.FormattingEnabled = true;
            this.lstServer.ItemHeight = 20;
            this.lstServer.Location = new System.Drawing.Point(12, 503);
            this.lstServer.Name = "lstServer";
            this.lstServer.Size = new System.Drawing.Size(706, 304);
            this.lstServer.TabIndex = 19;
            this.lstServer.SelectedIndexChanged += new System.EventHandler(this.lstServer_SelectedIndexChanged);
            this.lstServer.DoubleClick += new System.EventHandler(this.lstServer_DoubleClick);
            // 
            // lblListaServer
            // 
            this.lblListaServer.AutoSize = true;
            this.lblListaServer.Location = new System.Drawing.Point(8, 480);
            this.lblListaServer.Name = "lblListaServer";
            this.lblListaServer.Size = new System.Drawing.Size(132, 20);
            this.lblListaServer.TabIndex = 16;
            this.lblListaServer.Text = "Lista Server SMB";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(116, 813);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(98, 49);
            this.btnElimina.TabIndex = 21;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnConnetti
            // 
            this.btnConnetti.Location = new System.Drawing.Point(129, 413);
            this.btnConnetti.Name = "btnConnetti";
            this.btnConnetti.Size = new System.Drawing.Size(111, 55);
            this.btnConnetti.TabIndex = 14;
            this.btnConnetti.Text = "Connetti";
            this.btnConnetti.UseVisualStyleBackColor = true;
            this.btnConnetti.Click += new System.EventHandler(this.btnConnetti_Click);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(518, 273);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(74, 24);
            this.chkSave.TabIndex = 24;
            this.chkSave.Text = "Salva";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // lblNomeSMB
            // 
            this.lblNomeSMB.AutoSize = true;
            this.lblNomeSMB.Location = new System.Drawing.Point(12, 51);
            this.lblNomeSMB.Name = "lblNomeSMB";
            this.lblNomeSMB.Size = new System.Drawing.Size(148, 20);
            this.lblNomeSMB.TabIndex = 1;
            this.lblNomeSMB.Text = "Nome Connessione";
            // 
            // txtNomeSMB
            // 
            this.txtNomeSMB.Location = new System.Drawing.Point(12, 74);
            this.txtNomeSMB.Name = "txtNomeSMB";
            this.txtNomeSMB.Size = new System.Drawing.Size(361, 26);
            this.txtNomeSMB.TabIndex = 2;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(12, 413);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(111, 55);
            this.btnSalva.TabIndex = 13;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnSvuota
            // 
            this.btnSvuota.Location = new System.Drawing.Point(363, 413);
            this.btnSvuota.Name = "btnSvuota";
            this.btnSvuota.Size = new System.Drawing.Size(113, 55);
            this.btnSvuota.TabIndex = 23;
            this.btnSvuota.Text = "Svuota";
            this.btnSvuota.UseVisualStyleBackColor = true;
            this.btnSvuota.Click += new System.EventHandler(this.btnSvuota_Click);
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(12, 347);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(47, 20);
            this.lblDrive.TabIndex = 11;
            this.lblDrive.Text = "Unità";
            // 
            // cmbDriveLetter
            // 
            this.cmbDriveLetter.FormattingEnabled = true;
            this.cmbDriveLetter.Location = new System.Drawing.Point(12, 370);
            this.cmbDriveLetter.Name = "cmbDriveLetter";
            this.cmbDriveLetter.Size = new System.Drawing.Size(121, 28);
            this.cmbDriveLetter.TabIndex = 12;
            // 
            // rtbOutput
            // 
            this.rtbOutput.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.Location = new System.Drawing.Point(741, 350);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(790, 423);
            this.rtbOutput.TabIndex = 28;
            this.rtbOutput.Text = "";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(1092, 327);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(81, 20);
            this.lblOutput.TabIndex = 27;
            this.lblOutput.Text = "Message";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(741, 812);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(123, 45);
            this.btnLog.TabIndex = 30;
            this.btnLog.Text = "Svuota LOG";
            this.btnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLog.UseMnemonic = false;
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(741, 779);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(790, 26);
            this.txtUUID.TabIndex = 29;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(12, 193);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(361, 26);
            this.txtDomain.TabIndex = 6;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(12, 170);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(67, 20);
            this.lblDomain.TabIndex = 5;
            this.lblDomain.Text = "Dominio";
            // 
            // chkPersist
            // 
            this.chkPersist.AutoSize = true;
            this.chkPersist.Location = new System.Drawing.Point(518, 303);
            this.chkPersist.Name = "chkPersist";
            this.chkPersist.Size = new System.Drawing.Size(162, 24);
            this.chkPersist.TabIndex = 25;
            this.chkPersist.Text = "Persistente SI/NO";
            this.chkPersist.UseVisualStyleBackColor = true;
            // 
            // btnDuplica
            // 
            this.btnDuplica.Location = new System.Drawing.Point(12, 813);
            this.btnDuplica.Name = "btnDuplica";
            this.btnDuplica.Size = new System.Drawing.Size(98, 49);
            this.btnDuplica.TabIndex = 20;
            this.btnDuplica.Text = "Duplica";
            this.btnDuplica.UseVisualStyleBackColor = true;
            this.btnDuplica.Click += new System.EventHandler(this.btnDuplica_Click);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(518, 333);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(157, 24);
            this.chkShowPassword.TabIndex = 26;
            this.chkShowPassword.Text = "Mostra Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(539, 471);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 26);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.WordWrap = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblCerca
            // 
            this.lblCerca.AutoSize = true;
            this.lblCerca.Location = new System.Drawing.Point(488, 474);
            this.lblCerca.Name = "lblCerca";
            this.lblCerca.Size = new System.Drawing.Size(51, 20);
            this.lblCerca.TabIndex = 17;
            this.lblCerca.Text = "Cerca";
            // 
            // btnDisconnetti
            // 
            this.btnDisconnetti.Location = new System.Drawing.Point(246, 413);
            this.btnDisconnetti.Name = "btnDisconnetti";
            this.btnDisconnetti.Size = new System.Drawing.Size(111, 55);
            this.btnDisconnetti.TabIndex = 15;
            this.btnDisconnetti.Text = "Disconnetti";
            this.btnDisconnetti.UseVisualStyleBackColor = true;
            this.btnDisconnetti.Click += new System.EventHandler(this.btnDisconnetti_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1542, 33);
            this.menuStrip.TabIndex = 100;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivioToolStripMenuItem,
            this.esportaConnessioniToolStripMenuItem,
            this.importaConnessioniToolStripMenuItem,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // archivioToolStripMenuItem
            // 
            this.archivioToolStripMenuItem.Name = "archivioToolStripMenuItem";
            this.archivioToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.archivioToolStripMenuItem.Text = "Archivio";
            this.archivioToolStripMenuItem.Click += new System.EventHandler(this.archivioToolStripMenuItem_Click);
            // 
            // esportaConnessioniToolStripMenuItem
            // 
            this.esportaConnessioniToolStripMenuItem.Name = "esportaConnessioniToolStripMenuItem";
            this.esportaConnessioniToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.esportaConnessioniToolStripMenuItem.Text = "Esporta Connessioni";
            this.esportaConnessioniToolStripMenuItem.Click += new System.EventHandler(this.esportaConnessioniToolStripMenuItem_Click);
            // 
            // importaConnessioniToolStripMenuItem
            // 
            this.importaConnessioniToolStripMenuItem.Name = "importaConnessioniToolStripMenuItem";
            this.importaConnessioniToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.importaConnessioniToolStripMenuItem.Text = "Importa Connessioni";
            this.importaConnessioniToolStripMenuItem.Click += new System.EventHandler(this.importaConnessioniToolStripMenuItem_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(279, 34);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Location = new System.Drawing.Point(870, 812);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(123, 45);
            this.btnSaveLog.TabIndex = 31;
            this.btnSaveLog.Text = "Salva LOG";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = global::SMBGUI.Properties.Resources.smb;
            this.picLogo.Image = global::SMBGUI.Properties.Resources.smb200;
            this.picLogo.Location = new System.Drawing.Point(518, 57);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 20;
            this.picLogo.TabStop = false;
            // 
            // lstConnessioni
            // 
            this.lstConnessioni.FormattingEnabled = true;
            this.lstConnessioni.ItemHeight = 20;
            this.lstConnessioni.Location = new System.Drawing.Point(741, 94);
            this.lstConnessioni.Name = "lstConnessioni";
            this.lstConnessioni.Size = new System.Drawing.Size(789, 224);
            this.lstConnessioni.TabIndex = 101;
            this.lstConnessioni.DoubleClick += new System.EventHandler(this.lstConnessioni_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1052, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 102;
            this.label1.Text = "Connessioni Stabilite";
            // 
            // contextMenuLST
            // 
            this.contextMenuLST.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuLST.Name = "contextMenuLST";
            this.contextMenuLST.Size = new System.Drawing.Size(61, 4);
            // 
            // frmGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1542, 869);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstConnessioni);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.btnDisconnetti);
            this.Controls.Add(this.lblCerca);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.btnDuplica);
            this.Controls.Add(this.chkPersist);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.txtUUID);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.cmbDriveLetter);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.btnSvuota);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.txtNomeSMB);
            this.Controls.Add(this.lblNomeSMB);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.btnConnetti);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.lblListaServer);
            this.Controls.Add(this.lstServer);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "frmGui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMBGui";
            this.Load += new System.EventHandler(this.frmGui_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ListBox lstServer;
        private System.Windows.Forms.Label lblListaServer;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnConnetti;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.Label lblNomeSMB;
        private System.Windows.Forms.TextBox txtNomeSMB;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnSvuota;
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.ComboBox cmbDriveLetter;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.CheckBox chkPersist;
        private System.Windows.Forms.Button btnDuplica;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCerca;
        private System.Windows.Forms.Button btnDisconnetti;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.ToolStripMenuItem esportaConnessioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaConnessioniToolStripMenuItem;
        private System.Windows.Forms.ListBox lstConnessioni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuLST;
    }
}

