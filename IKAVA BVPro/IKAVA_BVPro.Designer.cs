namespace IKAVA_Systembehandler.Plugins
{
    partial class IKAVA_BVPro
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
            this.dbConnectionControl1 = new IKAVA_Systembehandler.DB.DBConnectionControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // logg1
            // 
            this.logg1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logg1.HTMLEnabled = false;
            this.logg1.Location = new System.Drawing.Point(3, 274);
            this.logg1.Name = "logg1";
            this.logg1.Size = new System.Drawing.Size(657, 195);
            this.logg1.TabIndex = 1;
            // 
            // dbConnectionControl1
            // 
            this.dbConnectionControl1.conn = null;
            this.dbConnectionControl1.Location = new System.Drawing.Point(3, 3);
            this.dbConnectionControl1.logg1 = this.logg1;
            this.dbConnectionControl1.MinimumSize = new System.Drawing.Size(260, 175);
            this.dbConnectionControl1.Name = "dbConnectionControl1";
            this.dbConnectionControl1.ShowDatabaseSelector = false;
            this.dbConnectionControl1.Size = new System.Drawing.Size(260, 175);
            this.dbConnectionControl1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(663, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(269, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 272);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funksjoner";
            // 
            // IKAVA_BVPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.logg1);
            this.Controls.Add(this.dbConnectionControl1);
            this.Name = "IKAVA_BVPro";
            this.Size = new System.Drawing.Size(663, 494);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DB.DBConnectionControl dbConnectionControl1;
        private Logg logg1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}
