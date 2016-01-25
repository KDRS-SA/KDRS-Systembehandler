namespace IKAVA_Systembehandler.Plugins
{
    partial class TabellEksport
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
            this.logg1 = new IKAVA_Systembehandler.Logg();
            this.dbConnectionControl2 = new IKAVA_Systembehandler.DB.DBConnectionControl();
            this.tableFunctionsControl1 = new IKAVA_Systembehandler.DB.TableFunctionsControl();
            this.SuspendLayout();
            // 
            // logg1
            // 
            this.logg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logg1.HTMLEnabled = true;
            this.logg1.Location = new System.Drawing.Point(3, 184);
            this.logg1.Name = "logg1";
            this.logg1.Size = new System.Drawing.Size(605, 223);
            this.logg1.TabIndex = 2;
            // 
            // dbConnectionControl2
            // 
            this.dbConnectionControl2.conn = null;
            this.dbConnectionControl2.Location = new System.Drawing.Point(3, 3);
            this.dbConnectionControl2.logg1 = this.logg1;
            this.dbConnectionControl2.MinimumSize = new System.Drawing.Size(260, 175);
            this.dbConnectionControl2.Name = "dbConnectionControl2";
            this.dbConnectionControl2.ShowDatabaseSelector = true;
            this.dbConnectionControl2.Size = new System.Drawing.Size(274, 175);
            this.dbConnectionControl2.TabIndex = 3;
            this.dbConnectionControl2.OnDatabaseConnected += new IKAVA_Systembehandler.DB.DBConnectionControl.DatabaseConnectedEventHandler(this.dbConnectionControl2_OnDatabaseConnected);
            // 
            // tableFunctionsControl1
            // 
            this.tableFunctionsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableFunctionsControl1.conn = null;
            this.tableFunctionsControl1.Enabled = false;
            this.tableFunctionsControl1.Location = new System.Drawing.Point(283, 3);
            this.tableFunctionsControl1.logg1 = this.logg1;
            this.tableFunctionsControl1.MinimumSize = new System.Drawing.Size(184, 175);
            this.tableFunctionsControl1.MySqlInstallationPath = null;
            this.tableFunctionsControl1.Name = "tableFunctionsControl1";
            this.tableFunctionsControl1.ShowADDML = false;
            this.tableFunctionsControl1.ShowCSV = true;
            this.tableFunctionsControl1.ShowXML = true;
            this.tableFunctionsControl1.Size = new System.Drawing.Size(325, 175);
            this.tableFunctionsControl1.TabIndex = 4;
            this.tableFunctionsControl1.Load += new System.EventHandler(this.tableFunctionsControl1_Load);
            // 
            // TabellEksport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableFunctionsControl1);
            this.Controls.Add(this.dbConnectionControl2);
            this.Controls.Add(this.logg1);
            this.Name = "TabellEksport";
            this.Size = new System.Drawing.Size(611, 410);
            this.ResumeLayout(false);

        }

        #endregion

        private Logg logg1;
        private DB.DBConnectionControl dbConnectionControl2;
        private DB.TableFunctionsControl tableFunctionsControl1;
    }
}
