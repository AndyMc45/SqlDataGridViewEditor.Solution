using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


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
        // No editing - 1 data row only for this studentDegree
        public static System.Data.DataTable courseTermInfoDT { get; set; } // No editing - 1 data row only for this studentDegree 

        //private static Word.Application wordApp()
        //{
        //    Word.Application app = new Microsoft.Office.Interop.Word.Application
        //    {
        //        Visible = false,
        //        ScreenUpdating = false,
        //        DisplayAlerts = Word.WdAlertLevel.wdAlertsNone
        //    };
           
        //    return app;
        //}

        public static void printTranscript(CultureInfo ci, ref StringBuilder sbErrors)
        {
            string transTemplate = AppData.GetKeyValue("TranscriptTemplate");
            if (File.Exists(transTemplate))
            {
                if (studentDegreeInfoDT != null && studentDegreeInfoDT.Rows.Count == 1)
                {

                    WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open(transTemplate, true);
                    if (wordprocessingDocument is null)
                    {
                        throw new ArgumentNullException(nameof(wordprocessingDocument));
                    }
                    string myPath = "C:\\Users\\AndrewMcCafferty\\Documents\\test.doc";
                    WordprocessingDocument myDocument = wordprocessingDocument.Clone(myPath);
                    if (myDocument is null)
                    {
                        throw new ArgumentNullException(nameof(myDocument));
                    }


                    // Assign a reference to the existing document body.
                    MainDocumentPart myMainDocumentPart = myDocument.MainDocumentPart ?? myDocument.AddMainDocumentPart();
                    Body myBody = myMainDocumentPart.Document.Body;
                    

                    // Find the first table in the document.
                    Table table = myBody.Elements<Table>().First();

                    // Find the second row in the table.
                    TableRow row = table.Elements<TableRow>().ElementAt(1);

                    // Find the third cell in the row.
                    TableCell cell = row.Elements<TableCell>().ElementAt(2);

                    // Find the first paragraph in the table cell.
                    Paragraph p = cell.Elements<Paragraph>().First();

                    // Find the first run in the paragraph.
                    Run r = p.Elements<Run>().First();

                    // Set the text for the run.
                    Text t = r.Elements<Text>().First();
                    t.Text = "Test";
                    myDocument.Save();

                    // object missing = System.Reflection.Missing.Value;
                    // Create application
                    //                    Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    //                    //Create a new document
                    //                    Word.Document document = app.Documents.Add(transTemplate, ref missing, ref missing, ref missing);

                    //                    string studentName = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "studentName");
                    //                    // Table, Row, Column index all start at 1
                    //                    document.Tables[1].Cell(1, 2).Range.Text = studentName;

                    //                    string startDate = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "startDate");
                    //                    startDate = DateTime.Parse(startDate,ci).ToString("MM/yyyy");
                    //                    document.Tables[1].Cell(1, 6).Range.Text = startDate;

                    //                    string studentDegree = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "degreeName");
                    //                    document.Tables[1].Cell(2, 2).Range.Text = studentDegree;

                    //                    int currentTermID = -1;
                    //                    int currentRow = 2;  // Starts at 1; first row is the title row
                    //                    foreach (DataRow transDR in transcriptDT.Rows)
                    //                    {
                    //                        // Get information about current term
                    //                        int termID = Int32.Parse(dataHelper.getColumnValueinDR(transDR, "term"));
                    //                        List<string> tTermsColNames = new List<string> { "term", "termName", "startYear","startMonth","endYear", "endMonth" };
                    //                        Dictionary<string, string> tTermsColValues = TranscriptHelper.GetPkRowColumnValues(
                    //                                TableName.terms, termID, tTermsColNames, ref sbErrors);
                    //                        string term = tTermsColValues["term"];
                    //                        if (termID != currentTermID)
                    //                        {
                    //                            string termName = tTermsColValues["termName"];
                    //                            string startYear = tTermsColValues["startYear"];
                    //                            // string startMonth = tTermsColValues["startMonth"];
                    //                            string endYear = tTermsColValues["endYear"];
                    //                            // string endMonth = tTermsColValues["endMonth"];
                    //                            // string termStartDate = startMonth + "/" + startYear;
                    //                            // string termEndDate = endMonth + "/" + endYear;

                    //                            DateTime dt = new DateTime(Int32.Parse(startYear), Int32.Parse(startYear), 1);
                    //                            string termDate = startYear;
                    //                            if (startYear != endYear)
                    //                            {
                    //                                termDate = string.Format("{0} - {1}", startYear, endYear);
                    //                            }
                    //                            termDate = termDate + "年 ";
                    //                            document.Tables[2].Cell(currentRow, 1).Range.Text = term;
                    //                            document.Tables[2].Cell(currentRow, 3).Range.Text = termDate + termName;
                    ////                            document.Tables[2].Cell(currentRow, 4).Range.Text = termName;
                    //                            document.Tables[2].Rows.Add();
                    //                            currentRow = currentRow + 1;
                    //                            currentTermID = termID;
                    //                        }
                    //                        string courseName = dataHelper.getColumnValueinDR(transDR, "courseName");
                    //                        string facultyName = dataHelper.getColumnValueinDR(transDR, "facultyName");
                    //                        string department = dataHelper.getColumnValueinDR(transDR, "depName");

                    //                        document.Tables[2].Cell(currentRow, 1).Range.Text = term;
                    //                        document.Tables[2].Cell(currentRow, 2).Range.Text = department;
                    //                        document.Tables[2].Cell(currentRow, 3).Range.Text = courseName;
                    //                        document.Tables[2].Cell(currentRow, 4).Range.Text = facultyName;
                    //                        document.Tables[2].Rows.Add();
                    //                        currentRow = currentRow + 1;
                    //                    }
                    //                    app.Visible = true;
                }
            }
        }
    }
}

