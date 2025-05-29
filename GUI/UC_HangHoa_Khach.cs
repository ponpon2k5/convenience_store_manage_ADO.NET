using System;
using System.Data;
using System.Windows.Forms;
using QLBanHang_3Tang.BS_layer;

namespace Convenience_Store_Management.GUI
{
    public partial class UC_HangHoa_Khach : UserControl
    {
        private BLHangHoa blHangHoa = new BLHangHoa();

        // Khai báo một delegate cho sự kiện khi sản phẩm được thêm vào giỏ hàng
        // Truyền trực tiếp các thông tin cần thiết
        public delegate void AddToCartEventHandler(object sender, string maSanPham, string tenSP, int soLuong, decimal gia);

        // Khai báo sự kiện
        public event AddToCartEventHandler OnAddToCart;

        public UC_HangHoa_Khach()
        {
            InitializeComponent();
        }

        private void UC_HangHoa_Khach_Load(object sender, EventArgs e)
        {
            LoadHangHoaData();
        }

        public void LoadHangHoaData() // Đặt là public để có thể gọi từ bên ngoài khi cần refresh
        {
            try
            {
                DataSet ds = blHangHoa.LayHangHoa();
                dataGridView1.DataSource = ds.Tables[0];

                // Đặt header text cho DataGridView
                if (dataGridView1.Columns.Contains("MaSanPham"))
                    dataGridView1.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                if (dataGridView1.Columns.Contains("TenSP"))
                    dataGridView1.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                if (dataGridView1.Columns.Contains("SoLuong"))
                    dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng Tồn";
                if (dataGridView1.Columns.Contains("Gia"))
                    dataGridView1.Columns["Gia"].HeaderText = "Giá";

                // Định dạng cột Giá
                if (dataGridView1.Columns.Contains("Gia"))
                {
                    dataGridView1.Columns["Gia"].DefaultCellStyle.Format = "N0"; // Định dạng số không thập phân (ví dụ: 10,000)
                }

                // Chặn người dùng chỉnh sửa trực tiếp trên DataGridView
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
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
                decimal gia = Convert.ToDecimal(selectedRow.Cells["Gia"].Value);

                int quantityToAdd = 1; // Mặc định thêm 1 sản phẩm vào giỏ hàng

                if (quantityToAdd <= 0)
                {
                    MessageBox.Show("Số lượng thêm vào phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra số lượng tồn kho trước khi thêm vào giỏ (trong giỏ hàng tạm thời)
                // Lưu ý: Đây chỉ là kiểm tra ban đầu, số lượng thực tế sẽ được trừ khi thanh toán.
                if (quantityToAdd > soLuongTon)
                {
                    MessageBox.Show($"Sản phẩm '{tenSP}' chỉ còn {soLuongTon} sản phẩm. Không đủ số lượng bạn yêu cầu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kích hoạt sự kiện OnAddToCart, truyền thông tin sản phẩm trực tiếp
                OnAddToCart?.Invoke(this, maSanPham, tenSP, quantityToAdd, gia);

                MessageBox.Show($"{quantityToAdd} x '{tenSP}' đã được thêm vào giỏ hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // KHÔNG LoadHangHoaData() ở đây, vì số lượng tồn kho chỉ được trừ khi thanh toán.
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để thêm vào giỏ hàng.", "Chưa Chọn Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}