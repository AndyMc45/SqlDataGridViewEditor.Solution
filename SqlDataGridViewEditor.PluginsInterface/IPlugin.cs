using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlDataGridViewEditor;

namespace SqlDataGridViewEditor.PluginsInterface
{
    public interface IPlugin
    {
        // Interface requires two things - a string("Name()") and a ControlTemplate("PlugInControls()")
        String Name();
        ControlTemplate CntTemplate();
        Form MainForm { set; }
    }
}
