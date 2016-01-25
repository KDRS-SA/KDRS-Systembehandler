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
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using IKAVA_Systembehandler.DB;

namespace IKAVA_Systembehandler.Plugins
{
    public partial class MiniSofie : UserControl, IIKAVA_Systembehandler_Plugin
    {
        Hashtable settings = new Hashtable();
        DB.ConnectionHandler conn;

        public MiniSofie()
        {
            InitializeComponent();

            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass" });
                ConnectionHandler.Server = settings["server"].ToString();
                ConnectionHandler.Username = settings["user"].ToString();
                ConnectionHandler.Password = settings["pass"].ToString();
            }
            catch
            {
                MessageBox.Show("Ingen settings.xml-fil..");
            }
        }

        private void MiniSofie_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Systemnavn + " " + Versjon;
            dbConnectionControl1.logg1 = logg1;
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "MiniSofie"; }
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
            string path = selectDestinationFolder1.SelectedPath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //string connectionString;
            //connectionString = "SERVER=localhost\\sqlexpress2008;" + "DATABASE=u_osksofie;UID=Tormod;PASSWORD=Tormod;";
            //SqlConnection conn = (SqlConnection)dbConnectionControl1.conn.; // new SqlConnection(connectionString + ";Connect Timeout=300");
            //SqlConnection conn2 = // new SqlConnection(connectionString + ";Connect Timeout=300");
            //conn2.Open();
            //conn.Open();

            if (!conn.CreateConnection(ConnectionHandler.Server, ConnectionHandler.Database, ConnectionHandler.Username, ConnectionHandler.Password))
            {
                logg1.Log("Databasetilkobling feilet. Vennlig korriger innstillinger og prøv igjen.");
            }

            SqlCommand cmd = new SqlCommand("SELECT d.U_ARKMAPPE, a.U_MAPTITL1, a.U_ANTDOK, a.U_SISTEDOK, a.U_RETTETDA, d.U_DOKNR, d.U_JOURNR, d.U_DOKAAR, d.U_DOKDATO, d.U_SAKSBEH FROM U_ARKMAPPE a right join U_DOKUMENT d on a.U_ARKMAPPE = d.U_ARKMAPPE order by d.U_ARKMAPPE; ");
            //cmd.Connection.Open();
            SqlDataReader sqlReader = cmd.ExecuteReader();

            int cnt = 0;

            string U_ARKMAPPE = string.Empty;
            string U_MAPTITL1 = string.Empty;
            short U_DOKNR = 0;
            int U_JOURNR = 0;
            string U_DOKDATO = "000000000000";
            string U_DOKAAR = "0000";
            string filepath = string.Empty;
            string filename = string.Empty;
            string command = string.Empty;
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader sqlReader2;

            try
            {
                while (sqlReader.Read())
                {
                    U_ARKMAPPE = sqlReader.IsDBNull(0) ? "null" : sqlReader.GetString(0);
                    U_MAPTITL1 = sqlReader.IsDBNull(1) ? "null" : sqlReader.GetString(1);
                    U_DOKNR = sqlReader.IsDBNull(5) ? short.Parse("0") : sqlReader.GetInt16(5);
                    U_JOURNR = sqlReader.IsDBNull(6) ? 0 : sqlReader.GetInt32(6);
                    U_DOKAAR = sqlReader.IsDBNull(7) ? "0000" : sqlReader.GetInt16(7).ToString();
                    U_DOKDATO = sqlReader.IsDBNull(8) ? "00000000" : sqlReader.GetInt32(8).ToString();

                    filepath = path + U_ARKMAPPE.TrimStart().TrimEnd() + " - " + U_MAPTITL1.TrimStart().TrimEnd() + "\\" + U_DOKAAR.ToString() + "\\";
                    filepath = CleanFileName(filepath);
                    if (!Directory.Exists(filepath))
                    {
                        Console.WriteLine(filepath);
                        Directory.CreateDirectory(filepath);
                    }
                    try
                    {
                        if (cnt % 1000 == 0)
                            Console.WriteLine(cnt);
                        filename = filepath + U_DOKDATO;
                        filename += " DOKNR " + U_DOKNR.ToString().PadLeft(5, Char.Parse("0"));
                        filename += " JOURNR " + U_JOURNR.ToString().PadLeft(5, Char.Parse("0"));
                        //filename += " (SAKSBEH " + (sqlReader.IsDBNull(10) ? "Ukjent" : (sqlReader.GetString(10).TrimEnd().TrimStart() == "??" ? "Ukjent" : sqlReader.GetString(10).TrimStart().TrimEnd())) + ")";
                        filename += ".rtf";

                        if (File.Exists(filename))
                        {
                            cnt++;
                            continue;
                        }

                        Console.Write(cnt++ + " - " + filename);

                        command = "SELECT d.U_TEXTUTR FROM U_DOKUMENT d where d.U_ARKMAPPE = '" + U_ARKMAPPE + "' and d.U_DOKNR = " + U_DOKNR.ToString() + " and d.U_JOURNR = " + U_JOURNR.ToString() + ";";
                        cmd2.CommandText = command;
                        //cmd2.Connection = conn2;
                        sqlReader2 = cmd2.ExecuteReader();
                        while (sqlReader2.Read())
                        {
                            StreamWriter sw = new StreamWriter(filename);
                            sw.Write(sqlReader2.IsDBNull(0) ? "" : sqlReader2.GetString(0));
                            sw.Close();
                            Console.WriteLine(" - OK!");
                        }
                        sqlReader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dok-eksport feilet. Feilmelding : " + Environment.NewLine + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                logg1.Log(ex.Message);
            }
            logg1.Log("Totalt : " + cnt + Environment.NewLine);
        }

        private static string CleanFileName(string fileName)
        {
            return fileName.Replace("|", "_"); // Fjern eventuelle pipe-tegn. Faktisk hendelse fra Farsund med navn inneholdende pipe-tegn.
        }

        private void dbConnectionControl1_OnDatabaseConnected()
        {
            // do something on db-connection.
            conn = dbConnectionControl1.conn;
        }
    }
}
