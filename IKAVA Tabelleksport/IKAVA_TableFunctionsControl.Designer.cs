namespace IKAVA_Systembehandler.DB
{
    partial class TableFunctionsControl
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDumpToCSV = new System.Windows.Forms.Label();
            this.txtDumpToCSV = new System.Windows.Forms.TextBox();
            this.btnDumpToCSV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.btnDumpToXml = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDumpToCSV);
            this.groupBox4.Controls.Add(this.txtDumpToCSV);
            this.groupBox4.Controls.Add(this.btnDumpToCSV);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.lstTables);
            this.groupBox4.Controls.Add(this.btnDumpToXml);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 212);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabeller";
            // 
            // lblDumpToCSV
            // 
            this.lblDumpToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDumpToCSV.AutoSize = true;
            this.lblDumpToCSV.Enabled = false;
            this.lblDumpToCSV.Location = new System.Drawing.Point(123, 153);
            this.lblDumpToCSV.Name = "lblDumpToCSV";
            this.lblDumpToCSV.Size = new System.Drawing.Size(53, 13);
            this.lblDumpToCSV.TabIndex = 17;
            this.lblDumpToCSV.Text = "Separator";
            // 
            // txtDumpToCSV
            // 
            this.txtDumpToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDumpToCSV.Enabled = false;
            this.txtDumpToCSV.Location = new System.Drawing.Point(177, 150);
            this.txtDumpToCSV.Name = "txtDumpToCSV";
            this.txtDumpToCSV.Size = new System.Drawing.Size(23, 20);
            this.txtDumpToCSV.TabIndex = 16;
            this.txtDumpToCSV.Text = ";";
            // 
            // btnDumpToCSV
            // 
            this.btnDumpToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDumpToCSV.Location = new System.Drawing.Point(206, 146);
            this.btnDumpToCSV.Name = "btnDumpToCSV";
            this.btnDumpToCSV.Size = new System.Drawing.Size(128, 27);
            this.btnDumpToCSV.TabIndex = 15;
            this.btnDumpToCSV.Text = "Dump til fil (CSV)";
            this.btnDumpToCSV.UseVisualStyleBackColor = true;
            this.btnDumpToCSV.Click += new System.EventHandler(this.btnDumpToCSV_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Lag ADDML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstTables
            // 
            this.lstTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(6, 19);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(328, 121);
            this.lstTables.TabIndex = 13;
            // 
            // btnDumpToXml
            // 
            this.btnDumpToXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDumpToXml.Location = new System.Drawing.Point(206, 179);
            this.btnDumpToXml.Name = "btnDumpToXml";
            this.btnDumpToXml.Size = new System.Drawing.Size(128, 27);
            this.btnDumpToXml.TabIndex = 12;
            this.btnDumpToXml.Text = "Dump til XML (MySql)";
            this.btnDumpToXml.UseVisualStyleBackColor = true;
            this.btnDumpToXml.Click += new System.EventHandler(this.btnDumpToXml_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // TableFunctionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Enabled = false;
            this.MinimumSize = new System.Drawing.Size(340, 175);
            this.Name = "TableFunctionsControl";
            this.Size = new System.Drawing.Size(340, 212);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.Button btnDumpToXml;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnDumpToCSV;
        private System.Windows.Forms.Label lblDumpToCSV;
        private System.Windows.Forms.TextBox txtDumpToCSV;
    }
}
