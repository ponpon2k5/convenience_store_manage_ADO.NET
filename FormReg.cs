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
                sdt_text.Visible = false;
                label.Visible = false;
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
            string identifier = ""; // This will hold MaNhanVien or SDTKhachHang
            string userRole = "";
            string error = "";
            bool detailAdded = false;

            // Determine user role and corresponding identifier
            if (NhanVienCb.Checked)
            {
                userRole = "Employee";
                identifier = manv_text.Text.Trim(); // Get MaNhanVien from manv_text
            }
            else if (KhachHangCb.Checked)
            {
                userRole = "Customer";
                identifier = sdt_text.Text.Trim(); // Get SDTKhachHang from sdt_text
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

            // Validate identifier field
            if (string.IsNullOrEmpty(identifier))
            {
                MessageBox.Show($"Vui lòng nhập {(userRole == "Employee" ? "Mã NV" : "SĐT")} của bạn.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Additional validation for customer phone number (assuming it must be 10 digits and numeric)
            if (userRole == "Customer" && (identifier.Length != 10 || !identifier.All(char.IsDigit)))
            {
                MessageBox.Show("Số điện thoại khách hàng phải có đúng 10 chữ số và chỉ chứa số.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username already exists to prevent duplicate registrations
            if (blTaiKhoan.KiemTraTonTaiTenDangNhap(username, ref error))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Step 1: Add user details to NHAN_VIEN or KHACH_HANG table
                if (userRole == "Employee")
                {
                    // Assuming 'username' as a placeholder for the employee's full name.
                    // The employee's phone number (SdtNV) is not provided in the UI.
                    // Using a dummy phone number or trying to use MaNhanVien if it's a valid 10-digit number.
                    string employeeFullName = username; // Placeholder for full name
                    string employeePhoneNumber = "0123456789"; // Default dummy phone

                    // Attempt to use the identifier (MaNhanVien) as the phone number if it's a valid format.
                    if (identifier.Length == 10 && identifier.All(char.IsDigit))
                    {
                        employeePhoneNumber = identifier;
                    }
                    else if (!identifier.All(char.IsDigit))
                    {
                        // Inform the user if MaNhanVien is not a valid phone number format.
                        MessageBox.Show("Mã nhân viên chỉ được chứa số nếu bạn muốn sử dụng nó làm số điện thoại. Số điện thoại tạm thời sẽ là: " + employeePhoneNumber, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    detailAdded = blTaiKhoan.ThemNhanVien(identifier, employeeFullName, employeePhoneNumber, ref error);
                }
                else if (userRole == "Customer")
                {
                    // Assuming 'username' as a placeholder for the customer's name.
                    // Date of birth (NgaySinh) is not provided in the UI, so passing null.
                    detailAdded = blTaiKhoan.ThemKhachHang(identifier, username, null, ref error);
                }

                // If adding user details fails, stop the registration process
                if (!detailAdded)
                {
                    MessageBox.Show("Không thể thêm thông tin chi tiết người dùng: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Create the login account in DANG_NHAP_NHAN_VIEN or DANG_NHAP_KHACH_HANG
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
                    // (e.g., deleting the user details added in Step 1).
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