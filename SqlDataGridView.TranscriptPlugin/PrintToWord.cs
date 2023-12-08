using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;


namespace SqlDataGridViewEditor.TranscriptPlugin
{
    public static class PrintToWord
    {

        // There are 3 dataTables for transcript and one extra for course role 
        public static System.Data.DataTable studentDegreeInfoDT { get; set; } // No editing - 1 data row only for this studentDegree 
        public static System.Data.DataTable transcriptDT { get; set; }  // No editing. Transcripts filtered on this studentDegree

        // StudentReqDT is created from scrath -columns added to mainform dataHelper.fieldDT to allows sqlStudentReq factory
        public static System.Data.DataTable studentReqDT { get; set; } // No editing.  
        // A 4th Datatable and Sql for course role - I also use transcriptDT / sql but filter on course
        public static System.Data.DataTable courseTermInfoDT { get; set; } // No editing - 1 data row only for this studentDegree 

        public static void printTranscript(CultureInfo ci, ref StringBuilder sbErrors)
        {
            string transTemplate = AppData.GetKeyValue("TranscriptTemplate");
            if (File.Exists(transTemplate))
            {
                if (studentDegreeInfoDT != null && studentDegreeInfoDT.Rows.Count == 1)
                {
                    object missing = System.Reflection.Missing.Value;
                    // Create application
                    Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    //Create a new document
                    Word.Document document = app.Documents.Add(transTemplate, ref missing, ref missing, ref missing);

                    string studentName = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "studentName");
                    // Table, Row, Column index all start at 1
                    document.Tables[1].Cell(1, 2).Range.Text = studentName;

                    string startDate = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "startDate");
                    startDate = DateTime.Parse(startDate,ci).ToString("MM/yyyy");
                    document.Tables[1].Cell(1, 6).Range.Text = startDate;

                    string studentDegree = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "degreeName");
                    document.Tables[1].Cell(2, 2).Range.Text = studentDegree;

                    int currentTermID = -1;
                    int currentRow = 2;  // Starts at 1; first row is the title row
                    foreach (DataRow transDR in transcriptDT.Rows)
                    {
                        // Get information about current term
                        int termID = Int32.Parse(dataHelper.getColumnValueinDR(transDR, "term"));
                        List<string> tTermsColNames = new List<string> { "term", "termName", "startYear","startMonth","endYear", "endMonth" };
                        Dictionary<string, string> tTermsColValues = TranscriptHelper.GetPkRowColumnValues(
                                TableName.terms, termID, tTermsColNames, ref sbErrors);
                        string term = tTermsColValues["term"];
                        if (termID != currentTermID)
                        {
                            string termName = tTermsColValues["termName"];
                            string startYear = tTermsColValues["startYear"];
                            string startMonth = tTermsColValues["startMonth"];
                            string endYear = tTermsColValues["endYear"];
                            string endMonth = tTermsColValues["endMonth"];
                            string termStartDate = startMonth + "/" + startYear;
                            string termEndDate = endMonth + "/" + endYear;

                            termStartDate = DateTime.Parse(termStartDate, ci).ToString("yyyy年MM月");
                            termEndDate = DateTime.Parse(termEndDate, ci).ToString("yyyy年MM月");

                            document.Tables[2].Cell(currentRow, 1).Range.Text = term;
                            document.Tables[2].Cell(currentRow, 3).Range.Text = termStartDate + " - " + termEndDate;
                            document.Tables[2].Cell(currentRow, 4).Range.Text = termName;
                            document.Tables[2].Rows.Add();
                            currentRow = currentRow + 1;
                            currentTermID = termID;
                        }
                        string courseName = dataHelper.getColumnValueinDR(transDR, "courseName");
                        string facultyName = dataHelper.getColumnValueinDR(transDR, "facultyName");
                        string department = dataHelper.getColumnValueinDR(transDR, "depName");

                        document.Tables[2].Cell(currentRow, 1).Range.Text = term;
                        document.Tables[2].Cell(currentRow, 2).Range.Text = department;
                        document.Tables[2].Cell(currentRow, 3).Range.Text = courseName;
                        document.Tables[2].Cell(currentRow, 4).Range.Text = facultyName;
                        document.Tables[2].Rows.Add();
                        currentRow = currentRow + 1;
                    }
                    app.Visible = true;

                }
            }
        }
    }
}

