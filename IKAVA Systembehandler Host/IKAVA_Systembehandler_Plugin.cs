using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKAVA_Systembehandler
{
    public enum ControlType
    {
        System,
        Tool
    }

    public interface IIKAVA_Systembehandler_Plugin
    {
        string Systemnavn { get; }
        string Versjon { get; }
        ControlType type { get; }
    }

    public interface iCustomParams
    {
        string FileToLoad { get; set; }
    }
}
