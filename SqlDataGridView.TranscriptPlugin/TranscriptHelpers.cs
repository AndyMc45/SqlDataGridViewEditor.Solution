using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SqlDataGridViewEditor;

namespace SqlDataGridViewEditor.TranscriptPlugin
{
    internal static class transcriptHelper
    {
        internal static void UpdateStuGradReqDR(DataRow sgrDR, int sdDegreeLevel, int tDegreeLevel, int sdDeliveryLevel, int tDeliveryLevel,
                    Single grade_QP, bool grade_EarnedCredits, bool grade_creditsInQPA, Single credits, bool xTimes)
        {
            if (sdDegreeLevel! == tDeliveryLevel)
            {
                // errorMsgs.Add("Error");
            }
        }

        // Get list of requirements fulfilled by this requirement
        internal static void getlistOfRequirementsFulfilledBy(int reqID, ref List<int> returnList)
        {
            if (!returnList.Contains(reqID))
            {
                returnList.Add(reqID); // Fulfills itself
            }
            SqlFactory requirementMapSql = new SqlFactory(TableName.requirments_MapTable, 0, 0);
            field ancestorFld = TranscriptField.RequirementsMap_req_AncestorID;
            where wh = new where(ancestorFld, reqID.ToString());
            requirementMapSql.myWheres.Add(wh);
            string sqlString = requirementMapSql.returnSql(command.selectAll);
            DataTable dt = new DataTable();
            MsSql.FillDataTable(dt, sqlString);
            foreach (DataRow dr in dt.Rows)
            {
                int descendantReqCol = dr.Table.Columns.IndexOf(TranscriptField.RequirementsMap_req_DescendantID.fieldName);
                int descendantReq = Int32.Parse(dr[descendantReqCol].ToString());
                if (!returnList.Contains(descendantReq))
                {
                    getlistOfRequirementsFulfilledBy(descendantReq, ref returnList);
                }
            }
        }



    }

    internal static class TableName
    {
        // Names of the tables <string>
        internal static string coursesTable = "Courses";
        internal static string courseTermsTable = "CourseTerms";
        internal static string degreeLevelTable = "DegreeLevel";
        internal static string degreesTable = "Degrees";
        internal static string deliveryMethodTable = "DeliveryMethod";
        internal static string departmentsTable = "Departments";
        internal static string facultyTable = "Faculty";
        internal static string gradesTable = "Grades";
        internal static string gradRequirementsTable = "GradRequirements";
        internal static string handbooksTable = "Handbooks";
        internal static string requirementsTable = "Requirements";
        internal static string requirmentNameTable = "RequirementName";
        internal static string requirments_MapTable = "Requirements_Map";
        internal static string studentDegreesTable = "StudentDegrees";
        internal static string studentGradReqTable = "StudentGradReq";   // 
        internal static string studentsTable = "Students";
        internal static string termsTable = "Terms";
        internal static string transcriptTable = "Transcript";
        internal static string transferCreditsTable = "TransferCredits";
    }
    internal static class TranscriptField
    {

        // Non-FK Columns in tables that are used -  (field has table, column, dbType, size)
        internal static field Student_StudentName = dataHelper.getFieldFromFieldsDT(TableName.studentsTable, "studentName");
        internal static field Degrees_DegreeName = dataHelper.getFieldFromFieldsDT(TableName.degreesTable, "degreeName");

        // Needed in filling studentGradReqTable
        internal static field CourseTerms_Credits = dataHelper.getFieldFromFieldsDT(TableName.courseTermsTable, "credits");
        internal static field DegreeLevel_DegreeLevel = dataHelper.getFieldFromFieldsDT(TableName.degreeLevelTable, "degreeLevel");
        internal static field DeliveryMethod_level = dataHelper.getFieldFromFieldsDT(TableName.deliveryMethodTable, "deliveryLevel");
        internal static field ReqName_xTimes = dataHelper.getFieldFromFieldsDT(TableName.requirmentNameTable, "xTimes");

        internal static field Grades_QP = dataHelper.getFieldFromFieldsDT(TableName.gradesTable, "QP");
        internal static field Grades_earnedCredits = dataHelper.getFieldFromFieldsDT(TableName.gradesTable, "earnedCredits");
        internal static field Grades_creditsInQPA = dataHelper.getFieldFromFieldsDT(TableName.gradesTable, "creditsInQPA");
        internal static field GradRequirements_reqCreditsOrTimes = dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "reqCreditsOrTimes");
        internal static field GradRequirements_reqEqDmCredits = dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "reqEqDmCredits");
        internal static field GradRequirements_creditLimit = dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "creditLimit");
        internal static field RequirementsMap_req_AncestorID = dataHelper.getFieldFromFieldsDT(TableName.requirments_MapTable, "req_AncestorID");
        internal static field RequirementsMap_req_DescendantID = dataHelper.getFieldFromFieldsDT(TableName.requirments_MapTable, "req_DescendantID");

        // Columns that are Updated
        internal static field SGRT_crReq = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crReq");
        internal static field SGRT_crEarned = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crEarned");
        internal static field SGRT_crInProgress = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crInProgress");
        internal static field SGRT_crLimit = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crLimit");
        internal static field SGRT_crUnused = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crUnused");
        internal static field SGRT_crEqDmReq = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crEqDmReq");
        internal static field SGRT_crEqDmErnd = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crEqDmErnd");
        internal static field SGRT_crEqDmInPro = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crEqDmInPro");
        internal static field SGRT_QP_total = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "QP_total");
        internal static field SGRT_QP_credits = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "QP_credits");
        internal static field SGRT_QP_average = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "QP_average");
        internal static field SGRT_Fulfilled = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "Fulfilled");
    }

}
