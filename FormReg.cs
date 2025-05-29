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

            // Khởi tạo trạng thái ban đầu của label và text TextBox
            label.Text = "Mã NV:";
            sdt_text.Text = "";
            manv_text.Visible = true; // Make manv_text visible
            sdt_text.Visible = false; // Make sdt_text invisible for employee
            label.Text = "Mã NV:"; // Update label text for employee (this is redundant with manhanvien_label)
            manhanvien_label.Text = "Mã NV:"; // Update label text for employee
            manhanvien_label.Visible = true; // Make manhanvien_label visible
            label.Visible = false; // Make label (for SDT) invisible
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
            string identifier = ""; // This will hold MaNhanVien or SDTKhachHang
            string userRole = "";
            string error = "";
            bool detailAdded = false;

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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem trường định danh (Mã NV / SĐT) có trống không
            if (string.IsNullOrEmpty(identifier))
            {
                MessageBox.Show($"Vui lòng nhập {(userRole == "Employee" ? "Mã NV" : "SĐT")} của bạn.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra sự tồn tại của tên đăng nhập trước khi thêm chi tiết
            if (blTaiKhoan.KiemTraTonTaiTenDangNhap(username, ref error))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Bước 1: Thêm chi tiết người dùng vào bảng NHAN_VIEN hoặc KHACH_HANG
                

                if (!detailAdded)
                {
                    MessageBox.Show("Không thể thêm thông tin chi tiết người dùng: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu không thêm được chi tiết
                }

                // Bước 2: Tạo tài khoản trong bảng DANG_NHAP_NHAN_VIEN hoặc DANG_NHAP_KHACH_HANG
                if (blTaiKhoan.ThemTaiKhoan(username, password, userRole, identifier, ref error))
                {
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close(); // Đóng form đăng ký sau khi đăng ký thành công
                }
                else
                {
                    // Nếu thêm tài khoản thất bại, cần thêm logic để rollback (xóa) thông tin chi tiết đã thêm trước đó.
                    MessageBox.Show("Đăng ký tài khoản thất bại: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // TODO: Implement rollback logic here if necessary
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

        // Đảm bảo chỉ một checkbox được chọn và cập nhật hiển thị các trường nhập liệu
        private void NhanVienCb_CheckedChanged(object sender, EventArgs e)
        {
            if (NhanVienCb.Checked)
            {
                KhachHangCb.Checked = false;
                manv_text.Visible = true;
                manhanvien_label.Visible = true;
                sdt_text.Visible = false;
                label.Visible = false;
                manv_text.Text = "";
                sdt_text.Text = ""; // Clear text when switching
            }
        }

        private void KhachHangCb_CheckedChanged(object sender, EventArgs e)
        {
            if (KhachHangCb.Checked)
            {
                NhanVienCb.Checked = false;
                manv_text.Visible = false;
                manhanvien_label.Visible = false;
                sdt_text.Visible = true;
                label.Visible = true;
                sdt_text.Text = "";
                manv_text.Text = ""; // Clear text when switching
            }
        }
    }
}