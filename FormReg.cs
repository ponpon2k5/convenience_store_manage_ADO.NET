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

            // Khởi tạo trạng thái ban đầu của label4 và text TextBox
            label.Text = "Mã NV:";
            sdt_text.Text = "";
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
            string identifier = sdt_text.Text.Trim(); // Lấy giá trị từ text TextBox
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

            // Kiểm tra xem trường định danh (Mã NV / SĐT) có trống không
            if (string.IsNullOrEmpty(identifier))
            {
                MessageBox.Show($"Vui lòng nhập {(userRole == "Employee" ? "Mã NV" : "SĐT")} của bạn.", "Lỗi Đăng Ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    maNhanVien = identifier; // Sử dụng giá trị từ text TextBox cho Mã NV
                    string hoTenNV = "Nhân Viên Mới (chưa nhập)"; // Placeholder: Cần thêm TextBox cho Họ Tên NV

                    // Tạo một số điện thoại ngẫu nhiên/duy nhất hơn để tránh lỗi trùng lặp
                    Random rnd = new Random();
                    string sdtNV = "0" + (rnd.Next(100000000, 999999999)).ToString();
                    // Hoặc yêu cầu người dùng nhập nếu có TextBox riêng cho SdtNV
                    // string sdtNV = "0000000000"; // Đây là nguyên nhân lỗi nếu bị trùng

                    detailAdded = blTaiKhoan.ThemNhanVien(maNhanVien, hoTenNV, sdtNV, ref error);
                }
                else if (userRole == "Customer")
                {
                    sdtKhachHang = identifier; // Sử dụng giá trị từ text TextBox cho SĐT khách hàng
                    string tenKH = "Khách Hàng Mới (chưa nhập)"; // Placeholder: Cần thêm TextBox cho Tên KH
                    DateTime? ngaySinh = null;       // Placeholder: Cần thêm DateTimePicker cho Ngày Sinh

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
                    // Nếu thêm tài khoản thất bại, có thể cần thêm logic để rollback (xóa) thông tin chi tiết đã thêm trước đó.
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

        // Đảm bảo chỉ một checkbox được chọn và cập nhật label4
        private void NhanVienCb_CheckedChanged(object sender, EventArgs e)
        {
            if (NhanVienCb.Checked)
            {
                KhachHangCb.Checked = false;
                label.Text = "Mã NV:";
                sdt_text.Text = ""; // Xóa nội dung khi chuyển đổi
            }
        }

        private void KhachHangCb_CheckedChanged(object sender, EventArgs e)
        {
            if (KhachHangCb.Checked)
            {
                NhanVienCb.Checked = false;
                label.Text = "SĐT:";
                sdt_text.Text = ""; // Xóa nội dung khi chuyển đổi
            }
        }
    }
}