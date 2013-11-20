using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace IKAVA_Systembehandler
{
    public class FileLog
    {
        public enum logType
        {
            Info,
            Filliste_konvertert,
            Filliste_ikkekonvertert
        }

        public static string logfilename { get; set; }
        public static string logpath { get; set; }

        public static StreamWriter sw_info;
        public static StreamWriter sw_filliste_konvertert;
        public static StreamWriter sw_filliste_ikkekonvertert;

        public FileLog()
        {
            if (logpath == string.Empty || logpath == null)
                logpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string timestamp = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "") + " - ";
            if (logpath != string.Empty)
            {
                sw_info = new StreamWriter(Path.GetFullPath(logpath) + @"\" + timestamp + "Info.log", true);
                sw_filliste_konvertert = new StreamWriter(Path.GetFullPath(logpath) + @"\" + timestamp + "Filliste_Konvertert.log", true);
                sw_filliste_ikkekonvertert = new StreamWriter(Path.GetFullPath(logpath) + @"\" + timestamp + "Filliste_Ikke_Konvertert.log", true);
            }
        }

        public static void CloseLog()
        {
            sw_info.Close();
            sw_filliste_konvertert.Close();
            sw_filliste_ikkekonvertert.Close();
        }

        public FileLog(string strLogPath)
        {
            string timestamp = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "") + " - ";
            logpath = strLogPath;
            sw_info = new StreamWriter(Path.GetFullPath(logpath) + @"\" + timestamp + "Info.log", true);
            sw_filliste_konvertert = new StreamWriter(Path.GetFullPath(logpath) + @"\" + timestamp + "Filliste_Konvertert.log", true);
            sw_filliste_ikkekonvertert = new StreamWriter(Path.GetFullPath(logpath) + @"\" + timestamp + "Filliste_Ikke_Konvertert.log", true);
        }

        public static bool LogWrite(string text, logType logtype)
        {
            StreamWriter sw = sw_info;

            switch (logtype)
            {
                case logType.Info:
                    sw = sw_info;
                    break;
                case logType.Filliste_konvertert:
                    sw = sw_filliste_konvertert;
                    break;
                case logType.Filliste_ikkekonvertert:
                    sw = sw_filliste_ikkekonvertert;
                    break;
            }

            if (logtype == logType.Filliste_konvertert || logtype == logType.Filliste_ikkekonvertert)
                sw.WriteLine(text);
            else
                sw.WriteLine(DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString() + " : " + text);
            sw.Flush();
            return true;
        }
    }
}
