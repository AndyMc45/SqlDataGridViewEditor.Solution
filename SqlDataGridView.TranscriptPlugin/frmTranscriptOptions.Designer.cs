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
            tabOptions = new TabPage();
            btnPrintEnglishTranscript = new Button();
            btnPrintTransscript = new Button();
            lblCourseRoleTemplateEnglish = new Label();
            lblCourseRoleTemplate = new Label();
            lblTranscriptTemplateEnglish = new Label();
            lblTranscriptTemplate = new Label();
            lblTemplateFolder = new Label();
            tabStudent = new TabPage();
            dgvStudent = new DataGridView();
            tabTranscript = new TabPage();
            dgvTranscript = new DataGridView();
            tabRequirements = new TabPage();
            dgvRequirements = new DataGridView();
            toolStripBottom = new ToolStrip();
            toolStripBtnNarrow = new ToolStripButton();
            tabControl1.SuspendLayout();
            tabOptions.SuspendLayout();
            tabStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            tabTranscript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTranscript).BeginInit();
            tabRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequirements).BeginInit();
            toolStripBottom.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabOptions);
            tabControl1.Controls.Add(tabStudent);
            tabControl1.Controls.Add(tabTranscript);
            tabControl1.Controls.Add(tabRequirements);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1182, 753);
            tabControl1.TabIndex = 7;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabOptions
            // 
            tabOptions.Controls.Add(btnPrintEnglishTranscript);
            tabOptions.Controls.Add(btnPrintTransscript);
            tabOptions.Controls.Add(lblCourseRoleTemplateEnglish);
            tabOptions.Controls.Add(lblCourseRoleTemplate);
            tabOptions.Controls.Add(lblTranscriptTemplateEnglish);
            tabOptions.Controls.Add(lblTranscriptTemplate);
            tabOptions.Controls.Add(lblTemplateFolder);
            tabOptions.Location = new Point(4, 29);
            tabOptions.Name = "tabOptions";
            tabOptions.Padding = new Padding(3);
            tabOptions.Size = new Size(1174, 720);
            tabOptions.TabIndex = 0;
            tabOptions.Text = "Options";
            tabOptions.UseVisualStyleBackColor = true;
            // 
            // btnPrintEnglishTranscript
            // 
            btnPrintEnglishTranscript.Location = new Point(32, 124);
            btnPrintEnglishTranscript.Name = "btnPrintEnglishTranscript";
            btnPrintEnglishTranscript.Size = new Size(200, 29);
            btnPrintEnglishTranscript.TabIndex = 13;
            btnPrintEnglishTranscript.Text = "Print English Transcript";
            btnPrintEnglishTranscript.UseVisualStyleBackColor = true;
            // 
            // btnPrintTransscript
            // 
            btnPrintTransscript.Location = new Point(32, 71);
            btnPrintTransscript.Name = "btnPrintTransscript";
            btnPrintTransscript.Size = new Size(200, 29);
            btnPrintTransscript.TabIndex = 12;
            btnPrintTransscript.Text = "Print Chinese Transcript";
            btnPrintTransscript.UseVisualStyleBackColor = true;
            // 
            // lblCourseRoleTemplateEnglish
            // 
            lblCourseRoleTemplateEnglish.AutoSize = true;
            lblCourseRoleTemplateEnglish.Location = new Point(245, 240);
            lblCourseRoleTemplateEnglish.Name = "lblCourseRoleTemplateEnglish";
            lblCourseRoleTemplateEnglish.Size = new Size(215, 20);
            lblCourseRoleTemplateEnglish.TabIndex = 9;
            lblCourseRoleTemplateEnglish.Text = "Course Role Template - English";
            // 
            // lblCourseRoleTemplate
            // 
            lblCourseRoleTemplate.AutoSize = true;
            lblCourseRoleTemplate.Location = new Point(245, 179);
            lblCourseRoleTemplate.Name = "lblCourseRoleTemplate";
            lblCourseRoleTemplate.Size = new Size(154, 20);
            lblCourseRoleTemplate.TabIndex = 8;
            lblCourseRoleTemplate.Text = "Course Role Template";
            // 
            // lblTranscriptTemplateEnglish
            // 
            lblTranscriptTemplateEnglish.AutoSize = true;
            lblTranscriptTemplateEnglish.Location = new Point(245, 128);
            lblTranscriptTemplateEnglish.Name = "lblTranscriptTemplateEnglish";
            lblTranscriptTemplateEnglish.Size = new Size(200, 20);
            lblTranscriptTemplateEnglish.TabIndex = 7;
            lblTranscriptTemplateEnglish.Text = "Transcript Template - English";
            // 
            // lblTranscriptTemplate
            // 
            lblTranscriptTemplate.AutoSize = true;
            lblTranscriptTemplate.Location = new Point(245, 80);
            lblTranscriptTemplate.Name = "lblTranscriptTemplate";
            lblTranscriptTemplate.Size = new Size(139, 20);
            lblTranscriptTemplate.TabIndex = 6;
            lblTranscriptTemplate.Text = "Transcript Template";
            // 
            // lblTemplateFolder
            // 
            lblTemplateFolder.AutoSize = true;
            lblTemplateFolder.Location = new Point(32, 28);
            lblTemplateFolder.Name = "lblTemplateFolder";
            lblTemplateFolder.Size = new Size(117, 20);
            lblTemplateFolder.TabIndex = 5;
            lblTemplateFolder.Text = "Template Folder";
            // 
            // tabStudent
            // 
            tabStudent.Controls.Add(dgvStudent);
            tabStudent.Location = new Point(4, 29);
            tabStudent.Name = "tabStudent";
            tabStudent.Size = new Size(1174, 720);
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
            dgvStudent.Size = new Size(1174, 209);
            dgvStudent.TabIndex = 0;
            // 
            // tabTranscript
            // 
            tabTranscript.Controls.Add(dgvTranscript);
            tabTranscript.Location = new Point(4, 29);
            tabTranscript.Name = "tabTranscript";
            tabTranscript.Size = new Size(1174, 720);
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
            tabRequirements.Size = new Size(1174, 720);
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
            dgvRequirements.Size = new Size(1168, 714);
            dgvRequirements.TabIndex = 0;
            // 
            // toolStripBottom
            // 
            toolStripBottom.Dock = DockStyle.Bottom;
            toolStripBottom.ImageScalingSize = new Size(20, 20);
            toolStripBottom.Items.AddRange(new ToolStripItem[] { toolStripBtnNarrow });
            toolStripBottom.Location = new Point(0, 726);
            toolStripBottom.Name = "toolStripBottom";
            toolStripBottom.Size = new Size(1182, 27);
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
            // frmTranscriptOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(toolStripBottom);
            Controls.Add(tabControl1);
            Name = "frmTranscriptOptions";
            Text = "frmOptions";
            Load += frmTranscriptOptions_Load;
            tabControl1.ResumeLayout(false);
            tabOptions.ResumeLayout(false);
            tabOptions.PerformLayout();
            tabStudent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            tabTranscript.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTranscript).EndInit();
            tabRequirements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequirements).EndInit();
            toolStripBottom.ResumeLayout(false);
            toolStripBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TabControl tabControl1;
        private Label lblCourseRoleTemplateEnglish;
        private Label lblCourseRoleTemplate;
        private Label lblTranscriptTemplateEnglish;
        private Label lblTranscriptTemplate;
        private Label lblTemplateFolder;
        public TabPage tabOptions;
        public TabPage tabRequirements;
        public DataGridView dgvRequirements;
        private Button btnPrintTransscript;
        private TabPage tabTranscript;
        private Button btnPrintEnglishTranscript;
        private DataGridView dgvTranscript;
        private TabPage tabStudent;
        private DataGridView dgvStudent;
        private ToolStrip toolStripBottom;
        private ToolStripButton toolStripBtnNarrow;
    }
}