using SqlDataGridViewEditor.PluginsInterface;
using System.Text;


namespace SqlDataGridViewEditor.TranscriptPlugin
{
    // This plugin class has been discovered by reflection in the main program form.
    // It has been instantiated - and so the constructor has run.
    // Some of its public values have been changed by the main program
    // A click in the main program calls its callback function
    // The callback function opens frmTranscriptOptions - which allows user to do various things
    public class TransPlugin : IPlugin
    {
        #region Variables
        public String Name() { return this.name; }
        public ControlTemplate CntTemplate() { return cntTemplate; }
        public Form MainForm  // read-write instance property
        {
            set => mainForm = value;
        }
        public String TranslationCultureName() { return translationCultureName; }
        public Dictionary<string, string> ColumnHeaderTranslations() { return columnHeaderTranslations; }

        private ControlTemplate cntTemplate;
        private String name = String.Empty;
        private Dictionary<string, string> columnHeaderTranslations;
        private Form mainForm;   // This will be set to the main form by a delegate
        private string translationCultureName;
        #endregion

        public TransPlugin(String name)
        {
            this.name = "Transcripts";
            var tupleList = new List<(String, String)>
            {
                ("Print Transcript", "printTranscript"),
                ("Print Class List", "printClassList"),
                ("Options", "options")
            };

            frmTranscriptOptions fOptions = new frmTranscriptOptions();
            cntTemplate = new ControlTemplate(("Transcripts", "transcriptMenu"),
                                                tupleList, fOptions, Transcript_CallBack);
            columnHeaderTranslations = TranscriptHelper.FillColumnHeaderTranslationDictionary();
            translationCultureName = "zh-Hant";  // Hard coded to the language of the translation
        }

        // CallBack - If things are good, then open the form with 'job'
        void Transcript_CallBack(object? sender, EventArgs<string> e)
        {
            if (e.Value == "transcriptMenu")
            {
                // Disable some menuItems

            }
            else if (e.Value == "options")
            {
                frmTranscriptOptions fOptions = new frmTranscriptOptions();
                fOptions.myJob = frmTranscriptOptions.Job.options;
                fOptions.ShowDialog();
            }
            else if (e.Value == "printTranscript")
            {
                int studentDegreeID = SetStudentDegreeID();  // Shows error message if any
                if (studentDegreeID == 0)
                {
                    // Messages shown already by setStudentDegreeID and so do nothing here.
                }
                else
                {
                    frmTranscriptOptions fOptions = new frmTranscriptOptions();
                    fOptions.myJob = frmTranscriptOptions.Job.printTranscript;
                    fOptions.studentDegreeID = studentDegreeID;
                    fOptions.headerTranslations = columnHeaderTranslations;
                    fOptions.translationCultureName = translationCultureName;

                    fOptions.ShowDialog();    // 
                }
            }
            // The only difference between class role and grade sheet is the template that is used
            else if (e.Value == "printClassList")
            {
                int courseTermID = SetCourseTermDegreeID();  // Shows error message if any
                if (courseTermID == 0)
                {
                    // Messages shown already by SetCourseTermDegreeID() so do nothing more.
                }
                else
                {
                    frmTranscriptOptions fOptions = new frmTranscriptOptions();
                    fOptions.myJob = frmTranscriptOptions.Job.printClassList;
                    fOptions.courseTermID = courseTermID;
                    fOptions.headerTranslations = columnHeaderTranslations;
                    fOptions.translationCultureName = translationCultureName;
                    fOptions.ShowDialog();    // 
                }
            }
            else
            {
                MessageBox.Show("Message From ToolStrip, Received in Inherited User Control : " + e.Value);
            }
        }

        private int SetStudentDegreeID()
        {
            StringBuilder sbError = new StringBuilder();
            int studentDegreeID = 0;
            // MainForm variable in the plugin has been set to the mainForm of the program by a delegate.  See mainForm constructor. 
            DataGridViewForm dgvForm = (DataGridViewForm)mainForm;
            // Get the studentDegreeID and then call "PrepareToPrint"
            SqlFactory sqlCur = dgvForm.currentSql;
            // Return 0 if no table selected in main form
            if (dgvForm.currentSql == null) { return 0; }
            // Try to get Student ID
            if (dgvForm.dataGridView1.SelectedRows.Count == 1)
            {
                if (dgvForm.currentSql.myTable == TableName.transcript)
                {
                    //Get studentDegreeID column
                    field fld = dataHelper.getForeignKeyFromRefTableName(dgvForm.currentSql.myTable, TableName.studentDegrees);
                    int colNum = dgvForm.getDGVcolumn(fld);
                    studentDegreeID = (Int32)dgvForm.dataGridView1.SelectedRows[0].Cells[colNum].Value;
                }
                else if (dgvForm.currentSql.myTable == TableName.studentDegrees)
                {
                    field fld = dataHelper.getTablePrimaryKeyField(TableName.studentDegrees);
                    int colNum = dgvForm.getDGVcolumn(fld);
                    studentDegreeID = (Int32)dgvForm.dataGridView1.SelectedRows[0].Cells[colNum].Value;
                }
                else if (dgvForm.currentSql.myTable == TableName.students)
                {
                    string err = String.Format(Properties.PluginResources.selectStudentInTable01, TableName.studentDegrees, TableName.students);
                    sbError.AppendLine(err);
                }
                else
                {
                    string err = String.Format(Properties.PluginResources.selectOneRowinTable0or1, TableName.transcript, TableName.studentDegrees);
                    sbError.AppendLine(err);
                }
            }
            else
            {
                sbError.AppendLine(Properties.PluginResources.selectExactlyOneRow);
            }

            if (sbError.Length > 0)
            {
                MessageBox.Show(sbError.ToString(), "Error message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return 0;
            }
            return studentDegreeID;
        }

        private int SetCourseTermDegreeID()
        {
            StringBuilder sbError = new StringBuilder();
            int courseTermID = 0;
            // MainForm variable in the plugin has been set to the mainForm of the program by a delegate.  See mainForm constructor. 
            DataGridViewForm dgvForm = (DataGridViewForm)mainForm;
            // Get the studentDegreeID and then call "PrepareToPrint"
            SqlFactory sqlCur = dgvForm.currentSql;
            // Return 0 if no table selected in main form
            if (dgvForm.currentSql == null) { return 0; }
            // Try to get Course Term ID
            if (dgvForm.dataGridView1.SelectedRows.Count == 1)
            {
                if (dgvForm.currentSql.myTable == TableName.transcript)
                {
                    //Get studentDegreeID column
                    field fld = dataHelper.getForeignKeyFromRefTableName(dgvForm.currentSql.myTable, TableName.courseTerms);
                    int colNum = dgvForm.getDGVcolumn(fld);
                    courseTermID = (Int32)dgvForm.dataGridView1.SelectedRows[0].Cells[colNum].Value;
                }
                else if (dgvForm.currentSql.myTable == TableName.courseTerms)
                {
                    field fld = dataHelper.getTablePrimaryKeyField(TableName.courseTerms);
                    int colNum = dgvForm.getDGVcolumn(fld);
                    courseTermID = (Int32)dgvForm.dataGridView1.SelectedRows[0].Cells[colNum].Value;
                }
                else if (dgvForm.currentSql.myTable == TableName.courses)
                {
                    string err = String.Format(Properties.PluginResources.selectCourseInTable01, TableName.courseTerms, TableName.courses);
                    sbError.AppendLine(err);
                }
                else
                {
                    string err = String.Format(Properties.PluginResources.selectOneRowinTable0or1, TableName.transcript, TableName.courseTerms);
                    sbError.AppendLine(err);
                }
            }
            else
            {
                sbError.AppendLine(Properties.PluginResources.selectExactlyOneRow);
            }

            if (sbError.Length > 0)
            {
                MessageBox.Show(sbError.ToString(), "Error message", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return 0;
            }
            return courseTermID;
        }

    }
}
