using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Win32;

namespace IKAVA_Systembehandler
{
    public class Tools
    {
        String MySqlInstallationPath = String.Empty;
        static XmlDocument xDoc = new XmlDocument();
        static string SettingsPath = "";

        #region Settings
        public static Hashtable LoadSettings(string FileName, string[] Parameters)
        {
            SettingsPath = FileName;

            Hashtable hashtable = new Hashtable();
            xDoc.Load(FileName);
            foreach (string p in Parameters)
            {
                try
                {
                    hashtable[p] = GetSetting(p);
                }
                catch { }
            }
            return hashtable;
        }

        public static void SaveSettings()
        {
            xDoc.Save(SettingsPath);
        }

        public static bool SetSetting(string settingname, string value)
        {
            if (xDoc.GetElementsByTagName(settingname).Count > 0)
            {
                xDoc.GetElementsByTagName(settingname)[0].InnerText = value;
                return true;
            }
            return false;
        }

        public static string GetSetting(string settingname)
        {
            if (xDoc.GetElementsByTagName(settingname).Count > 0)
            {
                return xDoc.SelectSingleNode("settings").SelectSingleNode(settingname).InnerText;
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region Network
        /// <summary>
        /// Ping server-address (ex localhost, 192.168.2.36, www.vg.no etc..)
        /// </summary>
        /// <param name="Server">Server url/name</param>
        /// <param name="Message">Returned message (requires "out")</param>
        /// <returns>bool true/false for ping result</returns>
        public static bool PingServer(string Server, out string Message)
        {
            try
            {
                PingReply reply = new Ping().Send(Server, 3000);
                if (reply.Status == IPStatus.Success)
                {
                    Message = "'" + Server + "' er tilgjengelig på nett. Ping : " + reply.RoundtripTime + " ms." + Environment.NewLine;
                    return true;
                }
            }
            catch { }
            Message = "'" + Server + "' svarer ikke på ping." + Environment.NewLine;
            return false;
        }

        public static bool TcpConnect(string Server, string Port, out string Message)
        {
            string retVal = string.Empty;
            string ServerToPing = Server;
            if (Server.Contains("\\"))
            {
                ServerToPing = Server.Substring(0, Server.IndexOf("\\"));
            }
            if (PingServer(ServerToPing, out retVal))
            {
                TcpClient tcpClient = new TcpClient();
                try
                {
                    tcpClient.Connect(Server, int.Parse(Port));
                    if (tcpClient.Connected)
                    {
                        Message = "'" + Server + "' er tilgjengelig på nett, og svarer på port '" + Port + "'" + Environment.NewLine;
                        return true;
                    }
                    Message = "'" + Server + "' svarer ikke på ping." + Environment.NewLine;
                    return false;
                }
                catch (Exception ex)
                {
                    Message = "Tilkobling til '" + Server + "' på port '" + Port + "' gav følgende feilmelding:" + Environment.NewLine + ex.Message + Environment.NewLine;
                    return false;
                }
            }
            else
            {
                retVal = "'" + Server + "' svarer ikke på ping." + Environment.NewLine;
            }
            Message = retVal;
            return false;
        }

        #endregion

        #region Office Detection
        public enum OfficeComponent
        {
            Word,
            Excel,
            PowerPoint,
            Outlook
        }

        public int GetInstalledOfficeVersion(OfficeComponent officeComponent)
        {
            string path = GetComponentPath(officeComponent);
            return GetMajorVersion(path);
        }

        public string GetInstalledVersionOfficeAsText(OfficeComponent officeComponent)
        {
            string version = string.Empty;

            switch (GetInstalledOfficeVersion(officeComponent))
            {
                case 16: version = "MS Office 2016 - "; break;
                case 15: version = "MS Office 2013 - "; break;
                case 14: version = "MS Office 2010 - "; break;
                case 12: version = "MS Office 2007 - "; break;
                case 11: version = "MS Office 2003 - "; break;
                case 10: version = "MS Office 2002 - "; break;
                case 9: version = "MS Office 2000 - "; break;
                case 8: version = "MS Office 97 - "; break;
                case 7: version = "MS Office 95 - "; break;
                default: version = "Fant ingen office-installasjon"; break;
            }
            return version + officeComponent.ToString();
        }

        private string GetComponentPath(OfficeComponent _component)
        {
            const string RegKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths";
            string toReturn = string.Empty;
            string _key = string.Empty;

            switch (_component)
            {
                case OfficeComponent.Word:
                    _key = "winword.exe";
                    break;
                case OfficeComponent.Excel:
                    _key = "excel.exe";
                    break;
                case OfficeComponent.PowerPoint:
                    _key = "powerpnt.exe";
                    break;
                case OfficeComponent.Outlook:
                    _key = "outlook.exe";
                    break;
            }

            //looks inside CURRENT_USER:
            RegistryKey _mainKey = Registry.CurrentUser;
            try
            {
                _mainKey = _mainKey.OpenSubKey(RegKey + "\\" + _key, false);
                if (_mainKey != null)
                {
                    toReturn = _mainKey.GetValue(string.Empty).ToString();
                }
            }
            catch
            { }

            //if not found, looks inside LOCAL_MACHINE:
            _mainKey = Registry.LocalMachine;
            if (string.IsNullOrEmpty(toReturn))
            {
                try
                {
                    _mainKey = _mainKey.OpenSubKey(RegKey + "\\" + _key, false);
                    if (_mainKey != null)
                    {
                        toReturn = _mainKey.GetValue(string.Empty).ToString();
                    }
                }
                catch
                { }
            }

            //closing the handle:
            if (_mainKey != null)
                _mainKey.Close();

            return toReturn;
        }

        private int GetMajorVersion(string _path)
        {
            int toReturn = 0;
            if (File.Exists(_path))
            {
                try
                {
                    FileVersionInfo _fileVersion = FileVersionInfo.GetVersionInfo(_path);
                    toReturn = _fileVersion.FileMajorPart;
                }
                catch
                { }
            }
            return toReturn;
        }
        #endregion
    }
}
