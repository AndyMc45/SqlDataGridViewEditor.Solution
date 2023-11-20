using InfoBox;
using System.Data;



namespace SqlDataGridViewEditor.TranscriptPlugin
{
    public partial class frmTranscriptOptions : Form
    {
        public frmTranscriptOptions()
        {
            InitializeComponent();
            // Execute the loading
        }

        public void SetPathLabel(string keyValue, Label label)
        {
            if (keyValue != string.Empty)
            {
                label.Text = keyValue;
            }
        }
        private void frmTranscriptOptions_Load(object sender, EventArgs e)
        {
            // Load options
            SetPathLabel(AppData.GetKeyValue("templateFolder"), lblPathTemplateFolder);
            SetPathLabel(AppData.GetKeyValue("TranscriptTemplate"), lblPathTemplate);

            toolStripBtnNarrow.Enabled = false;  // Viewing options
            if (myJob == Job.options)
            {
                // Nothing to do yet - can
            }
            else if (myJob == Job.printTranscript)
            {
                // Fill studentDegree dgv
                fillStudentDegreeDataRow();
                // Fill transcripts dgv
                fillTranscriptTable();
                //Fill frmOptions - Requirements DataGridView with Student Grad requirements table
                fillGradRequirementsDT();
                if (errorMsgs.Count > 0)
                {
                    InformationBox.Show(String.Join(Environment.NewLine, Environment.NewLine), "Warnings", InformationBoxIcon.Warning);
                }
            }
        }

        #region variables
        // main variable
        internal Job myJob { get; set; }   // Must be loaded to do anything
        public int studentDegreeID { get; set; }
        public List<string> errorMsgs = new List<string>();

        // There are 3 dgv's and 3 sql's in three different tabs
        public System.Data.DataTable studentDegreeInfoDT { get; set; } // No editing - 1 data row only for this studentDegree 
        private SqlFactory sqlStudentDegrees { get; set; }

        public System.Data.DataTable transcriptDT { get; set; }  // No editing. Transcripts filtered on this studentDegree
        private SqlFactory sqlTranscript { get; set; }
        // StudentReqDT is created from scrath - but added to data dataHelper.fieldDT
        // This allows us to format the dgv with sqlStudentReq

        public System.Data.DataTable studentReqDT { get; set; } // No editing.  
        private SqlFactory sqlStudentReq { get; set; }

        // Following two set to the dgv and sql that are showing in the options tab
        private DataGridView dgvCurrentlyViewing { get; set; }
        private SqlFactory sqlCurrentlyViewing { get; set; }

        #endregion

        private void fillStudentDegreeDataRow() // Also sets studentDegreeID if not set
        {
            studentDegreeInfoDT = TranscriptHelper.GetOneRowDataTable(TableName.studentDegrees, studentDegreeID, ref errorMsgs);
            if (studentDegreeInfoDT != null)
            {
                // Add a QPA datacolumn
                DataColumn dc = new DataColumn("QPA", typeof(decimal));
                studentDegreeInfoDT.Columns.Add(dc);
                dgvStudent.DataSource = studentDegreeInfoDT;
                sqlStudentDegrees = new SqlFactory(TableName.studentDegrees, 0, 0);  // Only needed to allow following
                dgvHelper.SetHeaderColorsOnWritePage(dgvStudent, sqlStudentDegrees.myTable, sqlStudentDegrees.myFields);
                dgvHelper.SetNewColumnWidths(dgvStudent, sqlStudentDegrees.myFields, true);
            }

        }

        private void fillTranscriptTable()
        {
            if (studentDegreeInfoDT != null)  // Trust all is O.K. if studentDegreesDataRow is set
            {
                // 0, 0 means no paging - false means don't include all columns of all foreign keys - would be 89 if we did
                sqlTranscript = new SqlFactory(TableName.transcript, 0, 0, false);
                field fkStudentDegreeID =
                    dataHelper.getForeignKeyFromRefTableName(TableName.transcript, TableName.studentDegrees);
                where wh = new where(fkStudentDegreeID, studentDegreeID.ToString());
                sqlTranscript.myWheres.Add(wh);
                string sqlString = sqlTranscript.returnSql(command.selectAll);
                transcriptDT = new System.Data.DataTable();
                // I fill the transcript table into a datatable, and show it in the "transcript" tab
                string strError = MsSql.FillDataTable(transcriptDT, sqlString);
                if (strError != string.Empty)
                {
                    errorMsgs.Add("ERROR filling transcript table: " + strError);
                }
                else
                {
                    dgvTranscript.DataSource = transcriptDT;
                    dgvHelper.SetHeaderColorsOnWritePage(dgvTranscript, sqlTranscript.myTable, sqlTranscript.myFields);
                    dgvHelper.SetNewColumnWidths(dgvTranscript, sqlTranscript.myFields, true);
                }
            }
        }

        private void fillGradRequirementsDT()
        {
            // 1. Create a table "StudentReq" - this table is not in the database.
            // Add this table to dataHelper.fieldsDT so that I can use an sqlFactory to style the table 
            // Add rows to dataHelper.fieldsDT. Only do it once in a session
            string filter = "TableName = 'StudentReq'";
            DataRow[] drs = dataHelper.fieldsDT.Select(filter);
            // If no rows in above, the rows have already been added to dataHelper.fieldsDT
            if (drs.Count() == 0)
            {
                dataHelper.AddRowToFieldsDT("StudentReq", 1, "StudentReqID", "StudentReqID", "int", false, true, true, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
                // GradRequirement Table -  includes requirementNameID, degreeID, handbookID
                dataHelper.AddRowToFieldsDT("StudentReq", 8, "Required", "Required", "real", false, false, false, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 9, "Limit", "Limit", "real", false, false, false, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
                //RequirementName table - includes reqTypeID
                dataHelper.AddRowToFieldsDT("StudentReq", 5, "ReqNameDK", "ReqNameDK", "nvarchar", false, false, false, false, true, 200, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 6, "ReqName", "ReqName", "nvarchar", false, false, false, false, true, 200, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 7, "eReqName", "eReqName", "nvarchar", false, false, false, false, true, 200, String.Empty, String.Empty, String.Empty, 0);
                //RequirementType table -
                dataHelper.AddRowToFieldsDT("StudentReq", 2, "ReqTypeDK", "ReqTypeDK", "nvarchar", false, false, false, false, false, 200, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 3, "ReqType", "ReqType", "nvarchar", false, false, false, false, false, 200, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 4, "eReqType", "eReqType", "nvarchar", false, false, false, false, false, 200, String.Empty, String.Empty, String.Empty, 0);
                // Need to calucate the following from transcript
                dataHelper.AddRowToFieldsDT("StudentReq", 10, "Earned", "Earned", "real", false, false, false, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 11, "Needed", "Needed", "real", false, false, false, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 12, "InProgress", "InProgress", "real", false, false, false, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
                dataHelper.AddRowToFieldsDT("StudentReq", 13, "Icredits", "Icredits", "real", false, false, false, false, false, 4, String.Empty, String.Empty, String.Empty, 0);
            }

            // 2. Get Grad Requirements for this degree and handbook
            int intHandbookID = Int32.Parse(dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "handbookID"));
            int intDegreeID = Int32.Parse(dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "degreeID"));
            SqlFactory sqlGradReq = new SqlFactory(TableName.gradRequirements, 0, 0);
            where wh1 = new where(TableField.GradRequirements_DegreeID, intDegreeID.ToString());
            where wh2 = new where(TableField.GradRequirements_handbookID, intHandbookID.ToString());
            sqlGradReq.myWheres.Add(wh1);
            sqlGradReq.myWheres.Add(wh2);
            string sqlString = sqlGradReq.returnSql(command.selectAll);
            // Put degree requirements in a new DataTable grDaDt.dt
            MsSqlWithDaDt grDaDt = new MsSqlWithDaDt(sqlString);

            // 3. Put all the basic information about this degree, degreeLevel, degreeDeliveryMethod into 3 dictionaries.
            // Degree - "degreeName", "deliveryMethodID", "eDegreeName", "degreeLevelID"
            List<string> sDegreeColNames = new List<string> { "degreeName", "deliveryMethodID", "eDegreeName", "degreeLevelID" };
            Dictionary<string, string> sDegreeColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.degrees, intDegreeID, sDegreeColNames, ref errorMsgs);

            // degreeLevel - "degreeLevelName", "degreeLevel"
            int sDegreeLevelID = Int32.Parse(sDegreeColValues["degreeLevelID"]);
            List<string> sDegreeLevelColNames = new List<string> { "degreeLevelName", "degreeLevel" };
            Dictionary<string, string> sDegreeLevelColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.degreeLevel, sDegreeLevelID, sDegreeLevelColNames, ref errorMsgs);
            int sDegreeLevel = Int32.Parse(sDegreeLevelColValues["degreeLevel"]);
            string sDegreeLevelName = sDegreeLevelColValues["degreeLevelName"];


            // DeliveryMethod - "deliveryMethodName", "eDeliveryMethodName", "deliveryLevel"
            int intDeliveryMethodID = Int32.Parse(dataHelper.getColumnValueinDR(studentDegreeInfoDT.Rows[0], "deliveryMethodID"));
            List<string> sDeliveryMethodColNames = new List<string> { "delMethName", "eDelMethName", "deliveryLevel" };
            Dictionary<string, string> sDeliveryMethodColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.deliveryMethod, intDeliveryMethodID, sDeliveryMethodColNames, ref errorMsgs);

            // 4. Create sqlFactory for studentReq - this will give you sqlStudentReq.myFields()
            sqlStudentReq = new SqlFactory("StudentReq", 0, 0);

            // 5. Create studentReqDT and add a column for each field.
            //    We will add a row to this table for each requirement and fill it. 
            studentReqDT = new System.Data.DataTable();
            foreach (field f in sqlStudentReq.myFields)
            {
                DataColumn dc = new DataColumn(f.fieldName, dataHelper.ConvertDbTypeToType(f.dbType));
                // Make StudentReqID the primary key
                if (f.fieldName == "StudentReqID")
                {
                    dc.AutoIncrement = true;
                    dc.AutoIncrementSeed = 1;
                    dc.AutoIncrementStep = 1;
                }
                studentReqDT.Columns.Add(dc);
            }

            // 6. Main routine: Fill studentReqDT 
            foreach (DataRow drGradReq in grDaDt.dt.Rows)
            {
                //6a. Get information we need from drGradReq.
                Decimal creditLimit = Decimal.Parse(dataHelper.getColumnValueinDR(drGradReq, "creditLimit"));
                Decimal reqCredits = Decimal.Parse(dataHelper.getColumnValueinDR(drGradReq, "reqUnits"));
                int requirementNameID = Int32.Parse(dataHelper.getColumnValueinDR(drGradReq, "requirementNameID"));

                //6b. Get information from requirmentName Table
                List<string> ReqTableColNames = new List<string> { "reqTypeID", "reqNameDK", "reqName", "eReqName" };
                Dictionary<string, string> ReqTableColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.requirementName, requirementNameID, ReqTableColNames, ref errorMsgs);

                //6c. Get information from requirementType table
                int intReqTypeID = Int32.Parse(ReqTableColValues["reqTypeID"]);
                List<string> ReqTypeColNames = new List<string> { "reqTypeDK", "reqType", "eReqType" };
                Dictionary<string, string> ReqTypeColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.requirementType, intReqTypeID, ReqTypeColNames, ref errorMsgs);


                //6d. Add a row to studentReqDT for this drGradReq, and fill it
                //   (Except for credits earned / inProgress / needed, we have all that we need to fill this row )

                DataRow dr = studentReqDT.NewRow();
                // List of columns:  "StudentReqID", "Required", "Limit", "ReqNameDK", "ReqName", "eReqName"
                // . . . "ReqTypeDK", "ReqType", "eReqType", "Earned", "InProgress", "Needed"
                // "StudentReqID" is the Primary key and column set to autoincrement.
                dataHelper.setColumnValueInDR(dr, "Required", reqCredits);
                dataHelper.setColumnValueInDR(dr, "Limit", creditLimit);
                dataHelper.setColumnValueInDR(dr, "ReqNameDK", ReqTableColValues["reqNameDK"]);
                dataHelper.setColumnValueInDR(dr, "ReqName", ReqTableColValues["reqName"]);
                dataHelper.setColumnValueInDR(dr, "eReqName", ReqTableColValues["eReqName"]);
                dataHelper.setColumnValueInDR(dr, "ReqTypeDK", ReqTypeColValues["reqTypeDK"]);
                dataHelper.setColumnValueInDR(dr, "ReqType", ReqTypeColValues["reqType"]);
                dataHelper.setColumnValueInDR(dr, "eReqType", ReqTypeColValues["eReqType"]);
                dataHelper.setColumnValueInDR(dr, "Earned", 0);
                dataHelper.setColumnValueInDR(dr, "InProgress", 0);
                dataHelper.setColumnValueInDR(dr, "Needed", 0);
                dataHelper.setColumnValueInDR(dr, "Icredits", 0);

                // Finally
                studentReqDT.Rows.Add(dr);
            }

            // 7. Loop through the transcripts and for each course loop through studentReqDT updating "earned"and "InProgress"
            //    Also keep track of QPA credits and QPA pointsEarned
            //    At end, fill in the "Needed" and record QPA
            decimal qpaCredits = 0;
            decimal qpaPoints = 0;
            foreach (DataRow drTrans in transcriptDT.Rows)
            {
                // Get all required information - add "c" before variable for "course"
                // Information from transcript datarow - "GradeID","gradeStatusID", "deliveryMethodID", "CourseTermID"
                int cGradeID = Int32.Parse(dataHelper.getColumnValueinDR(drTrans, "gradeID"));
                int cGradeStatusID = Int32.Parse(dataHelper.getColumnValueinDR(drTrans, "gradeStatusID"));
                int cDeliveryMethodID = Int32.Parse(dataHelper.getColumnValueinDR(drTrans, "deliveryMethodID"));
                int cCourseTermID = Int32.Parse(dataHelper.getColumnValueinDR(drTrans, "courseTermID"));

                // Grades - "grade", "QP", "earnedCredits" "creditsInQPA"
                List<string> cGradesColNames = new List<string> { "grade", "QP", "earnedCredits", "creditsInQPA" };
                Dictionary<string, string> cGradesColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.grades, cGradeID, cGradesColNames, ref errorMsgs);
                Decimal cGradeQP = Decimal.Parse(cGradesColValues["QP"]);
                Boolean cEarnedCredits = Boolean.Parse(cGradesColValues["earnedCredits"]);
                Boolean cCreditsInQPA = Boolean.Parse(cGradesColValues["creditsInQPA"]);
                string cGrade = cGradesColValues["grade"];

                // GradeStatus - "statusKey", "statusName", "eStatusName"
                List<string> cGradeStatusColNames = new List<string> { "statusKey", "statusName", "eStatusName" };
                Dictionary<string, string> cGradesStatusColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.gradeStatus, cGradeStatusID, cGradeStatusColNames, ref errorMsgs);
                string cStatusKey = cGradesStatusColValues["statusKey"];

                // deliveryMethod - "delMethName", "eDelMethName", "deliveryLevel"
                List<string> cDelMethColNames = new List<string> { "delMethDK", "delMethName", "eDelMethName", "deliveryLevel" };
                Dictionary<string, string> cDelMethColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.deliveryMethod, cDeliveryMethodID, cDelMethColNames, ref errorMsgs);

                // CourseTerms - "courseID", "credits"
                List<string> cCourseTermColNames = new List<string> { "courseID", "credits" };
                Dictionary<string, string> cCourseTermColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.courseTerms, cCourseTermID, cCourseTermColNames, ref errorMsgs);
                Decimal cCredits = Decimal.Parse(cCourseTermColValues["credits"]);

                // Course - "requirementNameID", "degreeLevelID", "repeatsPermitted"
                int cCourseID = Int32.Parse(cCourseTermColValues["courseID"]);
                List<string> CourseColNames = new List<string> { "courseName", "requirementNameID", "degreeLevelID", "repeatsPermitted" };
                Dictionary<string, string> cCourseColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.courses, cCourseID, CourseColNames, ref errorMsgs);
                string cCourseName = cCourseColValues["courseName"];

                // Requirements - "reqNameDK", "reqName", "eReqName"
                int cReqID = Int32.Parse(cCourseColValues["requirementNameID"]);
                List<string> cReqColNames = new List<string> { "reqNameDK", "reqName", "eReqName", "Ancestors" };
                Dictionary<string, string> cReqColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.requirementName, cReqID, cReqColNames, ref errorMsgs);
                string cReqNameDK = cReqColValues["reqNameDK"];
                string cAncestors = cReqColValues["Ancestors"];

                // DegreeLevel - "degreeLevelName", "degreeLevel"
                int cDegLevelID = Int32.Parse(cCourseColValues["degreeLevelID"]);
                List<string> cDegreeLevelColNames = new List<string> { "degreeLevelName", "degreeLevel" };
                Dictionary<string, string> cDegreeLevelColValues = TranscriptHelper.GetPkRowColumnValues(
                    TableName.degreeLevel, cDegLevelID, cDegreeLevelColNames, ref errorMsgs);

                // Update relevant rows in studentReqDT
                // First check that the row is forCredit and that the degreeLevel is correct
                if (cStatusKey == "forCredit")  // Ignore all others - error check that this key is in Database
                {
                    int cDegreeLevel = Int32.Parse(cDegreeLevelColValues["degreeLevel"]);
                    if (cDegreeLevel < sDegreeLevel)
                    {
                        string cDegreeLevelName = cDegreeLevelColValues["degreeLevelName"];
                        errorMsgs.Add(String.Format("Degree level of '{0} ({1})' is lower than student degree level ({2}). No credit granted.",
                                    cCourseName, cDegreeLevelName, sDegreeLevelName));
                    }
                    else
                    {
                        // Loop through the rows in studentReqDT
                        foreach (DataRow studentReqDR in studentReqDT.Rows)
                        {
                            // Check if this drTrans dataRow meets this requirement - 
                            string srReqNameDK = dataHelper.getColumnValueinDR(studentReqDR, "ReqNameDK");
                            List<string> cAncestorsList = cAncestors.Split(",").ToList();
                            if (srReqNameDK == cReqNameDK || cAncestorsList.Contains(srReqNameDK))
                            {
                                string srReqTypeDK = dataHelper.getColumnValueinDR(studentReqDR, "ReqTypeDK");
                                if (srReqTypeDK != "credits" || srReqTypeDK != "hours" || srReqTypeDK != "times")
                                {
                                    if (cEarnedCredits)
                                    {
                                        Decimal earned = Decimal.Parse(dataHelper.getColumnValueinDR(studentReqDR, "Earned"));
                                        earned = earned + cCredits;
                                        dataHelper.setColumnValueInDR(studentReqDR, "Earned", earned);
                                    }
                                    else if (cGrade == "NG")
                                    {
                                        Decimal inProgress = Decimal.Parse(dataHelper.getColumnValueinDR(studentReqDR, "InProgress"));
                                        inProgress = inProgress + cCredits;
                                        dataHelper.setColumnValueInDR(studentReqDR, "InProgress", inProgress);
                                    }
                                }
                            }
                        }
                        // Update QPAcredits and QPApoints
                        if (cCreditsInQPA)
                        {
                            qpaPoints = qpaPoints + (cCredits * cGradeQP);
                            qpaCredits = qpaCredits + cCredits;
                        }
                    }
                }
                else if (cEarnedCredits)
                {
                    // cStatusKey is not "forCredit" but the grade indicates student has earned credit
                    string strWarn = String.Format("{0} has a grade but its statusKey is {1}. ", cCourseName, cStatusKey);
                    errorMsgs.Add(strWarn);
                }
            }
            // Set needed
            foreach (DataRow dr in studentReqDT.Rows)
            {
                Decimal required = Decimal.Parse(dataHelper.getColumnValueinDR(dr, "Required"));
                Decimal earned = Decimal.Parse(dataHelper.getColumnValueinDR(dr, "Earned"));
                Decimal needed = Math.Max(0, required - earned);
                dataHelper.setColumnValueInDR(dr, "Needed", needed);
            }
            // Set QPA
            Decimal QPA = 0;
            if (qpaCredits != 0)
            {
                QPA = Math.Round(qpaPoints / qpaCredits, 2);
            }
            dgvStudent[dgvStudent.Columns.Count - 1, 0].Value = QPA.ToString();

            // Load dgv
            dgvRequirements.DataSource = studentReqDT;
            dgvHelper.SetHeaderColorsOnWritePage(dgvRequirements, sqlStudentReq.myTable, sqlStudentReq.myFields);
            dgvHelper.SetNewColumnWidths(dgvRequirements, sqlStudentReq.myFields, true);
        }

        private void toolStripBtnNarrow_Click(object sender, EventArgs e)
        {
            if (sqlCurrentlyViewing != null)
            {
                if (toolStripBtnNarrow.Tag == "narrow")
                {
                    dgvHelper.SetNewColumnWidths(dgvCurrentlyViewing, sqlCurrentlyViewing.myFields, true);
                    toolStripBtnNarrow.Tag = "wide";
                    toolStripBtnNarrow.Text = "Wide";

                }
                else
                {
                    dgvHelper.SetNewColumnWidths(dgvCurrentlyViewing, sqlCurrentlyViewing.myFields, false);
                    toolStripBtnNarrow.Tag = "narrow";
                    toolStripBtnNarrow.Text = "Narrow";
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabOptions)
            {
                toolStripBtnNarrow.Enabled = false;
                btnPrintTranscript.Enabled = true;  // Testing
//                btnPrintTranscript.Enabled = true;
            }
            else if (tabControl1.SelectedTab == tabStudent)
            {
                if (sqlStudentDegrees == null)
                {
                    toolStripBtnNarrow.Enabled = false;
                }
                else
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvStudent;
                    sqlCurrentlyViewing = sqlStudentDegrees;
                }
            }
            else if (tabControl1.SelectedTab == tabTranscript)
            {
                if (sqlTranscript == null)
                {
                    toolStripBtnNarrow.Enabled = false;
                }
                else
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvTranscript;
                    sqlCurrentlyViewing = sqlTranscript;
                }
            }
            else if (tabControl1.SelectedTab == tabRequirements)
            {
                if (sqlStudentReq == null)
                {
                    toolStripBtnNarrow.Enabled = false;
                }
                else
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvRequirements;
                    sqlCurrentlyViewing = sqlStudentReq;
                }
            }
            else
            {
                toolStripBtnNarrow.Enabled = false;
                dgvCurrentlyViewing = null;
                sqlCurrentlyViewing = null;

            }
        }

        private void btnPrintTranscript_Click(object sender, EventArgs e)
        {
            printTranscript();
        }


        private void lblTemplateFolder_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string fbdPath = folderBrowserDialog1.SelectedPath;
            if (result == DialogResult.Cancel) { return; }
            lblPathTemplateFolder.Text = fbdPath;
            AppData.SaveKeyValue("TemplateFolder", fbdPath);

        }

        private void lblTranscriptTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            string templateFolder = AppData.GetKeyValue("TemplateFolder");
            if(templateFolder != null && Directory.Exists(templateFolder)) 
            {
                openFileDialog1.InitialDirectory = templateFolder;
            }
            openFileDialog1.Filter = "dot files(*.dot)|*.dot|dotx files(*.dotx)|*.dotx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                lblPathTemplate.Text = filePath;
                AppData.SaveKeyValue("TranscriptTemplate", filePath);
            }


        }

        internal enum Job
        {
            options,
            printTranscript,
            printClassRole
        }


    }
}
