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
            SqlFactory requirementMapSql = new SqlFactory(TableName.requirmentNameMapTable, 0, 0);
            field ancestorFld = TranscriptField.ReqName_Ancestors;
            where wh = new where(ancestorFld, reqID.ToString());
            requirementMapSql.myWheres.Add(wh);
            string sqlString = requirementMapSql.returnSql(command.selectAll);
            DataTable dt = new DataTable();
            MsSql.FillDataTable(dt, sqlString);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    int descendantReqCol = dr.Table.Columns.IndexOf(TranscriptField.RequirementsMap_req_DescendantID.fieldName);
            //    int descendantReq = Int32.Parse(dr[descendantReqCol].ToString());
            //    if (!returnList.Contains(descendantReq))
            //    {
            //        getlistOfRequirementsFulfilledBy(descendantReq, ref returnList);
            //    }
            //}
        }



    }

    internal static class TableName
    {
        // Names of the tables <string>
        internal static string coursesTable { get => "Courses"; }
        internal static string courseTermsTable { get =>  "CourseTerms";}
        internal static string degreeLevelTable { get =>  "DegreeLevel";}
internal static string degreesTable { get =>  "Degrees";}
        internal static string deliveryMethodTable { get =>  "DeliveryMethod";}
        internal static string departmentsTable { get =>  "Departments";}
        internal static string facultyTable { get =>  "Faculty";}
        internal static string gradesTable { get =>  "Grades";}
        internal static string gradesStatus { get =>   "GradesStadus";}
    internal static string gradReqDelivMethTable { get => "GradReqDelivMeth"; }
        internal static string gradRequirementsTable { get =>   "GradRequirements";}
        internal static string handbooksTable { get =>   "Handbooks";}
        internal static string requirmentNameTable { get =>   "RequirementName";}
        internal static string requirmentNameMapTable { get =>   "RequirementNameMap";}
        internal static string studentDegreesTable { get =>   "StudentDegrees";}
        internal static string studentGradReqTable { get =>   "StudentGradReq";}   
        internal static string studentsTable { get =>   "Students";}
        internal static string termsTable { get =>   "Terms";}
        internal static string transcriptTable { get =>   "Transcript";}
        internal static string transferCreditsTable { get =>   "TransferCredits";}


    }
    internal static class TranscriptField
    {

        // Non-FK Columns in tables that are used -  (field has table, column, dbType, size)
        internal static field Student_StudentName { get => dataHelper.getFieldFromFieldsDT(TableName.studentsTable, "studentName");}
        internal static field StudentDegrees_HandbookID { get => dataHelper.getFieldFromFieldsDT(TableName.studentDegreesTable, "handbookID"); }
        internal static field StudentDegrees_DegreeID { get => dataHelper.getFieldFromFieldsDT(TableName.studentDegreesTable, "degreeID"); }
        internal static field Degrees_DegreeName { get =>   dataHelper.getFieldFromFieldsDT(TableName.degreesTable, "degreeName");}

        // Needed in filling studentGradReqTable
        internal static field CourseTerms_Credits { get =>   dataHelper.getFieldFromFieldsDT(TableName.courseTermsTable, "credits");}

        internal static field Courses_degreeLevelID { get =>   dataHelper.getFieldFromFieldsDT(TableName.coursesTable, "degeeLevelID");}

        internal static field DegreeLevel_DegreeLevel { get =>   dataHelper.getFieldFromFieldsDT(TableName.degreeLevelTable, "degreeLevel");}
        internal static field DeliveryMethod_level { get =>   dataHelper.getFieldFromFieldsDT(TableName.deliveryMethodTable, "deliveryLevel");}

        internal static field ReqName_reqName { get =>   dataHelper.getFieldFromFieldsDT(TableName.requirmentNameTable, "reqName");}
        internal static field ReqName_Ancestors { get =>   dataHelper.getFieldFromFieldsDT(TableName.requirmentNameTable, "Ancestors");}

        internal static field Grades_QP { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradesTable, "QP");}
        internal static field Grades_earnedCredits { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradesTable, "earnedCredits");}
        internal static field Grades_creditsInQPA { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradesTable, "creditsInQPA");}

        internal static field GradRequirements_handbookID { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "handbookID");}
        internal static field GradRequirements_reqCredits { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "reqCredits");}
        internal static field GradRequirements_reqTimes { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "reqTimes");}
        internal static field GradRequirements_reqEqDmCredits { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "reqEqDmCredits");}
        internal static field GradRequirements_creditLimit { get =>   dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "creditLimit");}
        internal static field GradRequirements_DegreeID { get => dataHelper.getFieldFromFieldsDT(TableName.gradRequirementsTable, "degreeID"); }



        // Columns that are Updated
        internal static field SGRT_crReq = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crReq");
        internal static field SGRT_crEarned = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crEarned");
        internal static field SGRT_crInProgress = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crInProgress");
        internal static field SGRT_crLimit = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crLimit");
        internal static field SGRT_crUnused = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crUnused");
        internal static field SGRT_crDelMethReq = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crDelMethReq");
        internal static field SGRT_crDelMethErnd = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crDelMethErnd");
        internal static field SGRT_crDelMethInPro = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "crDelMethInPro");
        internal static field SGRT_QP_total = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "QP_total");
        internal static field SGRT_QP_credits = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "QP_credits");
        internal static field SGRT_QP_average = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "QP_average");
        internal static field SGRT_Fulfilled = dataHelper.getFieldFromFieldsDT(TableName.studentGradReqTable, "Fulfilled");
    }

}
