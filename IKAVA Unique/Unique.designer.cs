namespace IKAVA_Systembehandler.Plugins
{
    partial class Unique
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkExtendedLogging = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumberOfFilesInFolder = new System.Windows.Forms.TextBox();
            this.chkSpanFolders = new System.Windows.Forms.CheckBox();
            this.chkReplaceChars = new System.Windows.Forms.CheckBox();
            this.chkDoMax = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDoMax = new System.Windows.Forms.TextBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNumberOfRows = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblNumberOfDocuments = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dbConnectionControl1 = new IKAVA_Systembehandler.DB.DBConnectionControl();
            this.logg1 = new IKAVA_Systembehandler.Logg();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 97);
            this.label3.TabIndex = 24;
            this.label3.Text = "For Unique-databaser (Marthe, Oskar ++) er det dokumenter fra tabellen UQWidetab " +
    "e.l. som systemet er kodet for å hente ut.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbTables);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(269, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 267);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Velg dokumenttabell";
            // 
            // cbTables
            // 
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(6, 19);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(143, 21);
            this.cbTables.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(40, 45);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Hent dokumentliste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkExtendedLogging);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNumberOfFilesInFolder);
            this.groupBox3.Controls.Add(this.chkSpanFolders);
            this.groupBox3.Controls.Add(this.chkReplaceChars);
            this.groupBox3.Controls.Add(this.chkDoMax);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtDoMax);
            this.groupBox3.Controls.Add(this.chkOverwrite);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.txtFolder);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblNumberOfRows);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.lblNumberOfDocuments);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(429, 3);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(364, 267);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fredrift";
            // 
            // chkExtendedLogging
            // 
            this.chkExtendedLogging.AutoSize = true;
            this.chkExtendedLogging.Location = new System.Drawing.Point(7, 163);
            this.chkExtendedLogging.Name = "chkExtendedLogging";
            this.chkExtendedLogging.Size = new System.Drawing.Size(168, 17);
            this.chkExtendedLogging.TabIndex = 21;
            this.chkExtendedLogging.Text = "Utvidet logging (tidkrevende..)";
            this.chkExtendedLogging.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(301, 242);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 21);
            this.button4.TabIndex = 20;
            this.button4.Text = "Stopp";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 145);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "filer";
            // 
            // txtNumberOfFilesInFolder
            // 
            this.txtNumberOfFilesInFolder.Location = new System.Drawing.Point(110, 142);
            this.txtNumberOfFilesInFolder.Name = "txtNumberOfFilesInFolder";
            this.txtNumberOfFilesInFolder.Size = new System.Drawing.Size(50, 20);
            this.txtNumberOfFilesInFolder.TabIndex = 18;
            this.txtNumberOfFilesInFolder.Text = "100000";
            // 
            // chkSpanFolders
            // 
            this.chkSpanFolders.AutoSize = true;
            this.chkSpanFolders.Location = new System.Drawing.Point(7, 144);
            this.chkSpanFolders.Name = "chkSpanFolders";
            this.chkSpanFolders.Size = new System.Drawing.Size(105, 17);
            this.chkSpanFolders.TabIndex = 17;
            this.chkSpanFolders.Text = "Lagre i mapper á";
            this.chkSpanFolders.UseVisualStyleBackColor = true;
            // 
            // chkReplaceChars
            // 
            this.chkReplaceChars.AutoSize = true;
            this.chkReplaceChars.Location = new System.Drawing.Point(7, 108);
            this.chkReplaceChars.Name = "chkReplaceChars";
            this.chkReplaceChars.Size = new System.Drawing.Size(163, 17);
            this.chkReplaceChars.TabIndex = 16;
            this.chkReplaceChars.Text = "Erstatt æøå (NOTIS-WP-filer)";
            this.chkReplaceChars.UseVisualStyleBackColor = true;
            // 
            // chkDoMax
            // 
            this.chkDoMax.AutoSize = true;
            this.chkDoMax.Location = new System.Drawing.Point(7, 89);
            this.chkDoMax.Name = "chkDoMax";
            this.chkDoMax.Size = new System.Drawing.Size(75, 17);
            this.chkDoMax.TabIndex = 15;
            this.chkDoMax.Text = "Ta kun de";
            this.chkDoMax.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(129, 89);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "første";
            // 
            // txtDoMax
            // 
            this.txtDoMax.Location = new System.Drawing.Point(83, 87);
            this.txtDoMax.Name = "txtDoMax";
            this.txtDoMax.Size = new System.Drawing.Size(41, 20);
            this.txtDoMax.TabIndex = 12;
            this.txtDoMax.Text = "100";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(7, 127);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(153, 17);
            this.chkOverwrite.TabIndex = 11;
            this.chkOverwrite.Text = "Overskriv eksisterende filer";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(331, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 20);
            this.button3.TabIndex = 10;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(4, 33);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(322, 20);
            this.txtFolder.TabIndex = 6;
            this.txtFolder.Text = "c:\\test\\";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Lagringssti";
            // 
            // lblNumberOfRows
            // 
            this.lblNumberOfRows.AutoSize = true;
            this.lblNumberOfRows.Location = new System.Drawing.Point(122, 70);
            this.lblNumberOfRows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfRows.Name = "lblNumberOfRows";
            this.lblNumberOfRows.Size = new System.Drawing.Size(13, 13);
            this.lblNumberOfRows.TabIndex = 8;
            this.lblNumberOfRows.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Rader i tabellen:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(238, 242);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(58, 21);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNumberOfDocuments
            // 
            this.lblNumberOfDocuments.AutoSize = true;
            this.lblNumberOfDocuments.Location = new System.Drawing.Point(122, 55);
            this.lblNumberOfDocuments.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumberOfDocuments.Name = "lblNumberOfDocuments";
            this.lblNumberOfDocuments.Size = new System.Drawing.Size(13, 13);
            this.lblNumberOfDocuments.TabIndex = 4;
            this.lblNumberOfDocuments.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Antall dokumenter:";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(4, 218);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(353, 20);
            this.progressBar1.TabIndex = 0;
            // 
            // dbConnectionControl1
            // 
            this.dbConnectionControl1.conn = null;
            this.dbConnectionControl1.Location = new System.Drawing.Point(3, 3);
            this.dbConnectionControl1.logg1 = this.logg1;
            this.dbConnectionControl1.MinimumSize = new System.Drawing.Size(260, 175);
            this.dbConnectionControl1.Name = "dbConnectionControl1";
            this.dbConnectionControl1.ShowDatabaseSelector = true;
            this.dbConnectionControl1.Size = new System.Drawing.Size(260, 267);
            this.dbConnectionControl1.TabIndex = 27;
            this.dbConnectionControl1.OnDatabaseConnected += new IKAVA_Systembehandler.DB.DBConnectionControl.DatabaseConnectedEventHandler(this.dbConnectionControl1_OnDatabaseConnected);
            // 
            // logg1
            // 
            this.logg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logg1.HTMLEnabled = false;
            this.logg1.Location = new System.Drawing.Point(3, 275);
            this.logg1.Name = "logg1";
            this.logg1.Size = new System.Drawing.Size(790, 177);
            this.logg1.TabIndex = 26;
            // 
            // Unique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dbConnectionControl1);
            this.Controls.Add(this.logg1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Unique";
            this.Size = new System.Drawing.Size(798, 455);
            this.Load += new System.EventHandler(this.Unique_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumberOfFilesInFolder;
        private System.Windows.Forms.CheckBox chkSpanFolders;
        private System.Windows.Forms.CheckBox chkReplaceChars;
        private System.Windows.Forms.CheckBox chkDoMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDoMax;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNumberOfRows;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNumberOfDocuments;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Logg logg1;
        private System.Windows.Forms.CheckBox chkExtendedLogging;
        private DB.DBConnectionControl dbConnectionControl1;
    }
}
