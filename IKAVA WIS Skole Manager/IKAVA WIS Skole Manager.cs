using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IKAVA_Systembehandler;
using IKAVA_DBConnectionHandler;
using System.Collections;
using IKAVA_Systembehandler.DB;
using IKAVA_DBConnectionHandler.Properties;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;


namespace IKAVA_WISSkole_Manager
{
    public partial class IKAVA_WISSkole_Manager : UserControl, IIKAVA_Systembehandler_Plugin
    {
        public ConnectionHandler conn { get; set; }

        Hashtable settings = new Hashtable();

        public IKAVA_WISSkole_Manager()
        {
            InitializeComponent();
            
            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass", "MySqlInstallationPath" });
                ConnectionHandler.Server = settings["server"].ToString();
                ConnectionHandler.Username = settings["user"].ToString();
                ConnectionHandler.Password = settings["pass"].ToString();
            }
            catch
            {
                MessageBox.Show("Ingen settings.xml-fil..");
            }
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "WIS Skole Manager"; }
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

        private void dbConnectionControl1_OnDatabaseConnected()
        {
            conn = dbConnectionControl1.conn;
            label2.Text = GetExtensVersion();
        }

        private string GetExtensVersion()
        {
            string sql = "Select * from system";

            if (conn == null)
                conn.CreateConnection(ConnectionHandler.Server, ConnectionHandler.Database, ConnectionHandler.Username, ConnectionHandler.Password);
            
            MySqlCommand cmd = new MySqlCommand(sql, MySqlConnector.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            string retString = "";
            while (reader.Read())
            {
                retString = reader.GetString(0);
            }
            reader.Close();

            return retString;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtSavePath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ConnectionHandler.Database == "")
            {
                logg1.Log("Du må velge en WIS Skole database i dropdown til venstre", Logg.LogType.Info); return;
            }
            
            string sql = "SELECT e.id, e.fornavn, e.etternavn, e.født, e.personnr, s.SkoleNavnNytt, l.fornavn, l.etternavn from elev e, skole s, lerer l where s.id = e.SkoleId and s.rektorid = l.id";

            MySqlCommand cmd = new MySqlCommand(sql, MySqlConnector.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            //List<string> elever = new List<string>();
            string last = string.Empty;
            StreamWriter sw = null;
            StreamReader sr = null;
            
            string originalTemplateText = string.Empty;
            string documentText = string.Empty;

            sr = File.OpenText(txtTemplate.Text);
            originalTemplateText = sr.ReadToEnd();
            sr.Close();
            int cnt = 1;
            while (reader.Read())
            {

                if (reader.IsDBNull(1))
                    continue;

                elevInfo currentElev = new elevInfo();
                
                currentElev.id          = reader.IsDBNull(0) ? 0 : int.Parse(reader.GetString(0));
                currentElev.fornavn     = reader.IsDBNull(1) ? "ikke oppgitt" : reader.GetString(1);
                currentElev.etternavn   = reader.IsDBNull(2) ? "ikke oppgitt" : reader.GetString(2);
                currentElev.fodt        = reader.IsDBNull(3) ? DateTime.Parse("01.01.1901") : DateTime.Parse(reader.GetString(3));
                currentElev.personnr    = reader.IsDBNull(4) ? 0 : int.Parse(reader.GetString(4));
                currentElev.skolenavn   = reader.IsDBNull(5) ? "ikke oppgitt" : reader.GetString(5);
                currentElev.rektornavn  = (reader.IsDBNull(6) ? "ikke oppgitt" : reader.GetString(0))+" "+(reader.IsDBNull(7) ? "ikke oppgitt": reader.GetString(7));

                currentElev.fodselsnr = currentElev.fodt.ToString("ddMMyy") + currentElev.personnr;

                //last = currentElev.id;
                if (sw != null)
                {
                    logg1.Log(cnt.ToString().PadLeft(5,Char.Parse("0")) + ". Karakterutskrift for " + currentElev.fornavn + " " + currentElev.etternavn + Environment.NewLine, Logg.LogType.Info);
                    sw.Close();
                }
                string filename = Path.Combine(txtSavePath.Text, (currentElev.fodt.ToString("yyyy-MM-dd") + "-" + currentElev.etternavn + ", " + currentElev.fornavn + ".rtf");
                
                documentText = originalTemplateText;

                // Perform replaces of main parameters..
                documentText = documentText.Replace("xFODTx", currentElev.fodselsnr)
                    //.Replace("xVITNEMALNUMMERx", (reader.IsDBNull(1)?"":reader.GetString(1)))
                    .Replace("xNAVNx", ConvertToRtf((reader.IsDBNull(1) ? "" : reader.GetString(1)) + " " + (reader.IsDBNull(2) ? "" : reader.GetString(2))))
                    //.Replace("xAVGANGSARx", (reader.IsDBNull(3) ? "" : reader.GetString(3)))
                    //.Replace("xORDENx", ConvertToRtf((reader.IsDBNull(4) ? "" : reader.GetString(4))))
                    //.Replace("xSTEDx", ConvertToRtf((reader.IsDBNull(5) ? "" : reader.GetString(5))))
                    //.Replace("xDATOx", (reader.IsDBNull(6) ? "" : reader.GetString(6)))
                    .Replace("xREKTORx", ConvertToRtf((reader.IsDBNull(6) ? "" : reader.GetString(6))))
                    .Replace("xSKOLEx", ConvertToRtf((reader.IsDBNull(5) ? "" : reader.GetString(5))));
                    //.Replace("xATFERDx", ConvertToRtf((reader.IsDBNull(9) ? "" : reader.GetString(9))))
                    //.Replace("xMERKNADERx", "") // dummy replace..
                    //.Replace("xKONTAKTLARERx", ""); // dummy replace..

                // Insert classes and grades..
                //string sql2 = "SELECT faglinjenr, fagkode, valgfagtekst, standpunkt, eksamenskarakter, proveform,";
                //sql2 += "eksamensmanad, eksamensar from vitnemalkurs where vitnemalsnr =  '" + reader.GetString(1) + "' order by CAST( faglinjenr AS UNSIGNED )";

                //string connectionString;
                //connectionString = "SERVER=" + ConnectionHandler.Server + ";" + "DATABASE=" + (ConnectionHandler.Database == null ? "" : ConnectionHandler.Database).ToString() + ";" + "UID=" + ConnectionHandler.Username + ";" + "PASSWORD=" + ConnectionHandler.Password + ";";
                //MySqlConnection connection2 = new MySqlConnection(connectionString + ";Connect Timeout=300");
                //connection2.Open();
                //MySqlCommand cmd2 = new MySqlCommand(sql2, connection2);
                //MySqlDataReader reader2 = cmd2.ExecuteReader();
                
                //string classText = string.Empty;

                //classText += @"{\rtf1\ansi\ansicpg865\deff0\fs20 \trowd \cellx500 \cellx1800 \cellx5000 \cellx5750 \cellx7200 \cellx8450 \cellx9700 \intbl\qc\clbrdrb NR\cell \intbl\qc\clbrdrb FAGKODE\cell \intbl\ql\clbrdrb FAG\cell \intbl\qc\clbrdrb " + ConvertToRtf("ÅR") + @"\cell \intbl\qc\clbrdrb STANDPUNKT\cell \intbl\qc\clbrdrb EKSAMEN\cell \intbl\qc\clbrdrb EKS.FORM\cell \row ";
                ////classText += "  "+"   "+"FAGKODE"+"   "+"FAG                                     "+" | " + "ÅR " + " | " + Environment.NewLine;

                //while (reader2.Read())
                //{
                //    classText += @"\trowd \cellx500 \cellx1800 \cellx5000 \cellx5750 \cellx7200 \cellx8450 \cellx9700 \intbl\qc " + ConvertToRtf((reader2.IsDBNull(0) ? "--" : reader2.GetString(0)).PadLeft(2)) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(1) ? "--" : reader2.GetString(1)).PadRight(8)) + @"\cell \intbl\ql " + ConvertToRtf((reader2.IsDBNull(2) ? "" : reader2.GetString(2)).PadRight(40)) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(6) ? "--" : reader2.GetString(6)) + (reader2.IsDBNull(7) ? "--" : reader2.GetString(7)).Substring(2)) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(3) ? "--" : reader2.GetString(3))) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(4) ? "--" : reader2.GetString(4))) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(5) ? "--" : reader2.GetString(5))) + @"\cell \row ";
                //}
                //classText += "}";
                //reader2.Close();
                ////logg1.Log(classText, Logg.LogType.Info);

                //documentText = documentText.Replace("xFAGLINJERx", classText);

                sw = File.CreateText(filename);
                sw.Write(documentText.ToString());
                sw.Flush();
                sw.Close();
                cnt++;
            }

            logg1.Log("Ferdig med å skrive " + cnt.ToString() + " karakterutskrifter." + Environment.NewLine, Logg.LogType.Info);
            reader.Close();
        }

        private string ConvertToRtf(string value)
        {
            string result  = string.Empty;
            //Thread.Sleep(50);
            Application.DoEvents();
            using (RichTextBox richTextBox = new RichTextBox())
            {
                richTextBox.Text = value;
                int offset = richTextBox.Rtf.IndexOf(@"\f0\fs17") + 8; // offset = 118;
                int len = richTextBox.Rtf.LastIndexOf(@"\par") - offset;
                result = richTextBox.Rtf.Substring(offset, len).Trim();
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtTemplate.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = "x" + new Random(10000000);
            string filetext = string.Empty;
            string persId = string.Empty;

            if (ConnectionHandler.Database == "")
            {
                logg1.Log("Du må velge en IST EXTENS database i dropdown til venstre", Logg.LogType.Info); return;
            }

            logg1.Log("Kjører spørring mot databasen. Kan ta litt tid ved større mengder elever.", Logg.LogType.Info);

            Cursor.Current = Cursors.WaitCursor;

            string sql = "select e.personid, p.fornamn, p.efternamn, p.adr, p.postnr, p.ort, e.enhet, en.namn, e.startdatum, e.anttimmar, e.antdagar "
            + "from elevfranv e, enhet en, person p "
            + "where e.enhet = en.enhet and p.personid = e.personid "
            + "order by e.personid, e.startdatum;";

            MySqlCommand cmd = new MySqlCommand(sql, MySqlConnector.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            bool first = true;
            int cnt = 0;
            try
            {
                while (reader.Read())
                {
                    //elevInfo currentElev = new elevInfo();
                    //currentElev.id = 
                    if ((reader.IsDBNull(0) ? "0" : reader.GetString(0)) == persId)
                    {
                        first = false;
                        cnt++;
                    }
                    else
                    {
                        if (filetext != string.Empty)
                        {
                            string currentFilename = Path.Combine(txtReportSavePath.Text, filename);
                            if (!File.Exists(currentFilename))
                            {
                                StreamWriter sw = File.CreateText(currentFilename);
                                logg1.Log("Skriver rapport for '" + persId + "'" + Environment.NewLine, Logg.LogType.Info);
                                sw.Write(filetext);
                                sw.Flush();
                                sw.Close();
                            }
                            else
                            {
                                if (chkOverwrite.Checked)
                                {
                                    File.Delete(currentFilename);
                                    StreamWriter sw = File.CreateText(currentFilename);
                                    logg1.Log("Skriver rapport for '" + persId + "'" + Environment.NewLine, Logg.LogType.Info);
                                    sw.Write(filetext);
                                    sw.Flush();
                                    sw.Close();
                                }
                                else
                                {
                                    logg1.Log("Fil for '" + persId + "' finnes. Skriver ikke over." + Environment.NewLine, Logg.LogType.Info);
                                }
                            }
                        }

                        persId = (reader.IsDBNull(0) ? "" : reader.GetString(0));
                        filename = persId + ".txt";
                        first = true;
                        filetext = string.Empty;
                    }

                    if (first)
                        filetext += "Fraværsrapport for " + (reader.IsDBNull(1) ? "" : reader.GetString(1)) + " " + (reader.IsDBNull(2) ? "" : reader.GetString(2)) + " (" + (reader.IsDBNull(0) ? "" : reader.GetString(0)) + ")" + Environment.NewLine + Environment.NewLine;
                    //else
                    filetext += "Fraværets start : " + (reader.IsDBNull(8) ? "" : reader.GetString(8)).Substring(0,10) + " - Fraværslengde : " + (reader.IsDBNull(10) ? "0" : reader.GetString(10)) + " dager og " + (reader.IsDBNull(9) ? "0" : reader.GetString(9)) + " timer." + Environment.NewLine;
                }

                if (filetext != string.Empty)
                {
                    string currentFilename = Path.Combine(txtReportSavePath.Text, filename);
                    if (!File.Exists(currentFilename))
                    {
                        StreamWriter sw = File.CreateText(currentFilename);
                        logg1.Log("Skriver rapport for '" + persId + "'" + Environment.NewLine, Logg.LogType.Info);
                        sw.Write(filetext);
                        sw.Flush();
                        sw.Close();
                    }
                    else
                    {
                        if (chkOverwrite.Checked)
                        {
                            File.Delete(currentFilename);
                            StreamWriter sw = File.CreateText(currentFilename);
                            logg1.Log("Skriver rapport for '" + persId + "'" + Environment.NewLine, Logg.LogType.Info);
                            sw.Write(filetext);
                            sw.Flush();
                            sw.Close();
                        }
                        else
                        {
                            logg1.Log("Fil for '" + persId + "' finnes. Skriver ikke over." + Environment.NewLine, Logg.LogType.Info);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                filetext += ex.Message;
            }
            reader.Close();
            logg1.Log("Totalt "+cnt+" rapportfiler skrevet." + Environment.NewLine, Logg.LogType.Info);
            Cursor.Current = DefaultCursor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtReportSavePath.Text = folderBrowserDialog1.SelectedPath;
        }
    }

    public class elevInfo
    {
        public int id { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public DateTime fodt { get; set; }
        public int personnr { get; set; }
        public string skolenavn { get; set; }
        public string rektornavn {get; set;}
        public string fodselsnr { get; set; }
        public string orden { get; set; }
        public string adferd { get; set; }
        public List<fagInfo> fag { get; set; }
    }

    public class fagInfo
    {
        public string fagkode { get; set; }

    }
}
