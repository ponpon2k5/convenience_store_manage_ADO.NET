// BUS/BLHangHoa.cs
using System;
using System.Data;
using Convenience_Store_Management.DAL;

namespace QLBanHang_3Tang.BS_layer
{
    public class BLHangHoa
    {
        public ConnectDB db;

        public BLHangHoa()
        {
            db = new ConnectDB();
        }

        public DataSet LayHangHoa()
        {
            // Include GiaNhap in SELECT statement
            string sql = "SELECT MaSanPham, TenSP, SoLuong, Gia, GiaNhap FROM HANG_HOA";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }

        // ThemHangHoa: Added giaNhap parameter and its inclusion in SQL
        public bool ThemHangHoa(string maSanPham, string tenSP, int soLuong, decimal gia, decimal giaNhap, ref string error) // Added 'decimal giaNhap'
        {
            // IMPORTANT: SQL Injection Vulnerability!
            string tenSPSafe = tenSP.Replace("'", "''");
            string giaStr = gia.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string giaNhapStr = giaNhap.ToString(System.Globalization.CultureInfo.InvariantCulture); // Convert decimal GiaNhap

            // SQL INSERT statement with GiaNhap
            string sql = $"INSERT INTO HANG_HOA (MaSanPham, TenSP, SoLuong, Gia, GiaNhap) " +
                         $"VALUES ('{maSanPham.Replace("'", "''")}', N'{tenSPSafe}', {soLuong}, {giaStr}, {giaNhapStr})";

            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // XoaHangHoa remains unchanged
        public bool XoaHangHoa(string maSanPham, ref string error)
        {
            string sql = $"DELETE FROM HANG_HOA WHERE MaSanPham = '{maSanPham.Replace("'", "''")}'";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // LayMaSanPhamTuTen remains unchanged
        public string LayMaSanPhamTuTen(string tenSP)
        {
            string sql = $"SELECT MaSanPham FROM HANG_HOA WHERE TenSP = N'{tenSP.Replace("'", "''")}'";

            DataSet ds = null;
            string maSanPham = null;
            try
            {
                ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    maSanPham = ds.Tables[0].Rows[0]["MaSanPham"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy mã sản phẩm: " + ex.Message);
            }
            return maSanPham;
        }

        // LayGiaBan remains unchanged (as it specifically gets selling price)
        public decimal? LayGiaBan(string maSP)
        {
            string sql = $"SELECT Gia FROM HANG_HOA WHERE MaSanPham = '{maSP.Replace("'", "''")}'";

            DataSet ds = null;
            decimal? giaBan = null;
            try
            {
                ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    giaBan = Convert.ToDecimal(ds.Tables[0].Rows[0]["Gia"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy giá bán: " + ex.Message);
            }
            return giaBan;
        }

        // TimHangHoa: Included GiaNhap in SELECT statement
        public DataSet TimHangHoa(string maSanPham, ref string error)
        {
            string sql = $"SELECT MaSanPham, TenSP, SoLuong, Gia, GiaNhap FROM HANG_HOA WHERE MaSanPham LIKE '%{maSanPham.Replace("'", "''")}%'";
            try
            {
                return db.ExecuteQueryDataSet(sql, CommandType.Text);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}