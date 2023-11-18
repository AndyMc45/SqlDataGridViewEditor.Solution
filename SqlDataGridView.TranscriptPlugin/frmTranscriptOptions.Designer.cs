namespace SqlDataGridViewEditor.TranscriptPlugin
{
    partial class frmTranscriptOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranscriptOptions));
            tabControl1 = new TabControl();
            tabActions = new TabPage();
            btnPrintEnglishTranscript = new Button();
            tabStudent = new TabPage();
            dgvStudent = new DataGridView();
            tabTranscript = new TabPage();
            dgvTranscript = new DataGridView();
            tabRequirements = new TabPage();
            dgvRequirements = new DataGridView();
            tabOptions = new TabPage();
            lblPathTemplateFolder = new Label();
            lblPathTemplate = new Label();
            lblTemplateFolder = new LinkLabel();
            lblEnglishCourseRoleTemplate = new LinkLabel();
            lblCourseRoleTemplate = new LinkLabel();
            lblEnglishTranscriptTemplate = new LinkLabel();
            lblTranscriptTemplate = new LinkLabel();
            lblOptions = new Label();
            toolStripBottom = new ToolStrip();
            toolStripBtnNarrow = new ToolStripButton();
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            tabControl1.SuspendLayout();
            tabActions.SuspendLayout();
            tabStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            tabTranscript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTranscript).BeginInit();
            tabRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequirements).BeginInit();
            tabOptions.SuspendLayout();
            toolStripBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabActions);
            tabControl1.Controls.Add(tabStudent);
            tabControl1.Controls.Add(tabTranscript);
            tabControl1.Controls.Add(tabRequirements);
            tabControl1.Controls.Add(tabOptions);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1582, 753);
            tabControl1.TabIndex = 7;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabActions
            // 
            tabActions.Controls.Add(btnPrintEnglishTranscript);
            tabActions.Location = new Point(4, 29);
            tabActions.Name = "tabActions";
            tabActions.Size = new Size(1574, 720);
            tabActions.TabIndex = 4;
            tabActions.Text = "Actions";
            tabActions.UseVisualStyleBackColor = true;
            // 
            // btnPrintEnglishTranscript
            // 
            btnPrintEnglishTranscript.Location = new Point(296, 31);
            btnPrintEnglishTranscript.Name = "btnPrintEnglishTranscript";
            btnPrintEnglishTranscript.Size = new Size(200, 29);
            btnPrintEnglishTranscript.TabIndex = 14;
            btnPrintEnglishTranscript.Text = "Print English Transcript";
            btnPrintEnglishTranscript.UseVisualStyleBackColor = true;
            btnPrintEnglishTranscript.Click += btnPrintEnglishTranscript_Click;
            // 
            // tabStudent
            // 
            tabStudent.Controls.Add(dgvStudent);
            tabStudent.Location = new Point(4, 29);
            tabStudent.Name = "tabStudent";
            tabStudent.Size = new Size(1574, 720);
            tabStudent.TabIndex = 3;
            tabStudent.Text = "Student";
            tabStudent.UseVisualStyleBackColor = true;
            // 
            // dgvStudent
            // 
            dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudent.Dock = DockStyle.Top;
            dgvStudent.Location = new Point(0, 0);
            dgvStudent.Name = "dgvStudent";
            dgvStudent.RowHeadersWidth = 51;
            dgvStudent.RowTemplate.Height = 29;
            dgvStudent.Size = new Size(1574, 209);
            dgvStudent.TabIndex = 0;
            // 
            // tabTranscript
            // 
            tabTranscript.Controls.Add(dgvTranscript);
            tabTranscript.Location = new Point(4, 29);
            tabTranscript.Name = "tabTranscript";
            tabTranscript.Size = new Size(1574, 720);
            tabTranscript.TabIndex = 2;
            tabTranscript.Text = "Transcript";
            tabTranscript.UseVisualStyleBackColor = true;
            // 
            // dgvTranscript
            // 
            dgvTranscript.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTranscript.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTranscript.Location = new Point(0, 0);
            dgvTranscript.Name = "dgvTranscript";
            dgvTranscript.RowHeadersWidth = 51;
            dgvTranscript.RowTemplate.Height = 29;
            dgvTranscript.Size = new Size(1174, 694);
            dgvTranscript.TabIndex = 0;
            // 
            // tabRequirements
            // 
            tabRequirements.AutoScroll = true;
            tabRequirements.Controls.Add(dgvRequirements);
            tabRequirements.Location = new Point(4, 29);
            tabRequirements.Name = "tabRequirements";
            tabRequirements.Padding = new Padding(3);
            tabRequirements.Size = new Size(1574, 720);
            tabRequirements.TabIndex = 1;
            tabRequirements.Text = "Requirements";
            tabRequirements.UseVisualStyleBackColor = true;
            // 
            // dgvRequirements
            // 
            dgvRequirements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequirements.Dock = DockStyle.Fill;
            dgvRequirements.Location = new Point(3, 3);
            dgvRequirements.Name = "dgvRequirements";
            dgvRequirements.RowHeadersWidth = 51;
            dgvRequirements.RowTemplate.Height = 29;
            dgvRequirements.Size = new Size(1568, 714);
            dgvRequirements.TabIndex = 0;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(lblPathTemplateFolder);
            tabOptions.Controls.Add(lblPathTemplate);
            tabOptions.Controls.Add(lblTemplateFolder);
            tabOptions.Controls.Add(lblEnglishCourseRoleTemplate);
            tabOptions.Controls.Add(lblCourseRoleTemplate);
            tabOptions.Controls.Add(lblEnglishTranscriptTemplate);
            tabOptions.Controls.Add(lblTranscriptTemplate);
            tabOptions.Controls.Add(lblOptions);
            tabOptions.Location = new Point(4, 29);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new Padding(3);
            tabOptions.Size = new Size(1574, 720);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Options";
            tabOptions.UseVisualStyleBackColor = true;
            // 
            // lblPathTemplateFolder
            // 
            lblPathTemplateFolder.AutoSize = true;
            lblPathTemplateFolder.BorderStyle = BorderStyle.FixedSingle;
            lblPathTemplateFolder.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathTemplateFolder.Location = new Point(280, 283);
            lblPathTemplateFolder.Name = "lblPathTemplateFolder";
            lblPathTemplateFolder.Size = new Size(136, 19);
            lblPathTemplateFolder.TabIndex = 21;
            lblPathTemplateFolder.Text = "Template Folder Path";
            // 
            // lblPathTemplate
            // 
            lblPathTemplate.AutoSize = true;
            lblPathTemplate.BorderStyle = BorderStyle.FixedSingle;
            lblPathTemplate.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathTemplate.Location = new Point(280, 83);
            lblPathTemplate.Name = "lblPathTemplate";
            lblPathTemplate.Size = new Size(158, 19);
            lblPathTemplate.TabIndex = 20;
            lblPathTemplate.Text = "Transcript Template Path";
            // 
            // lblTemplateFolder
            // 
            lblTemplateFolder.AutoSize = true;
            lblTemplateFolder.Location = new Point(30, 280);
            lblTemplateFolder.Name = "lblTemplateFolder";
            lblTemplateFolder.Size = new Size(124, 20);
            lblTemplateFolder.TabIndex = 19;
            lblTemplateFolder.TabStop = true;
            lblTemplateFolder.Text = "Template Folder :";
            lblTemplateFolder.LinkClicked += lblTemplateFolder_LinkClicked_1;
            // 
            // lblEnglishCourseRoleTemplate
            // 
            lblEnglishCourseRoleTemplate.AutoSize = true;
            lblEnglishCourseRoleTemplate.Location = new Point(30, 230);
            lblEnglishCourseRoleTemplate.Name = "lblEnglishCourseRoleTemplate";
            lblEnglishCourseRoleTemplate.Size = new Size(161, 20);
            lblEnglishCourseRoleTemplate.TabIndex = 18;
            lblEnglishCourseRoleTemplate.TabStop = true;
            lblEnglishCourseRoleTemplate.Text = "Course Role Template :";
            // 
            // lblCourseRoleTemplate
            // 
            lblCourseRoleTemplate.AutoSize = true;
            lblCourseRoleTemplate.Location = new Point(30, 180);
            lblCourseRoleTemplate.Name = "lblCourseRoleTemplate";
            lblCourseRoleTemplate.Size = new Size(161, 20);
            lblCourseRoleTemplate.TabIndex = 17;
            lblCourseRoleTemplate.TabStop = true;
            lblCourseRoleTemplate.Text = "Course Role Template :";
            // 
            // lblEnglishTranscriptTemplate
            // 
            lblEnglishTranscriptTemplate.AutoSize = true;
            lblEnglishTranscriptTemplate.Location = new Point(30, 130);
            lblEnglishTranscriptTemplate.Name = "lblEnglishTranscriptTemplate";
            lblEnglishTranscriptTemplate.Size = new Size(197, 20);
            lblEnglishTranscriptTemplate.TabIndex = 16;
            lblEnglishTranscriptTemplate.TabStop = true;
            lblEnglishTranscriptTemplate.Text = "English Transcript Template :";
            // 
            // lblTranscriptTemplate
            // 
            lblTranscriptTemplate.AutoSize = true;
            lblTranscriptTemplate.Location = new Point(30, 80);
            lblTranscriptTemplate.Name = "lblTranscriptTemplate";
            lblTranscriptTemplate.Size = new Size(146, 20);
            lblTranscriptTemplate.TabIndex = 15;
            lblTranscriptTemplate.TabStop = true;
            lblTranscriptTemplate.Text = "Transcript Template :";
            lblTranscriptTemplate.LinkClicked += lblTranscriptTemplate_LinkClicked;
            // 
            // lblOptions
            // 
            lblOptions.AutoSize = true;
            lblOptions.BackColor = Color.Transparent;
            lblOptions.FlatStyle = FlatStyle.Flat;
            lblOptions.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblOptions.Location = new Point(30, 40);
            lblOptions.Margin = new Padding(3);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(166, 20);
            lblOptions.TabIndex = 6;
            lblOptions.Text = "Folders and Templates";
            // 
            // toolStripBottom
            // 
            toolStripBottom.Dock = DockStyle.Bottom;
            toolStripBottom.ImageScalingSize = new Size(20, 20);
            toolStripBottom.Items.AddRange(new ToolStripItem[] { toolStripBtnNarrow });
            toolStripBottom.Location = new Point(0, 726);
            toolStripBottom.Name = "toolStripBottom";
            toolStripBottom.Size = new Size(1582, 27);
            toolStripBottom.TabIndex = 15;
            toolStripBottom.Text = "toolStrip1";
            // 
            // toolStripBtnNarrow
            // 
            toolStripBtnNarrow.Alignment = ToolStripItemAlignment.Right;
            toolStripBtnNarrow.AutoToolTip = false;
            toolStripBtnNarrow.BackColor = Color.RoyalBlue;
            toolStripBtnNarrow.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripBtnNarrow.ForeColor = Color.GhostWhite;
            toolStripBtnNarrow.Image = (Image)resources.GetObject("toolStripBtnNarrow.Image");
            toolStripBtnNarrow.ImageAlign = ContentAlignment.MiddleRight;
            toolStripBtnNarrow.ImageTransparentColor = Color.Magenta;
            toolStripBtnNarrow.Name = "toolStripBtnNarrow";
            toolStripBtnNarrow.Size = new Size(62, 24);
            toolStripBtnNarrow.Tag = "narrow";
            toolStripBtnNarrow.Text = "Narrow";
            toolStripBtnNarrow.Click += toolStripBtnNarrow_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmTranscriptOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 753);
            Controls.Add(toolStripBottom);
            Controls.Add(tabControl1);
            Name = "frmTranscriptOptions";
            Text = "frmOptions";
            Load += frmTranscriptOptions_Load;
            tabControl1.ResumeLayout(false);
            tabActions.ResumeLayout(false);
            tabStudent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            tabTranscript.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTranscript).EndInit();
            tabRequirements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequirements).EndInit();
            tabOptions.ResumeLayout(false);
            tabOptions.PerformLayout();
            toolStripBottom.ResumeLayout(false);
            toolStripBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TabControl tabControl1;
        private Label lblOptions;
        public TabPage tabOptions;
        public TabPage tabRequirements;
        public DataGridView dgvRequirements;
        private TabPage tabTranscript;
        private DataGridView dgvTranscript;
        private TabPage tabStudent;
        private DataGridView dgvStudent;
        private ToolStrip toolStripBottom;
        private ToolStripButton toolStripBtnNarrow;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Label lblSaveDocuments;
        private LinkLabel lblTranscriptTemplate;
        private TabPage tabActions;
        private Button btnPrintEnglishTranscript;
        private LinkLabel lblT;
        private LinkLabel lblEnglishCourseRoleTemplate;
        private LinkLabel lblCourseRoleTemplate;
        private LinkLabel lblEnglishTranscriptTemplate;
        private Label lblPathTemplate;
        private LinkLabel lblTemplateFolder;
        private Label lblPathTemplateFolder;
    }
}