using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// "Shared" means that all plugins have a ControlTemplate
namespace SqlDataGridViewEditor.PluginsInterface
{
    public class ControlTemplate
    {
        public Form frmTemplate;

        public ToolStripMenuItem menuStrip;

        public event EventHandler<EventArgs<String>> CallBack;

        // Constructor - called by plugin
        public ControlTemplate( (String,String) menuName, 
                                List<(String, String)> menuItems, 
                                Form frmOptions,
                                EventHandler<EventArgs<String>> callBack)
        {
            frmTemplate = frmOptions;
            CallBack = callBack;

            // Define and fill the menuStrip
            ToolStripMenuItem topLevelMenuStripItem = new ToolStripMenuItem(menuName.Item1);
            topLevelMenuStripItem.Text = menuName.Item1;
            topLevelMenuStripItem.Tag = menuName.Item2; 

            foreach ((String, String) tuple in menuItems)
            {
                ToolStripMenuItem dropDownMenuStripItem = new ToolStripMenuItem(tuple.Item1);
                dropDownMenuStripItem.Click += new EventHandler(MenuItemClickHandler);
                dropDownMenuStripItem.Tag = tuple.Item2;
                topLevelMenuStripItem.DropDownItems.Add(dropDownMenuStripItem);
            }
            menuStrip = topLevelMenuStripItem;
            menuStrip.Text = menuName.Item1;
            menuStrip.Tag = menuName.Item2;
            menuStrip.Click += new EventHandler(MenuItemClickHandler);
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem receivedMenuItem = (ToolStripMenuItem)sender;
            CallBack.SafeInvoke(this, new EventArgs<string>(receivedMenuItem.Tag.ToString()));
        }
    }
}
