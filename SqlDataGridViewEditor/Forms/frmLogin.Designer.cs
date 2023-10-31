namespace SqlDataGridViewEditor
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmdOK = new Button();
            cmdCancel = new Button();
            txtPassword = new TextBox();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // cmdOK
            // 
            cmdOK.Location = new Point(218, 63);
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new Size(94, 29);
            cmdOK.TabIndex = 1;
            cmdOK.Text = "O.K.";
            cmdOK.UseVisualStyleBackColor = true;
            cmdOK.Click += cmdOK_Click;
            // 
            // cmdCancel
            // 
            cmdCancel.Location = new Point(26, 63);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.Size = new Size(94, 29);
            cmdCancel.TabIndex = 2;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = true;
            cmdCancel.Click += cmdCancel_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(133, 20);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(149, 27);
            txtPassword.TabIndex = 0;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(26, 20);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password :";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 135);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(cmdCancel);
            Controls.Add(cmdOK);
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmdOK;
        private Button cmdCancel;
        private TextBox txtPassword;
        private Label lblPassword;
    }
}