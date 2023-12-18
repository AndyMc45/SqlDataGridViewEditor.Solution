using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using InfoBox;

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

        private static void InsertTextInTable(Table table, int intRow, int intCell, string text)
        {
            // Find the third cell in the row.
            TableRow row = table.Elements<TableRow>().ElementAt(intRow); 
            TableCell cell = row.Elements<TableCell>().ElementAt(intCell);
            // Find the first paragraph in the table cell.
            if (cell.Elements<Paragraph>().Count() == 0)
            { 
                Paragraph newPara = new Paragraph();
                cell.AddChild(newPara);
            }
            Paragraph p = cell.Elements<Paragraph>().First();
            // Find the first run in the paragraph.
            if(p.Elements<Run>().Count() == 0 ) 
            {
                Run run = new Run();
                p.AddChild(run);
            }
            Run r = p.Elements<Run>().First();
            if (r.Elements<Text>().Count() == 0)
            { 
                Text eText = new Text();
                r.AddChild(eText);
            }
            // Set the text for the run.
            Text t = r.Elements<Text>().First();
            t.Text = text;
        }
        public static void printTranscript(CultureInfo ci, ref StringBuilder sbErrors)
        {
            string transTemplate = AppData.GetKeyValue("TranscriptTemplate");
            if (File.Exists(transTemplate))
            {
                if (studentDegreeInfoDT != null && studentDegreeInfoDT.Rows.Count == 1)
                {
                    string studentName = string.Empty;  // Useed in file natme
                    // Write file to byteArray and read it into a memory stream
                    byte[] byteArray = File.ReadAllBytes(transTemplate);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        stream.Write(byteArray, 0, (int)byteArray.Length);
                        // Get the wordDoc and fill the tables
                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
                        {
                            // Assign a reference to the existing document body.
                            MainDocumentPart myMainDocumentPart = wordDoc.MainDocumentPart ?? wordDoc.AddMainDocumentPart();
                            Body wordDocBody = myMainDocumentPart.Document.Body;

                            // Find the first table in the document.
                            Table table = wordDocBody.Elements<Table>().First();
                            studentName = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "studentName");
                            InsertTextInTable(table, 0, 1, studentName);
                            string studentDegree = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "degreeName");
                            InsertTextInTable(table, 1, 1, studentDegree);
                            string strCreditsEarned = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "creditsEarned");
                            InsertTextInTable(table, 0, 3, strCreditsEarned);
                            string strQPA = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "QPA");
                            InsertTextInTable(table, 1, 3, strQPA);
                            string startDate = dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "startDate");
                            startDate = DateTime.Parse(startDate).ToString("MM - yyyy");
                            InsertTextInTable(table, 0, 5, startDate);

                            // Find second table and fill it
                            table = wordDocBody.Elements<Table>().ElementAt(1);
                            int currentTermID = -1;
                            int currentRow = 1;  // Starts at 1; first row is the title row
                            foreach (DataRow transDR in transcriptDT.Rows)
                            {
                                // Get information about current term
                                int termID = Int32.Parse(dataHelper.getColumnValueinDR(transDR, "termID"));
                                List<string> tTermsColNames = new List<string> { "term", "termName", "startYear", "startMonth", "endYear", "endMonth" };
                                Dictionary<string, string> tTermsColValues = TranscriptHelper.GetPkRowColumnValues(
                                        TableName.terms, termID, tTermsColNames, ref sbErrors);
                                string term = tTermsColValues["term"];
                                if (termID != currentTermID)
                                {
                                    string termName = tTermsColValues["termName"];
                                    string startYear = tTermsColValues["startYear"];
                                    string endYear = tTermsColValues["endYear"];
                                    string termDate = startYear;
                                    if (startYear != endYear)
                                    {
                                        termDate = string.Format("{0} - {1}", startYear, endYear);
                                    }
                                    termDate = termDate + "年 ";
                                    InsertTextInTable(table, currentRow, 2, termDate + termName);
                                    // Prepare for next row    
                                    TableRow newTermRow = new TableRow();
                                    for (int i = 0; i < table.Elements<TableRow>().First().Elements<TableCell>().Count(); i++)
                                    {
                                        TableCell newCell = new TableCell(new Paragraph(new Run(new Text(string.Empty))));
                                        newTermRow.Append(newCell);
                                    }
                                    table.Append(newTermRow);
                                    currentRow = currentRow + 1;
                                    currentTermID = termID;
                                }
                                string courseName = dataHelper.getColumnValueinDR(transDR, "courseName");
                                string facultyName = dataHelper.getColumnValueinDR(transDR, "facultyName");
                                string department = dataHelper.getColumnValueinDR(transDR, "depName");
                                string credits = dataHelper.getColumnValueinDR(transDR, "credits");
                                string grade = dataHelper.getColumnValueinDR(transDR, "grade");
                                string reqNameDK = dataHelper.getColumnValueinDR(transDR, "reqNameDK");
                                // Round off the credits
                                decimal dCredits = Decimal.Parse(credits);
                                dCredits = Decimal.Round(dCredits, 2);
                                credits = dCredits.ToString();

                                InsertTextInTable(table, currentRow, 0, term);
                                InsertTextInTable(table, currentRow, 1, department);
                                InsertTextInTable(table, currentRow, 2, courseName);
                                InsertTextInTable(table, currentRow, 3, facultyName);
                                InsertTextInTable(table, currentRow, 4, credits);
                                InsertTextInTable(table, currentRow, 5, grade);
                                if(reqNameDK != department) 
                                { 
                                    InsertTextInTable(table, currentRow, 6, reqNameDK);
                                }

                                // Prepare for next row - clone this before adding information
                                TableRow newRow = new TableRow();
                                for (int i = 0; i < table.Elements<TableRow>().First().Elements<TableCell>().Count(); i++)
                                {
                                    TableCell newCell = new TableCell(new Paragraph(new Run(new Text(string.Empty))));
                                    newRow.Append(newCell);
                                }
                                table.Append(newRow);

                                currentRow = currentRow + 1;
                            }
                            // Find Requirment table and fill it
                            if (PrintToWord.studentReqDT != null)
                            {
                                currentRow = 1; // Skip first row
                                table = wordDocBody.Elements<Table>().ElementAt(2);
                                foreach (DataRow reqDR in PrintToWord.studentReqDT.Rows)
                                {
                                    string reqType = dataHelper.getColumnValueinDR(reqDR, "ReqType");
                                    string reqName = dataHelper.getColumnValueinDR(reqDR, "ReqName");
                                    string delMethName = dataHelper.getColumnValueinDR(reqDR, "DelMethName");
                                    string required = dataHelper.getColumnValueinDR(reqDR, "Required");
                                    string earned = dataHelper.getColumnValueinDR(reqDR, "Earned");
                                    string needed = dataHelper.getColumnValueinDR(reqDR, "Needed");
                                    string inProgress = dataHelper.getColumnValueinDR(reqDR, "InProgress");
                                    // Prepare for next row
                                    TableRow newTermRow = new TableRow();
                                    for (int i = 0; i < table.Elements<TableRow>().First().Elements<TableCell>().Count(); i++)
                                    {
                                        TableCell newCell = new TableCell(new Paragraph(new Run(new Text(string.Empty))));
                                        newTermRow.Append(newCell);
                                    }
                                    table.Append(newTermRow);
                                    // Write to 3rd table
                                    InsertTextInTable(table, currentRow, 0, reqType);
                                    InsertTextInTable(table, currentRow, 1, reqName);
                                    InsertTextInTable(table, currentRow, 2, delMethName);
                                    InsertTextInTable(table, currentRow, 3, required);
                                    InsertTextInTable(table, currentRow, 4, earned);
                                    InsertTextInTable(table, currentRow, 5, needed);
                                    InsertTextInTable(table, currentRow, 6, inProgress);
                                    currentRow = currentRow + 1;
                                }
                            }
                        }
                        // Save the stream to the disk
                        string myPath = AppData.GetKeyValue("DocumentFolder");
                        myPath = myPath + "\\" + studentName.Replace(" ","_") + "." + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + ".docx";
                        try
                        {
                            byte[] newByteArray = UseBinaryReader(stream);
                            File.WriteAllBytes(myPath, newByteArray);
                        }
                        catch (Exception ex){ InformationBox.Show(ex.Message);return; }

                        // Open microsoft word
                        InformationBoxResult infoResult = InformationBox.Show("Do you want to open the transcript in Word?",InformationBoxIcon.Question, InformationBoxButtons.YesNo);
                        if(infoResult == InformationBoxResult.Yes) 
                        {
                            Process process = new Process();
                            process.StartInfo = new ProcessStartInfo(myPath)
                            {
                                UseShellExecute = true
                            };
                            // process.StartInfo.Arguments = "-n";
                            // process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                            process.Start();
                            // process.WaitForExit();// Waits here for the process to exit.
                        }
                    }
                }
            }
        }
        public static byte[] UseBinaryReader(Stream stream)
        {
            byte[] bytes;
            stream.Position = 0;
            using (var binaryReader = new BinaryReader(stream))
            {
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }
            return bytes;
        }

    }
}

