// FormReg.cs
using System;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer; // Đảm bảo namespace này đúng

namespace Convenience_Store_Management
{
    public partial class FormReg : Form
    {
        private BLTaiKhoan blTaiKhoan = new BLTaiKhoan(); // Khởi tạo BLL

        public FormReg()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*'; // Ẩn mật khẩu mặc định
            NhanVienCb.Checked = true; // Đặt lựa chọn mặc định là Nhân viên

            // IMPORTANT:
            // The current UI (FormReg.Designer.cs) does not contain separate input fields for:
            // - Employee ID (MaNhanVien) or Phone Number (SdtNV) for employees.
            // - Customer Name (TenKH) or Date of Birth (NgaySinh) for customers.
            // - A specific label (like 'label4' mentioned in the request) to dynamically change its text.
            // The 'txtAccount' is used as the 'TenDangNhap' (username).
            // For a complete solution, you would need to add these controls in FormReg.Designer.cs
            // and implement their logic here.
        }

        private void cbShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            // Chuyển đổi hiển thị mật khẩu
            if (cbShowPwd.Checked)
            {
                txtPwd.PasswordChar = '\0'; // Hiển thị mật khẩu
            }
            else
            {
                txtPwd.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }

        private void btnLogin_Click(object sender, EventArgs e) // Đây là nút "Sign up" của bạn
        {
            string username = txtAccount.Text.Trim(); // This is the 'Account name' (TenDangNhap)
            string password = txtPwd.Text.Trim();
            string userRole = "";
            string error = "";

            if (NhanVienCb.Checked)
            {
                userRole = "Employee"; // Đổi từ "NhânVien" sang "Employee" để khớp với DB
            }
            else if (KhachHangCb.Checked)
            {
                userRole = "Customer"; // Đổi từ "KhachHang" sang "Customer" để khớp với DB
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

            string maNhanVien = null;
            string sdtKhachHang = null;
            bool detailAdded = false;

            try
            {
                if (userRole == "Employee")
                {
                    // Generate MaNhanVien automatically.
                    // If you need user input for MaNhanVien, HoTenNV, SdtNV, you must add TextBoxes to the UI.
                    maNhanVien = "NV" + DateTime.Now.ToString("ddHHmmss");
                    string hoTenNV = "Nhân Viên Mới"; // Placeholder: Replace with actual input from a TextBox if available.
                    string sdtNV = "0000000000";      // Placeholder: Replace with actual input from a TextBox if available.
                                                      // Ensure this phone number is unique and valid for the database.

                    detailAdded = blTaiKhoan.ThemNhanVien(maNhanVien, hoTenNV, sdtNV, ref error); //
                }
                else if (userRole == "Customer")
                {
                    // Assuming 'username' is intended to be the customer's phone number (SDTKhachHang).
                    // If you need a separate input for SDT and username, you must add TextBoxes to the UI.
                    sdtKhachHang = username;
                    string tenKH = "Khách Hàng Mới"; // Placeholder: Replace with actual input from a TextBox if available.
                    DateTime? ngaySinh = null;       // Placeholder: Replace with actual input from a DateTimePicker if available.

                    detailAdded = blTaiKhoan.ThemKhachHang(sdtKhachHang, tenKH, ngaySinh, ref error); //
                }

                if (!detailAdded)
                {
                    MessageBox.Show("Không thể thêm thông tin chi tiết người dùng: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu không thêm được chi tiết
                }

                // Bước 2: Tạo tài khoản trong bảng DANG_NHAP, liên kết với ID vừa tạo
                if (blTaiKhoan.ThemTaiKhoan(username, password, userRole, maNhanVien, sdtKhachHang, ref error)) //
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close(); // Đóng form đăng ký sau khi đăng ký thành công
                }
                else
                {
                    // Nếu thêm tài khoản thất bại, có thể cần xóa thông tin chi tiết đã thêm (tùy thuộc vào yêu cầu)
                    MessageBox.Show("Đăng ký tài khoản thất bại: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Đảm bảo chỉ một checkbox được chọn
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