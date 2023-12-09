﻿namespace SqlDataGridViewEditor.TranscriptPlugin
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabActions = new TabPage();
            btnPrintCourseRole = new Button();
            btnPrintTranscript = new Button();
            tabStudent = new TabPage();
            dgvStudent = new DataGridView();
            tabTranscript = new TabPage();
            dgvTranscript = new DataGridView();
            tabRequirements = new TabPage();
            dgvRequirements = new DataGridView();
            tabOptions = new TabPage();
            lblPathEnglishCourseRoleTemplate = new Label();
            lblPathEnglishTranscriptTemplate = new Label();
            lblEnglishCourseRoleTemplate = new LinkLabel();
            lblEnglishTranscriptTemplate = new LinkLabel();
            lblPathDocumentFolder = new Label();
            lblDocumentFolder = new LinkLabel();
            lblRestartMsg = new Label();
            cmbInterfaceLanguage = new ComboBox();
            lblLanguage = new Label();
            lblPathCourseRoleTemplate = new Label();
            lblPathTemplateFolder = new Label();
            lblPathTransTemplate = new Label();
            lblTemplateFolder = new LinkLabel();
            lblCourseRoleTemplate = new LinkLabel();
            lblTranscriptTemplate = new LinkLabel();
            lblOptions = new Label();
            tabExit = new TabPage();
            toolStripBottom = new ToolStrip();
            toolStripBtnNarrow = new ToolStripButton();
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            btnPrintEnglishCourseRole = new Button();
            btnPrintEnglishTranscript = new Button();
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
            tabControl1.Controls.Add(tabExit);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1582, 723);
            tabControl1.TabIndex = 7;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl1.Resize += tabControl1_Resize;
            // 
            // tabActions
            // 
            tabActions.Controls.Add(btnPrintEnglishCourseRole);
            tabActions.Controls.Add(btnPrintEnglishTranscript);
            tabActions.Controls.Add(btnPrintCourseRole);
            tabActions.Controls.Add(btnPrintTranscript);
            tabActions.Location = new Point(4, 29);
            tabActions.Name = "tabActions";
            tabActions.Size = new Size(1574, 690);
            tabActions.TabIndex = 4;
            tabActions.Text = "Actions";
            tabActions.UseVisualStyleBackColor = true;
            // 
            // btnPrintCourseRole
            // 
            btnPrintCourseRole.Location = new Point(20, 120);
            btnPrintCourseRole.Name = "btnPrintCourseRole";
            btnPrintCourseRole.Size = new Size(200, 29);
            btnPrintCourseRole.TabIndex = 15;
            btnPrintCourseRole.Text = "Print Course Role";
            btnPrintCourseRole.UseVisualStyleBackColor = true;
            btnPrintCourseRole.Click += btnPrintCourseRole_Click;
            // 
            // btnPrintTranscript
            // 
            btnPrintTranscript.Location = new Point(20, 40);
            btnPrintTranscript.Name = "btnPrintTranscript";
            btnPrintTranscript.Size = new Size(200, 29);
            btnPrintTranscript.TabIndex = 14;
            btnPrintTranscript.Text = "Print Transcript";
            btnPrintTranscript.UseVisualStyleBackColor = true;
            btnPrintTranscript.Click += btnPrintTranscript_Click;
            // 
            // tabStudent
            // 
            tabStudent.AutoScroll = true;
            tabStudent.Controls.Add(dgvStudent);
            tabStudent.Location = new Point(4, 29);
            tabStudent.Name = "tabStudent";
            tabStudent.Size = new Size(1574, 690);
            tabStudent.TabIndex = 3;
            tabStudent.Text = "Student";
            tabStudent.UseVisualStyleBackColor = true;
            // 
            // dgvStudent
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            tabTranscript.AutoScroll = true;
            tabTranscript.Controls.Add(dgvTranscript);
            tabTranscript.Location = new Point(4, 29);
            tabTranscript.Name = "tabTranscript";
            tabTranscript.Size = new Size(1574, 690);
            tabTranscript.TabIndex = 2;
            tabTranscript.Text = "Transcript";
            tabTranscript.UseVisualStyleBackColor = true;
            // 
            // dgvTranscript
            // 
            dgvTranscript.AllowUserToAddRows = false;
            dgvTranscript.AllowUserToDeleteRows = false;
            dgvTranscript.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvTranscript.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvTranscript.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTranscript.Dock = DockStyle.Left;
            dgvTranscript.GridColor = Color.WhiteSmoke;
            dgvTranscript.Location = new Point(0, 0);
            dgvTranscript.Name = "dgvTranscript";
            dgvTranscript.RowHeadersWidth = 51;
            dgvTranscript.RowTemplate.Height = 29;
            dgvTranscript.Size = new Size(1574, 690);
            dgvTranscript.TabIndex = 0;
            // 
            // tabRequirements
            // 
            tabRequirements.AutoScroll = true;
            tabRequirements.Controls.Add(dgvRequirements);
            tabRequirements.Location = new Point(4, 29);
            tabRequirements.Name = "tabRequirements";
            tabRequirements.Padding = new Padding(3);
            tabRequirements.Size = new Size(1574, 690);
            tabRequirements.TabIndex = 1;
            tabRequirements.Text = "Requirements";
            tabRequirements.UseVisualStyleBackColor = true;
            // 
            // dgvRequirements
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvRequirements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvRequirements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequirements.Dock = DockStyle.Left;
            dgvRequirements.Location = new Point(3, 3);
            dgvRequirements.Name = "dgvRequirements";
            dgvRequirements.RowHeadersWidth = 51;
            dgvRequirements.RowTemplate.Height = 29;
            dgvRequirements.Size = new Size(1568, 684);
            dgvRequirements.TabIndex = 0;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(lblPathEnglishCourseRoleTemplate);
            tabOptions.Controls.Add(lblPathEnglishTranscriptTemplate);
            tabOptions.Controls.Add(lblEnglishCourseRoleTemplate);
            tabOptions.Controls.Add(lblEnglishTranscriptTemplate);
            tabOptions.Controls.Add(lblPathDocumentFolder);
            tabOptions.Controls.Add(lblDocumentFolder);
            tabOptions.Controls.Add(lblRestartMsg);
            tabOptions.Controls.Add(cmbInterfaceLanguage);
            tabOptions.Controls.Add(lblLanguage);
            tabOptions.Controls.Add(lblPathCourseRoleTemplate);
            tabOptions.Controls.Add(lblPathTemplateFolder);
            tabOptions.Controls.Add(lblPathTransTemplate);
            tabOptions.Controls.Add(lblTemplateFolder);
            tabOptions.Controls.Add(lblCourseRoleTemplate);
            tabOptions.Controls.Add(lblTranscriptTemplate);
            tabOptions.Controls.Add(lblOptions);
            tabOptions.Location = new Point(4, 29);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new Padding(3);
            tabOptions.Size = new Size(1574, 690);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Options";
            tabOptions.UseVisualStyleBackColor = true;
            // 
            // lblPathEnglishCourseRoleTemplate
            // 
            lblPathEnglishCourseRoleTemplate.AutoSize = true;
            lblPathEnglishCourseRoleTemplate.BorderStyle = BorderStyle.FixedSingle;
            lblPathEnglishCourseRoleTemplate.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathEnglishCourseRoleTemplate.Location = new Point(258, 227);
            lblPathEnglishCourseRoleTemplate.Name = "lblPathEnglishCourseRoleTemplate";
            lblPathEnglishCourseRoleTemplate.Size = new Size(218, 19);
            lblPathEnglishCourseRoleTemplate.TabIndex = 31;
            lblPathEnglishCourseRoleTemplate.Text = "English Course Role Template Path";
            // 
            // lblPathEnglishTranscriptTemplate
            // 
            lblPathEnglishTranscriptTemplate.AutoSize = true;
            lblPathEnglishTranscriptTemplate.BorderStyle = BorderStyle.FixedSingle;
            lblPathEnglishTranscriptTemplate.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathEnglishTranscriptTemplate.Location = new Point(258, 177);
            lblPathEnglishTranscriptTemplate.Name = "lblPathEnglishTranscriptTemplate";
            lblPathEnglishTranscriptTemplate.Size = new Size(204, 19);
            lblPathEnglishTranscriptTemplate.TabIndex = 30;
            lblPathEnglishTranscriptTemplate.Text = "English Transcript Template Path";
            // 
            // lblEnglishCourseRoleTemplate
            // 
            lblEnglishCourseRoleTemplate.AutoSize = true;
            lblEnglishCourseRoleTemplate.Location = new Point(30, 224);
            lblEnglishCourseRoleTemplate.Name = "lblEnglishCourseRoleTemplate";
            lblEnglishCourseRoleTemplate.Size = new Size(212, 20);
            lblEnglishCourseRoleTemplate.TabIndex = 29;
            lblEnglishCourseRoleTemplate.TabStop = true;
            lblEnglishCourseRoleTemplate.Text = "English Course Role Template :";
            lblEnglishCourseRoleTemplate.LinkClicked += lblEnglishCourseRoleTemplate_LinkClicked;
            // 
            // lblEnglishTranscriptTemplate
            // 
            lblEnglishTranscriptTemplate.AutoSize = true;
            lblEnglishTranscriptTemplate.Location = new Point(30, 174);
            lblEnglishTranscriptTemplate.Name = "lblEnglishTranscriptTemplate";
            lblEnglishTranscriptTemplate.Size = new Size(197, 20);
            lblEnglishTranscriptTemplate.TabIndex = 28;
            lblEnglishTranscriptTemplate.TabStop = true;
            lblEnglishTranscriptTemplate.Text = "English Transcript Template :";
            lblEnglishTranscriptTemplate.LinkClicked += lblEnglishTranscriptTemplate_LinkClicked;
            // 
            // lblPathDocumentFolder
            // 
            lblPathDocumentFolder.AutoSize = true;
            lblPathDocumentFolder.BorderStyle = BorderStyle.FixedSingle;
            lblPathDocumentFolder.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathDocumentFolder.Location = new Point(258, 325);
            lblPathDocumentFolder.Name = "lblPathDocumentFolder";
            lblPathDocumentFolder.Size = new Size(143, 19);
            lblPathDocumentFolder.TabIndex = 27;
            lblPathDocumentFolder.Text = "Document Folder Path";
            // 
            // lblDocumentFolder
            // 
            lblDocumentFolder.AutoSize = true;
            lblDocumentFolder.Location = new Point(30, 322);
            lblDocumentFolder.Name = "lblDocumentFolder";
            lblDocumentFolder.Size = new Size(131, 20);
            lblDocumentFolder.TabIndex = 26;
            lblDocumentFolder.TabStop = true;
            lblDocumentFolder.Text = "Document Folder :";
            lblDocumentFolder.LinkClicked += lblDocumentFolder_LinkClicked;
            // 
            // lblRestartMsg
            // 
            lblRestartMsg.AutoSize = true;
            lblRestartMsg.Location = new Point(258, 429);
            lblRestartMsg.Name = "lblRestartMsg";
            lblRestartMsg.Size = new Size(490, 20);
            lblRestartMsg.TabIndex = 25;
            lblRestartMsg.Text = "After changing interface language, please close and restart this program.";
            // 
            // cmbInterfaceLanguage
            // 
            cmbInterfaceLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInterfaceLanguage.FormattingEnabled = true;
            cmbInterfaceLanguage.Location = new Point(258, 379);
            cmbInterfaceLanguage.Name = "cmbInterfaceLanguage";
            cmbInterfaceLanguage.Size = new Size(336, 28);
            cmbInterfaceLanguage.TabIndex = 24;
            cmbInterfaceLanguage.SelectedIndexChanged += cmbInterfaceLanguage_SelectedIndexChanged;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.BackColor = Color.Transparent;
            lblLanguage.FlatStyle = FlatStyle.Flat;
            lblLanguage.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblLanguage.ImeMode = ImeMode.NoControl;
            lblLanguage.Location = new Point(30, 379);
            lblLanguage.Margin = new Padding(3);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(144, 20);
            lblLanguage.TabIndex = 23;
            lblLanguage.Text = "Interface Language";
            // 
            // lblPathCourseRoleTemplate
            // 
            lblPathCourseRoleTemplate.AutoSize = true;
            lblPathCourseRoleTemplate.BorderStyle = BorderStyle.FixedSingle;
            lblPathCourseRoleTemplate.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathCourseRoleTemplate.Location = new Point(258, 133);
            lblPathCourseRoleTemplate.Name = "lblPathCourseRoleTemplate";
            lblPathCourseRoleTemplate.Size = new Size(172, 19);
            lblPathCourseRoleTemplate.TabIndex = 22;
            lblPathCourseRoleTemplate.Text = "Course Role Template Path";
            // 
            // lblPathTemplateFolder
            // 
            lblPathTemplateFolder.AutoSize = true;
            lblPathTemplateFolder.BorderStyle = BorderStyle.FixedSingle;
            lblPathTemplateFolder.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathTemplateFolder.Location = new Point(258, 275);
            lblPathTemplateFolder.Name = "lblPathTemplateFolder";
            lblPathTemplateFolder.Size = new Size(136, 19);
            lblPathTemplateFolder.TabIndex = 21;
            lblPathTemplateFolder.Text = "Template Folder Path";
            // 
            // lblPathTransTemplate
            // 
            lblPathTransTemplate.AutoSize = true;
            lblPathTransTemplate.BorderStyle = BorderStyle.FixedSingle;
            lblPathTransTemplate.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPathTransTemplate.Location = new Point(258, 83);
            lblPathTransTemplate.Name = "lblPathTransTemplate";
            lblPathTransTemplate.Size = new Size(158, 19);
            lblPathTransTemplate.TabIndex = 20;
            lblPathTransTemplate.Text = "Transcript Template Path";
            // 
            // lblTemplateFolder
            // 
            lblTemplateFolder.AutoSize = true;
            lblTemplateFolder.Location = new Point(30, 272);
            lblTemplateFolder.Name = "lblTemplateFolder";
            lblTemplateFolder.Size = new Size(124, 20);
            lblTemplateFolder.TabIndex = 19;
            lblTemplateFolder.TabStop = true;
            lblTemplateFolder.Text = "Template Folder :";
            lblTemplateFolder.LinkClicked += lblTemplateFolder_LinkClicked;
            // 
            // lblCourseRoleTemplate
            // 
            lblCourseRoleTemplate.AutoSize = true;
            lblCourseRoleTemplate.Location = new Point(30, 130);
            lblCourseRoleTemplate.Name = "lblCourseRoleTemplate";
            lblCourseRoleTemplate.Size = new Size(161, 20);
            lblCourseRoleTemplate.TabIndex = 16;
            lblCourseRoleTemplate.TabStop = true;
            lblCourseRoleTemplate.Text = "Course Role Template :";
            lblCourseRoleTemplate.LinkClicked += lblCourseRoleTemplate_LinkClicked;
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
            // tabExit
            // 
            tabExit.Location = new Point(4, 29);
            tabExit.Name = "tabExit";
            tabExit.Size = new Size(1574, 690);
            tabExit.TabIndex = 5;
            tabExit.Text = "Exit";
            tabExit.UseVisualStyleBackColor = true;
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
            // btnPrintEnglishCourseRole
            // 
            btnPrintEnglishCourseRole.Location = new Point(320, 120);
            btnPrintEnglishCourseRole.Name = "btnPrintEnglishCourseRole";
            btnPrintEnglishCourseRole.Size = new Size(250, 29);
            btnPrintEnglishCourseRole.TabIndex = 17;
            btnPrintEnglishCourseRole.Text = "Print English Course Role";
            btnPrintEnglishCourseRole.UseVisualStyleBackColor = true;
            btnPrintEnglishCourseRole.Click += btnPrintEnglishCourseRole_Click;
            // 
            // btnPrintEnglishTranscript
            // 
            btnPrintEnglishTranscript.Location = new Point(320, 40);
            btnPrintEnglishTranscript.Name = "btnPrintEnglishTranscript";
            btnPrintEnglishTranscript.Size = new Size(250, 29);
            btnPrintEnglishTranscript.TabIndex = 16;
            btnPrintEnglishTranscript.Text = "Print English Transcript";
            btnPrintEnglishTranscript.UseVisualStyleBackColor = true;
            btnPrintEnglishTranscript.Click += btnPrintEnglishTranscript_Click;
            // 
            // frmTranscriptOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 753);
            Controls.Add(toolStripBottom);
            Controls.Add(tabControl1);
            Name = "frmTranscriptOptions";
            Load += frmTranscriptOptions_Load;
            Resize += frmTranscriptOptions_Resize;
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
        private Button btnPrintTranscript;
        private LinkLabel lblT;
        private LinkLabel lblCourseRoleTemplate;
        private Label lblPathTransTemplate;
        private LinkLabel lblTemplateFolder;
        private Label lblPathTemplateFolder;
        private Button btnPrintCourseRole;
        private Label lblPathCourseRoleTemplate;
        private Label lblLanguage;
        private Label lblRestartMsg;
        private ComboBox cmbInterfaceLanguage;
        private TabPage tabExit;
        private Label lblPathDocumentFolder;
        private LinkLabel lblDocumentFolder;
        private Label lblPathEnglishCourseRoleTemplate;
        private Label lblPathEnglishTranscriptTemplate;
        private LinkLabel lblEnglishCourseRoleTemplate;
        private LinkLabel lblEnglishTranscriptTemplate;
        private Button btnPrintEnglishCourseRole;
        private Button btnPrintEnglishTranscript;
    }
}