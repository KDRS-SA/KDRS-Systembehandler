using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.Office.Interop.Word;
using System.Collections;

namespace IKAVA_Systembehandler.Plugins
{
    public partial class PDFConverter : UserControl, IIKAVA_Systembehandler_Plugin
    {
        public static Hashtable passwordList = new Hashtable();
        public static string inn_sti = System.IO.Directory.GetCurrentDirectory();
        public static string inn_fil = string.Empty;
        public static string log_sti = string.Empty;
        public static string ut_sti = string.Empty;
        public static string filtype = "doc"; // dokumenttype
        public static string rekursiv = "nei";
        public static string overskriv = "nei";
        //public static string passordfil = "";
        public static string passordString = "";
        public static string inn_fil_string = "";
        //public static string separator = ",";
        public static bool showApp = false;
        // bool stopp = false;
        int progress = 0;

        static int empty = 0;
        static int exists = 0;
        static int error = 0;
        static int passwordprotected = 0;
        static string currentPassword = string.Empty;

        public static Microsoft.Office.Interop.Word.Document wordDocument = null;
        public static Microsoft.Office.Interop.Word.Application wordApplication = null;
        public static MailMerge mm;
        public static object paramMissing = Type.Missing;

        public static WdExportFormat paramExportFormat = WdExportFormat.wdExportFormatPDF;

        public static bool paramOpenAfterExport = false;

        public static WdExportOptimizeFor paramExportOptimizeFor = WdExportOptimizeFor.wdExportOptimizeForPrint;
        public static WdExportRange paramExportRange = WdExportRange.wdExportAllDocument;

        public static int paramStartPage = 0;
        public static int paramEndPage = 0;
        public static WdExportItem paramExportItem = WdExportItem.wdExportDocumentContent;
        public static bool paramIncludeDocProps = true;
        public static bool paramKeepIRM = true;
        public static int jumpAhead = 0;
        public static WdExportCreateBookmarks paramCreateBookmarks = WdExportCreateBookmarks.wdExportCreateWordBookmarks;
        public static bool paramDocStructureTags = true;
        public static bool paramBitmapMissingFonts = true;
        public static FileLog log;
        public static List<string> filer = new List<string>();
        public static List<string> filersomskalfjernes = new List<string>();

        string strOfficeVersion = string.Empty;
        int intOfficeVersion = 0;
        Tools t = new Tools();

        public PDFConverter()
        {
            InitializeComponent();

            strOfficeVersion = t.GetInstalledVersionOfficeAsText(Tools.OfficeComponent.Word);
            intOfficeVersion = t.GetInstalledOfficeVersion(Tools.OfficeComponent.Word);
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "PDF Converter"; }
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

        private void btnChooseInPath_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtInPath.Text = folderBrowserDialog1.SelectedPath;

            if (txtOutPath.Text == "")
                txtOutPath.Text = txtInPath.Text;
        }

        private void btnChooseOutPath_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtOutPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtInFile.Text = openFileDialog1.FileName;
        }

        private void btnPassordFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
                txtPasswordFile.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inn_fil = txtInFile.Text;

            backgroundWorker1.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileInfo[] logfiles;
            Cursor = Cursors.Default;
            logg1.Log("Ferdig med konvertering. Sjekk loggfilene under for å kontrollere resultat:" + Environment.NewLine, Logg.LogType.Info);
            IEnumerable<string> lf = Directory.EnumerateFiles(txtInPath.Text, "*.log", SearchOption.TopDirectoryOnly);

            logfiles = Directory.GetFiles(txtInPath.Text, "*.log", SearchOption.TopDirectoryOnly).Select(x => new FileInfo(x)).OrderByDescending(x => x.LastWriteTime).Take(3).ToArray();

            foreach (FileInfo logfile in logfiles)
            {
                logg1.Log(logfile.FullName + Environment.NewLine, Logg.LogType.Info);
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DoConversion();
        }


        private void DoConversion()
        {
            filer.Clear();

            inn_sti = txtInPath.Text;
            ut_sti = txtOutPath.Text;

            if (rbFileType.Checked)
                filtype="doc|docx";
            if (rbFileType1.Checked)
                filtype="rtf";
            if (rbFileType2.Checked)
                filtype="txt";

            if (log_sti == string.Empty)
                log_sti = inn_sti;

            //Init log
            log = new FileLog(log_sti);

            // les passordfil
            if (txtPasswordFile.Text != "")
            {
                string separator = (rbSeparator1.Checked ? "," : rbSeparator2.Checked ? ";" : "");
                StreamReader sr = File.OpenText(txtPasswordFile.Text);
                while (!sr.EndOfStream)
                {
                    string[] passordStringArray = sr.ReadLine().Split(separator.ToCharArray());

                    passordStringArray[0] = Path.GetFileName(passordStringArray[0].ToLower());

                    if (!passwordList.ContainsKey(passordStringArray[0].ToLower()))
                        passwordList.Add(passordStringArray[0].ToLower(), passordStringArray[1]);
                }

                LogFromThread(progress, "Lest passordfil med totalt " + passwordList.Count + " passord" + Environment.NewLine);
            }

            if (inn_fil != string.Empty)
            {
                LogFromThread(progress, "Åpner inn_fil = " + inn_fil + "..." + Environment.NewLine);

                StreamReader sr = File.OpenText(inn_fil);
                List<string> tmp = new List<string>();

                while (!sr.EndOfStream)
                    filer.Add(sr.ReadLine());

                LogFromThread(progress, "Ferdig med å lese inn_fil med totalt " + filer.Count + " filer" + Environment.NewLine);

            }
            else
            {

                LogFromThread(progress, "Finner filer... " + Environment.NewLine);

                if (filtype.Contains("|"))
                {
                    // Mange filtyper..
                    foreach (string ftype in filtype.Split("|".ToCharArray()))
                    {
                        if (filer == null)
                            filer = Directory.GetFiles(inn_sti, "*." + ftype, (chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).ToList<string>();
                        else
                            filer.AddRange(Directory.GetFiles(inn_sti, "*." + ftype, (chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).ToList<string>());
                    }
                }
                else
                {
                    // Hvis ingen passordfil er oppgitt, kjøres det kun mot eksisterende filer.
                    try
                    {
                        filer = Directory.GetFiles(inn_sti, "*." + filtype, (chkRecursive.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)).ToList<string>();
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        LogFromThread(progress, "Du har ikke lesetilgang til en eller flere mapper i InnSti (" + inn_sti + ")" + Environment.NewLine + "Vennligst kontroller tilgang og prøv igjen. Feilmelding var :" + Environment.NewLine + ex.Message + Environment.NewLine);
                        MessageBox.Show("Du har ikke lesetilgang til en eller flere mapper i InnSti (" + inn_sti + ")" + Environment.NewLine + "Vennligst kontroller tilgang og prøv igjen. Feilmelding var :" + Environment.NewLine + ex.Message + Environment.NewLine);
                    }
                }

                LogFromThread(progress, filer.Count + " funnet..." + Environment.NewLine);
            }


            // fjerne rtf-filer som benyttes til brevfletting

            LogFromThread(progress, "Finner filer som ikke skal være med... Dette kan ta en del tid.. " + Environment.NewLine);

            int tmpcnt = 0;
            if (rbFileType.Checked) // Kun nødvendig å kjøre sjekk mot word-filer.
            {
                LogFromThread(progress, "Finner temporære word-filer (inneholder ~)" + Environment.NewLine);
                foreach (string fil in filer)
                {
                    if (fil.Contains("~"))
                    {
                        filersomskalfjernes.Add(fil); // fjern word-temp-filer
                        continue;
                    }
                }
                tmpcnt = 0;
            }
            if (!chkOverwrite.Checked)
            {
                LogFromThread(0, "Finner allerede konverterte filer (PDF-versjon eksisterer)" + Environment.NewLine);
                foreach (string fil in filer)
                {
                    tmpcnt++;
                    if (tmpcnt % 1000 == 0)
                        LogFromThread(0, tmpcnt + " kontrollert.." + Environment.NewLine);
                    if (!chkOverwrite.Checked && File.Exists(Path.ChangeExtension(fil, "pdf")))
                    {
                        filersomskalfjernes.Add(fil); // fjern word-temp-filer
                        continue;
                    }
                }
            }
            tmpcnt = 0;
            /* Ikke nødvendig, for hvis man har krysset av for doc, vil ingen rtf-filer ligge i filer-array.
             * Har man krysset av for rtf eller txt, er ikke dette en aktuell sjekk å kjøre.
            if (rbFileType.Checked) // Kun nødvendig å kjøre sjekk mot word-filer.
            {
                if (filtype.Contains("doc"))
                {
                    LogFromThread(0, "Finner duplikater (doc/rtf-par som er flettedatafil-par)..." + Environment.NewLine);
                    foreach (string fil in filer)
                    {
                        tmpcnt++;
                        if (tmpcnt % 1000 == 0)
                            LogFromThread(0, tmpcnt + " kontrollert.." + Environment.NewLine);

                        //if (Debugger.IsAttached)
                        //{
                        //    if (tmpcnt > 2000)
                        //        break;
                        //}

                        string filetosearchfor = Path.GetFileNameWithoutExtension(fil);
                        List<string> hits = filer.FindAll(file => Path.GetFileNameWithoutExtension(file) == filetosearchfor);
                        if (hits.Count > 1)
                        {
                            if (!filersomskalfjernes.Contains(Path.ChangeExtension(fil, "RTF")))
                                filersomskalfjernes.Add(Path.ChangeExtension(fil, "RTF"));
                        }
                    }
                }
            }
            */

            LogFromThread(0, "Funnet " + filersomskalfjernes.Count + " filer som ikke skal konverteres" + Environment.NewLine);
            foreach (string fil in filersomskalfjernes)
                filer.Remove(fil);

            LogFromThread(0, "Totalt antall filer for konvertering: " + filer.Count + Environment.NewLine);

            // ********************************************************

            #region processqueue
            if (jumpAhead > filer.Count)
            {
                LogFromThread(0, "Hopp-over-teller er større en antall filer i prosesseringskø. Vennligst oppgi et mindre antall." + Environment.NewLine);
                return;
            }

            for (int a = jumpAhead; a < filer.Count; a++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    LogFromThread((100 / filer.Count) * a, Environment.NewLine + "Konvertering avbrutt av operatør." + Environment.NewLine);
                    break;
                }
                ProcessFile(filer[a], a);
                
            }
            #endregion

            // Quit Word and release the ApplicationClass object.
            CloseApplication();
            FileLog.CloseLog();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
           
        }

        private void LogFromThread(int progress, string message)
        {
            backgroundWorker1.ReportProgress(progress, message);
        }

        void ProcessFile(string filename, int cnt)
        {
            progress = Math.Abs((100 / filer.Count) * cnt);

            if (filename.Contains("~"))
                return;

            #region Kverk word-prosesser som henger..
            // kill prosesser som ikke skal være der...
            Process[] procs = Process.GetProcessesByName("WINWORD");
            if (procs.Length > 1)
                foreach (Process process in procs)
                {
                    process.Kill();
                }
            #endregion

            try
            {
                if (wordApplication.Documents.Count > 0)
                {
                    procs = Process.GetProcessesByName("WINWORD");
                    foreach (Process process in procs)
                        process.Kill();
                }
            }
            catch { }

            try
            {
                string title = wordApplication.Caption;
            }
            catch
            {
                LogFromThread(progress, "Oppretter word-app.." + Environment.NewLine);
                CreateApplication();
            }

            DateTime start = DateTime.Now;
            try
            {
                LogFromThread(progress, "(" + (cnt+1).ToString() + " av " + filer.Count + ") ..." + filename.Substring(filename.Length - 15) + " - ");

                #region Sjekk på tom fil
                if (new FileInfo(filename).Length == 0) // empty file -> continue..
                {
                    FileLog.LogWrite("Filen " + filename + " var tom. Hoppet over.", FileLog.logType.Info);
                    LogFromThread(progress, " Fil er tom. Går videre. " + Environment.NewLine);
                    empty++;

                    return;
                }
                #endregion

                #region Opprettelse av filnavn for pdf
                string outfile = string.Empty;

                ut_sti = ut_sti.ToLower();

                string tmpFil = Path.GetFileName(filename);

                if (ut_sti == "")
                    outfile = Path.ChangeExtension(filename, ".pdf");
                else
                {
                    string newPath = Path.GetFullPath(filename).Replace(inn_sti, ut_sti);
                    newPath = Path.ChangeExtension(newPath, ".pdf");

                    outfile = newPath;
                }
                if (File.Exists(outfile) && !chkOverwrite.Checked) // file exists, and not overwrite -> continue..
                {
                    LogFromThread(progress, " Eksisterer. Går videre. " + Environment.NewLine);
                    exists++;

                    return;
                }
                else if (File.Exists(outfile))
                {
                    LogFromThread(progress, " Overskriver. ");
                }
                #endregion

                #region Åpning av fil og passordhåndtering

                string pwMatch = "";

                string key = Path.GetFileName(filename);

                if (passwordList.ContainsKey(key.ToLower()))
                {
                    pwMatch = passwordList[key.ToLower()].ToString();
                }

                if (pwMatch != "")
                {
                    // åpne kilde med passord
                    try
                    {
                        wordDocument = wordApplication.Documents.OpenNoRepairDialog(
                        filename, ref paramMissing, false,
                        ref paramMissing, pwMatch, ref paramMissing,
                        ref paramMissing, pwMatch, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing, ref paramMissing, ref paramMissing,
                        ref paramMissing);

                        if (wordDocument.ProtectionType != WdProtectionType.wdNoProtection)
                            wordDocument.Protect(WdProtectionType.wdNoProtection, ref paramMissing, ref paramMissing, ref paramMissing, ref paramMissing);

                        passwordprotected++;
                        currentPassword = pwMatch;
                    }
                    catch (Exception ex)
                    {
                        LogFromThread(progress, "Finner ingen måte å åpne dokumentet på. Går videre. " + Environment.NewLine);
                        FileLog.LogWrite("Fant ingen måte å åpne '" + filename + "' på. Hopper videre." + ex.Message, FileLog.logType.Info);
                        FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                        error++;
                        return;
                    }

                    LogFromThread(progress, " Passord:" + pwMatch);
                }
                else
                {
                    try
                    {
                        // åpne kilde uten passord.
                        wordDocument = wordApplication.Documents.OpenNoRepairDialog(
                            filename, ref paramMissing, false,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing, 28591, ref paramMissing,
                            ref paramMissing, ref paramMissing, ref paramMissing,
                            ref paramMissing);
                    }
                    catch (Exception ex)
                    {
                        LogFromThread(progress, "Finner ingen måte å åpne dokumentet på. Går videre. " + Environment.NewLine);
                        FileLog.LogWrite("Fant ingen måte å åpne '" + filename + "' på. Hopper videre." + ex.Message, FileLog.logType.Info);
                        FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                        error++;
                        return;
                    }
                }
                Thread.Sleep(int.Parse(txtWaitProcess.Text));
                if (filtype == "txt")
                {
                    wordDocument.PageSetup.LeftMargin = 1.0f;
                    wordDocument.PageSetup.RightMargin = 1.0f;
                    wordDocument.PageSetup.TopMargin = 1.0f;
                    wordDocument.PageSetup.BottomMargin = 1.0f;
                    wordApplication.Selection.Document.Content.Select();
                    wordApplication.Selection.Font.Shrink();
                    wordApplication.Selection.Font.Shrink();
                }

                #endregion

                #region Ekspandering av sub-dokumenter

                try
                {
                    //Thread.Sleep(int.Parse(txtWaitProcess.Text));
                    if (wordDocument.IsMasterDocument)
                    {
                        bool missingFiles = false;

                        foreach (Subdocument s in wordDocument.Subdocuments)
                        {
retry: //stygt.. men dog..
                            if (!File.Exists(s.Name))
                            {
                                string p = Directory.GetParent(Path.GetDirectoryName(s.Name)).ToString();
                                string[] files = Directory.GetFiles(p, Path.GetFileName(s.Name));
                                if (files.Count() == 0)
                                {
                                    missingFiles = true;
                                    FileLog.LogWrite(filename.Substring(filename.Length - 15) + " ble ikke konvertert. FileNotFound ved sjekk av " + s.Name + ".", FileLog.logType.Info);
                                    LogFromThread(progress, " Fant ikke subdokumenter '" + s.Name + "'. Går videre." + Environment.NewLine);
                                }
                                else if (files.Count() == 1)
                                {
                                    File.Copy(files[0], s.Name);
                                    FileLog.LogWrite(filename.Substring(filename.Length - 15) + " ble ikke konvertert. Subdokument funnet på annen plassering. kopiert til " + s.Name + ".", FileLog.logType.Info);
                                    LogFromThread(progress, " Fant subdokument ('" + s.Name + "' plassert på '" + files[0] + "') med feil plassering. Kopiert til riktig." + Environment.NewLine);
                                    goto retry;
                                }
                                else
                                {
                                    missingFiles = true;
                                    FileLog.LogWrite(filename.Substring(filename.Length - 15) + " ble ikke konvertert. Ett eller flere subdokumenter mangler. For mange matchende alternativer funnet.", FileLog.logType.Info);
                                    LogFromThread(progress, "For mange matchende alternative subdokumenter funnet. Går videre." + Environment.NewLine);
                                }
                            }
                        }

                        if (!missingFiles)
                        {
                            int retryCounter = 0;
retry: //stygt.. men dog..
                            try
                            {
                                retryCounter++;
                                wordDocument.ActiveWindow.ActivePane.View.Type = WdViewType.wdOutlineView;
                                wordApplication.ActiveWindow.View.Type = WdViewType.wdMasterView;
                                Thread.Sleep(int.Parse(txtWaitProcess.Text));
                                wordDocument.Subdocuments.Expanded = true;
                                Thread.Sleep(int.Parse(txtWaitProcess.Text));
                            }
                            catch (Exception ex)
                            {
                                if (retryCounter < 10)
                                {
                                    logg1.Log(".", Logg.LogType.Info);
                                    goto retry;
                                }
                                FileLog.LogWrite(filename.Substring(filename.Length - 15) + " ble ikke konvertert. Feil ved ekspansjon. Error:" + ex.Message, FileLog.logType.Info);
                                LogFromThread(progress, " Feil ved eksp. av subdoks. Går videre." + Environment.NewLine);
                                FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                                error++;
                                CloseDocument();
                                return;
                            }
                        }
                        else
                        {
                            FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                            error++;
                            CloseDocument();

                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    FileLog.LogWrite("Filen '..." + filename.Substring(filename.Length - 15) + "' ble ikke konvertert. Subdokument-feil." + ex.Message, FileLog.logType.Info);
                    FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                    LogFromThread(progress, "...Feil oppstått " + ex.Message + Environment.NewLine);
                    error++;
                    CloseDocument();
                    return;
                }
                #endregion

                #region MailMerge
                string mergeFile = Path.ChangeExtension(filename.ToLower(), "rtf");
                if (mergeFile != filename.ToLower() && File.Exists(mergeFile))
                {
                    // Det finnes en korresponderende rtf-fil. Sannsynligvis en data-merge-fil.
                    LogFromThread(progress, " Fletter... ");

                    mm = wordDocument.MailMerge;
                    string mergefil = Path.ChangeExtension(filename.ToLower(), "rtf");

                    mm.OpenDataSource(mergefil, ref paramMissing, false, true, ref paramMissing, false, currentPassword, currentPassword);

                    mm.Destination = WdMailMergeDestination.wdSendToNewDocument;
                    mm.Execute();
                    Thread.Sleep(4000);
                    if (!saveDocument(wordApplication.Documents[1], outfile)) // lagre dok i nytt vindu
                    {
                        FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                        error++;
                    }
                    else
                        FileLog.LogWrite(filename, FileLog.logType.Filliste_konvertert);
                }
                else
                {
                    // Export it in the specified format.
                    if (!saveDocument(wordDocument, outfile))
                    {
                        FileLog.LogWrite(filename, FileLog.logType.Filliste_ikkekonvertert);
                        error++;
                    }
                    else
                        FileLog.LogWrite(filename, FileLog.logType.Filliste_konvertert);
                }
                #endregion
                Thread.Sleep(int.Parse(txtWaitProcess.Text));
                // Close and release the Document object.
                CloseDocument();

                TimeSpan elapsed = DateTime.Now - start;
                LogFromThread(progress, " (" + elapsed.Seconds + "." + elapsed.Milliseconds + " s)" + Environment.NewLine);
            }
            catch (Exception ex)
            {

                error++;
                FileLog.LogWrite("FEIL! Feil ved konvertering av " + filename + "." + Environment.NewLine + "Feilen var :" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, FileLog.logType.Info);
                LogFromThread(progress, "FEIL! Feil ved konvertering av " + filename.Substring(filename.Length - 15) + "." + Environment.NewLine + "Se info.log for beskrivelse." + Environment.NewLine);
                CloseDocument();
                CloseApplication();
            }

        }



        public bool saveDocument(Document document, string outfile)
        {
            if (!Directory.Exists(Path.GetDirectoryName(outfile)))
                Directory.CreateDirectory(Path.GetDirectoryName(outfile));
            try
            {
                if (document != null)
                    document.ExportAsFixedFormat(outfile,
                            paramExportFormat, paramOpenAfterExport,
                            paramExportOptimizeFor, paramExportRange, paramStartPage,
                            paramEndPage, paramExportItem, paramIncludeDocProps,
                            paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                            paramBitmapMissingFonts, chkPDFA.Checked,
                            ref paramMissing);
            }
            catch (Exception ex)
            {
                FileLog.LogWrite("Fikk ikke til å lagre dokumentet. Filen '" + outfile + "' må behandles manuelt." + ex.Message, FileLog.logType.Info);
                LogFromThread(progress, "Fikk ikke til å lagre dokumentet. Filen '" + outfile + "' må behandles manuelt" + Environment.NewLine);
                return false;
            }
            return true;
        }

        public void CloseApplication()
        {
            try
            {
                if (wordApplication != null)
                {
                    wordApplication.Quit(false, ref paramMissing, ref paramMissing);
                    wordApplication = null;
                }
            }
            catch (Exception ex)
            {
                LogFromThread(progress, "Kunne ikke lukke word-app" + Environment.NewLine);
                LogFromThread(progress, "Feilmeldingen var : " + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }

        public void CloseDocument()
        {
            int numRetries = 10;
            int retries = 0;
retry:  //stygt.. men dog..

            try
            {
                retries++;

                if (wordDocument != null)
                {
                    wordDocument.Close(false, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }

                if (wordApplication.Documents.Count > 0)
                    wordApplication.Documents.Close(false, ref paramMissing, ref paramMissing);
            }
            catch (Exception ex)
            {
                if (retries == 1)
                    LogFromThread(progress, " Venter på word...");
                if (retries < numRetries)
                {
                    Thread.Sleep(500);
                    LogFromThread(progress, ".");
                    goto retry;
                }
                                //}
                LogFromThread(progress, " Kunne ikke lukke dokumentet i word." + Environment.NewLine);
                LogFromThread(progress, " Feilmeldingen var : " + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }

        public void CreateApplication()
        {
            try
            {
                int proc = GetProcessIdByWindowTitle("IKAVA_V1");
                if (proc != Int32.MaxValue)
                    Process.GetProcessById(proc).Kill(); // hvis det finnes en word-prosess fra før med IKAVA_V1-tittel, kill it..
            }
            catch { }

            try
            {
                wordApplication = new Microsoft.Office.Interop.Word.Application();
                wordApplication.Visible = chkShowWindow.Checked;
                wordApplication.WindowState = WdWindowState.wdWindowStateNormal;
                wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                wordApplication.Caption = "IKAVA_V1";
                wordApplication.Left = 1;
                wordApplication.Top = 1;
                wordApplication.Height = 600; wordApplication.Width = 400;
            }
            catch (Exception ex)
            {
                LogFromThread(progress, "Error creating word-app. (" + ex.Message + ")" + Environment.NewLine);
            }
            try
            {
                wordDocument = new Microsoft.Office.Interop.Word.Document();
            }
            catch (Exception ex)
            {
                LogFromThread(progress, "Error creating word-doc. (" + ex.Message + ")" + Environment.NewLine);
            }
        }

        public static int GetProcessIdByWindowTitle(string AppId)
        {
            Process[] P_CESSES = Process.GetProcesses();
            for (int p_count = 0; p_count < P_CESSES.Length; p_count++)
            {
                if (P_CESSES[p_count].MainWindowTitle.Contains(AppId))
                {

                    return P_CESSES[p_count].Id;
                }
            }
            return Int32.MaxValue;
        }

        public void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            
            LogFromThread(progress, Environment.NewLine + "Avslutter prosesser" + Environment.NewLine);

            // Close and release the Document object.
            CloseDocument();

            // Quit Word and release the ApplicationClass object.
            CloseApplication();
            LogFromThread(progress, "Program ferdig." + Environment.NewLine);
        }

        private void PDFConverter_Load(object sender, EventArgs e)
        {
            lblWarning.Visible = false;
            if (intOfficeVersion < 11)
            {
                lblWarning.Text += " Denne moduler er kodet for bruk med Office 2003 og 2007. Vennligst oppgrader Office.";
                lblWarning.Visible = true;
            }
            else if (intOfficeVersion > 15)
            {
                lblWarning.Text += "Denne modulen er testet med Office 2003 til 2013. Du har " + strOfficeVersion + ". Ved feil kan det være du mangler Office Interop Assemblies installert.";
                lblWarning.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            logg1.Log(e.UserState.ToString(), Logg.LogType.Info);
        }

    }
}