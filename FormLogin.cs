using System;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer; // Make sure to include your BLL namespace

namespace Convenience_Store_Management
{
    public partial class FormLogin : Form
    {
        private BLTaiKhoan blTaiKhoan = new BLTaiKhoan(); // Instantiate the BLL

        public FormLogin()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*'; // Hide password by default
            NhanVienCb.Checked = true; // Set default selection for role
        }

        private void cbShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            if (cbShowPwd.Checked)
            {
                txtPwd.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPwd.PasswordChar = '*'; // Hide password
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtAccount.Text.Trim();
            string password = txtPwd.Text.Trim();
            string userRole = "";
            string error = "";

            if (NhanVienCb.Checked)
            {
                userRole = "NhanVien";
            }
            else if (KhachHangCb.Checked)
            {
                userRole = "KhachHang";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản (Nhân viên hoặc Khách hàng).", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (blTaiKhoan.KiemTraDangNhap(username, password, userRole, ref error))
            {
                MessageBox.Show($"Đăng nhập thành công với vai trò: {userRole}!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (userRole == "NhanVien")
                {
                    // You might want to pass the employee ID to the NhanVien form
                    // For now, just open the form
                    FormNhanVien formNhanVien = new FormNhanVien();
                    formNhanVien.Show();
                }
                else if (userRole == "KhachHang")
                {
                    // You might want to pass the customer ID (phone number) to the KhachHang form
                    FormKhachHang formKhachHang = new FormKhachHang();
                    formKhachHang.Show();
                }
                this.Hide(); // Hide the login form
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc bạn chọn sai loại tài khoản!\n" + error, "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Add event handlers for checkboxes to ensure only one is selected
        private void NhanVienCb_CheckedChanged(object sender, EventArgs e)
        {
            if (NhanVienCb.Checked)
            {
                KhachHangCb.Checked = false;
            }
        }

        private void KhachHangCb_CheckedChanged(object sender, EventArgs e)
        {
            if (KhachHangCb.Checked)
            {
                NhanVienCb.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) // This is the "Sign up" button
        {
            FormReg formReg = new FormReg();
            formReg.Show();
            this.Hide(); // Hide the login form when opening registration
        }
    }
}