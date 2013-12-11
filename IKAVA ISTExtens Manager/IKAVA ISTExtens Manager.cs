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


namespace IKAVA_ISTExtens_Manager
{
    public partial class IKAVA_ISTExtens_Manager : UserControl, IIKAVA_Systembehandler_Plugin
    {
        public ConnectionHandler conn { get; set; }

        Hashtable settings = new Hashtable();

        public IKAVA_ISTExtens_Manager()
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
            get { return "IST Extens Manager"; }
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
            string sql = "Select * from version";

            if (conn == null)
                conn.CreateConnection(ConnectionHandler.Server, ConnectionHandler.Database, ConnectionHandler.Username, ConnectionHandler.Password);
            
            MySqlCommand cmd = new MySqlCommand(sql, MySqlConnector.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            string retString = "";
            while (reader.Read())
            {
                retString = "v" + reader.GetString(0) + "." + reader.GetString(1) + "(" + DateTime.Parse(reader.GetString(2)).ToShortDateString() + ")";
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
                logg1.Log("Du må velge en IST EXTENS database i dropdown til venstre", Logg.LogType.Info); return;
            }
            // søk
            // select * from aktivitet where personid = xxxxxx xxxxx
            // select * from vitnemal
            // select * from vitnemalkurs
            // SELECT vi.elevnamn, v.fodelsenr, v.vitnemalsnr, v.faglinjenr, v.fagkode, v.valgfagtekst, v.standpunkt, v.eksamenskarakter, v.proveform, v.eksamensar FROM vitnemalkurs v left join vitnemal vi on vi.fodelsenr = v.fodelsenr

            //string sql = "SELECT vi.elevnamn, v.fodelsenr, v.vitnemalsnr, v.faglinjenr, v.fagkode, v.valgfagtekst, v.standpunkt, v.eksamenskarakter, v.proveform, v.eksamensar, v.eksamensmanad, vi.orden, vi.adferd, vi.rektornavn, vi.utstedersted, vi.utstedelsedato FROM vitnemalkurs v left join vitnemal vi on vi.fodelsenr = v.fodelsenr";
            
            string sql = "SELECT fodelsenr, vitnemalsnr, elevnamn, avgangsar, orden, "; 
                  sql += "utstedersted, utstedelsedato, rektornavn, enhet, adferd from vitnemal";

            MySqlCommand cmd = new MySqlCommand(sql, MySqlConnector.connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            //List<string> elever = new List<string>();
            string last = string.Empty;
            StreamWriter sw = null;
            StreamReader sr = null;
            
            //xFODTx            reader.GetString(0)
            //xVITNEMÅLNUMMERx  reader.GetString(1)
            //xNAVNx            reader.GetString(2)
            //xAVGANGSARx       reader.GetString(3)
            //xORDENx           reader.GetString(4)
            //xSTEDx            reader.GetString(5)
            //xDATOx            reader.GetString(6)
            //xREKTORx          reader.GetString(7)
            //xSKOLEx           reader.GetString(8)
            //xATFERDx          reader.GetString(9)
            //xKONTAKTLÆRERx    reader.GetString(xx)
            string originalTemplateText = string.Empty;
            string documentText = string.Empty;

            sr = File.OpenText(txtTemplate.Text);
            originalTemplateText = sr.ReadToEnd();
            sr.Close();

            while (reader.Read())
            {
                last = reader.GetString(1);
                if (sw != null)
                {
                    logg1.Log("Skrevet karakterutskrift for " + reader.GetString(0) + Environment.NewLine, Logg.LogType.Info);
                    sw.Close();
                }
                string filename = Path.Combine(txtSavePath.Text, reader.GetString(0) + "-" + reader.GetString(1) + ".rtf");
                
                documentText = originalTemplateText;
                
                // Perform replaces of main parameters..
                documentText = documentText.Replace("xFODTx", (reader.IsDBNull(0) ? "" : reader.GetString(0)))
                    .Replace("xVITNEMALNUMMERx", (reader.IsDBNull(1)?"":reader.GetString(1)))
                    .Replace("xNAVNx", ConvertToRtf((reader.IsDBNull(2) ? "" : reader.GetString(2))))
                    .Replace("xAVGANGSARx", (reader.IsDBNull(3) ? "" : reader.GetString(3)))
                    .Replace("xORDENx", ConvertToRtf((reader.IsDBNull(4) ? "" : reader.GetString(4))))
                    .Replace("xSTEDx", ConvertToRtf((reader.IsDBNull(5) ? "" : reader.GetString(5))))
                    .Replace("xDATOx", (reader.IsDBNull(6) ? "" : reader.GetString(6)))
                    .Replace("xREKTORx", ConvertToRtf((reader.IsDBNull(7) ? "" : reader.GetString(7))))
                    .Replace("xSKOLEx", ConvertToRtf((reader.IsDBNull(8) ? "" : reader.GetString(8))))
                    .Replace("xATFERDx", ConvertToRtf((reader.IsDBNull(9) ? "" : reader.GetString(9))))
                    .Replace("xMERKNADERx", "") // dummy replace..
                    .Replace("xKONTAKTLARERx", ""); // dummy replace..

                // Insert classes and grades..
                string sql2 = "SELECT faglinjenr, fagkode, valgfagtekst, standpunkt, eksamenskarakter, proveform,";
                sql2 += "eksamensmanad, eksamensar from vitnemalkurs where vitnemalsnr =  '" + reader.GetString(1) + "' order by CAST( faglinjenr AS UNSIGNED )";

                string connectionString;
                connectionString = "SERVER=" + ConnectionHandler.Server + ";" + "DATABASE=" + (ConnectionHandler.Database == null ? "" : ConnectionHandler.Database).ToString() + ";" + "UID=" + ConnectionHandler.Username + ";" + "PASSWORD=" + ConnectionHandler.Password + ";";
                MySqlConnection connection2 = new MySqlConnection(connectionString + ";Connect Timeout=300");
                connection2.Open();
                MySqlCommand cmd2 = new MySqlCommand(sql2, connection2);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                
                string classText = string.Empty;

                classText += @"{\rtf1\ansi\ansicpg865\deff0\fs20 \trowd \cellx500 \cellx1800 \cellx5000 \cellx5750 \cellx7200 \cellx8450 \cellx9700 \intbl\qc\clbrdrb NR\cell \intbl\qc\clbrdrb FAGKODE\cell \intbl\ql\clbrdrb FAG\cell \intbl\qc\clbrdrb " + ConvertToRtf("ÅR") + @"\cell \intbl\qc\clbrdrb STANDPUNKT\cell \intbl\qc\clbrdrb EKSAMEN\cell \intbl\qc\clbrdrb EKS.FORM\cell \row ";
                //classText += "  "+"   "+"FAGKODE"+"   "+"FAG                                     "+" | " + "ÅR " + " | " + Environment.NewLine;

                while (reader2.Read())
                {
                    classText += @"\trowd \cellx500 \cellx1800 \cellx5000 \cellx5750 \cellx7200 \cellx8450 \cellx9700 \intbl\qc " + ConvertToRtf((reader2.IsDBNull(0) ? "--" : reader2.GetString(0)).PadLeft(2)) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(1) ? "--" : reader2.GetString(1)).PadRight(8)) + @"\cell \intbl\ql " + ConvertToRtf((reader2.IsDBNull(2) ? "" : reader2.GetString(2)).PadRight(40)) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(6) ? "--" : reader2.GetString(6)) + (reader2.IsDBNull(7) ? "--" : reader2.GetString(7)).Substring(2)) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(3) ? "--" : reader2.GetString(3))) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(4) ? "--" : reader2.GetString(4))) + @"\cell \intbl\qc " + ConvertToRtf((reader2.IsDBNull(5) ? "--" : reader2.GetString(5))) + @"\cell \row ";
                }
                classText += "}";
                reader2.Close();
                //logg1.Log(classText, Logg.LogType.Info);

                documentText = documentText.Replace("xFAGLINJERx", classText);

                sw = File.CreateText(filename);
                sw.Write(documentText.ToString());
                sw.Flush();
                sw.Close();
            }
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
    }
}
