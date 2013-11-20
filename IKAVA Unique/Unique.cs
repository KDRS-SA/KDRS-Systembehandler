using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Net.NetworkInformation;
using IKAVA_Systembehandler;
using IKAVA_Systembehandler.DB;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace IKAVA_Systembehandler.Plugins
{
    public partial class Unique : UserControl, IIKAVA_Systembehandler_Plugin
    {
        Hashtable settings = new Hashtable();
        List<string> ids = new List<string>();
        //string MySqlInstallationPath = ""; // Path to MySqlDump.exe-file.
        string currentTable = string.Empty;
        bool stop = false;
        DB.ConnectionHandler conn;

        public Unique()
        {
            InitializeComponent();

            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass" }); //, "MySqlInstallationPath" });
                ConnectionHandler.Server = settings["server"].ToString();
                ConnectionHandler.Username = settings["user"].ToString();
                ConnectionHandler.Password = settings["pass"].ToString();
            }
            catch
            {
                MessageBox.Show("Ingen settings.xml-fil..");
            }
        }

        private void Unique_Load(object sender, EventArgs e)
        {
            dbConnectionControl1.logg1 = logg1;
        }
        


        private void dbConnectionControl1_OnDatabaseConnected()
        {
            // do something on db-connection.
            conn = dbConnectionControl1.conn;
            FillTableList();
        }

        private void FillTableList()
        {
            cbTables.Items.Clear();
            List<string> tableList = conn.GetListOfTables();
            cbTables.Items.AddRange(tableList.ToArray());

            for (int a = 0; a < cbTables.Items.Count; a++)
            {
                if (cbTables.Items[a].ToString().ToLower().Contains("widetab"))
                {
                    cbTables.SelectedIndex = a;
                    ConnectionHandler.Table = cbTables.SelectedItem.ToString();
                    break;
                }
            }
            this.Enabled = true;
            if (cbTables.SelectedIndex == -1)
            {
                //this.Enabled = false;
                logg1.Log("ERROR : Dette ser ikke ut til å være en Unique-database. Finner ingen tabeller som inneholder 'WIDETAB'" + Environment.NewLine, Logg.LogType.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            logg1.Log("Et øyeblikk....", Logg.LogType.Info);
            string table;
            try
            {
                table = cbTables.SelectedItem.ToString();
            }
            catch { logg1.Log("Du må velge en tabell i listen for å gå videre." + Environment.NewLine, Logg.LogType.Info); return; }

           ConnectionHandler.Table = table;

            logg1.Log("Sjekker om det finnes primærnøkler i tabellen '" + table + "'" + Environment.NewLine, Logg.LogType.Info);

            if (conn.HasPrimaryKeys(cbTables.SelectedItem.ToString()))
            {
                logg1.Log("Funnet primærnøkler for " + cbTables.SelectedItem.ToString() + "." + Environment.NewLine, Logg.LogType.Info);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Fant ingen primærnøkler. Ønsker du å opprette disse? (Dette kan ta noe tid.. men gjør resten av prosessen betydelig raskere!)", "Opprette primærnøkler?", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    logg1.Log("Fant ingen primærnøkler for " + ConnectionHandler.Table + ". Opprettelse av primærnøkler er anbefalt, men kan ta veldig lang tid!" + Environment.NewLine, Logg.LogType.Info);
                    logg1.Log("Alternativt bruk PHPMyAdmin og kjør : 'ALTER TABLE " + ConnectionHandler.Table + " ADD PRIMARY KEY myKey (id, seq);'" + Environment.NewLine, Logg.LogType.Info);
                }
                else
                {
                    logg1.Log("Legger til primærnøkler. Dette kan ta lang tid.." + Environment.NewLine, Logg.LogType.Info);

                    if (!conn.CreatePrimaryKeys(table, new string[] { "id", "seq" }))
                    {
                        logg1.Log(Environment.NewLine + "Feilmelding ved opprettelse av primørnøkler. Please do this directly using PHPMyAdmin or other alternatives." + Environment.NewLine, Logg.LogType.Error);
                        logg1.Log("Ved å bruke PHPMyAdmin kan du kjøre: 'ALTER TABLE " + ConnectionHandler.Database + "." + ConnectionHandler.Table + " ADD PRIMARY KEY myKey (id, seq);' under SQL-fanen." + Environment.NewLine, Logg.LogType.Error);
                        DialogResult dr2 = MessageBox.Show("Feil ved opprettelse av primærnøkler. Ønsker du å avbryte prosessen og legge til primærnøkler manuelt i feks. PHPMyAdmin?", "Feil ved opprettelse av primærnøkler", MessageBoxButtons.YesNo);
                        if (dr2 == System.Windows.Forms.DialogResult.Yes)
                            return;
                    }
                    else
                    {
                        logg1.Log("Primærnøkler lagt til." + Environment.NewLine, Logg.LogType.Info);
                    }
                }
            }

            logg1.Log(Environment.NewLine + "Ser etter dokumenter. Kan ta litt tid.." + Environment.NewLine, Logg.LogType.Info);

            try
            {
                ids.Clear();
                ids.AddRange(conn.Unique_GetListOfIds().ToArray());
            }
            catch (Exception ex)
            {
                logg1.Log(ex.Message, Logg.LogType.Error);
                return;
            }
            int docs = ids.Count();
            int rows = conn.GetRowCountOfTable(table);

            if (docs > 0)
                groupBox3.Enabled = true;
            else
                groupBox3.Enabled = false;
            lblNumberOfDocuments.Text = docs.ToString();
            lblNumberOfRows.Text = rows.ToString();
            logg1.Log(Environment.NewLine + "Fant " + lblNumberOfDocuments.Text + " dokumenter. Klar til uthenting." + Environment.NewLine, Logg.LogType.Info);
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            stop = false;
            try
            {
                if (!Directory.Exists(txtFolder.Text))
                    Directory.CreateDirectory(txtFolder.Text);
            }
            catch
            {
                logg1.Log(Environment.NewLine + "Kunne ikke finne eller opprette mappen '" + txtFolder.Text + "'. Vennligst oppgi en annen mappe.", Logg.LogType.Error);
                return;
            }
            DateTime start = DateTime.Now;
            string extension = "txt";
            progressBar1.Maximum = ids.Count;
            progressBar1.Value = 0;

            string folder = txtFolder.Text;
            int folderCount = 1;
            foreach (string id in ids)
            {
                if (stop)
                {
                    DialogResult dr = MessageBox.Show("Avbryte prosessen?", "Avbrutt av operatør", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        logg1.Log("Prosessen stoppet før slutt av operatør.", Logg.LogType.Info);
                        stop = false;
                        return;
                    }
                    else
                    {
                        stop = false;
                    }
                }

                if (chkSpanFolders.Checked)
                {
                    if (progressBar1.Value % int.Parse(txtNumberOfFilesInFolder.Text) == 0)
                    {
                        folder = txtFolder.Text;
                        folder = folder + "\\" + folderCount;
                        Directory.CreateDirectory(folder);
                        folderCount++;
                    }
                }

                if (chkDoMax.Checked)
                    if (progressBar1.Value > int.Parse(txtDoMax.Text))
                        break;

                progressBar1.Value++;
                progressBar1.Refresh();

                Application.DoEvents();

                if (!chkOverwrite.Checked)
                    if (File.Exists(folder + "\\" + id + ".txt") || (File.Exists(folder + "\\" + id + ".rtf")))
                    {
                        if (chkExtendedLogging.Checked)
                            logg1.Log("Fil '" + id + "' eksisterer. Overskriver ikke. Hopper videre." + Environment.NewLine, Logg.LogType.Info);
                        continue;
                    }
                if (chkExtendedLogging.Checked) 
                    logg1.Log(Environment.NewLine + "Prosesserer " + id, Logg.LogType.Info);

                string docString = conn.Unique_GetStringFromSequenceForDocId(id);

                if (docString.Length > 16 && docString.Substring(0, 16).ToLower().Contains("rtf"))
                {
                    if (chkExtendedLogging.Checked) 
                        logg1.Log(" Filetype: RTF. ", Logg.LogType.Info);
                    extension = "rtf";
                }
                else
                {
                    if (chkExtendedLogging.Checked)
                        logg1.Log(" Filetype: Ukjent. Lagrer som .txt. ", Logg.LogType.Info);
                    extension = "txt";
                }

                if (extension == "txt" && chkReplaceChars.Checked)
                {
                    docString = docString.Replace("{", "æ");
                    docString = docString.Replace("|", "ø");
                    docString = docString.Replace("}", "å");
                    docString = docString.Replace("[", "Æ");
                    docString = docString.Replace("\\", "Ø");
                    docString = docString.Replace("]", "Å");
                }

                StreamWriter sw = new StreamWriter(folder + "\\" + id + "." + extension, false);
                sw.Write(docString);
                sw.Flush();
                sw.Close();

                Application.DoEvents();
            }
            logg1.Log(Environment.NewLine + Environment.NewLine + (progressBar1.Value) + " dokumenter hentet ut på " + (DateTime.Now - start).TotalMinutes + " minutter.", Logg.LogType.Info);
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "Unique Suiten (Marthe, Oskar ++)"; }
        }

        public string Versjon
        {
            get { return "v1.0"; }
        }

        public ControlType type
        {
            get { return ControlType.System; }
        }

        #endregion

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
