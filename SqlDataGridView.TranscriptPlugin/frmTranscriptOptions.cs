using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDataGridViewEditor.TranscriptPlugin
{
    public partial class frmTranscriptOptions : Form
    {
        internal Job myJob { get; set; }   // Must be loaded to do anything

        public int studentDegreeID { get; set; }

        private DataGridView dgvCurrentlyViewing { get; set; }
        private SqlFactory sqlCurrentlyViewing { get; set; }


        public frmTranscriptOptions()
        {
            InitializeComponent();
            // Execute the loading
        }

        private void frmTranscriptOptions_Load(object sender, EventArgs e)
        {
            toolStripBtnNarrow.Enabled = false;  // Viewing options
            if(myJob == Job.options)
            {
                // Nothing to do yet - can
            }
            else if (myJob == Job.printTranscript)
            {
                // Get all the information about this student-degree
                fillStudentDegreeDataRow();

                // Fill main form dataGridView1 with the transcripts for this student
                // fillTranscriptTable();

                //Fill frmOptions - Requirements DataGridView with Student Grad requirements table
                // fillGradRequirementsDT();
            }
        }

        public DataTable studentDegreesDataTable { get; set; } // No editing - 1 data row only 
        // transscriptDT is a the transcript table filtered on this student-degree
        public DataTable transcriptDT { get; set; }  // No editing
        // gradRequirementsDT is gradRequirment table filtered on this student's degree and yearbook
        public DataTable gradRequirementsDT { get; set; } // No editing

        public List<string> errorMsgs { get; set; }

        private SqlFactory studentDegreesSql;

        private SqlFactory transcriptSql;

        private void fillStudentDegreeDataRow() // Also sets studentDegreeID if not set
        {
            studentDegreesSql = new SqlFactory(TableName.studentDegreesTable, 0, 0, false);
            field fld = dataHelper.getTablePrimaryKeyField(TableName.studentDegreesTable);
            where wh = new where(fld, studentDegreeID.ToString());
            studentDegreesSql.myWheres.Add(wh);
            // Get data row
            string sqlString = studentDegreesSql.returnSql(command.selectAll);
            studentDegreesDataTable = new DataTable();
            string strError = MsSql.FillDataTable(studentDegreesDataTable, sqlString);
            dgvStudent.DataSource = studentDegreesDataTable;
            dgvHelper.SetHeaderColorsOnWritePage(dgvStudent, studentDegreesSql.myTable, studentDegreesSql.myFields);
        }

        private void fillTranscriptTable()
        {
            if (studentDegreesDataTable != null)  // Trust all is O.K. if studentDegreesDataRow is set
            {
                // 0, 0 means no paging - false means don't include all columns of all foreign keys - would be 89 if we did
                SqlFactory transcriptSql = new SqlFactory(TableName.transcriptTable, 0, 0, false);
                field fkStudentDegreeID =
                    dataHelper.getForeignKeyFromRefTableName(TableName.transcriptTable, TableName.studentDegreesTable);
                where wh = new where(fkStudentDegreeID, studentDegreeID.ToString());
                transcriptSql.myWheres.Add(wh);
                string sqlString = transcriptSql.returnSql(command.selectAll);
                transcriptDT = new DataTable();
                // I fill the transcript table into a datatable, and show it in the "transcript" tab
                string strError = MsSql.FillDataTable(transcriptDT, sqlString);
                if (strError != string.Empty) { errorMsgs.Add("ERROR in fillTranscriptTable (Transcript.cs): " + strError); }
            }
        }

        private void fillGradRequirementsDT()
        {
            // I show the student's GradRequirements table in the frmOptions form
            frmTranscriptOptions fOptions = new frmTranscriptOptions();
            // I use a public delegate to load the gr table into fOptions, but it could be done directly.
            // Define the delegate - i.e. point the delegate to a function in the form

            if (studentDegreesDataTable != null)
            {
                Dictionary<int, List<int>> requirement_fullmap = new Dictionary<int, List<int>>();

                //1. Get old records for this student (put in sgrDaDt) -- added these last time we printed his/her transcript
                SqlFactory studentGradReqSql = new SqlFactory(TableName.studentGradReqTable, 0, 0);
                field fkSGR_StudentDegreeID = dataHelper.getForeignKeyFromRefTableName(TableName.studentGradReqTable, TableName.studentDegreesTable);
                where wh_Sgr_SdID = new where(fkSGR_StudentDegreeID, studentDegreeID.ToString());
                studentGradReqSql.myWheres.Add(wh_Sgr_SdID);
                string sqlString = studentGradReqSql.returnSql(command.selectAll);
                MsSqlWithDaDt sgrDaDt = new MsSqlWithDaDt(sqlString);
                string strError = sgrDaDt.errorMsg;
                if (strError != string.Empty) { errorMsgs.Add("ERROR in fillGradRequirementsDT (Transcript.cs): " + strError); }

                //2. Delete these old records from sgrDaDt / and push deletes down to studentGradReqTable
                MsSql.SetDeleteCommand(studentGradReqSql.myTable, sgrDaDt.da); // delete rows based on primary key
                MsSql.DeleteRowsFromDT(sgrDaDt.dt, wh_Sgr_SdID); //wh used to select rows to delete, and then deletes (based on pk of selected rows)

                //3. Get GradRequirements records for this student / degree / handbook (Place in gradRequirementDT - not edited)
                SqlFactory GradRequirementsSql = new SqlFactory(TableName.gradRequirementsTable, 0, 0);
                // Get DegreeID where value (from studentDegreesDataRow)
                field StuDegree_DegreeID = dataHelper.getForeignKeyFromRefTableName(TableName.studentDegreesTable, TableName.degreesTable);
                string myDegreeID = studentDegreesSql.getStringValueFromDataRowBasefield(studentDegreesDataTable.Rows[0], StuDegree_DegreeID);
                // Get DegreeID Where field in GradReq table
                field GradReq_DegreeID = dataHelper.getForeignKeyFromRefTableName(TableName.gradRequirementsTable, TableName.degreesTable);
                // Create and add the where (i.e. where GradReq.DegreeID = this student degreeID)
                where whDegreeID = new where(GradReq_DegreeID, myDegreeID);
                GradRequirementsSql.myWheres.Add(whDegreeID);

                // Get HandbookID where and add - same as above
                field fk_SD_HandbookID = dataHelper.getForeignKeyFromRefTableName(TableName.studentDegreesTable, TableName.handbooksTable);
                string myHandbookID = studentDegreesSql.getStringValueFromDataRowBasefield(studentDegreesDataTable.Rows[0], fk_SD_HandbookID);
                field fkHandbookID = dataHelper.getForeignKeyFromRefTableName(TableName.gradRequirementsTable, TableName.handbooksTable);
                where whHandbookID = new where(fkHandbookID, myHandbookID);
                GradRequirementsSql.myWheres.Add(whHandbookID);

                // Get rows in GradRequirement table filtered by above two wheres - and fill gradRequiremensDT with these rows
                string sqlString2 = GradRequirementsSql.returnSql(command.selectAll);
                gradRequirementsDT = new DataTable();
                string errorMsg2 = MsSql.FillDataTable(gradRequirementsDT, sqlString2);
                if (errorMsg2 != string.Empty) { errorMsgs.Add("ERROR in fillGradRequirements 2 (Transcript.cs): " + errorMsg2); }

                //4a. Insert a corresponding row in studentGradReq - NOTE: studentGradReq was emptied above, now replacing these rows 
                field fk_studgradReq_gradReqID = dataHelper.getForeignKeyFromRefTableName(TableName.studentGradReqTable, TableName.gradRequirementsTable);
                field pkGradReqTable = dataHelper.getTablePrimaryKeyField(TableName.gradRequirementsTable);

                foreach (DataRow dr in gradRequirementsDT.Rows)  // Rows in GradRequirement Table
                {
                    List<where> whList = new List<where>();
                    whList.Add(wh_Sgr_SdID); // Defined above
                    string pkGradReqTable_value = GradRequirementsSql.getStringValueFromDataRowBasefield(dr, pkGradReqTable); // Get GradRequirement ID
                    where wh_GradReqID = new where(fk_studgradReq_gradReqID, pkGradReqTable_value);  // Used to insert into studGradReq table
                    whList.Add(wh_GradReqID);
                    // Insert row into studentGradReqTable with only StudentDegreeID and gradReqID foreign key filled
                    MsSql.SetInsertCommand(TableName.studentGradReqTable, whList, sgrDaDt.da);
                    sgrDaDt.da.InsertCommand.ExecuteNonQuery();
                }
                // 4b. Reload sgrDaDt into memory with new values from studentGradReq table - i.e. the rows inserted in 4a
                studentGradReqSql.myWheres.Clear();
                studentGradReqSql.myWheres.Add(wh_Sgr_SdID);
                sqlString = studentGradReqSql.returnSql(command.selectAll);
                sgrDaDt.dt = new DataTable();
                strError = MsSql.FillDataTable(sgrDaDt.dt, sqlString);
                if (strError != string.Empty) { errorMsgs.Add("ERROR in fillGradRequirementsDT (Transcript.cs): " + strError); }

                //5a.  Set update command on extraDA - (Note: still using sgrDaDt.dt and da - now with rows that have only stuDegreeID and gradReqID  .)
                List<field> updateFields = new List<field>();
                updateFields.Add(TranscriptField.SGRT_crReq);
                updateFields.Add(TranscriptField.SGRT_crEarned);
                updateFields.Add(TranscriptField.SGRT_crInProgress);
                updateFields.Add(TranscriptField.SGRT_crLimit);
                updateFields.Add(TranscriptField.SGRT_crUnused);
                updateFields.Add(TranscriptField.SGRT_crEqDmReq);
                updateFields.Add(TranscriptField.SGRT_crEqDmErnd);
                updateFields.Add(TranscriptField.SGRT_crEqDmInPro);
                updateFields.Add(TranscriptField.SGRT_QP_total);
                updateFields.Add(TranscriptField.SGRT_QP_credits);
                updateFields.Add(TranscriptField.SGRT_QP_average);
                MsSql.SetUpdateCommand(updateFields, sgrDaDt.dt);

                //5c. Fill rows of sgrDaDt.dt (studentGradReqTable for this student) from the rows in transcriptDT
                field pkTranscripts = dataHelper.getTablePrimaryKeyField(TableName.transcriptTable);
                foreach (DataRow transDR in transcriptDT.Rows)
                {
                    // 0. Primary key - for use in noting errors
                    int pkThisTransDR = Int32.Parse(transcriptSql.getStringValueFromDataRowBasefield(transDR, pkTranscripts, TableName.transcriptTable));
                    // 1. Get all the information we need from transDR
                    // Get foreign key we are looking for
                    field fkFieldToFind = dataHelper.getForeignKeyFromRefTableName(TableName.coursesTable, TableName.requirementsTable);
                    int courseReqIdValue = transcriptSql.getIntValueFromDataRowBasefield(transDR, fkFieldToFind, TableName.coursesTable);
                    bool xTimes = transcriptSql.getBoolValueFromDataRowBasefield(transDR, TranscriptField.ReqName_xTimes, TableName.requirementsTable);
                    // Get two degreeLevels to make sure course is as high as this degree degreeLevel - otherwise credits wasted
                    int sdDegreeLevel = transcriptSql.getIntValueFromDataRowBasefield(transDR, TranscriptField.DegreeLevel_DegreeLevel, TableName.studentDegreesTable);
                    int courseTermDegreeLevel = transcriptSql.getIntValueFromDataRowBasefield(transDR, TranscriptField.DegreeLevel_DegreeLevel, TableName.courseTermsTable);
                    // Get two DeliveryMethod_levels to check totals on delivery-methods
                    // Following uses distance from transcript to deliveryMethod in stack to pick the short keyStack
                    int courseDeliveryLevel = transcriptSql.getIntValueFromDataRowBasefield(transDR, TranscriptField.DeliveryMethod_level, TableName.transcriptTable);
                    int stuDegDeliveryLevel = transcriptSql.getIntValueFromDataRowBasefield(transDR, TranscriptField.DeliveryMethod_level, TableName.studentDegreesTable);
                    // Get grade details  -  Grades table columns: int: QP, bit: earnedCredits, bit: creditsInQPA
                    Single gradeQP = transcriptSql.getSingleValueFromDataRowBasefield(transDR, TranscriptField.Grades_QP, TableName.transcriptTable);
                    bool grade_earnedCredits = transcriptSql.getBoolValueFromDataRowBasefield(transDR, TranscriptField.Grades_earnedCredits, TableName.transcriptTable);
                    bool grade_creditsInQPA = transcriptSql.getBoolValueFromDataRowBasefield(transDR, TranscriptField.Grades_creditsInQPA, TableName.transcriptTable);
                    // Get number of credits this course is worth
                    Single courseCredits = transcriptSql.getSingleValueFromDataRowBasefield(transDR, TranscriptField.CourseTerms_Credits, TableName.courseTermsTable);

                    // 2. Add the requirement to requirements map, if this reqID is not already in the map
                    if (!requirement_fullmap.Keys.Contains(courseReqIdValue))
                    {
                        List<int> fullMap = new List<int>();
                        transcriptHelper.getlistOfRequirementsFulfilledBy(courseReqIdValue, ref fullMap);
                        requirement_fullmap.Add(courseReqIdValue, fullMap);
                    }

                    // 3. Insert this information in dataHelper.extraDT, and then push down to studentGradRequirments (the table in extraDT)
                    //    Loop through stuGradReq table and add this transcript row if it meets this requirement 
                    foreach (DataRow stuGradReqDR in sgrDaDt.dt.Rows)
                    {
                        // fk_studgradReq_gradReqID defined above when inserting values into sgrt (Just getting FK field name in sgrt - probabaly 'requirementID')
                        int sgrt_reqID = studentGradReqSql.getIntValueFromDataRowBasefield(stuGradReqDR, fk_studgradReq_gradReqID);
                        // Check if this transcript fulfills the requirement of this row of the student's stuGradReq table
                        if (requirement_fullmap[courseReqIdValue].Contains(sgrt_reqID))
                        {
                            UpdateStuGradReqDR(stuGradReqDR, sdDegreeLevel, courseTermDegreeLevel, stuDegDeliveryLevel, courseDeliveryLevel,
                                gradeQP, grade_earnedCredits, grade_creditsInQPA, courseCredits, xTimes);
                        }
                    }
                }
                fOptions.dgvRequirements.DataSource = sgrDaDt.dt;
                fOptions.Show();
            }
        }

        private void UpdateStuGradReqDR(DataRow sgrDR, int sdDegreeLevel, int tDegreeLevel, int sdDeliveryLevel, int tDeliveryLevel,
        Single grade_QP, bool grade_EarnedCredits, bool grade_creditsInQPA, Single credits, bool xTimes)
        {
            if (sdDegreeLevel! == tDeliveryLevel)
            {
                errorMsgs.Add("Error");
            }
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
                    dgvHelper.SetNewColumnWidths(dgvStudent, studentDegreesSql.myFields, false);
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
            }
            else
            {
                if (tabControl1.SelectedTab == tabStudent)
                {
                    if (dgvStudent == null)
                    {
                        toolStripBtnNarrow.Enabled = false;
                    }
                    else
                    {
                        toolStripBtnNarrow.Enabled = true;
                        dgvCurrentlyViewing = dgvStudent;
                        sqlCurrentlyViewing = studentDegreesSql;
                    }
                }
                else
                {
                    toolStripBtnNarrow.Enabled = false;
                    dgvCurrentlyViewing = null;
                    sqlCurrentlyViewing = null;

                }

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
