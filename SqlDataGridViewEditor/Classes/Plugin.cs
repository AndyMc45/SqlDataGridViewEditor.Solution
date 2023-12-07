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


        static internal MenuStrip Load_Plugins(ref Dictionary<string,string> colHeaderTranslations, ref string translationCultureName)
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
            // For each plugin, add its menustrip to plugInMenus
            // For each plugin, add its translations to the ColumnHeader
            if (container != null)
            {
                loadedPlugins = container.ResolveAll<IPlugin>();
                if (loadedPlugins.Count() > 0) { 
                    foreach (var loadedPlugin in loadedPlugins)
                    {
                        // Tomorrow - redo the 'transcript existed above but not now
                        // loadedPlugin.CntTemplate().menuStrip.Text = plugInMenus.Text;
                        plugInMenus.Items.Add(loadedPlugin.CntTemplate().menuStrip);
                        // First in is approved if there is a conflict
                        foreach (string key in loadedPlugin.ColumnHeaderTranslations().Keys)
                        {
                            if (!colHeaderTranslations.ContainsKey(key))
                            { 
                                colHeaderTranslations.Add(key, loadedPlugin.ColumnHeaderTranslations()[key]);
                            }
                        }
                        // The language of the translation - if two plugins have this, the last one wins!
                        // The UICulture is set in the plugin.
                        // If it is set to the translationCultureName, the headers will be translated
                        translationCultureName = loadedPlugin.TranslationCultureName();
                    }
                }
            }
            return plugInMenus;

        }
    }

    // Future Plugin - Address book
    // Print mailing labels, phone book,address book, email list, get email list
}
