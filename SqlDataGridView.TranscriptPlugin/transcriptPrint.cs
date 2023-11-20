// using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace SqlDataGridViewEditor.TranscriptPlugin
{
    public partial class frmTranscriptOptions : Form
    {
        internal void printTranscript()
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
                    document.Tables[1].Cell(2,2).Range.Text = studentName;
                    app.Visible = true;

                }
            }
        }
    }
}
//Parameters for Document.Add
//Template
//Object
//Optional Object. The name of the template to be used for the new document.If this argument is omitted, the Normal template is used.
//NewTemplate
//Object
//Optional Object. True to open the document as a template. The default value is False.
//DocumentType
//Object
//Optional Object. Can be one of the following WdNewDocumentType constants: wdNewBlankDocument, wdNewEmailMessage, wdNewFrameset, or wdNewWebPage. The default constant is wdNewBlankDocument.
//Visible
//Object
//Optional Object. True to open the document in a visible window.If this value is False, Microsoft Word opens the document but sets the Visible property of the document window to False. The default value is True.