using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Unity;
using SqlDataGridViewEditor.PluginsInterface;
// using SqlDataGridViewEditor.TranscriptPlugin.Plugins;


namespace SqlDataGridViewEditor
{

    public delegate void MainFormDelegate(Form dgvForm);

    internal static class Plugins
    {
        static IUnityContainer? container = null;
        static internal String pluginFilePath = String.Empty;
        // Get set of all plugins
        static internal IEnumerable<SqlDataGridViewEditor.PluginsInterface.IPlugin>? loadedPlugins;
        // When invoked, this will add the mainForm into all plugins
        public static void ExportForm(Form dgvForm)
        {
            if (loadedPlugins != null)
            {
                foreach (SqlDataGridViewEditor.PluginsInterface.IPlugin plugIn in loadedPlugins)
                {
                    plugIn.MainForm = dgvForm;
                }
            }
        }


        static internal MenuStrip Load_Plugins()
        {
            MenuStrip plugInMenus = new MenuStrip();
            pluginFilePath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\PluginsToConsume\";
            container = new UnityContainer();
            string[] files = Directory.GetFiles(pluginFilePath, "*.dll");

            Int32 pluginCount = 1;

            foreach (String file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);

                foreach (Type T in assembly.GetTypes())
                {
                    foreach (Type iface in T.GetInterfaces())
                    {
                        if (iface == typeof(IPlugin))
                        {
                            // pluginInstance.name = "transcripts"
                            IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(T, new[] { "Live Plugin " + pluginCount++ });
                            container.RegisterInstance<IPlugin>(pluginInstance.Name(), pluginInstance);
                        }
                    }
                }
            }
            // At this point the unity container has all the plugin data loaded onto it. 
            if (container != null)
            {
                loadedPlugins = container.ResolveAll<IPlugin>();
                if (loadedPlugins.Count() > 0) { 
                    foreach (var loadedPlugin in loadedPlugins)
                    {
                        // Tomorrow - redo the 'transcript existed above but not now
                        // loadedPlugin.CntTemplate().menuStrip.Text = plugInMenus.Text;
                        plugInMenus.Items.Add(loadedPlugin.CntTemplate().menuStrip);

                    }
                }
            }
            return plugInMenus;

        }
    }
}
