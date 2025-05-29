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
            // Thêm các input field cần thiết cho Ngày Sinh, Tên NV/KH, SĐT NV/KH
            // Ví dụ:
            // labelTen = new Label() { Text = "Tên:", Location = new Point(122, 280) };
            // txtTen = new TextBox() { Location = new Point(266, 280), Size = new Size(157, 27) };
            // this.Controls.Add(labelTen);
            // this.Controls.Add(txtTen);
            // ... và các controls khác tương tự
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
            string username = txtAccount.Text.Trim();
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

            // Để đơn giản hóa, tôi sẽ sử dụng các giá trị placeholder cho các thông tin chi tiết
            // Trong thực tế, bạn cần thêm các textbox/datetimepicker trên form để lấy các thông tin này
            string maNhanVien = null;
            string sdtKhachHang = null;
            bool detailAdded = false;

            try
            {
                if (userRole == "Employee")
                {
                    // Tạo MaNhanVien tự động hoặc lấy từ input (nếu có)
                    // Ví dụ: NV + timestamp rút gọn
                    maNhanVien = "NV" + DateTime.Now.ToString("ddHHmmss");
                    // Giả sử có textbox cho TenNhanVien (txtHoTenNV) và SdtNV (txtSdtNV)
                    // Nếu bạn chưa có, bạn cần thêm chúng vào FormReg.Designer.cs và FormReg.cs
                    string hoTenNV = "Nhân Viên Mới"; // Thay bằng txtHoTenNV.Text
                    string sdtNV = "0123456789";      // Thay bằng txtSdtNV.Text (hoặc một số điện thoại duy nhất)

                    detailAdded = blTaiKhoan.ThemNhanVien(maNhanVien, hoTenNV, sdtNV, ref error);
                }
                else if (userRole == "Customer")
                {
                    // Lấy SDT từ username hoặc từ input (nếu có)
                    // Giả sử có textbox cho TenKH (txtTenKH) và DatePicker cho NgaySinh (dtpNgaySinh)
                    // Nếu bạn chưa có, bạn cần thêm chúng vào FormReg.Designer.cs và FormReg.cs
                    sdtKhachHang = username; // Giả sử username là SĐT khách hàng
                    string tenKH = "Khách Hàng Mới"; // Thay bằng txtTenKH.Text
                    DateTime? ngaySinh = null;       // Thay bằng dtpNgaySinh.Value

                    detailAdded = blTaiKhoan.ThemKhachHang(sdtKhachHang, tenKH, ngaySinh, ref error);
                }

                if (!detailAdded)
                {
                    MessageBox.Show("Không thể thêm thông tin chi tiết người dùng: " + error, "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu không thêm được chi tiết
                }

                // Bước 2: Tạo tài khoản trong bảng DANG_NHAP, liên kết với ID vừa tạo
                if (blTaiKhoan.ThemTaiKhoan(username, password, userRole, maNhanVien, sdtKhachHang, ref error))
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