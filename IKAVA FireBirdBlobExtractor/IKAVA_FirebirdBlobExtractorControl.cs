using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.IO;
using System.Threading;

namespace IKAVA_Systembehandler.Plugins
{
    public partial class FirebirdBlobExtractorControl : UserControl, IIKAVA_Systembehandler_Plugin
    {
        public FirebirdBlobExtractorControl()
        {
            InitializeComponent();
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "HKDATA PPT Blob Extractor"; }
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtSavePath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Firebird databasefil (.fdb)|*.fdb"; 
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtDatabaseFile.Text = openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                ParseOld();
            else if (radioButton2.Checked)
                ParseNew();
        }

        private void ParseOld()
        {
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.UserID = "SYSDBA";
            csb.Password = "masterkey";
            csb.Database = txtDatabaseFile.Text; 
            csb.ServerType = FbServerType.Default; // embedded Firebird

            List<tabelldef> tabelldefs = new List<tabelldef>();

            tabelldefs.Add(new tabelldef() { tableName = "BREVDB", idNum = 0, kliNum = 1, dokNum = 14 });
            tabelldefs.Add(new tabelldef() { tableName = "JOURNALER", idNum = 0, kliNum = 4, dokNum = 10 });
            tabelldefs.Add(new tabelldef() { tableName = "TEKSTBH", idNum = 0, dokNum = 5 });

            FbConnection c = new FbConnection(csb.ToString());
            c.Open();

            foreach (tabelldef t in tabelldefs)
            {
                Application.DoEvents();
                logg1.Refresh();
                try
                {
                    FbCommand cmd = new FbCommand("SELECT * FROM " + t.tableName, c);

                    using (FbDataReader r = cmd.ExecuteReader())
                    {
                        if (!Directory.Exists(Path.Combine(txtSavePath.Text, t.tableName)))
                            Directory.CreateDirectory(Path.Combine(txtSavePath.Text, t.tableName));

                        while (r.Read())
                        {
                            StreamWriter sw = File.CreateText(txtSavePath.Text + @"\" + t.tableName + @"\" + r.GetString(t.idNum) + (t.kliNum == -1 ? "" : "_" + r.GetString(t.kliNum)) + ".rtf");
                            sw.Write(r.GetString(t.dokNum));
                            sw.Close();
                            logg1.Log("Hentet ut " + t.tableName + " med id " + r.GetString(t.idNum) + Environment.NewLine, Logg.LogType.Info);
                            Application.DoEvents();
                            logg1.Refresh();
                        }
                    }
                }
                catch (Exception ex) {
                    logg1.Log("Feil ved uthenting av " + t.tableName + ". Feilen var : " + ex.Message + Environment.NewLine, Logg.LogType.Info);
                }
            }
            //Console.ReadKey();
        }

        private void ParseNew()
        {
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.UserID = "SYSDBA";
            csb.Password = "masterkey";
            csb.Database = txtDatabaseFile.Text;
            csb.ServerType = FbServerType.Default; // embedded Firebird

            List<tabelldef> tabelldefs = new List<tabelldef>();

            tabelldefs.Add(new tabelldef() { tableName = "HKJOURDOC", idNum = 0, dokNum = 1 });
            tabelldefs.Add(new tabelldef() { tableName = "MELDINGDOC", idNum = 0, dokNum = 1 });
            tabelldefs.Add(new tabelldef() { tableName = "MELDINGERDB", idNum = 0, kliNum = 1, dokNum = 1 });
            tabelldefs.Add(new tabelldef() { tableName = "TEKSTBHDOC", idNum = 0, dokNum = 1 });

            FbConnection c = new FbConnection(csb.ToString());
            c.Open();
            int count = 0;
            string outText = string.Empty;
            foreach (tabelldef t in tabelldefs)
            {
                Application.DoEvents();
                logg1.Refresh();
                try
                {
                    int tabCount = 0;
                    FbCommand cmd = new FbCommand("SELECT * FROM " + t.tableName, c);

                    using (FbDataReader r = cmd.ExecuteReader())
                    {
                        if (!Directory.Exists(Path.Combine(txtSavePath.Text, t.tableName)))
                            Directory.CreateDirectory(Path.Combine(txtSavePath.Text, t.tableName));

                        while (r.Read())
                        {
                            StreamWriter sw = File.CreateText(txtSavePath.Text + @"\" + t.tableName + @"\" + r.GetString(t.idNum) + (t.kliNum == -1 ? "" : "_" + r.GetString(t.kliNum)) + ".rtf");
                            sw.Write(r.GetString(t.dokNum));
                            sw.Close();
                            logg1.Log("Hentet ut " + t.tableName + " med id " + r.GetString(t.idNum) + Environment.NewLine, Logg.LogType.Info);
                            count++;
                            tabCount++;
                            Application.DoEvents();
                            logg1.Refresh();
                        }
                    }

                    logg1.Log("Ferdig med " + t.tableName + ". Eksportert fra denne tabellen : " + tabCount + Environment.NewLine, Logg.LogType.Info);
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    logg1.Log("Feil ved uthenting av " + t.tableName + ". Feilen var : " + ex.Message + Environment.NewLine, Logg.LogType.Info); ;
                }
            }
            logg1.Log("Ferdig med eksport av totalt " + count + " dokumenter" + Environment.NewLine, Logg.LogType.Info); ;
            //Console.ReadKey();
        }
    }

    class tabelldef
    {
        public string tableName { get; set; }
        public int idNum { get; set; }
        public int dokNum { get; set; }
        public int kliNum { get; set; }

        public tabelldef()
        {
            tableName = string.Empty;
            idNum = -1;
            dokNum = -1;
            kliNum = -1;
        }
    }

    class argslistobj
    {
        public string arg { get; set; }
        public string value { get; set; }
    }
}
