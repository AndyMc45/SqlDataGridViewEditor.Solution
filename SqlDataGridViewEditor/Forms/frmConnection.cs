using Microsoft.VisualBasic;
// using System.Data.SqlClient;
using System.Text;
using System.Data;
using InfoBox;
using SqlDataGridViewEditor.Properties;

namespace SqlDataGridViewEditor
{
    internal partial class frmConnection
        : System.Windows.Forms.Form
    {

        public frmConnection() : base()
        {
            InitializeComponent();
            csList = new List<connectionString>();
        }

        public bool success = false;
        List<connectionString> csList { get; set; }
        private string password = string.Empty;

        private void frmConnection_Load(object sender, EventArgs e)
        {
            lblConnection.Text = MyResources.EnterConnectionStringDirections;
            //Load txtHelp
            txtHelp.Text = MyResources.MustPassTestBeforeOKButton;

            //Disable OK
            cmdOK.Enabled = false;

            // Load the dropdown combo list
            // Start with defaults - assume these are formatted correctly - no unnecessary spaces
            List<string> defaultComboItems = MsSql.defaultConnectionStrings();
            // Add past successful connections
            csList = AppData.GetConnectionStringList();
            foreach (connectionString conString in csList)
            {
                string strCb = conString.comboString;
                strCb = strCb.Replace(" ;", ";").Replace("; ", ";").Replace(" =", "=").Replace("= ", "=");
                if (!defaultComboItems.Contains(strCb))
                {
                    defaultComboItems.Add(strCb);
                }
            }
            cmbStrings.Items.Clear();
            cmbStrings.Items.AddRange(defaultComboItems.ToArray()) ;

            // Select the first - this will set the 3 txtboxes
            cmbStrings.SelectedIndex = 0;
        }

        private void cmdDatabaseList_Click(Object eventSender, EventArgs eventArgs)
        {
            StringBuilder sb = new StringBuilder();
            if (this.txtServer.Text == "")
            {
                sb.AppendLine("You must enter a Server name");
            }
            if (cmbStrings.Text.IndexOf("{2}") > -1 && this.txtUserId.Text == string.Empty)
            {
                sb.AppendLine("Enter a user name or choose a connection string without {2}.");
            }
            if (sb.Length > 0)
            {
                InformationBox.Show(sb.ToString());
            }
            else
            {
                string conStr = cmbStrings.Text;

                // Remove {1} from conStr
                int one = conStr.IndexOf("{1}");
                if (one > -1)
                {
                    int nextSemi = conStr.IndexOf(";", one);
                    int lastSemi = conStr.Substring(0, one).LastIndexOf(";");
                    conStr = conStr.Substring(0, lastSemi + 1) + conStr.Substring(nextSemi + 1);
                }

                conStr = String.Format(conStr, txtServer.Text, "none", txtUserId.Text);
                if (conStr.IndexOf("{3}") > -1)
                {
                    frmLogin passwordForm = new frmLogin();
                    passwordForm.ShowDialog();
                    string password = passwordForm.password;
                    passwordForm = null;
                    conStr.Replace("{3}", password);
                }
                List<string> databaseList = getSqlDatabaseList(conStr);
                if (databaseList.Count > 0)
                {
                    //frmDeleteDatabase used to show databases
                    frmListItems databaseListForm = new frmListItems();
                    databaseListForm.myList = databaseList;
                    databaseListForm.formCaption = "Hello";
                    databaseListForm.myJob = frmListItems.job.SelectString;
                    databaseListForm.ShowDialog();
                    if (databaseListForm.returnString != string.Empty)
                    {
                        this.txtDatabase.Text = databaseListForm.returnString;
                    }
                    databaseListForm = null;
                }
            }
        }

        private List<string> getSqlDatabaseList(string cs)
        {
            List<string> strList = new List<string>();
            try
            {
                MsSql.openNoDatabaseConnection(cs);
                DataTable databases = MsSql.noDatabaseConnection.GetSchema("Databases");
                foreach (DataRow database in databases.Rows)
                {
                    strList.Add(database.Field<String>("database_name"));
                }
                MsSql.CloseNoDatabaseConnection();
            }
            catch (Exception exc)
            {
                InformationBox.Show("Error opening connection: " + exc.Message, "Error opening Connection", InformationBoxIcon.Error);
            }
            return strList;
        }

        private void cmdCancel_Click(Object eventSender, EventArgs eventArgs)
        {
            this.Close();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            string cs = cmbStrings.Text;
            //Password
            string showUser = cs.Replace("{3}", "*********");  // Used in error message
            if (cs.IndexOf("{3}") >= 0)
            {
                frmLogin passwordForm = new frmLogin();
                passwordForm.ShowDialog();
                password = passwordForm.password;
                passwordForm = null;
                cs = cs.Replace("{3}", password);
            }
            cs = String.Format(cs, this.txtServer.Text, this.txtDatabase.Text, this.txtUserId.Text, password);
            //Try to open connection
            try
            {
                MsSql.CloseConnection();
                MsSql.openConnection(cs);  // No error handling in openConnection(cs)
                InformationBox.Show("Test passed.", "Success", InformationBoxIcon.Success);
                cmdOK.Enabled = true;
                success = true;
            }
            catch (System.Exception excep)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Error opening connection.");
                sb.AppendLine(excep.Message);
                InformationBox.Show(sb.ToString(), "Error", InformationBoxIcon.Error);
                cmdOK.Enabled = false;
                success = false;

                //if (Information.Err().Description != "")
                //{
                //    InformationBox.Show("We are sorry to report that the connection failed. " + Environment.NewLine
                //                    + "Your connection string : " + Environment.NewLine + showUser
                //                    + Environment.NewLine + "Error message:"
                //                    + Environment.NewLine + Information.Err().Description, "Error", InformationBoxIcon.Error);
                //}
            }
        }

        private void cmdOK_Click(Object eventSender, EventArgs eventArgs)
        {
            // Get the proposed combo string pattern
            string strCS = cmbStrings.Text;
            // Make substitutions
            strCS = String.Format(strCS, this.txtServer.Text, this.txtDatabase.Text, this.txtUserId.Text, password);
            // Create connection String object
            connectionString conString = new connectionString(cmbStrings.Text, this.txtServer.Text, this.txtUserId.Text,
                        this.txtDatabase.Text, MsSql.databaseType);
            // Remove old occurences from stored list of strings - csList is filled of form load.
            foreach (connectionString cs in csList)
            {
                if (AppData.sameConnectionString(cs, conString))
                {
                    csList.Remove(cs);
                    break;  // only remove once or you will get an error
                }
            }
            // The main form uses the first item in csList
            csList.Insert(0, conString);
            AppData.storeConnectionStringList(csList);
            this.Close();
        }

        private void cmbStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStrings.SelectedIndex > -1)
            {
                // Condition required because a default may have been selected
                if (csList.Count > cmbStrings.SelectedIndex)
                {
                    txtServer.Text = csList[cmbStrings.SelectedIndex].server;
                    txtUserId.Text = csList[cmbStrings.SelectedIndex].user;
                    txtDatabase.Text = csList[cmbStrings.SelectedIndex].databaseName;
                }
            }
        }

    }
}