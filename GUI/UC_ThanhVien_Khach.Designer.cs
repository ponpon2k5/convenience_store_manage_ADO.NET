namespace Convenience_Store_Management.GUI
{
    partial class UC_ThanhVien_Khach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentUsername = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label(); // Sửa lỗi ở đây: Đảm bảo đây là Label
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.btnChangeCredentials = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 11.9999981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sans Serif Collection", 11.9999981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label2.Location = new System.Drawing.Point(50, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu cũ:";
            //
            // txtCurrentUsername
            //
            this.txtCurrentUsername.Location = new System.Drawing.Point(300, 50);
            this.txtCurrentUsername.Name = "txtCurrentUsername";
            this.txtCurrentUsername.ReadOnly = true;
            this.txtCurrentUsername.Size = new System.Drawing.Size(250, 27);
            this.txtCurrentUsername.TabIndex = 2;
            //
            // txtCurrentPassword
            //
            this.txtCurrentPassword.Location = new System.Drawing.Point(300, 110);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(250, 27);
            this.txtCurrentPassword.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sans Serif Collection", 11.9999981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label3.Location = new System.Drawing.Point(50, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên đăng nhập mới:";
            this.label3.Visible = false; // Ẩn điều khiển này
            //
            // txtNewUsername
            //
            this.txtNewUsername.Location = new System.Drawing.Point(300, 170);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(250, 27);
            this.txtNewUsername.TabIndex = 5;
            this.txtNewUsername.Visible = false; // Ẩn điều khiển này
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sans Serif Collection", 11.9999981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label4.Location = new System.Drawing.Point(50, 170); // Di chuyển lên vị trí cũ của label3
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mật khẩu mới:";
            //
            // txtNewPassword
            //
            this.txtNewPassword.Location = new System.Drawing.Point(300, 170); // Di chuyển lên vị trí cũ của txtNewUsername
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(250, 27);
            this.txtNewPassword.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sans Serif Collection", 11.9999981F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.label5.Location = new System.Drawing.Point(50, 230); // Di chuyển lên vị trí cũ của label5 (tức label4 ban đầu)
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 39);
            this.label5.TabIndex = 8;
            this.label5.Text = "Xác nhận mật khẩu:";
            //
            // txtConfirmNewPassword
            //
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(300, 230); // Di chuyển lên vị trí cũ của txtConfirmNewPassword (tức txtNewPassword ban đầu)
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = '*';
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(250, 27);
            this.txtConfirmNewPassword.TabIndex = 9;
            //
            // btnChangeCredentials
            //
            this.btnChangeCredentials.Font = new System.Drawing.Font("Sans Serif Collection", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.btnChangeCredentials.Location = new System.Drawing.Point(300, 290); // Di chuyển lên
            this.btnChangeCredentials.Name = "btnChangeCredentials";
            this.btnChangeCredentials.Size = new System.Drawing.Size(150, 40);
            this.btnChangeCredentials.TabIndex = 10;
            this.btnChangeCredentials.Text = "Đổi mật khẩu";
            this.btnChangeCredentials.UseVisualStyleBackColor = true;
            this.btnChangeCredentials.Click += new System.EventHandler(this.btnChangeCredentials_Click);
            //
            // chkShowPassword
            //
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(560, 170); // Di chuyển lên
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(121, 24);
            this.chkShowPassword.TabIndex = 11;
            this.chkShowPassword.Text = "Hiển thị mật khẩu";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            //
            // UC_ThanhVien_Khach
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.btnChangeCredentials);
            this.Controls.Add(this.txtConfirmNewPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.txtCurrentUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UC_ThanhVien_Khach";
            this.Size = new System.Drawing.Size(858, 541);
            this.Load += new System.EventHandler(this.UC_ThanhVien_Khach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentUsername;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5; // Đã sửa lỗi ở đây
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmNewPassword;
        private System.Windows.Forms.Button btnChangeCredentials;
        private System.Windows.Forms.CheckBox chkShowPassword;
    }
}