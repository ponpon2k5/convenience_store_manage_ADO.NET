﻿namespace Convenience_Store_Management
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
            NhanVienCb = new CheckBox();
            KhachHangCb = new CheckBox();
            button1 = new Button(); // This is the "Sign up" button
            panel1.SuspendLayout();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(122, 136);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 34);
            label1.TabIndex = 0;
            label1.Text = "Account name";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(122, 199);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(109, 34);
            label2.TabIndex = 1;
            label2.Text = "Password";
            //
            // txtAccount
            //
            txtAccount.Location = new Point(266, 133);
            txtAccount.Margin = new Padding(2, 3, 2, 3);
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(157, 27);
            txtAccount.TabIndex = 2;
            //
            // txtPwd
            //
            txtPwd.Location = new Point(266, 199);
            txtPwd.Margin = new Padding(2, 3, 2, 3);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new Size(157, 27);
            txtPwd.TabIndex = 3;
            //
            // cbShowPwd
            //
            cbShowPwd.AutoSize = true;
            cbShowPwd.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbShowPwd.Location = new Point(486, 201);
            cbShowPwd.Margin = new Padding(2, 3, 2, 3);
            cbShowPwd.Name = "cbShowPwd";
            cbShowPwd.Size = new Size(189, 38);
            cbShowPwd.TabIndex = 4;
            cbShowPwd.Text = "Show password";
            cbShowPwd.UseVisualStyleBackColor = true;
            this.cbShowPwd.CheckedChanged += new System.EventHandler(this.cbShowPwd_CheckedChanged); // Event added
            //
            // btnLogin
            //
            btnLogin.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(108, 326);
            btnLogin.Margin = new Padding(2, 3, 2, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(70, 37);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click); // Event added
            //
            // btnExit
            //
            btnExit.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(486, 324);
            btnExit.Margin = new Padding(2, 3, 2, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(68, 41);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click); // Event added
            //
            // panel1
            //
            panel1.BackColor = Color.Red;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(641, 96);
            panel1.TabIndex = 7;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(22, 32);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(307, 39);
            label3.TabIndex = 0;
            label3.Text = "Convenience Store";
            //
            // NhanVienCb
            //
            NhanVienCb.AutoSize = true;
            NhanVienCb.Location = new Point(122, 258);
            NhanVienCb.Name = "NhanVienCb";
            NhanVienCb.Size = new Size(97, 24);
            NhanVienCb.TabIndex = 11;
            NhanVienCb.Text = "Nhân viên";
            NhanVienCb.UseVisualStyleBackColor = true;
            this.NhanVienCb.CheckedChanged += new System.EventHandler(this.NhanVienCb_CheckedChanged); // Event added
            //
            // KhachHangCb
            //
            KhachHangCb.AutoSize = true;
            KhachHangCb.Location = new Point(354, 258);
            KhachHangCb.Name = "KhachHangCb";
            KhachHangCb.Size = new Size(111, 24);
            KhachHangCb.TabIndex = 12;
            KhachHangCb.Text = "Khách Hàng";
            KhachHangCb.UseVisualStyleBackColor = true;
            this.KhachHangCb.CheckedChanged += new System.EventHandler(this.KhachHangCb_CheckedChanged); // Event added
            //
            // button1
            //
            button1.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(285, 326);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(108, 37);
            button1.TabIndex = 13;
            button1.Text = "Sign up";
            button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click); // Event added
            //
            // FormLogin
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 433);
            Controls.Add(button1);
            Controls.Add(KhachHangCb);
            Controls.Add(NhanVienCb);
            Controls.Add(panel1);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(cbShowPwd);
            Controls.Add(txtPwd);
            Controls.Add(txtAccount);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
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
        private CheckBox NhanVienCb;
        private CheckBox KhachHangCb;
        private Button button1;
    }
}