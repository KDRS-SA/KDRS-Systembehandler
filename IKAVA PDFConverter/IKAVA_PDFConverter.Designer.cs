namespace IKAVA_Systembehandler.Plugins
{
    partial class PDFConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFConverter));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkMulticore = new System.Windows.Forms.CheckBox();
            this.lblMultiCore = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblOfficeVersion = new System.Windows.Forms.Label();
            this.rdLO = new System.Windows.Forms.RadioButton();
            this.rdMSO = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.logg1 = new IKAVA_Systembehandler.Logg();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lboxFileFormat = new System.Windows.Forms.CheckedListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSkipNumber = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtWaitProcess = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkShowWindow = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkPDFA = new System.Windows.Forms.CheckBox();
            this.chkRecursive = new System.Windows.Forms.CheckBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSeparator3 = new System.Windows.Forms.RadioButton();
            this.rbSeparator2 = new System.Windows.Forms.RadioButton();
            this.rbSeparator1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPasswordFile = new System.Windows.Forms.TextBox();
            this.btnPassordFile = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtInFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChooseOutPath = new System.Windows.Forms.Button();
            this.btnChooseInPath = new System.Windows.Forms.Button();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chkCopyOriginalOnError = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.lblWarning);
            this.groupBox1.Controls.Add(this.logg1);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtInFile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnChooseOutPath);
            this.groupBox1.Controls.Add(this.btnChooseInPath);
            this.groupBox1.Controls.Add(this.txtOutPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInPath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(904, 579);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 632);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IKAVA PDFConverter";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkMulticore);
            this.groupBox7.Controls.Add(this.lblMultiCore);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(456, 400);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(442, 49);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Flerkjerneopsjoner";
            // 
            // chkMulticore
            // 
            this.chkMulticore.AutoSize = true;
            this.chkMulticore.Location = new System.Drawing.Point(6, 22);
            this.chkMulticore.Name = "chkMulticore";
            this.chkMulticore.Size = new System.Drawing.Size(95, 17);
            this.chkMulticore.TabIndex = 1;
            this.chkMulticore.Text = "Bruk MultiCore";
            this.chkMulticore.UseVisualStyleBackColor = true;
            // 
            // lblMultiCore
            // 
            this.lblMultiCore.AutoSize = true;
            this.lblMultiCore.Location = new System.Drawing.Point(107, 23);
            this.lblMultiCore.Name = "lblMultiCore";
            this.lblMultiCore.Size = new System.Drawing.Size(41, 13);
            this.lblMultiCore.TabIndex = 0;
            this.lblMultiCore.Text = "label18";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblOfficeVersion);
            this.groupBox6.Controls.Add(this.rdLO);
            this.groupBox6.Controls.Add(this.rdMSO);
            this.groupBox6.Location = new System.Drawing.Point(11, 251);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(268, 68);
            this.groupBox6.TabIndex = 40;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Automasjonsvalg";
            // 
            // lblOfficeVersion
            // 
            this.lblOfficeVersion.AutoSize = true;
            this.lblOfficeVersion.Location = new System.Drawing.Point(94, 21);
            this.lblOfficeVersion.Name = "lblOfficeVersion";
            this.lblOfficeVersion.Size = new System.Drawing.Size(13, 13);
            this.lblOfficeVersion.TabIndex = 2;
            this.lblOfficeVersion.Text = "()";
            // 
            // rdLO
            // 
            this.rdLO.AutoSize = true;
            this.rdLO.Enabled = false;
            this.rdLO.Location = new System.Drawing.Point(16, 42);
            this.rdLO.Name = "rdLO";
            this.rdLO.Size = new System.Drawing.Size(76, 17);
            this.rdLO.TabIndex = 1;
            this.rdLO.Text = "LibreOffice";
            this.rdLO.UseVisualStyleBackColor = true;
            // 
            // rdMSO
            // 
            this.rdMSO.AutoSize = true;
            this.rdMSO.Checked = true;
            this.rdMSO.Location = new System.Drawing.Point(16, 19);
            this.rdMSO.Name = "rdMSO";
            this.rdMSO.Size = new System.Drawing.Size(72, 17);
            this.rdMSO.TabIndex = 0;
            this.rdMSO.TabStop = true;
            this.rdMSO.Text = "MS Office";
            this.rdMSO.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(853, 149);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 29);
            this.button3.TabIndex = 39;
            this.button3.Text = "Stopp";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWarning.Location = new System.Drawing.Point(21, 130);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(530, 22);
            this.lblWarning.TabIndex = 38;
            this.lblWarning.Text = "Advarsel:";
            this.lblWarning.Visible = false;
            // 
            // logg1
            // 
            this.logg1.HTMLEnabled = false;
            this.logg1.Location = new System.Drawing.Point(6, 455);
            this.logg1.Name = "logg1";
            this.logg1.Size = new System.Drawing.Size(891, 171);
            this.logg1.TabIndex = 37;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lboxFileFormat);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(283, 156);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(167, 170);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filtype";
            // 
            // lboxFileFormat
            // 
            this.lboxFileFormat.CheckOnClick = true;
            this.lboxFileFormat.FormattingEnabled = true;
            this.lboxFileFormat.Items.AddRange(new object[] {
            "doc",
            "docx",
            "rtf",
            "txt",
            "pdf",
            "bin"});
            this.lboxFileFormat.Location = new System.Drawing.Point(6, 55);
            this.lboxFileFormat.Name = "lboxFileFormat";
            this.lboxFileFormat.Size = new System.Drawing.Size(154, 109);
            this.lboxFileFormat.TabIndex = 42;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(12, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(149, 33);
            this.label17.TabIndex = 39;
            this.label17.Text = "Velg filtype som skal konverteres til PDF/PDFA";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(745, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 29);
            this.button2.TabIndex = 35;
            this.button2.Text = "Start konvertering";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkCopyOriginalOnError);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtSkipNumber);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtWaitProcess);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.chkShowWindow);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(456, 183);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(441, 211);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Feilhåndtering";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(110, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(325, 42);
            this.label16.TabIndex = 38;
            this.label16.Text = "Hvis man ønsker å hoppe over x antall fra listen over filer til prosessering, for" +
    " eksempel hvis en fil henger seg til stadighet.\r\nDefault = 0. Feks \"Hopp over\"=1" +
    "50 starter på fil 150 i fillisten";
            // 
            // txtSkipNumber
            // 
            this.txtSkipNumber.Location = new System.Drawing.Point(72, 154);
            this.txtSkipNumber.Name = "txtSkipNumber";
            this.txtSkipNumber.Size = new System.Drawing.Size(32, 20);
            this.txtSkipNumber.TabIndex = 37;
            this.txtSkipNumber.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "Hopp over";
            // 
            // txtWaitProcess
            // 
            this.txtWaitProcess.Location = new System.Drawing.Point(36, 111);
            this.txtWaitProcess.Name = "txtWaitProcess";
            this.txtWaitProcess.Size = new System.Drawing.Size(29, 20);
            this.txtWaitProcess.TabIndex = 33;
            this.txtWaitProcess.Text = "10";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(110, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(325, 43);
            this.label12.TabIndex = 32;
            this.label12.Text = "Ved mange feilmeldinger på at word-objektet er i bruk, kan de være aktuelt å sett" +
    "e en liten sleep-timer feks til 500 (millisekunder). \r\nDefault = 10 (ms)";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(113, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(322, 97);
            this.label11.TabIndex = 30;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // chkShowWindow
            // 
            this.chkShowWindow.AutoSize = true;
            this.chkShowWindow.Checked = true;
            this.chkShowWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowWindow.Location = new System.Drawing.Point(16, 42);
            this.chkShowWindow.Name = "chkShowWindow";
            this.chkShowWindow.Size = new System.Drawing.Size(69, 17);
            this.chkShowWindow.TabIndex = 31;
            this.chkShowWindow.Text = "Vis vindu";
            this.chkShowWindow.UseVisualStyleBackColor = true;
            this.chkShowWindow.CheckedChanged += new System.EventHandler(this.chkShowWindow_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(69, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "ms";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Vent";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkPDFA);
            this.groupBox3.Controls.Add(this.chkRecursive);
            this.groupBox3.Controls.Add(this.chkOverwrite);
            this.groupBox3.Location = new System.Drawing.Point(10, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 86);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Innstillinger";
            // 
            // chkPDFA
            // 
            this.chkPDFA.AutoSize = true;
            this.chkPDFA.Location = new System.Drawing.Point(18, 19);
            this.chkPDFA.Name = "chkPDFA";
            this.chkPDFA.Size = new System.Drawing.Size(249, 17);
            this.chkPDFA.TabIndex = 20;
            this.chkPDFA.Text = "Konverter til PDFA (Bruker MS Words versjon..)";
            this.chkPDFA.UseVisualStyleBackColor = true;
            // 
            // chkRecursive
            // 
            this.chkRecursive.AutoSize = true;
            this.chkRecursive.Location = new System.Drawing.Point(17, 42);
            this.chkRecursive.Name = "chkRecursive";
            this.chkRecursive.Size = new System.Drawing.Size(218, 17);
            this.chkRecursive.TabIndex = 21;
            this.chkRecursive.Text = "Ta med undermapper til kildesti (rekursiv)";
            this.chkRecursive.UseVisualStyleBackColor = true;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(17, 65);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(221, 17);
            this.chkOverwrite.TabIndex = 22;
            this.chkOverwrite.Text = "Overskriv (hvis konvertert fil finnes fra før)";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSeparator3);
            this.groupBox2.Controls.Add(this.rbSeparator2);
            this.groupBox2.Controls.Add(this.rbSeparator1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPasswordFile);
            this.groupBox2.Controls.Add(this.btnPassordFile);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(9, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 124);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Passordhåndtering";
            // 
            // rbSeparator3
            // 
            this.rbSeparator3.AutoSize = true;
            this.rbSeparator3.Location = new System.Drawing.Point(71, 101);
            this.rbSeparator3.Name = "rbSeparator3";
            this.rbSeparator3.Size = new System.Drawing.Size(44, 17);
            this.rbSeparator3.TabIndex = 32;
            this.rbSeparator3.Text = "Tab";
            this.rbSeparator3.UseVisualStyleBackColor = true;
            // 
            // rbSeparator2
            // 
            this.rbSeparator2.AutoSize = true;
            this.rbSeparator2.Location = new System.Drawing.Point(134, 84);
            this.rbSeparator2.Name = "rbSeparator2";
            this.rbSeparator2.Size = new System.Drawing.Size(74, 17);
            this.rbSeparator2.TabIndex = 31;
            this.rbSeparator2.Text = "Semikolon";
            this.rbSeparator2.UseVisualStyleBackColor = true;
            // 
            // rbSeparator1
            // 
            this.rbSeparator1.AutoSize = true;
            this.rbSeparator1.Checked = true;
            this.rbSeparator1.Location = new System.Drawing.Point(70, 84);
            this.rbSeparator1.Name = "rbSeparator1";
            this.rbSeparator1.Size = new System.Drawing.Size(60, 17);
            this.rbSeparator1.TabIndex = 30;
            this.rbSeparator1.TabStop = true;
            this.rbSeparator1.Text = "Komma";
            this.rbSeparator1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Passordfil";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(214, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 67);
            this.label7.TabIndex = 23;
            this.label7.Text = "Sti til kommaseparert fil med passord. Filen må ha format :\r\n<sti til fil inklude" +
    "rt filnavn>, <passord>\r\nEtt nytt fil/passord per linje i filen.\r\nDefault = ingen" +
    "";
            // 
            // txtPasswordFile
            // 
            this.txtPasswordFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswordFile.Location = new System.Drawing.Point(66, 18);
            this.txtPasswordFile.Name = "txtPasswordFile";
            this.txtPasswordFile.Size = new System.Drawing.Size(89, 20);
            this.txtPasswordFile.TabIndex = 25;
            // 
            // btnPassordFile
            // 
            this.btnPassordFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPassordFile.Location = new System.Drawing.Point(161, 17);
            this.btnPassordFile.Name = "btnPassordFile";
            this.btnPassordFile.Size = new System.Drawing.Size(47, 21);
            this.btnPassordFile.TabIndex = 26;
            this.btnPassordFile.Text = "Velg...";
            this.btnPassordFile.UseVisualStyleBackColor = true;
            this.btnPassordFile.Click += new System.EventHandler(this.btnPassordFile_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Separator";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(214, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 41);
            this.label9.TabIndex = 27;
            this.label9.Text = "Tegn som brukes som separator i passordfil.\r\nDefault = , (komma)";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(558, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 21);
            this.button1.TabIndex = 19;
            this.button1.Text = "Velg...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtInFile
            // 
            this.txtInFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInFile.Location = new System.Drawing.Point(75, 99);
            this.txtInFile.Name = "txtInFile";
            this.txtInFile.Size = new System.Drawing.Size(476, 20);
            this.txtInFile.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Innfil";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(611, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 57);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fil med filliste for konvertering av spesifikke filer (for eksempel resultatet i " +
    "Filliste_Ikke_Konvertert.log fra en tidligere kjøring)\r\nDefault = ingen";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(611, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "Kildesti er stien hvor programmet skal se etter filer til konvertering";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(611, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "Destinasjon er som default lik Kildesti. Konverterte filer legges sammen med orig" +
    "inalfil.";
            // 
            // btnChooseOutPath
            // 
            this.btnChooseOutPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseOutPath.Location = new System.Drawing.Point(558, 48);
            this.btnChooseOutPath.Name = "btnChooseOutPath";
            this.btnChooseOutPath.Size = new System.Drawing.Size(47, 21);
            this.btnChooseOutPath.TabIndex = 13;
            this.btnChooseOutPath.Text = "Velg...";
            this.btnChooseOutPath.UseVisualStyleBackColor = true;
            this.btnChooseOutPath.Click += new System.EventHandler(this.btnChooseOutPath_Click);
            // 
            // btnChooseInPath
            // 
            this.btnChooseInPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseInPath.Location = new System.Drawing.Point(558, 23);
            this.btnChooseInPath.Name = "btnChooseInPath";
            this.btnChooseInPath.Size = new System.Drawing.Size(47, 21);
            this.btnChooseInPath.TabIndex = 12;
            this.btnChooseInPath.Text = "Velg...";
            this.btnChooseInPath.UseVisualStyleBackColor = true;
            this.btnChooseInPath.Click += new System.EventHandler(this.btnChooseInPath_Click);
            // 
            // txtOutPath
            // 
            this.txtOutPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutPath.Location = new System.Drawing.Point(75, 49);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(476, 20);
            this.txtOutPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destinasjon:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kildesti:";
            // 
            // txtInPath
            // 
            this.txtInPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInPath.Location = new System.Drawing.Point(75, 24);
            this.txtInPath.Name = "txtInPath";
            this.txtInPath.Size = new System.Drawing.Size(476, 20);
            this.txtInPath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // chkCopyOriginalOnError
            // 
            this.chkCopyOriginalOnError.AutoSize = true;
            this.chkCopyOriginalOnError.Checked = true;
            this.chkCopyOriginalOnError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyOriginalOnError.Location = new System.Drawing.Point(16, 188);
            this.chkCopyOriginalOnError.Name = "chkCopyOriginalOnError";
            this.chkCopyOriginalOnError.Size = new System.Drawing.Size(202, 17);
            this.chkCopyOriginalOnError.TabIndex = 39;
            this.chkCopyOriginalOnError.Text = "Kopier originalfil til destinasjon ved feil";
            this.chkCopyOriginalOnError.UseVisualStyleBackColor = true;
            // 
            // PDFConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(904, 632);
            this.Name = "PDFConverter";
            this.Size = new System.Drawing.Size(904, 632);
            this.Load += new System.EventHandler(this.PDFConverter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInPath;
        private System.Windows.Forms.Button btnChooseOutPath;
        private System.Windows.Forms.Button btnChooseInPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtInFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnPassordFile;
        private System.Windows.Forms.TextBox txtPasswordFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkRecursive;
        private System.Windows.Forms.CheckBox chkPDFA;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkShowWindow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSkipNumber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtWaitProcess;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private Logg logg1;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button button3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbSeparator1;
        private System.Windows.Forms.RadioButton rbSeparator3;
        private System.Windows.Forms.RadioButton rbSeparator2;
        private System.Windows.Forms.CheckedListBox lboxFileFormat;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdLO;
        private System.Windows.Forms.RadioButton rdMSO;
        private System.Windows.Forms.Label lblOfficeVersion;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblMultiCore;
        private System.Windows.Forms.CheckBox chkMulticore;
        private System.Windows.Forms.CheckBox chkCopyOriginalOnError;
    }
}
