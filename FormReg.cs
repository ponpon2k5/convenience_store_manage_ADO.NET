using System;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer; // Ensure this namespace is correct
using System.Linq; // Added for .All(char.IsDigit)

namespace Convenience_Store_Management
{
    public partial class FormReg : Form
    {
        private BLTaiKhoan blTaiKhoan = new BLTaiKhoan(); // Initialize BLL

        public FormReg()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*'; // Hide password by default
            NhanVienCb.Checked = true; // Set Employee as the default selected role

            // Initialize visibility of input fields based on the default selected role
            UpdateVisibilityBasedOnRole();
        }

        // Helper method to update visibility of identifier input fields
        private void UpdateVisibilityBasedOnRole()
        {
            if (NhanVienCb.Checked)
            {
                manv_text.Visible = true;
                manhanvien_label.Visible = true;
                sdt_text.Visible = true; // Employee needs SDT as well
                label.Visible = true;     // Label for SDT
                manv_text.Text = ""; // Clear text when switching
                sdt_text.Text = ""; // Clear text when switching
            }
            else if (KhachHangCb.Checked)
            {
                manv_text.Visible = false;
                manhanvien_label.Visible = false;
                sdt_text.Visible = true;
                label.Visible = true;
                sdt_text.Text = ""; // Clear text when switching
                manv_text.Text = ""; // Clear text when switching
            }
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

        private void btnLogin_Click(object sender, EventArgs e) // This is your "Sign up" button
        {
            string username = txtAccount.Text.Trim(); // Account name (TenDangNhap)
            string password = txtPwd.Text.Trim();
            string identifier = ""; // This will hold MaNhanVien or SDTKhachHang (for DANG_NHAP table)
            string userRole = "";
            string error = "";
            bool detailAdded = false;

            // Determine user role and corresponding identifier
            if (NhanVienCb.Checked)
            {
                userRole = "Employee";
            }
            else if (KhachHangCb.Checked)
            {
                userRole = "Customer";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản (Nhân viên hoặc Khách hàng).", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate basic inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate identifier field(s) based on role
            if (userRole == "Employee")
            {
                // Employee needs MaNhanVien and SdtNV
                if (string.IsNullOrEmpty(manv_text.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập Mã NV của bạn.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(sdt_text.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập SĐT của nhân viên.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (sdt_text.Text.Trim().Length != 10 || !sdt_text.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại nhân viên phải có đúng 10 chữ số và chỉ chứa số.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                identifier = manv_text.Text.Trim(); // MaNhanVien is the identifier for DANG_NHAP table
            }
            else if (userRole == "Customer")
            {
                // Customer needs only SDTKhachHang
                if (string.IsNullOrEmpty(sdt_text.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập SĐT của khách hàng.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (sdt_text.Text.Trim().Length != 10 || !sdt_text.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại khách hàng phải có đúng 10 chữ số và chỉ chứa số.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                identifier = sdt_text.Text.Trim(); // SDTKhachHang is the identifier for DANG_NHAP table
            }

            // Check if username already exists to prevent duplicate registrations
            if (blTaiKhoan.KiemTraTonTaiTenDangNhap(username, ref error))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Step 1: Add user details to NHAN_VIEN or KHACH_HANG table first
                if (userRole == "Employee")
                {
                    // For employee, use manv_text for MaNhanVien and sdt_text for SdtNV
                    // Use username as a placeholder for full name if not provided in UI.
                    string employeeMaNhanVien = manv_text.Text.Trim();
                    string employeeFullName = username; // Placeholder for HoTenNV
                    string employeePhoneNumber = sdt_text.Text.Trim();

                    detailAdded = blTaiKhoan.ThemNhanVien(employeeMaNhanVien, employeeFullName, employeePhoneNumber, ref error);
                }
                else if (userRole == "Customer")
                {
                    // For customer, use sdt_text for SDT
                    // Use username as a placeholder for customer name if not provided in UI.
                    string customerPhoneNumber = sdt_text.Text.Trim();
                    string customerName = username; // Placeholder for TenKH
                    DateTime? ngaySinh = null; // NgaySinh is not provided in the UI.

                    detailAdded = blTaiKhoan.ThemKhachHang(customerPhoneNumber, customerName, ngaySinh, ref error);
                }

                // If adding user details fails, stop the registration process
                if (!detailAdded)
                {
                    MessageBox.Show("Không thể thêm thông tin chi tiết người dùng: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Create the login account in DANG_NHAP table
                // The 'identifier' variable correctly holds MaNhanVien for Employee or SDTKhachHang for Customer
                if (blTaiKhoan.ThemTaiKhoan(username, password, userRole, identifier, ref error))
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close(); // Close the registration form after successful registration
                }
                else
                {
                    // If account creation fails, consider implementing rollback logic here
                    // (e.g., deleting the user details added in Step 1 from NHAN_VIEN/KHACH_HANG).
                    // For now, we will just show the error.
                    MessageBox.Show("Đăng ký tài khoản thất bại: " + error + "\nBạn có thể cần xóa thông tin chi tiết đã đăng ký nếu không có tài khoản liên kết.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handlers for checkboxes to ensure only one role is selected and update UI fields
        private void NhanVienCb_CheckedChanged(object sender, EventArgs e)
        {
            if (NhanVienCb.Checked)
            {
                KhachHangCb.Checked = false;
                UpdateVisibilityBasedOnRole();
            }
        }

        private void KhachHangCb_CheckedChanged(object sender, EventArgs e)
        {
            if (KhachHangCb.Checked)
            {
                NhanVienCb.Checked = false;
                UpdateVisibilityBasedOnRole();
            }
        }
    }
}