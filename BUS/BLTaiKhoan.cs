// BUS/BLTaiKhoan.cs
using System;
using System.Data;
using Convenience_Store_Management.DAL;

namespace QLBanHang_3Tang.BS_layer
{
    public class BLTaiKhoan
    {
        private ConnectDB db;

        public BLTaiKhoan()
        {
            db = new ConnectDB();
        }

        // Method to authenticate a user
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, string loaiTaiKhoan, ref string error)
        {
            string sql = "";
            string tableName = ""; // To store the table name dynamically

            if (loaiTaiKhoan == "Employee")
            {
                tableName = "DANG_NHAP_NHAN_VIEN";
            }
            else if (loaiTaiKhoan == "Customer")
            {
                tableName = "DANG_NHAP_KHACH_HANG";
            }
            else
            {
                error = "Loại tài khoản không hợp lệ.";
                return false;
            }

            // Query the specific login table
            // IMPORTANT: SQL Injection Vulnerability! Use parameterized queries in real apps.
            sql = $"SELECT COUNT(*) FROM {tableName} WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}' AND MatKhau = '{matKhau.Replace("'", "''")}'";

            try
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi khi kiểm tra đăng nhập: " + ex.Message;
                return false;
            }
        }

        // Method to check if a username already exists in either login table
        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap, ref string error)
        {
            // Check in DANG_NHAP_NHAN_VIEN
            string sqlEmployee = $"SELECT COUNT(*) FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'";
            // Check in DANG_NHAP_KHACH_HANG
            string sqlCustomer = $"SELECT COUNT(*) FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'";

            try
            {
                DataSet dsEmployee = db.ExecuteQueryDataSet(sqlEmployee, CommandType.Text);
                if (dsEmployee != null && dsEmployee.Tables.Count > 0 && Convert.ToInt32(dsEmployee.Tables[0].Rows[0][0]) > 0)
                {
                    return true; // Username exists in employee logins
                }

                DataSet dsCustomer = db.ExecuteQueryDataSet(sqlCustomer, CommandType.Text);
                if (dsCustomer != null && dsCustomer.Tables.Count > 0 && Convert.ToInt32(dsCustomer.Tables[0].Rows[0][0]) > 0)
                {
                    return true; // Username exists in customer logins
                }
                return false; // Username does not exist in either table
            }
            catch (Exception ex)
            {
                error = "Lỗi kiểm tra tên đăng nhập tồn tại: " + ex.Message;
                return true; // Assume existence to prevent duplicate creation on error
            }
        }

        // Method to add a new account to the appropriate login table
        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string loaiTaiKhoan, string identifier, ref string error)
        {
            string sql = "";

            if (loaiTaiKhoan == "Employee")
            {
                // Insert into DANG_NHAP_NHAN_VIEN
                // IMPORTANT: SQL Injection Vulnerability! Use parameterized queries in real apps.
                sql = $"INSERT INTO DANG_NHAP_NHAN_VIEN (TenDangNhap, MatKhau, MaNhanVien) VALUES ('{tenDangNhap.Replace("'", "''")}', '{matKhau.Replace("'", "''")}', '{identifier.Replace("'", "''")}')";
            }
            else if (loaiTaiKhoan == "Customer")
            {
                // Insert into DANG_NHAP_KHACH_HANG
                // IMPORTANT: SQL Injection Vulnerability! Use parameterized queries in real apps.
                sql = $"INSERT INTO DANG_NHAP_KHACH_HANG (TenDangNhap, MatKhau, SDTKhachHang) VALUES ('{tenDangNhap.Replace("'", "''")}', '{matKhau.Replace("'", "''")}', '{identifier.Replace("'", "''")}')";
            }
            else
            {
                error = "Loại tài khoản không hợp lệ.";
                return false;
            }

            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // Methods to add details for NHAN_VIEN and KHACH_HANG tables (these are separate from login tables)
        public bool ThemNhanVien(string maNhanVien, string hoTenNV, string sdtNV, ref string error)
        {
            string sql = $"INSERT INTO NHAN_VIEN (MaNhanVien, HoTenNV, SdtNV) VALUES ('{maNhanVien.Replace("'", "''")}', N'{hoTenNV.Replace("'", "''")}', '{sdtNV.Replace("'", "''")}')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        public bool ThemKhachHang(string sdtKhachHang, string tenKH, DateTime? ngaySinh, ref string error)
        {
            string ngaySinhStr = ngaySinh.HasValue ? $"'{ngaySinh.Value.ToString("yyyy-MM-dd")}'" : "NULL";
            string sql = $"INSERT INTO KHACH_HANG (SDT, TenKH, NgaySinh) VALUES ('{sdtKhachHang.Replace("'", "''")}', N'{tenKH.Replace("'", "''")}', {ngaySinhStr})";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // Method to retrieve MaNhanVien from DANG_NHAP_NHAN_VIEN
        public string LayMaNhanVienTuTenDangNhap(string tenDangNhap, ref string error)
        {
            string sql = $"SELECT MaNhanVien FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'";
            try
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["MaNhanVien"] != DBNull.Value)
                {
                    return ds.Tables[0].Rows[0]["MaNhanVien"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                error = "Lỗi lấy mã nhân viên từ tài khoản: " + ex.Message;
                return null;
            }
        }

        // Method to retrieve SDTKhachHang from DANG_NHAP_KHACH_HANG
        public string LaySDTKhachHangTuTenDangNhap(string tenDangNhap, ref string error)
        {
            string sql = $"SELECT SDTKhachHang FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'";
            try
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["SDTKhachHang"] != DBNull.Value)
                {
                    return ds.Tables[0].Rows[0]["SDTKhachHang"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                error = "Lỗi lấy SĐT khách hàng từ tài khoản: " + ex.Message;
                return null;
            }
        }
    }
}