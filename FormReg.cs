using System;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer; // Make sure to include your BLL namespace

namespace Convenience_Store_Management
{
    public partial class FormReg : Form
    {
        private BLTaiKhoan blTaiKhoan = new BLTaiKhoan(); // Instantiate the BLL

        public FormReg()
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

        private void btnLogin_Click(object sender, EventArgs e) // This is the "Sign up" button
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
                MessageBox.Show("Vui lòng chọn loại tài khoản (Nhân viên hoặc Khách hàng).", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (blTaiKhoan.KiemTraTonTaiTenDangNhap(username, ref error))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Step 1: Create the account in TaiKhoan table
            if (blTaiKhoan.ThemTaiKhoan(username, password, userRole, ref error))
            {
                // Step 2: If account creation is successful, add details to specific role table
                bool detailAdded = false;
                if (userRole == "NhanVien")
                {
                    // For simplicity, generate a simple employee ID or prompt for it
                    string maNhanVien = "NV" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(0, 8); // Example ID
                    // You might want to collect more details like TenNhanVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai
                    // For now, using placeholders or empty strings
                    detailAdded = blTaiKhoan.ThemNhanVien(maNhanVien, username, "New Employee", null, "", "", "", ref error);
                }
                else if (userRole == "KhachHang")
                {
                    // For customer, assume username is the phone number for simplicity, or prompt for SDT
                    // In a real app, you'd likely have a separate input for SDT
                    string sdtKhachHang = username; // Assuming username is phone number for customer registration
                    detailAdded = blTaiKhoan.ThemKhachHang(sdtKhachHang, username, "New Customer", "", ref error);
                }

                if (detailAdded)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close(); // Close registration form after successful registration
                }
                else
                {
                    // If detail addition fails, you might want to rollback the TaiKhoan creation
                    // This requires a transaction or a separate deletion method in BLL/DAL.
                    // For now, just show the error.
                    MessageBox.Show("Đăng ký tài khoản thành công nhưng không thể thêm thông tin chi tiết: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}