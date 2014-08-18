using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace IKAVA_Systembehandler
{
    public partial class Logg : UserControl
    {
        private bool _HTMLEnabled = false;
        public bool HTMLEnabled { 
            get { return _HTMLEnabled; }
            set { _HTMLEnabled = value; richTextBox1.Visible = value; textBox1.Visible = !value; } 
        }

        public enum LogType
        {
            Error,
            Warning,
            Info
        }

        public Logg()
        {
            InitializeComponent();
        }

        public void Log(string LogText, LogType type = LogType.Info)
        {
            if (HTMLEnabled)
            {
                richTextBox1.AppendText(LogText); 
                richTextBox1.ScrollToCaret();
            } else {
                textBox1.AppendText(LogText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.FileName = "logg.txt";
            DialogResult dr = sfd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(textBox1.Text + richTextBox1.Text);
                sw.Close();
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try { Process.Start(e.LinkText); } catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }
    }
}
