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
    public partial class Noark5Validator : UserControl, IIKAVA_Systembehandler_Plugin
    {
        string MySqlInstallationPath = ""; // Path to MySqlDump.exe-file.
        DB.ConnectionHandler conn;
        Hashtable settings = new Hashtable();

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "Noark5 validator - Overbygg for KDRS-PHP-versjon"; }
        }

        public string Versjon
        {
            get { return "v1.0"; }
        }

        public ControlType type
        {
            get { return ControlType.Tool; }
        }

        #endregion

        public Noark5Validator()
        {
            InitializeComponent();
            dbConnectionControl1.logg1 = logg1;

            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass", "MySqlInstallationPath" });
                ConnectionHandler.Server = settings["server"].ToString();
                ConnectionHandler.Username = settings["user"].ToString();
                ConnectionHandler.Password = settings["pass"].ToString();
                MySqlInstallationPath = settings["MySqlInstallationPath"].ToString();
            }
            catch
            {
                MessageBox.Show("Ingen settings.xml-fil..");
            }
        }
    }
}
