using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SqlDataGridViewEditor
{
    public static class dgvHelper
    {
        // Results of this coloring use in color combo boxes above
        public static void SetHeaderColorsOnWritePage(DataGridView dgv, string myTable, List<field> myFields)
        {
            FormOptions formOptions = AppData.GetFormOptions();
            dgv.EnableHeadersVisualStyles = false;
            int nonDkNumber = -1;
            int dkNumber = -1;
            bool currentArrayIsDkColors = false;
            string lastTable = myTable;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                // Display keys and foreignkeys
                field fieldi = myFields[i];
                bool myDisplayKey = dataHelper.isDisplayKey(fieldi) && fieldi.table == myTable;
                bool myForeignKey = dataHelper.isForeignKeyField(fieldi) && fieldi.table == myTable;
                bool myPrimaryKey = dataHelper.isTablePrimaryKeyField(fieldi); // Only myPrimaryKey in fields
                // Primary Key - easy
                if (myPrimaryKey)
                {
                    dgv.Columns[i].HeaderCell.Style.BackColor = formOptions.PrimaryKeyColor;
                    dgv.Columns[i].HeaderCell.Style.SelectionBackColor = formOptions.PrimaryKeyColor;
                }
                // Display Key - might be a typical display key or a foreign key - not yet handling a displaykey of foreign key
                else if (myDisplayKey)
                {
                    dkNumber++;  // Increase dkNumber
                    dgv.Columns[i].HeaderCell.Style.BackColor = formOptions.DkColorArray[dkNumber];
                    dgv.Columns[i].HeaderCell.Style.SelectionBackColor = formOptions.DkColorArray[dkNumber];
                    // Next two used below to handle a displaykey of foreign key
                    currentArrayIsDkColors = true;  // Tells me which array to use
                    if (myForeignKey)
                    {
                        lastTable = dataHelper.getForeignKeyRefField(fieldi).table;  // tells me we are handling a foreign key
                    }
                    else
                    {
                        lastTable = myTable;
                    }
                }
                else if (myForeignKey)  // A typical (non display-key) foreign key
                {
                    nonDkNumber++;
                    dgv.Columns[i].HeaderCell.Style.BackColor = formOptions.nonDkColorArray[nonDkNumber];
                    dgv.Columns[i].HeaderCell.Style.SelectionBackColor = formOptions.nonDkColorArray[nonDkNumber];
                    currentArrayIsDkColors = false;
                    lastTable = dataHelper.getForeignKeyRefField(fieldi).table;
                }
                // We are handling a display key of a foreign key - this assumes these occur after the foreign key
                else if (lastTable != myTable & fieldi.table != myTable)
                {
                    if (currentArrayIsDkColors)  // the foreign key is a disiplay key
                    {
                        dgv.Columns[i].HeaderCell.Style.BackColor = formOptions.DkColorArray[dkNumber];
                        dgv.Columns[i].HeaderCell.Style.SelectionBackColor = formOptions.DkColorArray[dkNumber];
                    }
                    else  // The foreign key is not a display key
                    {
                        dgv.Columns[i].HeaderCell.Style.BackColor = formOptions.nonDkColorArray[nonDkNumber];
                        dgv.Columns[i].HeaderCell.Style.SelectionBackColor = formOptions.nonDkColorArray[nonDkNumber];
                    }
                }
                else  // All other columns are yellow
                {
                    dgv.Columns[i].HeaderCell.Style.BackColor = formOptions.DefaultColumnColor;
                    dgv.Columns[i].HeaderCell.Style.SelectionBackColor = formOptions.DefaultColumnColor;
                    lastTable = myTable;
                }
            }
        }

        public static void SetNewColumnWidths(DataGridView dgv, List<field> myFields, bool narrowColumns)
        {
            // Starting with autosize when the table is first loaded takes too much time; don't do it. 
            // Also, this function takes 10 seconds for transcript table - so don't run it in loading page
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                field fl = myFields[i];
                string headerText = myFields[i].fieldName;  // Default headerText = Original header text
                int headerWidth;  // No default
                System.Drawing.Font font = dgv.Font;
                using (Graphics g = dgv.CreateGraphics())
                {
                    headerWidth = Math.Max(62, (int)g.MeasureString(headerText, font).Width);  // 62 the shortest
                }
                int currentWidth = dgv.Columns[i].Width;
                // Defaults
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // default Alignment
                int nextWidth = dataHelper.getStoredWidth(fl.table, fl.fieldName, currentWidth);  // Default 
                bool shortenHeaderText = false;  // default
                // Set 'shortenHeaderText', and nextWidth with switch
                DbType dbType = fl.dbType;
                switch (dbType)
                {
                    case DbType.Int32:
                    case DbType.Int16:
                    case DbType.Decimal:
                    case DbType.Int64:
                    case DbType.Byte:
                    case DbType.SByte:   // -127 to 127 - signed byte
                    case DbType.Double:
                    case DbType.Single:
                        if (narrowColumns)
                        {
                            shortenHeaderText = true;
                            nextWidth = 62;
                        }
                        else
                        {
                            nextWidth = Math.Max(62, headerWidth);
                        }
                        break;
                    default:
                        // Get the longest of the first 40 items
                        int r = 0;
                        int longestWidth = 62; // default
                        using (Graphics g = dgv.CreateGraphics())
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                r = r + 1;
                                if (r > 40) { break; }
                                if (row.Cells[i].Value != null) 
                                { 
                                int thisItemWidth = (int)g.MeasureString(row.Cells[i].Value.ToString(), font).Width;
                                longestWidth = Math.Max(thisItemWidth, longestWidth);
                                }
                            }
                        }
                        if (narrowColumns)
                        {
                            nextWidth = Math.Min(300, Math.Min(headerWidth, longestWidth));
                            if (headerWidth > longestWidth + 20)
                            {
                                shortenHeaderText = false; // Easier to guess from first few letters
                            }
                        }
                        else
                        {
                            nextWidth = Math.Max(headerWidth, longestWidth);
                        }
                        break;
                }  // End switch
                // Shorten the header text if set to true above and set Alignment = MiddleCenter
                if (shortenHeaderText)
                {
                    dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if (headerText.Length > 6)  // Can 6 letters fit in 62 ?
                    {
                        String newHeaderText = string.Empty;
                        string prefix = headerText.Substring(0, 1);
                        for (int j = 1; j < headerText.Length - 2; j++)  // Skip last two letters at end
                        {
                            if (prefix.Length < 3)
                            {
                                if (Char.IsUpper(headerText[j]) || headerText[j - 1] == '_')
                                {
                                    prefix = prefix + headerText[j];
                                }
                            }
                        }
                        if (prefix.Length == 1)
                        {
                            prefix = headerText.Substring(0, 2);
                        }
                        // prefix = prefix.ToUpper();
                        headerText = prefix + "_" + headerText.Substring(headerText.Length - 2, 2);
                    }
                }
                dgv.Columns[i].HeaderText = headerText;
                dgv.Columns[i].Width = nextWidth;
                // Prepare for next load of table before program closed - every column must be at least 62
                dataHelper.storeColumnWidth(fl.table, fl.fieldName, nextWidth);
            }
        }




    }
}
