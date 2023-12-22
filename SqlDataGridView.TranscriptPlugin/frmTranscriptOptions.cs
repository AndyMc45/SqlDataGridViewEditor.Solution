﻿using System.Data;
using System.Globalization;
using System.Resources;
using System.Text;

namespace SqlDataGridViewEditor.TranscriptPlugin
{
    public partial class frmTranscriptOptions : Form
    {
        public frmTranscriptOptions()
        {
            // Get previous culture
            uiCulture = AppData.GetKeyValue("UICulture");
            // Get cultures from the assemblies OF main program
            IEnumerable<CultureInfo> cultureList = GetAvailableCultures();
            foreach (CultureInfo culture in cultureList)
            {
                if (uiCulture == culture.Name)
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(uiCulture);
                    uiCultureFull = System.Threading.Thread.CurrentThread.CurrentUICulture;
                    break;
                }
            }

            InitializeComponent();

            // Load the cultures into the language cmbBox
            cmbInterfaceLanguage.Items.Clear();
            cmbInterfaceLanguage.DisplayMember = "Text";
            cmbInterfaceLanguage.ValueMember = "Value";
            DataTable items = new DataTable();
            DataColumn dc1 = new DataColumn("Text", typeof(string));
            DataColumn dc2 = new DataColumn("Value", typeof(string));
            items.Columns.Add(dc1);
            items.Columns.Add(dc2);
            DataRow emptyDR = items.NewRow();
            emptyDR[0] = " ------------------ ";
            emptyDR[1] = String.Empty;
            items.Rows.Add(emptyDR);
            foreach (CultureInfo culture in cultureList)
            {
                DataRow dr = items.NewRow();
                dr[0] = culture.EnglishName + "(" + culture.NativeName + ", " + culture.Name + ")";
                dr[1] = culture.Name;
                items.Rows.Add(dr);
            }
            loadingForm = true;
            cmbInterfaceLanguage.DataSource = items;
            for (int i = 0; i < cmbInterfaceLanguage.Items.Count; i++)
            {
                DataRowView itemValue = (DataRowView)cmbInterfaceLanguage.Items[i];
                if (itemValue[1].ToString() == uiCulture)
                {
                    cmbInterfaceLanguage.SelectedIndex = i;
                }
            }
            loadingForm = false;

            translateForm();
        }

        public static IEnumerable<CultureInfo> GetAvailableCultures()
        {
            List<CultureInfo> result = new List<CultureInfo>();

            ResourceManager rm = new ResourceManager(typeof(SqlDataGridViewEditor.Properties.MyResources));

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in cultures)
            {
                try
                {
                    if (culture.Equals(CultureInfo.InvariantCulture)) { continue; } //do not use "==", won't work
                    else
                    {
                        ResourceSet rs = rm.GetResourceSet(culture, true, false);
                        if (rs != null)
                        {
                            result.Add(culture);
                        }
                    }
                }
                catch (CultureNotFoundException)
                {
                    //NOP
                }
            }
            return result;
        }

        #region variables
        internal Job myJob { get; set; }   // Must be loaded to do anything
        public int studentDegreeID { get; set; }
        public int courseTermID { get; set; }
        public string uiCulture { get; set; }

        private CultureInfo uiCultureFull = CultureInfo.InvariantCulture;

        public Dictionary<string, string> headerTranslations { get; set; }
        public string translationCultureName { get; set; }

        public StringBuilder sbErrors = new StringBuilder();
        private SqlFactory sqlStudentDegrees { get; set; }
        private SqlFactory sqlTranscript { get; set; }
        private SqlFactory sqlGradReq { get; set; }
        private SqlFactory sqlCourseTermInfo { get; set; }


        // Following two set to the dgv and sql that are showing in the options tab
        private DataGridView dgvCurrentlyViewing { get; set; }
        private SqlFactory sqlCurrentlyViewing { get; set; }
        private Boolean loadingForm { get; set; }

        #endregion

        private void frmTranscriptOptions_Load(object sender, EventArgs e)
        {
            // Load path options
            SetPathLabel(AppData.GetKeyValue("TemplateFolder"), lblPathTemplateFolder);
            SetPathLabel(AppData.GetKeyValue("DocumentFolder"), lblPathDocumentFolder);
            SetPathLabel(AppData.GetKeyValue("DatabaseBackupFolder"), lblPathDatabaseFolder);
            SetPathLabel(AppData.GetKeyValue("TranscriptTemplate"), lblPathTransTemplate);
            SetPathLabel(AppData.GetKeyValue("CourseRoleTemplate"), lblPathCourseRoleTemplate);
            SetPathLabel(AppData.GetKeyValue("EnglishTranscriptTemplate"), lblPathEnglishTranscriptTemplate);
            SetPathLabel(AppData.GetKeyValue("CourseGradesTemplate"), lblPathCourseGradeTemplate);

            toolStripBtnNarrow.Enabled = false;  // Viewing options
            if (myJob == Job.options)
            {
                // 1. - Nothing to do
                tabControl1.SelectedTab = tabOptions;
            }
            else if (myJob == Job.printTranscript)
            {
                // 2.1 Fill studentDegree dgv
                TranscriptHelper.fillStudentDegreeDataRow(studentDegreeID, ref sbErrors);
                if (sbErrors.Length > 0)
                {
                    MessageBox.Show(sbErrors.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Load DGV
                    dgvStudent.DataSource = PrintToWord.studentDegreeInfoDT;
                    sqlStudentDegrees = new SqlFactory(TableName.studentDegrees, 0, 0);  // Only needed to allow following
                    dgvHelper.SetHeaderColorsOnWritePage(dgvStudent, sqlStudentDegrees.myTable, sqlStudentDegrees.myFields);
                    dgvHelper.SetNewColumnWidths(dgvStudent, sqlStudentDegrees.myFields, true);
                    dgvHelper.TranslateHeaders(dgvStudent);
                    // 2.2 Fill transcript
                    TranscriptHelper.fillStudentTranscriptTable(studentDegreeID, ref sbErrors);
                    if (sbErrors.Length > 0)
                    {
                        MessageBox.Show(sbErrors.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Load DGV
                        dgvTranscript.DataSource = PrintToWord.transcriptDT;
                        sqlTranscript = new SqlFactory(TableName.transcript, 0, 0, false); // Danger: must be same as in fillStudentTranscript
                        dgvHelper.SetHeaderColorsOnWritePage(dgvTranscript, sqlTranscript.myTable, sqlTranscript.myFields);
                        dgvHelper.SetNewColumnWidths(dgvTranscript, sqlTranscript.myFields, true);

                        dgvHelper.TranslateHeaders(dgvTranscript);

                        //2.3 Fill Grad Requirements DT
                        TranscriptHelper.fillGradRequirementsDT(ref sbErrors);
                        if (sbErrors.Length > 0)
                        {
                            MessageBox.Show(sbErrors.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Load dgv
                            dgvRequirements.DataSource = PrintToWord.studentReqDT;
                            sqlGradReq = new SqlFactory("StudentReq", 0, 0);
                            dgvHelper.SetHeaderColorsOnWritePage(dgvRequirements, sqlGradReq.myTable, sqlGradReq.myFields);
                            dgvHelper.SetNewColumnWidths(dgvRequirements, sqlGradReq.myFields, true);
                            dgvHelper.TranslateHeaders(dgvRequirements);
                            tabControl1.SelectedTab = tabTranscript;   // Enables proper buttons - do after above
                        }
                    }
                }
            }
            else if (myJob == Job.printClassRole)
            {
                // 3.1 Fill DT and then coureRole dgv - using 1st dgv panel (dgvStudent)
                TranscriptHelper.fillCourseTermDataRow(courseTermID, ref sbErrors);
                if (sbErrors.Length > 0)
                {
                    MessageBox.Show(sbErrors.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Fill dgv
                    dgvStudent.DataSource = PrintToWord.courseTermInfoDT;  // using dgvStudent, i.e. 1st tab.
                    tabStudent.Text = "Course";
                    sqlCourseTermInfo = new SqlFactory(TableName.courseTerms, 0, 0);  // Only needed to allow following
                    // Using the first dgv which is called 'dgvStudent'
                    dgvHelper.SetHeaderColorsOnWritePage(dgvStudent, sqlCourseTermInfo.myTable, sqlCourseTermInfo.myFields);
                    dgvHelper.SetNewColumnWidths(dgvStudent, sqlCourseTermInfo.myFields, true);

                    dgvHelper.TranslateHeaders(dgvStudent);

                    // 3.2 Fill CourseRoletable
                    TranscriptHelper.fillCourseRoleTable(courseTermID, ref sbErrors);  // Will select transcripts rows which are in this course
                    if (sbErrors.Length > 0)
                    {
                        MessageBox.Show(sbErrors.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Load DGV
                        dgvTranscript.DataSource = PrintToWord.transcriptDT;
                        tabTranscript.Text = "Course Role";
                        SqlFactory sqlTranscript = new SqlFactory(TableName.transcript, 0, 0, false); // Danger: must be same as in fillStudentTranscript
                        dgvHelper.SetHeaderColorsOnWritePage(dgvTranscript, sqlTranscript.myTable, sqlTranscript.myFields);
                        dgvHelper.SetNewColumnWidths(dgvTranscript, sqlTranscript.myFields, true);
                        dgvHelper.TranslateHeaders(dgvTranscript);
                        tabControl1.SelectedTab = tabTranscript;
                    }
                }
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
                    toolStripBtnNarrow.Text = Properties.PluginResources.toolStripBtnNarrowWide_Text;
                }
                else
                {
                    dgvHelper.SetNewColumnWidths(dgvCurrentlyViewing, sqlCurrentlyViewing.myFields, false);
                    toolStripBtnNarrow.Tag = "narrow";
                    toolStripBtnNarrow.Text = Properties.PluginResources.toolStripBtnNarrow_Text;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripBtnNarrow.Enabled = false;  // Default
            dgvCurrentlyViewing = null; // default
            sqlCurrentlyViewing = null; // default

            if (tabControl1.SelectedTab == tabOptions)
            {
                // toolStripBtnNarrow.Enabled = false;
            }
            else if (tabControl1.SelectedTab == tabActions)
            {
                btnPrintCourseRole.Enabled = false;
                btnPrintTranscript.Enabled = false;
                if (myJob == Job.printTranscript && sqlStudentDegrees != null)
                {
                    btnPrintTranscript.Enabled = true;
                }
                if (myJob == Job.printClassRole && sqlCourseTermInfo != null)
                {
                    btnPrintCourseRole.Enabled = true;
                }
            }
            else if (tabControl1.SelectedTab == tabStudent)  // May be Printing Transcript or printing Course Role
            {
                if (sqlStudentDegrees != null)
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvStudent;
                    sqlCurrentlyViewing = sqlStudentDegrees;
                }
                else if (sqlCourseTermInfo != null)
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvStudent;
                    sqlCurrentlyViewing = sqlCourseTermInfo;
                }
            }
            else if (tabControl1.SelectedTab == tabTranscript)
            {
                if (sqlTranscript != null)
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvTranscript;
                    sqlCurrentlyViewing = sqlTranscript;
                }
            }
            else if (tabControl1.SelectedTab == tabRequirements)
            {
                if (sqlGradReq != null)
                {
                    toolStripBtnNarrow.Enabled = true;
                    dgvCurrentlyViewing = dgvRequirements;
                    sqlCurrentlyViewing = sqlGradReq;
                }
            }
            else if (tabControl1.SelectedTab == tabExit)
            {
                this.Close();
            }
        }

        private void btnPrintTranscript_Click(object sender, EventArgs e)
        {
            PrintToWord.printTranscript(uiCultureFull, ref sbErrors);
        }
        private void btnPrintCourseRole_Click(object sender, EventArgs e)
        {

        }
        private void btnPrintEnglishTranscript_Click(object sender, EventArgs e)
        {

        }
        private void btnPrintCourseGrades_Click(object sender, EventArgs e)
        {

        }


        private void lblTemplateFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        private void lblDocumentFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string fbdPath = folderBrowserDialog1.SelectedPath;
            if (result == DialogResult.Cancel) { return; }
            lblPathDocumentFolder.Text = fbdPath;
            AppData.SaveKeyValue("DocumentFolder", fbdPath);
        }
        private void lblDatabaseFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string fbdPath = folderBrowserDialog1.SelectedPath;
            if (result == DialogResult.Cancel) { return; }
            lblPathDatabaseFolder.Text = fbdPath;
            AppData.SaveKeyValue("DatabaseBackupFolder", fbdPath);

        }

        private void lblTranscriptTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = SelectTemplateFile();
            openFileDialog1 = new OpenFileDialog();
            if (filePath != String.Empty)
            {
                lblPathTransTemplate.Text = filePath;
                AppData.SaveKeyValue("TranscriptTemplate", filePath);
            }
        }
        private void lblCourseRoleTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = SelectTemplateFile();
            openFileDialog1 = new OpenFileDialog();
            if (filePath != String.Empty)
            {
                lblPathCourseRoleTemplate.Text = filePath;
                AppData.SaveKeyValue("CourseRoleTemplate", filePath);
            }
        }
        private void lblEnglishTranscriptTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = SelectTemplateFile();
            openFileDialog1 = new OpenFileDialog();
            if (filePath != String.Empty)
            {
                lblPathEnglishTranscriptTemplate.Text = filePath;
                AppData.SaveKeyValue("EnglishTranscriptTemplate", filePath);
            }
        }
        private void lblCourseGradesTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = SelectTemplateFile();
            openFileDialog1 = new OpenFileDialog();
            if (filePath != String.Empty)
            {
                lblPathCourseGradeTemplate.Text = filePath;
                AppData.SaveKeyValue("CourseGradesTemplate", filePath);
            }

        }

        private string SelectTemplateFile()
        {
            string filePath = string.Empty;
            openFileDialog1 = new OpenFileDialog();
            string templateFolder = AppData.GetKeyValue("TemplateFolder");
            if (templateFolder != null && Directory.Exists(templateFolder))
            {
                openFileDialog1.InitialDirectory = templateFolder;
            }
            openFileDialog1.Filter = "Word files(*.docx)|*.docx|Old Word files(*.doc)|*.doc|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
            }
            return filePath;
        }

        /// <summary>
        /// Sets the path label text of a path option in the option tab
        /// </summary>
        /// <param name="keyValue">The string value of the path</param>
        /// <param name="label">The label which is to be ste</param>
        public static void SetPathLabel(string keyValue, Label label)
        {
            if (keyValue != string.Empty)
            {
                label.Text = keyValue;
            }
        }

        private void cmbInterfaceLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingForm)
            {
                string selValue = cmbInterfaceLanguage.SelectedValue.ToString();
                AppData.SaveKeyValue("UICulture", selValue);
            }
        }

        private void translateForm()
        {
            tabStudent.Text = Properties.PluginResources.tabStudent_Text;
            tabOptions.Text = Properties.PluginResources.tabOptions_Text;
            tabRequirements.Text = Properties.PluginResources.tabRequirements_Text;
            tabActions.Text = Properties.PluginResources.tabActions_Text;
            tabTranscript.Text = Properties.PluginResources.tabTranscript_Text;
            tabExit.Text = Properties.PluginResources.tabExit_Text;

            btnPrintCourseRole.Text = Properties.PluginResources.btnPrintCourseRole_Text;
            btnPrintTranscript.Text = Properties.PluginResources.btnPrintTranscript_Text;
            btnPrintCourseGrades.Text = Properties.PluginResources.btnPrintCourseGrades_Text;
            btnPrintEnglishTranscript.Text = Properties.PluginResources.btnEnglishPrintTranscript_Text;

            lblLanguage.Text = Properties.PluginResources.lblLanguage_Text;
            lblOptions.Text = Properties.PluginResources.lblOptions_Text;
            lblRestartMsg.Text = Properties.PluginResources.lblRestartMsg_Text;

            lblTemplateFolder.Text = Properties.PluginResources.lblTemplateFolder_Text;
            lblDocumentFolder.Text = Properties.PluginResources.lblDocumentFolder;
            lblTranscriptTemplate.Text = Properties.PluginResources.lblTranscriptTemplate_Text;
            lblEnglishTranscriptTemplate.Text = Properties.PluginResources.lblEnglishTranscriptTemplate;
            lblCourseGradesTemplate.Text = Properties.PluginResources.lblCourseGradesTemplate_Text;
            lblCourseRoleTemplate.Text = Properties.PluginResources.lblCourseRoleTemplate_Text;

            toolStripBtnNarrow.Text = Properties.PluginResources.toolStripBtnNarrow_Text;
        }

        private void frmTranscriptOptions_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width;
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
            tabControl1.Height = this.Height - toolStripBottom.Height;
            tabControl1.Width = this.Width;
        }


        internal enum Job
        {
            options,
            printTranscript,
            printClassRole
        }


    }
}
