// BUS/BLKhachHang.cs
using System;
using System.Data;
using Convenience_Store_Management.DAL;

namespace QLBanHang_3Tang.BS_layer
{
    public class BLKhachHang
    {
        public ConnectDB db; // Made public for direct transaction management if needed

        public BLKhachHang()
        {
            db = new ConnectDB();
        }

        // NEW: LayKhachHang (Get all customers) - general method
        public DataSet LayKhachHang(ref string error)
        {
            string sql = "SELECT SDT, TenKH, NgaySinh FROM KHACH_HANG";
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

        // NEW: TimKhachHang (Search Customer by SDT)
        public DataSet TimKhachHang(string sdt, ref string error)
        {
            // SQL Injection Vulnerability!
            string sql = $"SELECT SDT, TenKH, NgaySinh FROM KHACH_HANG WHERE SDT LIKE '%{sdt.Replace("'", "''")}%'";
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