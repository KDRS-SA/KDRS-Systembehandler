namespace IKAVA_Systembehandler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verktøyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hjelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omIKAVASystembehandlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filToolStripMenuItem,
            this.systemerToolStripMenuItem,
            this.verktøyToolStripMenuItem,
            this.hjelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(678, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filToolStripMenuItem
            // 
            this.filToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.filToolStripMenuItem.Name = "filToolStripMenuItem";
            this.filToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.filToolStripMenuItem.Text = "Fil";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // systemerToolStripMenuItem
            // 
            this.systemerToolStripMenuItem.Name = "systemerToolStripMenuItem";
            this.systemerToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.systemerToolStripMenuItem.Text = "Systemer";
            // 
            // verktøyToolStripMenuItem
            // 
            this.verktøyToolStripMenuItem.Name = "verktøyToolStripMenuItem";
            this.verktøyToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.verktøyToolStripMenuItem.Text = "Verktøy";
            // 
            // hjelpToolStripMenuItem
            // 
            this.hjelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.omIKAVASystembehandlerToolStripMenuItem});
            this.hjelpToolStripMenuItem.Name = "hjelpToolStripMenuItem";
            this.hjelpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hjelpToolStripMenuItem.Text = "Hjelp";
            // 
            // omIKAVASystembehandlerToolStripMenuItem
            // 
            this.omIKAVASystembehandlerToolStripMenuItem.Name = "omIKAVASystembehandlerToolStripMenuItem";
            this.omIKAVASystembehandlerToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.omIKAVASystembehandlerToolStripMenuItem.Text = "Om IKAVA Systembehandler";
            this.omIKAVASystembehandlerToolStripMenuItem.Click += new System.EventHandler(this.omIKAVASystembehandlerToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 466);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 498);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IKAVA Systembehandler v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verktøyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hjelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omIKAVASystembehandlerToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}

