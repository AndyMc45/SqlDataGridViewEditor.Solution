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
    internal static class TranscriptHelper
    {
        internal static DataTable GetOneRowDataTable(string tableName, int PkValue, ref List<string> errorMsgs)
        {
            SqlFactory sqlFactory = new SqlFactory(tableName, 0, 0, false);
            field fld = dataHelper.getTablePrimaryKeyField(tableName);
            where wh = new where(fld, PkValue.ToString());
            sqlFactory.myWheres.Add(wh);
            // Get data row
            string sqlString = sqlFactory.returnSql(command.selectAll);
            DataTable dt = new DataTable();
            string strError = MsSql.FillDataTable(dt, sqlString);
            if(strError != string.Empty) { errorMsgs.Add(strError); }
            return dt;
        }
        internal static Dictionary<string, string> GetPkRowColumnValues(string tableName, int pkValue, List<string> columnNames, ref List<string> errorMsgs)
        {
            var columnValues = new Dictionary<string, string>();
            DataTable dt = GetOneRowDataTable(tableName, pkValue, ref errorMsgs);                 
            SqlFactory sqlFactory = new SqlFactory(tableName, 0, 0);
            // Should be exactly one row in requirementNameDaDt.dt
            if(dt.Rows.Count != 1) { errorMsgs.Add(String.Format("Error: {0} rows in {1} with primary {2}", dt.Rows.Count.ToString(), tableName, pkValue.ToString()));}
            if (dt.Rows.Count > 0)
            {
                foreach( string colName in  columnNames )
                {
                    string colValue = dataHelper.getColumnValueinDR(dt.Rows[0], colName);
                    columnValues.Add(colName, colValue);
                }
            }
            return columnValues;
        }
    }
    internal static class TableName
    {
        // Names of the tables <string>
        internal static string courses { get => "Courses"; }
        internal static string courseTerms { get =>  "CourseTerms";}
        internal static string degreeLevel { get =>  "DegreeLevel";}
        internal static string degrees { get =>  "Degrees";}
        internal static string deliveryMethod { get =>  "DeliveryMethod";}
        internal static string departments { get =>  "Departments";}
        internal static string faculty { get =>  "Faculty";}
        internal static string grades { get =>  "Grades";}
        internal static string gradeStatus { get =>   "GradeStatus";}
        internal static string gradReqDelivMeth { get => "GradReqDelivMeth"; }
        internal static string gradRequirements { get =>   "GradRequirements";}
        internal static string handbooks { get =>   "Handbooks";}
        internal static string requirementName { get =>   "RequirementName";}
        internal static string requirementType { get => "RequirementType"; }
        internal static string studentDegrees { get =>   "StudentDegrees";}
        internal static string studentGradReq { get =>   "StudentGradReq";}   
        internal static string students { get =>   "Students";}
        internal static string terms { get =>   "Terms";}
        internal static string transcript { get =>   "Transcript";}
        internal static string transferCredits { get =>   "TransferCredits";}


    }
    internal static class TableField
    {
        // Fields used in where statement
        internal static field GradRequirements_DegreeID { get => dataHelper.getFieldFromFieldsDT(TableName.gradRequirements, "degreeID"); }
        internal static field GradRequirements_handbookID { get => dataHelper.getFieldFromFieldsDT(TableName.gradRequirements, "handbookID"); }
    }

}
