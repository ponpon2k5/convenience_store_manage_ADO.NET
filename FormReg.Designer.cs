namespace Convenience_Store_Management
{
    partial class FormReg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool
        disposing)
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
            sdt_text = new TextBox();
            label = new Label();
            manv_text = new TextBox();
            manhanvien_label = new Label();
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
            cbShowPwd.CheckedChanged += cbShowPwd_CheckedChanged;
            //
            // btnLogin
            //
            btnLogin.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(122, 400);
            btnLogin.Margin = new Padding(2, 3, 2, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(109, 39);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Sign up";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            //
            // btnExit
            //
            btnExit.Font = new Font("Franklin Gothic Medium Cond", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(355, 400);
            btnExit.Margin = new Padding(2, 3, 2, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(68, 39);
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
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(747, 96);
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
            NhanVienCb.Location = new Point(122, 257);
            NhanVienCb.Name = "NhanVienCb";
            NhanVienCb.Size = new Size(97, 24);
            NhanVienCb.TabIndex = 10;
            NhanVienCb.Text = "Nhân viên";
            NhanVienCb.UseVisualStyleBackColor = true;
            NhanVienCb.CheckedChanged += NhanVienCb_CheckedChanged;
            //
            // KhachHangCb
            //
            KhachHangCb.AutoSize = true;
            KhachHangCb.Location = new Point(355, 257);
            KhachHangCb.Name = "KhachHangCb";
            KhachHangCb.Size = new Size(111, 24);
            KhachHangCb.TabIndex = 11;
            KhachHangCb.Text = "Khách Hàng";
            KhachHangCb.UseVisualStyleBackColor = true;
            KhachHangCb.CheckedChanged += KhachHangCb_CheckedChanged;
            //
            // sdt_text
            //
            sdt_text.Location = new Point(266, 297);
            sdt_text.Margin = new Padding(2, 3, 2, 3);
            sdt_text.Name = "sdt_text";
            sdt_text.Size = new Size(157, 27);
            sdt_text.TabIndex = 13;
            //
            // label
            //
            label.AutoSize = true;
            label.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(122, 297);
            label.Margin = new Padding(2, 0, 2, 0);
            label.Name = "label";
            label.Size = new Size(54, 34);
            label.TabIndex = 12;
            label.Text = "SDT";
            label.TextAlign = ContentAlignment.MiddleCenter;
            //
            // manv_text
            //
            manv_text.Location = new Point(266, 342);
            manv_text.Margin = new Padding(2, 3, 2, 3);
            manv_text.Name = "manv_text";
            manv_text.Size = new Size(157, 27);
            manv_text.TabIndex = 15;
            //
            // manhanvien_label
            //
            manhanvien_label.AutoSize = true;
            manhanvien_label.Font = new Font("Franklin Gothic Medium Cond", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            manhanvien_label.Location = new Point(122, 342);
            manhanvien_label.Margin = new Padding(2, 0, 2, 0);
            manhanvien_label.Name = "manhanvien_label";
            manhanvien_label.Size = new Size(78, 34);
            manhanvien_label.TabIndex = 14;
            manhanvien_label.Text = "Mã NV";
            manhanvien_label.TextAlign = ContentAlignment.MiddleCenter;
            //
            // FormReg
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 494);
            Controls.Add(manv_text);
            Controls.Add(manhanvien_label);
            Controls.Add(sdt_text);
            Controls.Add(label);
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
            Name = "FormReg";
            Text = "FormReg";
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
        private TextBox sdt_text;
        private Label label;
        private TextBox manv_text;
        private Label manhanvien_label;
    }
}