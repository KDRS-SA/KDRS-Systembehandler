using System;
using System.Windows.Forms;
using IKAVA_Systembehandler.DB;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace IKAVA_Systembehandler.Plugins
{
    public partial class OpprettDatabase_MySql : UserControl, IIKAVA_Systembehandler_Plugin, iCustomParams
    {
        public string[] AcceptFileTypes {
            get { return new string[] {".sql"}; } 
        }

        string MySqlInstallationPath = ""; // Path to MySqlDump.exe-file.
        DB.ConnectionHandler conn;
        Hashtable settings = new Hashtable();

        public OpprettDatabase_MySql()
        {
            InitializeComponent();
            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass", "MySqlInstallationPath" });
                ConnectionHandler.Server = settings["server"].ToString();
                ConnectionHandler.Username = settings["user"].ToString();
                ConnectionHandler.Password = settings["pass"].ToString();
                MySqlInstallationPath = settings["MySqlInstallationPath"].ToString();
                ConnectionHandler.Database = "";
            }
            catch
            {
                MessageBox.Show("Ingen settings.xml-fil..");
            }

            
        }

        private void IKAVA_OpprettDatabase_MySql_Load(object sender, EventArgs e)
        {
            dbConnectionControl1.logg1 = logg1;
            label1.Text = this.Versjon;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (conn.CreateEmptyDatabase(txtDatabaseName.Text))
            {
                dbConnectionControl1.ShowDatabaseSelector = true;
                logg1.Log("Database '" + txtDatabaseName.Text + "' opprettet." + Environment.NewLine, Logg.LogType.Info);
                dbConnectionControl1.RefreshDatabaseList();
                dbConnectionControl1.SelectNamedDatabaseInList(txtDatabaseName.Text);
            }
            else
            {
                logg1.Log("Databasen '" + txtDatabaseName.Text + "' ble ikke opprettet. Det kan hende databasen allerede finnes." + Environment.NewLine, Logg.LogType.Error);
                DialogResult dr = MessageBox.Show("Databasen ble ikke opprettet pga. av at den sannsynligvis finnes fra før. " + Environment.NewLine + "Ønsker du å endre navn, trykk Avbryt/Cancel og endre navn i tekstfeltet." + Environment.NewLine + "Ønsker du å kjøre DROP DATABASE " + txtDatabaseName.Text + " mot server " + ConnectionHandler.Server + ", trykk OK", "Feil oppstått ved opprettelse av database", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    if (conn.DropDatabase(txtDatabaseName.Text))
                        logg1.Log("Databasen '" + txtDatabaseName.Text + "' ble droppet fra " + ConnectionHandler.Server, Logg.LogType.Info);
                    else
                        logg1.Log("En feil oppstod. Databasen '" + txtDatabaseName.Text + "' ble ikke droppet fra " + ConnectionHandler.Server, Logg.LogType.Info);
                }
            }

            //Start scripting of mysql-import.
            Process process1 = new Process();
            try
            {
retrymysql:
                if (!File.Exists(Path.Combine(MySqlInstallationPath, "mysql.exe")))
                {
                    logg1.Log("Kunne ikke finne mysql-applikasjonen på standardplassering. Du må ha MySQL installert på maskinen dette kjører på.", Logg.LogType.Error);
                    DialogResult dresult = MessageBox.Show("Kunne ikke finne mysql-applikasjonen på standardplassering (innenfor PATH-nivå). Ønsker du å velge mappe for plassering av MySql.exe manuelt?" + Environment.NewLine + "Normalt 'c:\\Program Files\\MySql\\<mysqlversjon>\\bin'", "MYSQLDUMP mangler..", MessageBoxButtons.OKCancel);
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
                    goto retrymysql;
                }

                Cursor = Cursors.WaitCursor;
                logg1.Log("Import kan ta lang tid. Command-vindu forsvinner igjen når prosessen er ferdig."+Environment.NewLine, Logg.LogType.Info);
                process1.StartInfo.FileName = "cmd.exe";
                process1.StartInfo.Arguments = "/c " + Path.Combine(MySqlInstallationPath, "mysql.exe");
                process1.StartInfo.Arguments += " -u " + ConnectionHandler.Username;
                process1.StartInfo.Arguments += " -p" + ConnectionHandler.Password;
                process1.StartInfo.Arguments += " -h " + ConnectionHandler.Server;
                process1.StartInfo.Arguments += " --default-character-set=utf8 ";
                process1.StartInfo.Arguments += " " + ConnectionHandler.Database + " ";
                process1.StartInfo.Arguments += " < \"" + txtLoadPath.Text + "\" "; 
                process1.Start();
            }
            catch (Exception ex)
            {
                logg1.Log(ex.Message, Logg.LogType.Error);
                return;
            }

            logg1.Log("Fremdrift:", Logg.LogType.Info);

            while (!process1.HasExited)
            {
                logg1.Log("#", Logg.LogType.Info);
                Thread.Sleep(1000);
                Application.DoEvents();
                logg1.Refresh();
            }

            process1.WaitForExit();
            process1.Close();
            Cursor = Cursors.Default;

            logg1.Log(Environment.NewLine+"Ferdig med import.", Logg.LogType.Info);
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "Opprett database (Fra SQL-fil. KUN MySql)"; }
        }

        public string Versjon
        {
            get { return "v1.1"; }
        }

        public ControlType type
        {
            get { return ControlType.Tool; }
        }

        #endregion

        private void dbConnectionControl1_OnDatabaseConnected()
        {
            conn = dbConnectionControl1.conn;
            groupBox5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Sql-script-filer|*.sql";
            DialogResult fileSelector = openFileDialog1.ShowDialog();

            if (fileSelector != System.Windows.Forms.DialogResult.OK)
            {
                Cursor = Cursors.Default;
                return;
            }
            txtLoadPath.Text = openFileDialog1.FileName;
            LoadSql();
        }

        private void LoadSql()
        {
            Cursor = Cursors.Hand;
            StreamReader sr = new StreamReader(txtLoadPath.Text);

            // DROP DATABASE IF EXISTS `man_oskar`;
            // CREATE DATABASE `man_oskar`;
            // USE `man_oskar`;

            string DatabaseName = "";
            Regex rex = new Regex("CREATE DATABASE (.*);");
            for (int a = 0; a < 150; a++) //read first 150 lines to find create database-statement.
            {
                string CompleteScript = sr.ReadLine();
                Match m = rex.Match(CompleteScript);
                if (m.Success)
                {
                    DatabaseName = m.Groups[1].Value.Replace("`", "");
                    break;
                }
            }

            txtDatabaseName.Text = ConnectionHandler.Database = DatabaseName;

            if (DatabaseName == "")
            {
                logg1.Log("Databasenavn ble ikke funnet i filen (Ingen Create database-statement)" + Environment.NewLine, Logg.LogType.Warning);
                txtDatabaseName.Text = "<oppgi databasenavn>";
            }
            else
            {
                logg1.Log("Databasenavn '" + ConnectionHandler.Database + "' ble funnet i filen." + Environment.NewLine, Logg.LogType.Info);
            }
            Cursor = Cursors.Default;
        }

        private void txtDatabaseName_Leave(object sender, EventArgs e)
        {
            txtDatabaseName.Text = txtDatabaseName.Text.ToLower();
        }

        #region iCustomParams Members

        string iCustomParams.FileToLoad
        {
            get { return txtLoadPath.Text; }
            set { txtLoadPath.Text = value; }
        }

        #endregion

        private void groupBox5_EnabledChanged(object sender, EventArgs e)
        {
            if (txtLoadPath.Text != "")
                LoadSql();
        }

        private void dbConnectionControl1_OnDatabaseConnected2()
        {
            conn = dbConnectionControl1.conn;
            groupBox5.Enabled = true;
        }
    }
}
