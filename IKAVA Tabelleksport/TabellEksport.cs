using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net.NetworkInformation;
using IKAVA_Systembehandler;
using IKAVA_Systembehandler.DB;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace IKAVA_Systembehandler.Plugins
{
    public partial class TabellEksport : UserControl, IIKAVA_Systembehandler_Plugin
    {
        string MySqlInstallationPath = ""; // Path to MySqlDump.exe-file.
        DB.ConnectionHandler conn;
        Hashtable settings = new Hashtable();

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "Tabelleksport til fil eller XML (kun FireBird og MySql)"; }
        }

        public string Versjon
        {
            get { return "v1.3"; }
        }

        public ControlType type
        {
            get { return ControlType.Tool; }
        }

        #endregion

        public TabellEksport()
        {
            InitializeComponent();
            dbConnectionControl2.logg1 = logg1;
            tableFunctionsControl1.logg1 = logg1;

            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass", "MySqlInstallationPath" });
                ConnectionHandler.Server = settings["server"].ToString();
                ConnectionHandler.Username = settings["user"].ToString();
                ConnectionHandler.Password = settings["pass"].ToString();
                MySqlInstallationPath = tableFunctionsControl1.MySqlInstallationPath = settings["MySqlInstallationPath"].ToString();
            }
            catch
            {
                MessageBox.Show("Ingen settings.xml-fil..");
            }
        }

        private void dbConnectionControl2_OnDatabaseConnected()
        {
            // do something on db-connection.
            conn = dbConnectionControl2.conn;
            tableFunctionsControl1.conn = dbConnectionControl2.conn;
            tableFunctionsControl1.MySqlInstallationPath = MySqlInstallationPath;
            tableFunctionsControl1.Enabled = true;
            tableFunctionsControl1.FillTableList();

            tableFunctionsControl1.ShowADDML = false;
            tableFunctionsControl1.ShowCSV = false;
            tableFunctionsControl1.ShowXML = false;

            switch (dbConnectionControl2.ServerTypeSelected)
            {
                case "FireBird":
                    tableFunctionsControl1.ShowCSV = true; break;
                case "MySql":
                    tableFunctionsControl1.ShowCSV = true; 
                    tableFunctionsControl1.ShowXML = true; 
                    break;
            }
        }

        private void tableFunctionsControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
