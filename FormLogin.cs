// FormLogin.cs
using System;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer; // Đảm bảo namespace này đúng

namespace Convenience_Store_Management
{
    public partial class FormLogin : Form
    {
        private BLTaiKhoan blTaiKhoan = new BLTaiKhoan(); // Khởi tạo BLL

        public FormLogin()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*'; // Ẩn mật khẩu mặc định
            NhanVienCb.Checked = true; // Đặt lựa chọn mặc định
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtAccount.Text.Trim();
            string password = txtPwd.Text.Trim();
            string userRole = "";
            string error = "";

            if (NhanVienCb.Checked)
            {
                userRole = "Employee"; // Đổi từ "NhânVien" sang "Employee"
            }
            else if (KhachHangCb.Checked)
            {
                userRole = "Customer"; // Đổi từ "KhachHang" sang "Customer"
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

                if (userRole == "Employee")
                {
                    // Lấy mã nhân viên để truyền vào FormNhanVien nếu cần
                    string maNhanVien = blTaiKhoan.LayMaNhanVienTuTenDangNhap(username, ref error);
                    FormNhanVien formNhanVien = new FormNhanVien(); // Có thể truyền maNhanVien vào constructor
                    formNhanVien.Show();
                }
                else if (userRole == "Customer")
                {
                    // Lấy SĐT khách hàng để truyền vào FormKhachHang nếu cần
                    string sdtKhachHang = blTaiKhoan.LaySDTKhachHangTuTenDangNhap(username, ref error);
                    FormKhachHang formKhachHang = new FormKhachHang(); // Có thể truyền sdtKhachHang vào constructor
                    formKhachHang.Show();
                }
                this.Hide(); // Ẩn form đăng nhập
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

        private void button1_Click(object sender, EventArgs e) // Đây là nút "Sign up" của bạn
        {
            FormReg formReg = new FormReg();
            formReg.Show();
            this.Hide(); // Ẩn form đăng nhập khi mở form đăng ký
        }
    }
}