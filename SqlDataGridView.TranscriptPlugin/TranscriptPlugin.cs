using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDataGridViewEditor.PluginsInterface;
using System.Data;
using System.Data.SqlClient;
using SqlDataGridViewEditor;
using InfoBox;


namespace SqlDataGridViewEditor.TranscriptPlugin.Plugins
{
    public class TransPlugin : IPlugin
    {
        private ControlTemplate cntTemplate;
        private String name = String.Empty;
        private Form mainForm;   // This will be set to the main form by a delegate
        public String Name() { return this.name; }
        public ControlTemplate CntTemplate() { return cntTemplate;}
        public Form  MainForm  // read-write instance property
        {
            set => mainForm = value;
        }


        public TransPlugin(String name)
        {
            this.name = "Transcripts"; 
            var tupleList = new List<(String, String)>
            {
                ("Graduation Requirements", "graduationRequirements"),
                ("Print Transcript", "printTranscript"),
                ("Print Transcript - English", "printTranscriptEnglish"),
                ("Print Course Role", "printCourseRole"),
                ("Pring Course Rold - English", "printCourseRoleEnglish"),
                ("Options", "options")
            };

            frmOptions fOptions = new frmOptions();
            cntTemplate = new ControlTemplate(  ("Transcripts","transcriptMenu"), 
                                                tupleList, 
                                                fOptions,
                                                Transcript_CallBack);
        
        }
        
        void Transcript_CallBack(object? sender, EventArgs<string> e)
        {
            if (e.Value == "transcriptMenu")
            {
                // Disable some menuItems
            }
            else if (e.Value == "options")
            {
                frmOptions fOptions = new frmOptions();
                fOptions.Show();
            }
            else if (e.Value == "graduationRequirements")
            {
                mnuTranscriptCheckGradRequirements_Click();
            }
            else
            {
                MessageBox.Show("Message2 From ToolStrip, Received in Inherited User Control : " + e.Value);
            }
        }

        private void mnuTranscriptCheckGradRequirements_Click()
        {
            SqlFactory sqlCur = ((DataGridViewForm)mainForm).currentSql;
            // if (currentSql == null) { return; }
            //if (currentSql.myTable == TaColNames.transcriptTable)
            //{
            //    if (dataGridView1.SelectedRows.Count == 1)
            //    {
            //        //Get studentDegreeID column
            //        field fld = dataHelper.getForeignKeyFromRefTableName(currentSql.myTable, TaColNames.studentDegreeTable);
            //        int colNum = getDGVcolumn(fld);
            //        int studentDegreeID = (Int32)dataGridView1.SelectedRows[0].Cells[colNum].Value;
            //        Transcript tScript = new Transcript(studentDegreeID);
            //        DataRow dr = tScript.studentDegreesDataRow;
            //        if (dr == null)
            //        {
            //            InformationBox.Show("Did not find student information.", "Missing student ?", InformationBoxIcon.Question);
            //            return;
            //        }

            //        // Fill other two tScript dataTables - not necessarily the same records as in our table
            //        tScript.fillTranscriptTable();
            //        // msgText("Transcript rows: " + tScript.transcriptDT.Rows.Count.ToString());

            //        //Fill Student Grad requirements table
            //        tScript.fillGradRequirementsDT();

            //    }

            //}
        }

    }
}
