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
    public partial class IKAVA_BVPro : UserControl, IIKAVA_Systembehandler_Plugin
    {
        public IKAVA_BVPro()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = Systemnavn + " " + Versjon;
        }

        #region IIKAVA_Systembehandler_Plugin Members

        public string Systemnavn
        {
            get { return "BVPro Manager"; }
        }

        public string Versjon
        {
            get { return "v1.0"; }
        }

        public ControlType type
        {
            get { return ControlType.System; }
        }

        #endregion
    }
}
