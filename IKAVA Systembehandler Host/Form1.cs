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

            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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

                    this.Width += 20;
                }
                else
                {
                    continue;
                }
            }
        }

    }
}
