using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKAVA_Tools
{
    public partial class SelectDestinationFolder : UserControl
    {
        string _selectedPath = string.Empty;

        /// <summary>
        /// SelectedPath inneholder valgt sti fra folderbrowserdialogen.
        /// </summary>
        public string SelectedPath {
            get { return _selectedPath; }
        }

        public SelectDestinationFolder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
                _selectedPath = fbd.SelectedPath;
            else
                MessageBox.Show("Vennligst velg en mappe for lagring!","Ingen lagringsmappe valgt");
        }
    }
}
