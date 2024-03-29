﻿namespace IKAVA_Systembehandler.DB
{
    partial class DBConnectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFDBFil = new System.Windows.Forms.Button();
            this.lblFDBFil = new System.Windows.Forms.Label();
            this.txtFDBFil = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbRememberSettings = new System.Windows.Forms.CheckBox();
            this.cbServerType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFDBFil);
            this.groupBox2.Controls.Add(this.lblFDBFil);
            this.groupBox2.Controls.Add(this.txtFDBFil);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.cbRememberSettings);
            this.groupBox2.Controls.Add(this.cbServerType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.cbDatabase);
            this.groupBox2.Controls.Add(this.lblUser);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtServer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblServer);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(347, 215);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Databaseinnstillinger";
            // 
            // btnFDBFil
            // 
            this.btnFDBFil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFDBFil.Image = global::IKAVA_DBConnectionHandler.Properties.Resources.folder;
            this.btnFDBFil.Location = new System.Drawing.Point(308, 48);
            this.btnFDBFil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFDBFil.Name = "btnFDBFil";
            this.btnFDBFil.Size = new System.Drawing.Size(33, 32);
            this.btnFDBFil.TabIndex = 17;
            this.btnFDBFil.UseVisualStyleBackColor = true;
            this.btnFDBFil.Visible = false;
            this.btnFDBFil.Click += new System.EventHandler(this.btnFDBFil_Click);
            // 
            // lblFDBFil
            // 
            this.lblFDBFil.AutoSize = true;
            this.lblFDBFil.Location = new System.Drawing.Point(13, 54);
            this.lblFDBFil.Name = "lblFDBFil";
            this.lblFDBFil.Size = new System.Drawing.Size(50, 17);
            this.lblFDBFil.TabIndex = 16;
            this.lblFDBFil.Text = "FDB-fil";
            this.lblFDBFil.Visible = false;
            // 
            // txtFDBFil
            // 
            this.txtFDBFil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFDBFil.Location = new System.Drawing.Point(113, 52);
            this.txtFDBFil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFDBFil.Name = "txtFDBFil";
            this.txtFDBFil.Size = new System.Drawing.Size(191, 22);
            this.txtFDBFil.TabIndex = 15;
            this.txtFDBFil.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IKAVA_DBConnectionHandler.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(80, 49);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // cbRememberSettings
            // 
            this.cbRememberSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRememberSettings.AutoSize = true;
            this.cbRememberSettings.Checked = true;
            this.cbRememberSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRememberSettings.Location = new System.Drawing.Point(21, 181);
            this.cbRememberSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRememberSettings.Name = "cbRememberSettings";
            this.cbRememberSettings.Size = new System.Drawing.Size(110, 21);
            this.cbRememberSettings.TabIndex = 12;
            this.cbRememberSettings.Text = "Husk verdier";
            this.cbRememberSettings.UseVisualStyleBackColor = true;
            this.cbRememberSettings.Visible = false;
            this.cbRememberSettings.CheckedChanged += new System.EventHandler(this.cbRememberSettings_CheckedChanged);
            // 
            // cbServerType
            // 
            this.cbServerType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbServerType.FormattingEnabled = true;
            this.cbServerType.Items.AddRange(new object[] {
            "MySql",
            "SqlServer",
            "FireBird"});
            this.cbServerType.Location = new System.Drawing.Point(113, 22);
            this.cbServerType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbServerType.Name = "cbServerType";
            this.cbServerType.Size = new System.Drawing.Size(225, 24);
            this.cbServerType.TabIndex = 6;
            this.cbServerType.Text = "MySql";
            this.cbServerType.SelectedIndexChanged += new System.EventHandler(this.cbServerType_SelectedIndexChanged);
            this.cbServerType.SelectedValueChanged += new System.EventHandler(this.cbServerType_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Passord";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(113, 80);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(225, 22);
            this.txtUser.TabIndex = 3;
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(113, 108);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(225, 22);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // cbDatabase
            // 
            this.cbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(113, 137);
            this.cbDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(225, 24);
            this.cbDatabase.TabIndex = 11;
            this.cbDatabase.DropDown += new System.EventHandler(this.cbDatabase_DropDown);
            this.cbDatabase.SelectedIndexChanged += new System.EventHandler(this.cbDatabase_SelectedIndexChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(13, 82);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Bruker";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Database";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(113, 52);
            this.txtServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(225, 22);
            this.txtServer.TabIndex = 1;
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            this.txtServer.Leave += new System.EventHandler(this.txtServer_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Servertype";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(13, 54);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(50, 17);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(205, 174);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Test kobling";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DBConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(347, 215);
            this.Name = "DBConnectionControl";
            this.Size = new System.Drawing.Size(347, 215);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbRememberSettings;
        private System.Windows.Forms.ComboBox cbServerType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFDBFil;
        private System.Windows.Forms.TextBox txtFDBFil;
        private System.Windows.Forms.Button btnFDBFil;
    }
}
