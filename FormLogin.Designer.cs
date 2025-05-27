namespace Convenience_Store_Management
{
    partial class FormLogin
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
            label2 = new Label();
            txtAccount = new TextBox();
            txtPwd = new TextBox();
            cbShowPwd = new CheckBox();
            btnLogin = new Button();
            btnExit = new Button();
            panel1 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(153, 143);
            label1.Name = "label1";
            label1.Size = new Size(124, 26);
            label1.TabIndex = 0;
            label1.Text = "Account name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(153, 209);
            label2.Name = "label2";
            label2.Size = new Size(86, 26);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // txtAccount
            // 
            txtAccount.Location = new Point(332, 140);
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(195, 22);
            txtAccount.TabIndex = 2;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(332, 209);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(195, 22);
            txtPwd.TabIndex = 3;
            // 
            // cbShowPwd
            // 
            cbShowPwd.AutoSize = true;
            cbShowPwd.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbShowPwd.Location = new Point(608, 211);
            cbShowPwd.Name = "cbShowPwd";
            cbShowPwd.Size = new Size(152, 30);
            cbShowPwd.TabIndex = 4;
            cbShowPwd.Text = "Show password";
            cbShowPwd.UseVisualStyleBackColor = true;
            cbShowPwd.CheckedChanged += cbShowPwd_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(153, 313);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(88, 28);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(442, 313);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 28);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 101);
            panel1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("ITC Avant Garde Std XLt", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(28, 34);
            label3.Name = "label3";
            label3.Size = new Size(257, 33);
            label3.TabIndex = 0;
            label3.Text = "Convenience Store";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 455);
            Controls.Add(panel1);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(cbShowPwd);
            Controls.Add(txtPwd);
            Controls.Add(txtAccount);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "FormLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtAccount;
        private TextBox txtPwd;
        private CheckBox cbShowPwd;
        private Button btnLogin;
        private Button btnExit;
        private Panel panel1;
        private Label label3;
    }
}