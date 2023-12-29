namespace SqlDataGridViewEditor.PluginsInterface
{
    public interface IPlugin
    {
        // Interface requires two things - a string("Name()") and a ControlTemplate("PlugInControls()")
        String Name();
        // Set appData to desired culture, and then translate if this is same as translationCultureName.
        // See DataGridViewForm.cs constructor.    
        String TranslationCultureName();
        ControlTemplate CntTemplate();
        Form MainForm { set; }

        Dictionary<string, string> ColumnHeaderTranslations();
    }
}
