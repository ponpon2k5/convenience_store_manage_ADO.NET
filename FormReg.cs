// FormReg.cs
using System;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer;
using System.Linq; // Added for .All(char.IsDigit)

namespace Convenience_Store_Management
{
    public partial class FormReg : Form
    {
        private BLTaiKhoan blTaiKhoan = new BLTaiKhoan();

        public FormReg()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*';
            NhanVienCb.Checked = true;

            UpdateVisibilityBasedOnRole();
        }

        private void UpdateVisibilityBasedOnRole()
        {
            if (NhanVienCb.Checked)
            {
                manv_text.Visible = true;
                manhanvien_label.Visible = true;
                sdt_text.Visible = true;
                label.Visible = true;
                manv_text.Text = "";
                sdt_text.Text = "";
            }
            else if (KhachHangCb.Checked)
            {
                manv_text.Visible = false;
                manhanvien_label.Visible = false;
                sdt_text.Visible = true;
                label.Visible = true;
                sdt_text.Text = "";
                manv_text.Text = "";
            }
        }

        private void cbShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPwd.Checked)
            {
                txtPwd.PasswordChar = '\0';
            }
            else
            {
                txtPwd.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) // This is your "Sign up" button
        {
            string username = txtAccount.Text.Trim();
            string password = txtPwd.Text.Trim();
            string identifier = "";
            string userRole = "";
            string error = "";
            bool detailAdded = false;

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

            // Add password length validation
            if (password.Length < 7) //
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 7 ký tự.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate identifier field(s) based on role
            if (userRole == "Employee")
            {
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
                // Validate phone number length for employee
                if (sdt_text.Text.Trim().Length != 10 || !sdt_text.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại nhân viên phải có đúng 10 chữ số và chỉ chứa số.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                identifier = manv_text.Text.Trim();
            }
            else if (userRole == "Customer")
            {
                if (string.IsNullOrEmpty(sdt_text.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng nhập SĐT của khách hàng.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Validate phone number length for customer
                if (sdt_text.Text.Trim().Length != 10 || !sdt_text.Text.Trim().All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại khách hàng phải có đúng 10 chữ số và chỉ chứa số.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                identifier = sdt_text.Text.Trim();
            }

            // Check if username already exists to prevent duplicate registrations
            if (blTaiKhoan.KiemTraTonTaiTenDangNhap(username, ref error))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (userRole == "Employee")
                {
                    string employeeMaNhanVien = manv_text.Text.Trim();
                    string employeeFullName = username;
                    string employeePhoneNumber = sdt_text.Text.Trim();

                    detailAdded = blTaiKhoan.ThemNhanVien(employeeMaNhanVien, employeeFullName, employeePhoneNumber, ref error);
                }
                else if (userRole == "Customer")
                {
                    string customerPhoneNumber = sdt_text.Text.Trim();
                    string customerName = username;
                    DateTime? ngaySinh = null;

                    detailAdded = blTaiKhoan.ThemKhachHang(customerPhoneNumber, customerName, ngaySinh, ref error);
                }

                if (!detailAdded)
                {
                    MessageBox.Show("Không thể thêm thông tin chi tiết người dùng: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (blTaiKhoan.ThemTaiKhoan(username, password, userRole, identifier, ref error))
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close();
                }
                else
                {
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