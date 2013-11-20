using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace IKAVA_Systembehandler.Tools
{
    public class DialogFinderProgram
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, IntPtr lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        
        public DialogFinderProgram()
        { 
            WndSearcher ws = new WndSearcher();

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);

            bw.RunWorkerAsync();
        }

        //const int WM_KEYDOWN = 0x100;
        //const int WM_KEYUP = 0x101;
        //const int L_KEY = 0x4C;
        //const int WM_NEXTDLGCTL = 0x0028;

        public static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (1 == 1)
            {
                Thread.Sleep(1000);
                IntPtr hWnd = WndSearcher.SearchForWindow("bosa_sdm_Microsoft", "Passord");
                if (hWnd != IntPtr.Zero)
                {
                    SetForegroundWindow(hWnd);
                    Thread.Sleep(100);
                    SendKeys.SendWait("{ENTER}");
                    //Thread.Sleep(100);
                }
            }
        }
    }

    public class WndSearcher
    {
        public static IntPtr SearchForWindow(string wndclass, string title)
        {
            SearchData sd = new SearchData { Wndclass = wndclass, Title = title };
            EnumWindows(new EnumWindowsProc(EnumProc), ref sd);
            return sd.hWnd;
        }

        public static bool EnumProc(IntPtr hWnd, ref SearchData data)
        {
            // Check classname and title 
            // This is different from FindWindow() in that the code below allows partial matches
            StringBuilder sb = new StringBuilder(1024);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString().StartsWith(data.Wndclass))
            {
                sb = new StringBuilder(1024);
                GetWindowText(hWnd, sb, sb.Capacity);
                if (sb.ToString().StartsWith(data.Title))
                {
                    data.hWnd = hWnd;
                    return false;    // Found the wnd, halt enumeration
                }
            }
            return true;
        }

        public class SearchData
        {
            // You can put any dicks or Doms in here...
            public string Wndclass;
            public string Title;
            public IntPtr hWnd;
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, ref SearchData data);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ref SearchData data);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    }
}
