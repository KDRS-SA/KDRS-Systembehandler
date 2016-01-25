namespace IKAVA_Systembehandler.Plugins
{
    partial class Noark5Validator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbConnectionControl1 = new IKAVA_Systembehandler.DB.DBConnectionControl();
            this.SuspendLayout();
            // 
            // logg1
            // 
            this.logg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logg1.HTMLEnabled = true;
            this.logg1.Location = new System.Drawing.Point(3, 280);
            this.logg1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logg1.MinimumSize = new System.Drawing.Size(605, 223);
            this.logg1.Name = "logg1";
            this.logg1.Size = new System.Drawing.Size(605, 224);
            this.logg1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(283, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.MinimumSize = new System.Drawing.Size(325, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(325, 271);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filinstillinger";
            // 
            // dbConnectionControl1
            // 
            this.dbConnectionControl1.conn = null;
            this.dbConnectionControl1.Location = new System.Drawing.Point(3, 3);
            this.dbConnectionControl1.logg1 = this.logg1;
            this.dbConnectionControl1.MinimumSize = new System.Drawing.Size(260, 175);
            this.dbConnectionControl1.Name = "dbConnectionControl1";
            this.dbConnectionControl1.ShowDatabaseSelector = true;
            this.dbConnectionControl1.Size = new System.Drawing.Size(276, 270);
            this.dbConnectionControl1.TabIndex = 28;
            // 
            // Noark5Validator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dbConnectionControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logg1);
            this.Name = "Noark5Validator";
            this.Size = new System.Drawing.Size(611, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private Logg logg1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DB.DBConnectionControl dbConnectionControl1;
    }
}
