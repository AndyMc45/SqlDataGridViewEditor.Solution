using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDataGridViewEditor.PluginsInterface;
using System.Data;
using System.Data.SqlClient;
using SqlDataGridViewEditor;
using InfoBox;
using System.Diagnostics.Eventing.Reader;

namespace SqlDataGridViewEditor.TranscriptPlugin
{
    public class TransPlugin : IPlugin
    {
        public String Name() { return this.name; }
        public ControlTemplate CntTemplate() { return cntTemplate; }
        public Form MainForm  // read-write instance property
        {
            set => mainForm = value;
        }
        private ControlTemplate cntTemplate;
        private String name = String.Empty;
        private Form mainForm;   // This will be set to the main form by a delegate


        public TransPlugin(String name)
        {
            this.name = "Transcripts"; 
            var tupleList = new List<(String, String)>
            {
                ("Print Transcript", "printTranscript"),
                ("Print Course Role", "printCourseRole"),
                ("Options", "options")
            };

            frmTranscriptOptions fOptions = new frmTranscriptOptions();
            cntTemplate = new ControlTemplate(  ("Transcripts","transcriptMenu"), 
                                                tupleList, fOptions, Transcript_CallBack);
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
                fOptions.Show();
            }
            else if (e.Value == "printTranscript")
            {
                int studentDegreeID = SetStudentDegreeID();  // Shows error message if any
                if (studentDegreeID == 0)
                { 
                    // Messages shown already so do nothing more.
                }
                else
                {
                    frmTranscriptOptions fOptions = new frmTranscriptOptions();
                    fOptions.myJob = frmTranscriptOptions.Job.printTranscript;
                    fOptions.studentDegreeID = studentDegreeID;
                    fOptions.Show();    // 
                }
            }
            else
            {
                MessageBox.Show("Message2 From ToolStrip, Received in Inherited User Control : " + e.Value);
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
                if (dgvForm.currentSql.myTable == TableName.transcriptTable)
                {
                    //Get studentDegreeID column
                    field fld = dataHelper.getForeignKeyFromRefTableName(dgvForm.currentSql.myTable, TableName.studentDegreesTable);
                    int colNum = dgvForm.getDGVcolumn(fld);
                    studentDegreeID = (Int32)dgvForm.dataGridView1.SelectedRows[0].Cells[colNum].Value;
                }
                else if (dgvForm.currentSql.myTable == TableName.studentDegreesTable)
                {
                    field fld = dataHelper.getTablePrimaryKeyField(TableName.studentDegreesTable);
                    int colNum = dgvForm.getDGVcolumn(fld);
                    studentDegreeID = (Int32)dgvForm.dataGridView1.SelectedRows[0].Cells[colNum].Value;
                }
                else if (dgvForm.currentSql.myTable == TableName.studentsTable)
                {
                    string err = String.Format("Select Student in {0} table (a descendant of the {1} table)", TableName.studentDegreesTable, TableName.studentsTable);
                    sbError.AppendLine(err);
                }
                else
                {
                    string err = String.Format("Please select 1 row in the {0} table or {1} table", TableName.transcriptTable, TableName.studentDegreesTable);
                    sbError.AppendLine(err);
                }
            }
            else
            {
                sbError.AppendLine("Please select exactly one row in the table");
            }

            if (sbError.Length > 0)
            {
                InformationBox.Show(sbError.ToString(), "Error message", InformationBoxIcon.Question);
                return 0;
            }
            return studentDegreeID;
        }
    }
}
