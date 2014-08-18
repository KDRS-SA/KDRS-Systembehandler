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
using IKAVA_Systembehandler;
using FirebirdSql.Data.FirebirdClient;

namespace IKAVA_Systembehandler.DB
{
    public partial class DBConnectionControl : UserControl
    {
        Hashtable settings = new Hashtable();

        string MySqlDumpExe = "";

        public ConnectionHandler conn { get; set; }
        //public FireBirdConnection fbconn { get; set; }

        public Logg logg1 { get; set; }
        public bool ShowDatabaseSelector {
            get
            {
                return cbDatabase.Visible;
            }
            set
            {
                cbDatabase.Visible = value;
                label5.Visible = value;
            }
        }

        public string ServerTypeSelected
        {
            get { return cbServerType.SelectedItem.ToString(); }
        }

        public DBConnectionControl()
        {
            InitializeComponent();
            
            try
            {
                settings = Tools.LoadSettings("settings.xml", new string[] { "server", "user", "pass", "MySqlDumpExe" });
                ConnectionHandler.Server = txtServer.Text = settings["server"].ToString();
                ConnectionHandler.Username = txtUser.Text = settings["user"].ToString();
                ConnectionHandler.Password = txtPassword.Text = settings["pass"].ToString();
                MySqlDumpExe = settings["MySqlDumpExe"].ToString();
            }
            catch
            {
                Console.WriteLine("Ingen settings.xml-fil.." + Environment.NewLine);
            }

            ShowDatabaseSelector = false;
        }

        private void txtServer_Leave(object sender, EventArgs e)
        {
            string Message = "";
            pictureBox1.Image = Resources.error;

            if (Tools.PingServer(txtServer.Text, out Message))
                pictureBox1.Image = Resources.ok;

            logg1.Log(Message, Logg.LogType.Info);
            pictureBox1.Visible = true;

            button1.Enabled = true;

            ConnectionHandler.Server = txtServer.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //switch (cbServerType.SelectedItem.ToString())
            //{
            //    case "MySql":
            //    case "MSSql":
                    if (cbRememberSettings.Checked)
                    {
                        Tools.SetSetting("servertype", cbServerType.SelectedIndex.ToString());
                        Tools.SetSetting("server", txtServer.Text);
                        Tools.SetSetting("user", txtUser.Text);
                        Tools.SetSetting("pass", txtPassword.Text);
                        Tools.SetSetting("fdbfile", txtFDBFil.Text);
                        Tools.SaveSettings();
                        logg1.Log("Innstillinger lagret." + Environment.NewLine, Logg.LogType.Info);
                    }

                    if (ShowDatabaseSelector && cbDatabase.SelectedItem == null)
                    {
                        logg1.Log("Vennligst bruk nedtrekksmenyen og velg en aktuell database." + Environment.NewLine, Logg.LogType.Error);
                        return;
                    }
                    else
                    {
                        if (ShowDatabaseSelector)
                            ConnectionHandler.Database = cbDatabase.SelectedItem.ToString();
                    }
                    Cursor = Cursors.WaitCursor;

                    try
                    {
                        if (conn == null)
                        {
                            var obj = Enum.Parse(typeof(ConnectionHandler.enDatabaseType), cbServerType.SelectedItem.ToString());
                            conn = new ConnectionHandler((ConnectionHandler.enDatabaseType)obj);
                        }

                        if (ConnectionHandler.Database != null)
                            conn.CreateConnection(ConnectionHandler.Server, ConnectionHandler.Database, ConnectionHandler.Username, ConnectionHandler.Password);

                        logg1.Log("Koblet til databaseserver " + ConnectionHandler.Server + "." + Environment.NewLine, Logg.LogType.Info);
                        DatabaseConnected();
                    }
                    catch (Exception ex)
                    {
                        logg1.Log("Tilkoblingen til databasen feilet. Kontroller innstillinger og prøv igjen." + Environment.NewLine + ex.Message + Environment.NewLine, Logg.LogType.Error);
                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
        }

        public delegate void DatabaseConnectedEventHandler();
        public delegate void FDBFileConnectedEventHandler();
        public event DatabaseConnectedEventHandler OnDatabaseConnected;
        public event FDBFileConnectedEventHandler OnFDBFileConnected;
        
        protected void DatabaseConnected()
        {
            OnDatabaseConnected();
        }

        protected void FDBFileConnected()
        {
            OnFDBFileConnected();
        }

        private void cbDatabase_DropDown(object sender, EventArgs e)
        {
            cbDatabase.Items.Clear();
            Cursor = Cursors.WaitCursor;
            try
            {
                conn = new ConnectionHandler(ConnectionHandler.enDatabaseType.MySql);
                cbDatabase.Items.AddRange(conn.GetListOfDatabases().ToArray());
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                logg1.Log("Feil ved tilkobling. Kontroller innstillinger og prøv igjen." + Environment.NewLine + ex.Message + Environment.NewLine, Logg.LogType.Error);
            }
            Cursor = Cursors.Default;
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDatabase.Items.Count > 0)
                ConnectionHandler.Database = cbDatabase.SelectedItem.ToString();
        }

        private void cbRememberSettings_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            cbDatabase.Items.Clear();
            cbDatabase.Refresh();
            ConnectionHandler.Server = txtServer.Text;
        }

        public void RefreshDatabaseList()
        {
            cbDatabase_DropDown(this, EventArgs.Empty);
        }

        public void SelectNamedDatabaseInList(string name)
        {
            cbDatabase.SelectedItem = name;
            
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            ConnectionHandler.Password = txtPassword.Text;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            ConnectionHandler.Username = txtUser.Text;
        }

        private void cbServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbServerType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbServerType.SelectedItem.ToString())
            {
                case "MySql":
                case "SqlServer":
                    txtServer.Visible = true;
                    lblServer.Visible = true;
                    lblFDBFil.Visible = false;
                    txtFDBFil.Visible = false;
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    label5.Visible = true;
                    cbDatabase.Visible = true;
                    btnFDBFil.Visible = false;
                    break;
                case "FireBird":
                    //txtServer.Visible = false;
                    lblServer.Visible = false;
                    lblFDBFil.Visible = true;
                    //txtFDBFil.Visible = true;
                    txtUser.Text = "SYSDBA";
                    txtPassword.Text = "masterkey";
                    ShowDatabaseSelector = false;    
                    //label5.Visible = false;
                    //cbDatabase.Visible = false;
                    btnFDBFil.Visible = true;
                    break;
            }
        }

        private void btnFDBFil_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            DialogResult dr = o.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtServer.Text = o.FileName;
            }
        }
    }
}
