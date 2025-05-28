using System;
using System.Data;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer; // Import namespace chứa BLHangHoa

namespace Convenience_Store_Management.GUI
{
    public partial class UC_HangHoa_Khach : UserControl
    {
        private BLHangHoa blHangHoa = new BLHangHoa(); // Sử dụng lớp BLHangHoa từ tầng BLL

        public UC_HangHoa_Khach()
        {
            InitializeComponent();
        }

        private void UC_HangHoa_Khach_Load(object sender, EventArgs e)
        {
            LoadHangHoaData();
        }

        private void LoadHangHoaData()
        {
            try
            {
                DataSet ds = blHangHoa.LayHangHoa();
                dataGridView1.DataSource = ds.Tables[0];

                if (dataGridView1.Columns.Contains("MaSanPham"))
                    dataGridView1.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                if (dataGridView1.Columns.Contains("TenSP"))
                    dataGridView1.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                if (dataGridView1.Columns.Contains("SoLuong"))
                    dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng Tồn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maSanPham = selectedRow.Cells["MaSanPham"].Value.ToString();
                string tenSP = selectedRow.Cells["TenSP"].Value.ToString();
                int soLuongTon = Convert.ToInt32(selectedRow.Cells["SoLuong"].Value);

                int quantityToAdd = 1;

                if (quantityToAdd <= 0)
                {
                    MessageBox.Show("Số lượng thêm vào phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string errorMessage = "";
                bool success = blHangHoa.CapNhatSoLuongHangHoa(maSanPham, quantityToAdd, ref errorMessage);

                if (success)
                {
                    MessageBox.Show($"{quantityToAdd} x '{tenSP}' đã được thêm vào giỏ hàng (số lượng tồn đã cập nhật).", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHangHoaData();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm vào giỏ hàng: " + errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm vào giỏ hàng.", "Chưa Chọn Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}