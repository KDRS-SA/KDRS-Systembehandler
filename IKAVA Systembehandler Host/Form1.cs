using IKAVA_Systembehandler.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKAVA_Systembehandler
{
    public partial class Form1 : Form
    {
        ICollection<Assembly> assemblies;
        ICollection<Type> pluginTypes = new List<Type>();

        public string FileToLoad = string.Empty;

        // type plugins
        class PluginType
        {
            public string path { get; set; }
            public Type type { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new System.Drawing.Size((int)System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width, (int)System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void omIKAVASystembehandlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetPlugins();
        }

        private void GetPlugins()
        {
        tryAgainCheckPath:
            string path = Path.Combine(Application.StartupPath, "plugins");
            string[] dllFileNames = null;
            if (Directory.Exists(path))
            {
                dllFileNames = Directory.GetFiles(path, "*.dll");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                goto tryAgainCheckPath;
            }

            assemblies = new List<Assembly>(dllFileNames.Length);
            foreach (string dllFile in dllFileNames)
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                Assembly assembly = Assembly.Load(an);
                assemblies.Add(assembly);
            }

            Type pluginType = typeof(IIKAVA_Systembehandler_Plugin);
            foreach (Assembly assembly in assemblies)
            {
                if (assembly != null)
                {
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                        {
                            continue;
                        }
                        else
                        {
                            if (type.GetInterface(pluginType.FullName) != null)
                            {
                                pluginTypes.Add(type);
                            }
                        }
                    }
                }
            }

            foreach (Type type in pluginTypes)
            {
                var ctor = type.GetConstructor(new Type[] { });
                var integration = ctor.Invoke(new object[] { }) as IIKAVA_Systembehandler_Plugin;
                ToolStripMenuItem tpMenuItem1 = (ToolStripMenuItem)menuStrip1.Items[1];
                switch (integration.type)
                {
                    case ControlType.System :
                        tpMenuItem1 = (ToolStripMenuItem)menuStrip1.Items[1];
                        break;
                    case ControlType.Tool:
                        tpMenuItem1 = (ToolStripMenuItem)menuStrip1.Items[2];
                        break;
                }
                ToolStripMenuItem newItem = new ToolStripMenuItem();
                newItem.Name = type.FullName;
                newItem.Text = integration.Systemnavn + " - " + integration.Versjon;
                newItem.Click += new System.EventHandler(this.ItemClick);
                tpMenuItem1.DropDownItems.Add(newItem);
            }
        }

        private void ItemClick(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            foreach (var pluginType in pluginTypes)
            {
                if (pluginType.FullName == ((ToolStripMenuItem)sender).Name)
                {
                    var ctor = pluginType.GetConstructor(new Type[] { });
                    var integration = ctor.Invoke(new object[] { }) as IIKAVA_Systembehandler_Plugin;

                    UserControl uc = integration as UserControl;
                    panel1.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    if (!uc.MinimumSize.IsEmpty)
                        this.Size = uc.MinimumSize;

                    this.Width += 10;
                    this.Height += 40;
                }
                else
                {
                    continue;
                }
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool allow = false;
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".sql")
                    {
                        allow = true;
                        break;
                    }
                }
                e.Effect = (allow ? DragDropEffects.Copy : DragDropEffects.None);
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 1)
                    MessageBox.Show("Støtter bare lasting av én (1) sql-fil av gangen");
                else
                {
                    if (Path.GetExtension(files[0]) == ".sql") // If sql file invoke OpprettDatabase_MySql-component;
                    {
                        panel1.Controls.Clear();
                        var pluginType = pluginTypes.Single(thing => thing.Name == "OpprettDatabase_MySql");
                        var ctor = pluginType.GetConstructor(new Type[] { });
                        var integration = ctor.Invoke(new object[] { }) as IIKAVA_Systembehandler_Plugin;

                        UserControl uc = integration as UserControl;
                        panel1.Controls.Add(uc);
                        uc.Dock = DockStyle.Fill;
                        if (!uc.MinimumSize.IsEmpty)
                            this.Size = uc.MinimumSize;

                        this.Width += 20;

                        iCustomParams ucontrol = uc as iCustomParams;
                        if (ucontrol != null)
                        {
                            ucontrol.FileToLoad = files[0];
                        }
                    }
                }
            }
        }

        private void verktøyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static string CurrentSettings(string settingName)
        {
            //Properties.Settings.Default.Reload();
            try
            {
                return Properties.Settings.Default[settingName].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public bool SetSetting(string settingName, string settingValue)
        {
            try
            {
                Properties.Settings.Default[settingName] = settingValue;
                Properties.Settings.Default.Save();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
