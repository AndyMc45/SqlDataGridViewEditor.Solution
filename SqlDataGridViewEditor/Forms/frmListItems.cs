//using System.Data;
// using System.Data.SqlClient;

namespace SqlDataGridViewEditor
{
    internal partial class frmListItems
        : System.Windows.Forms.Form
    {
        public frmListItems() : base()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public enum job
        {
            DeleteConnections,
            SelectString
        }

        //This form used for (1) deleting connections AND listing / selecting a from a list
        public job myJob;

        // For deleting connection, we will build a list of connection strings - see below
        List<connectionString> csList = new List<connectionString>();

        // For a list, we will feed in the list into myList
        public List<string> myList = new List<string>();

        public string formCaption;
        public string returnString = string.Empty;
        public int returnIndex = -1;

        private void frmListItems_Load(object sender, EventArgs e)
        {
            // listing strings to select - maybe databases or tables or anything
            if (myJob == job.SelectString)
            {
                this.cmdExit.Text = "OK";
            }
            else if (myJob == job.DeleteConnections)   // deleting databases fromlist
            {
                this.cmdExit.Text = "Delete";
            }
            // this.Text = formCaption; //"List of Databases on the Server";
            listBox1.Items.AddRange(myList.ToArray());
            // Set width of form
            int width = listBox1.Width;
            using (Graphics g = listBox1.CreateGraphics())
            {
                System.Drawing.Font font = listBox1.Font;
                int vertScrollBarWidth = 15;
                var itemsList = listBox1.Items.Cast<object>().Select(item => item.ToString());
                foreach (string s in itemsList)
                {
                    int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;
                    if (width < newWidth)
                    {
                        width = newWidth;
                    }
                }
            }
            listBox1.Width = width;
            this.Width = width + 70;
        }


        private void cmdExit_Click(Object eventSender, EventArgs eventArgs)
        {   // Return selected item 
            returnString = listBox1.GetItemText(listBox1.SelectedItem);
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                returnIndex = listBox1.SelectedIndex;
            }
        }

    }
}

