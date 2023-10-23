namespace SqlDataGridViewEditor.TranscriptPlugin
{
    partial class frmOptions
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
            lblTemplateFolder = new Label();
            lblTranscriptTemplate = new Label();
            lblTranscriptTemplateEnglish = new Label();
            lblCourseRoleTemplate = new Label();
            lblCourseRoleTemplateEnglish = new Label();
            lblSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTemplateFolder
            // 
            lblTemplateFolder.AutoSize = true;
            lblTemplateFolder.Location = new Point(38, 50);
            lblTemplateFolder.Name = "lblTemplateFolder";
            lblTemplateFolder.Size = new Size(117, 20);
            lblTemplateFolder.TabIndex = 0;
            lblTemplateFolder.Text = "Template Folder";
            lblTemplateFolder.Click += label1_Click;
            // 
            // lblTranscriptTemplate
            // 
            lblTranscriptTemplate.AutoSize = true;
            lblTranscriptTemplate.Location = new Point(38, 100);
            lblTranscriptTemplate.Name = "lblTranscriptTemplate";
            lblTranscriptTemplate.Size = new Size(139, 20);
            lblTranscriptTemplate.TabIndex = 1;
            lblTranscriptTemplate.Text = "Transcript Template";
            // 
            // lblTranscriptTemplateEnglish
            // 
            lblTranscriptTemplateEnglish.AutoSize = true;
            lblTranscriptTemplateEnglish.Location = new Point(38, 150);
            lblTranscriptTemplateEnglish.Name = "lblTranscriptTemplateEnglish";
            lblTranscriptTemplateEnglish.Size = new Size(200, 20);
            lblTranscriptTemplateEnglish.TabIndex = 2;
            lblTranscriptTemplateEnglish.Text = "Transcript Template - English";
            // 
            // lblCourseRoleTemplate
            // 
            lblCourseRoleTemplate.AutoSize = true;
            lblCourseRoleTemplate.Location = new Point(38, 200);
            lblCourseRoleTemplate.Name = "lblCourseRoleTemplate";
            lblCourseRoleTemplate.Size = new Size(154, 20);
            lblCourseRoleTemplate.TabIndex = 3;
            lblCourseRoleTemplate.Text = "Course Role Template";
            lblCourseRoleTemplate.Click += lblCourseRoleTemplate_Click;
            // 
            // lblCourseRoleTemplateEnglish
            // 
            lblCourseRoleTemplateEnglish.AutoSize = true;
            lblCourseRoleTemplateEnglish.Location = new Point(38, 250);
            lblCourseRoleTemplateEnglish.Name = "lblCourseRoleTemplateEnglish";
            lblCourseRoleTemplateEnglish.Size = new Size(215, 20);
            lblCourseRoleTemplateEnglish.TabIndex = 4;
            lblCourseRoleTemplateEnglish.Text = "Course Role Template - English";
            // 
            // lblSave
            // 
            lblSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblSave.Location = new Point(588, 390);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(94, 29);
            lblSave.TabIndex = 5;
            lblSave.Text = "Save";
            lblSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(708, 390);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 450);
            Controls.Add(btnCancel);
            Controls.Add(lblSave);
            Controls.Add(lblCourseRoleTemplateEnglish);
            Controls.Add(lblCourseRoleTemplate);
            Controls.Add(lblTranscriptTemplateEnglish);
            Controls.Add(lblTranscriptTemplate);
            Controls.Add(lblTemplateFolder);
            Name = "frmOptions";
            Text = "frmOptions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTemplateFolder;
        private Label lblTranscriptTemplate;
        private Label lblTranscriptTemplateEnglish;
        private Label lblCourseRoleTemplate;
        private Label lblCourseRoleTemplateEnglish;
        private Button lblSave;
        private Button btnCancel;
    }
}