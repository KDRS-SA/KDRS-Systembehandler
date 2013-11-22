﻿namespace IKAVA_Systembehandler.Plugins
{
    partial class OpprettDatabase_MySql
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLoadPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.logg1 = new IKAVA_Systembehandler.Logg();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dbConnectionControl1 = new IKAVA_Systembehandler.DB.DBConnectionControl();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtDatabaseName);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtLoadPath);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(266, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(311, 121);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Legg til ny";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Database:";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(220, 62);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 26);
            this.button6.TabIndex = 12;
            this.button6.Text = "Opprett db";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(258, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 21);
            this.button5.TabIndex = 11;
            this.button5.Text = "Velg...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Sti til .sql-fil";
            // 
            // txtLoadPath
            // 
            this.txtLoadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoadPath.Location = new System.Drawing.Point(6, 35);
            this.txtLoadPath.Name = "txtLoadPath";
            this.txtLoadPath.Size = new System.Drawing.Size(246, 20);
            this.txtLoadPath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // logg1
            // 
            this.logg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logg1.Location = new System.Drawing.Point(0, 184);
            this.logg1.Name = "logg1";
            this.logg1.Size = new System.Drawing.Size(577, 102);
            this.logg1.TabIndex = 20;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseName.Enabled = false;
            this.txtDatabaseName.Location = new System.Drawing.Point(65, 66);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(137, 20);
            this.txtDatabaseName.TabIndex = 15;
            this.txtDatabaseName.Leave += new System.EventHandler(this.txtDatabaseName_Leave);
            // 
            // dbConnectionControl1
            // 
            this.dbConnectionControl1.conn = null;
            this.dbConnectionControl1.Location = new System.Drawing.Point(0, 3);
            this.dbConnectionControl1.logg1 = null;
            this.dbConnectionControl1.MinimumSize = new System.Drawing.Size(260, 175);
            this.dbConnectionControl1.Name = "dbConnectionControl1";
            this.dbConnectionControl1.ShowDatabaseSelector = false;
            this.dbConnectionControl1.Size = new System.Drawing.Size(260, 175);
            this.dbConnectionControl1.TabIndex = 0;
            this.dbConnectionControl1.OnDatabaseConnected += new IKAVA_Systembehandler.DB.DBConnectionControl.DatabaseConnectedEventHandler(this.dbConnectionControl1_OnDatabaseConnected);
            // 
            // OpprettDatabase_MySql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logg1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dbConnectionControl1);
            this.Name = "OpprettDatabase_MySql";
            this.Size = new System.Drawing.Size(580, 289);
            this.Load += new System.EventHandler(this.IKAVA_OpprettDatabase_MySql_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IKAVA_Systembehandler.DB.DBConnectionControl dbConnectionControl1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLoadPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Logg logg1;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}