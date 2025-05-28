using System;
using System.Data;
using System.Data.SqlClient;

using Convenience_Store_Management.DAL; // Import namespace chứa lớp ConnectDB

namespace QLBanHang_3Tang.BS_layer
{
    class BLHangHoa
    {
        private ConnectDB db = null; // Khai báo một đối tượng ConnectDB

        public BLHangHoa()
        {
            db = new ConnectDB(); // Khởi tạo đối tượng ConnectDB
        }

        public DataSet LayHangHoa()
        {
            try
            {
                // Gọi phương thức ExecuteQueryDataSet từ đối tượng db
                return db.ExecuteQueryDataSet("SELECT MaSanPham, TenSP, SoLuong FROM HANG_HOA WHERE SoLuong > 0", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi lấy danh sách sản phẩm: " + ex.Message, ex);
            }
        }

        public bool CapNhatSoLuongHangHoa(string maSanPham, int soLuongBan, ref string err)
        {
            DataSet ds = null;
            try
            {
                ds = db.ExecuteQueryDataSet($"SELECT SoLuong FROM HANG_HOA WHERE MaSanPham = '{maSanPham}'", CommandType.Text);
            }
            catch (Exception ex)
            {
                err = "Lỗi khi kiểm tra tồn kho: " + ex.Message;
                return false;
            }

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                err = "Sản phẩm không tồn tại.";
                return false;
            }

            int currentStock = Convert.ToInt32(ds.Tables[0].Rows[0]["SoLuong"]);

            if (soLuongBan <= 0)
            {
                err = "Số lượng bán phải lớn hơn 0.";
                return false;
            }
            if (currentStock < soLuongBan)
            {
                err = $"Không đủ số lượng tồn kho cho sản phẩm '{maSanPham}'. Tồn kho hiện tại: {currentStock}";
                return false;
            }

            int newStock = currentStock - soLuongBan;
            string sqlString = $"UPDATE HANG_HOA SET SoLuong = {newStock} WHERE MaSanPham = '{maSanPham}'";

            // Gọi phương thức MyExecuteNonQuery từ đối tượng db
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}