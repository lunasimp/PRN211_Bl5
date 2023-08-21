namespace Shoe_Store
{
    partial class ResetPassword
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
            label1 = new Label();
            txtMail = new TextBox();
            btnCheck = new Button();
            gbPass = new GroupBox();
            btnSave = new Button();
            txtConfirmPass = new TextBox();
            txtNewPass = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnBack = new Button();
            gbPass.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 16);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Input email:";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(98, 12);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(218, 23);
            txtMail.TabIndex = 1;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(338, 12);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(75, 23);
            btnCheck.TabIndex = 2;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // gbPass
            // 
            gbPass.Controls.Add(btnSave);
            gbPass.Controls.Add(txtConfirmPass);
            gbPass.Controls.Add(txtNewPass);
            gbPass.Controls.Add(label3);
            gbPass.Controls.Add(label2);
            gbPass.Location = new Point(13, 53);
            gbPass.Name = "gbPass";
            gbPass.Size = new Size(400, 160);
            gbPass.TabIndex = 3;
            gbPass.TabStop = false;
            gbPass.Text = "New password";
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(298, 106);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Enabled = false;
            txtConfirmPass.Location = new Point(198, 62);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(175, 23);
            txtConfirmPass.TabIndex = 5;
            // 
            // txtNewPass
            // 
            txtNewPass.Enabled = false;
            txtNewPass.Location = new Point(198, 28);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(175, 23);
            txtNewPass.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 65);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 1;
            label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 31);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 0;
            label2.Text = "New Password:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(148, 230);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(128, 23);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back to login";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 265);
            Controls.Add(btnBack);
            Controls.Add(gbPass);
            Controls.Add(btnCheck);
            Controls.Add(txtMail);
            Controls.Add(label1);
            Name = "ResetPassword";
            Text = "ResetPassword";
            gbPass.ResumeLayout(false);
            gbPass.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMail;
        private Button btnCheck;
        private GroupBox gbPass;
        private Button btnSave;
        private TextBox txtConfirmPass;
        private TextBox txtNewPass;
        private Label label3;
        private Label label2;
        private Button btnBack;
    }
}