// GUI/UC_HoaDon.cs
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Convenience_Store_Management.GUI
{
    public partial class UC_HoaDon : UserControl
    {
        private BLHoaDonBan blHoaDonBan = new BLHoaDonBan();

        public UC_HoaDon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Retrieve data from UI controls
            string maHoaDon = txtMaHD.Text.Trim();
            string tenSanPham = txtTenSP.Text.Trim(); // Assuming this is TenSP input
            string soLuongStr = txtSoLuong.Text.Trim();
            string maNhanVien = txtMaNV.Text.Trim();
            DateTime ngayBan = dtpNgayBan.Value;

            // Basic validation for required fields
            if (string.IsNullOrEmpty(maHoaDon) || string.IsNullOrEmpty(tenSanPham) ||
                string.IsNullOrEmpty(soLuongStr) || string.IsNullOrEmpty(maNhanVien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn và sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong;
            if (!int.TryParse(soLuongStr, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string error = "";
            bool success = false;

            // NEW: Get MaSanPham from TenSP using BL method
            string maSanPham = blHoaDonBan.LayMaSanPhamTuTen(tenSanPham);
            if (string.IsNullOrEmpty(maSanPham))
            {
                MessageBox.Show("Không tìm thấy mã sản phẩm cho tên sản phẩm đã nhập. Vui lòng kiểm tra tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // NEW: Get GiaBan from MaSanPham using BL method
            decimal? giaBan = blHoaDonBan.LayGiaBan(maSanPham);
            if (giaBan == null)
            {
                MessageBox.Show("Không lấy được giá bán của sản phẩm. Vui lòng kiểm tra mã sản phẩm hoặc dữ liệu sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal thanhTien = soLuong * giaBan.Value; // Calculate line total using retrieved price

            // Assuming SDTKhachHang is nullable and not provided in this UI
            string sdtKhachHang = null;

            blHoaDonBan.db.BeginTransaction();
            try
            {
                // Call ThemHoaDonBan with 5 arguments (no tongTien)
                success = blHoaDonBan.ThemHoaDonBan(maHoaDon, maNhanVien, sdtKhachHang, ngayBan, ref error);
                if (!success)
                {
                    blHoaDonBan.db.RollbackTransaction();
                    MessageBox.Show($"Thêm hóa đơn thất bại: {error}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Call BL method to add the invoice detail (CHI_TIET_BAN)
                success = blHoaDonBan.ThemChiTietBan(maHoaDon, maSanPham, soLuong, giaBan.Value, thanhTien, ref error);
                if (!success)
                {
                    blHoaDonBan.db.RollbackTransaction();
                    MessageBox.Show($"Thêm chi tiết hóa đơn thất bại: {error}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update product quantity (decrease stock)
                success = blHoaDonBan.CapNhatSoLuongHangHoa(maSanPham, -soLuong, ref error);
                if (!success)
                {
                    blHoaDonBan.db.RollbackTransaction();
                    MessageBox.Show($"Cập nhật số lượng hàng hóa thất bại: {error}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                blHoaDonBan.db.CommitTransaction();
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally clear the input fields
                txtMaHD.Clear();
                txtTenSP.Clear(); // Clear TenSP
                txtSoLuong.Clear();
                txtMaNV.Clear();
                dtpNgayBan.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                blHoaDonBan.db.RollbackTransaction();
                MessageBox.Show($"Đã xảy ra lỗi không mong muốn trong quá trình thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}