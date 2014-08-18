using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using IKAVA_DBConnectionHandler.Properties;
using System.Diagnostics;
using System.IO;

namespace IKAVA_Systembehandler.DB
{
    public partial class TableFunctionsControl : UserControl
    {
        Hashtable settings = new Hashtable();

        public string MySqlInstallationPath { get; set; }
        public ConnectionHandler conn { get; set; }
        public Logg logg1 { get; set; }

        

        //ConnectionHandler conn;

        public TableFunctionsControl()
        {
            InitializeComponent();

        }

        public void FillTableList()
        {
            conn.CreateConnection(ConnectionHandler.Server, ConnectionHandler.Database, ConnectionHandler.Username, ConnectionHandler.Password);

            lstTables.Items.Clear();
            lstTables.Items.AddRange(conn.GetListOfTables().ToArray());
            logg1.Log("Koblet til database " + ConnectionHandler.Database + ". Lister ut tabeller." + Environment.NewLine, Logg.LogType.Info);
        }

        //public delegate void LogEventHandler(object sender, ProgressChangedEventArgs e);
        //public event LogEventHandler Logged;

        private void btnDumpToXml_Click(object sender, EventArgs e)
        {
            string outFolder = "";
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                outFolder = folderBrowserDialog1.SelectedPath;
            else
                return;

            fileSystemWatcher1.Path = outFolder;
            fileSystemWatcher1.Created += fileSystemWatcher1_Created;
            fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;
            
            List<string> tables = conn.GetListOfTables();
            Cursor = Cursors.WaitCursor;

            if (!File.Exists(Path.Combine(MySqlInstallationPath, "MySqlDump.exe")))
            {
                DialogResult dresult = MessageBox.Show("Kunne ikke finne mysqldump-applikasjonen på standardplassering (innenfor PATH-nivå). Ønsker du å velge mappe for plassering av MySqlDump.exe manuelt?" + Environment.NewLine + "Normalt 'c:\\Program Files\\MySql\\<mysqlversjon>\\bin'", "MYSQLDUMP mangler..", MessageBoxButtons.OKCancel);
                if (dresult == System.Windows.Forms.DialogResult.Cancel)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                DialogResult folderSelector = folderBrowserDialog1.ShowDialog();
                if (folderSelector != System.Windows.Forms.DialogResult.OK)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                MySqlInstallationPath = folderBrowserDialog1.SelectedPath;
                Tools.SetSetting("MySqlInstallationPath", MySqlInstallationPath);
                Tools.SaveSettings();
            }
            logg1.Log("Skriver tabeller til fil. Et øyeblikk..." + Environment.NewLine, Logg.LogType.Info);
            Cursor = Cursors.WaitCursor;

            Parallel.ForEach(tables, table =>
            {
                string filnavn = outFolder + "\\" + table + ".xml";
                FileStream ostrm = new FileStream(filnavn, FileMode.Create, FileAccess.Write);

                using (StreamWriter swriter = new StreamWriter(ostrm))
                {
                    Process process1 = new Process();
                    try
                    {
                        process1 = CreateProcess(process1, Path.Combine(MySqlInstallationPath, "MySqlDump.exe"), table);
                        process1.Start();
                    }
                    catch
                    {
                        Cursor = Cursors.Default;
                        return;
                    }
                    while (!process1.StandardOutput.EndOfStream)
                    {
                        Application.DoEvents();
                        swriter.WriteLine(process1.StandardOutput.ReadLine());
                    }
                    process1.WaitForExit();
                    process1.Close();
                }
                ostrm.Close();
                
            });

            Cursor = Cursors.Default;
        }

        void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            logg1.Log("Opprettet filen " + e.FullPath + Environment.NewLine, Logg.LogType.Info);
        }

        void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            logg1.Log("Overskrev filen " + e.FullPath + Environment.NewLine, Logg.LogType.Info);
        }

        private Process CreateProcess(Process process1, string filename, string table)
        {
            process1.StartInfo.RedirectStandardInput = false;
            process1.StartInfo.RedirectStandardOutput = true;
            process1.StartInfo.UseShellExecute = false;
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process1.StartInfo.CreateNoWindow = true;
            process1.StartInfo.FileName = filename;
            process1.StartInfo.Arguments = " --default-character-set=latin1 ";
            process1.StartInfo.Arguments += " --xml ";
            process1.StartInfo.Arguments += " --host=" + ConnectionHandler.Server;
            process1.StartInfo.Arguments += " --user=" + ConnectionHandler.Username;
            process1.StartInfo.Arguments += " --password=" + ConnectionHandler.Password;
            process1.StartInfo.Arguments += " " + ConnectionHandler.Database + " " + table;
            //logg1.Log("Starter eksport med følgende parametere: " + process1.StartInfo.Arguments, Logg.LogType.Info);
            return process1;
        }

        private void btnDumpToCSV_Click(object sender, EventArgs e)
        {
            string outFolder = "";
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                outFolder = folderBrowserDialog1.SelectedPath;
            else
                return;

            fileSystemWatcher1.Path = outFolder;
            fileSystemWatcher1.Created += fileSystemWatcher1_Created;
            fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;

            List<string> tables = conn.GetListOfTables();
            Cursor = Cursors.WaitCursor;

            logg1.Log("Skriver tabell(er) til CSV-fil(er). Et øyeblikk..." + Environment.NewLine, Logg.LogType.Info);
            Cursor = Cursors.WaitCursor;

            foreach (string table in tables)
            {
                //logg1.Log("Dumper " + table + " til CSV-fil"+Environment.NewLine);
                string filnavn = outFolder + "\\" + table.Trim() + ".csv";
                conn.DumpToCSVFile(table, filnavn, txtDumpToCSV.Text);
                Application.DoEvents();
            }

            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ikke implementert");
        }

        public bool ShowXML { 
            get { return btnDumpToXml.Enabled; }
            set { btnDumpToXml.Enabled = value; } 
        }

        public bool ShowCSV
        {
            get { return btnDumpToCSV.Enabled; }
            set { btnDumpToCSV.Enabled = value; lblDumpToCSV.Enabled = true; txtDumpToCSV.Enabled = true; }
        }

        public bool ShowADDML
        {
            get { return button1.Enabled; }
            set { button1.Enabled = value; }
        }
    }
}
