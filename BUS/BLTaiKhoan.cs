// BUS/BLTaiKhoan.cs
using System;
using System.Data;
using Convenience_Store_Management.DAL; // Đảm bảo namespace này đúng

namespace QLBanHang_3Tang.BS_layer
{
    public class BLTaiKhoan
    {
        private ConnectDB db;

        public BLTaiKhoan()
        {
            db = new ConnectDB();
        }

        // Phương thức kiểm tra đăng nhập
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, string loaiTaiKhoan, ref string error)
        {
            string sql = "";
            if (loaiTaiKhoan == "Employee")
            {
                // Query the DANG_NHAP table for employee login
                sql = $"SELECT COUNT(*) FROM DANG_NHAP WHERE TenDangNhap = '{tenDangNhap}' AND MatKhau = '{matKhau}' AND LoaiTaiKhoan = 'Employee'";
            }
            else if (loaiTaiKhoan == "Customer")
            {
                // Query the DANG_NHAP table for customer login
                sql = $"SELECT COUNT(*) FROM DANG_NHAP WHERE TenDangNhap = '{tenDangNhap}' AND MatKhau = '{matKhau}' AND LoaiTaiKhoan = 'Customer'";
            }
            else
            {
                error = "Loại tài khoản không hợp lệ.";
                return false;
            }

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

        // Phương thức kiểm tra tên đăng nhập đã tồn tại chưa (trong bảng DANG_NHAP)
        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap, ref string error)
        {
            // Check existence in the single DANG_NHAP table
            string sql = $"SELECT COUNT(*) FROM DANG_NHAP WHERE TenDangNhap = '{tenDangNhap}'";

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
                error = "Lỗi kiểm tra tên đăng nhập tồn tại: " + ex.Message;
                return true; // Giả định là tồn tại để ngăn chặn tạo trùng lặp khi có lỗi
            }
        }

        // Phương thức thêm tài khoản vào bảng DANG_NHAP
        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string loaiTaiKhoan, string identifier, ref string error)
        {
            string sql = "";
            string maNhanVienParam = "NULL";
            string sdtKhachHangParam = "NULL";

            if (loaiTaiKhoan == "Employee")
            {
                maNhanVienParam = $"'{identifier}'"; // identifier is MaNhanVien for Employee
            }
            else if (loaiTaiKhoan == "Customer")
            {
                sdtKhachHangParam = $"'{identifier}'"; // identifier is SDTKhachHang for Customer
            }
            else
            {
                error = "Loại tài khoản không hợp lệ.";
                return false;
            }
            // Insert into the single DANG_NHAP table
            sql = $"INSERT INTO DANG_NHAP (TenDangNhap, MatKhau, MaNhanVien, SDTKhachHang, LoaiTaiKhoan) VALUES ('{tenDangNhap}', '{matKhau}', {maNhanVienParam}, {sdtKhachHangParam}, '{loaiTaiKhoan}')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // Phương thức thêm Nhân viên vào bảng NHAN_VIEN
        public bool ThemNhanVien(string maNhanVien, string hoTenNV, string sdtNV, ref string error)
        {
            string sql = $"INSERT INTO NHAN_VIEN (MaNhanVien, HoTenNV, SdtNV) VALUES ('{maNhanVien}', N'{hoTenNV}', '{sdtNV}')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // Phương thức thêm Khách hàng vào bảng KHACH_HANG
        public bool ThemKhachHang(string sdtKhachHang, string tenKH, DateTime? ngaySinh, ref string error)
        {
            string ngaySinhStr = ngaySinh.HasValue ? $"'{ngaySinh.Value.ToString("yyyy-MM-dd")}'" : "NULL";
            string sql = $"INSERT INTO KHACH_HANG (SDT, TenKH, NgaySinh) VALUES ('{sdtKhachHang}', N'{tenKH}', {ngaySinhStr})";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        // Phương thức lấy ID của người dùng sau khi đăng nhập (nếu cần)
        public string LayMaNhanVienTuTenDangNhap(string tenDangNhap, ref string error)
        {
            // Select MaNhanVien from DANG_NHAP for Employee type
            string sql = $"SELECT MaNhanVien FROM DANG_NHAP WHERE TenDangNhap = '{tenDangNhap}' AND LoaiTaiKhoan = 'Employee'";
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

        public string LaySDTKhachHangTuTenDangNhap(string tenDangNhap, ref string error)
        {
            // Select SDTKhachHang from DANG_NHAP for Customer type
            string sql = $"SELECT SDTKhachHang FROM DANG_NHAP WHERE TenDangNhap = '{tenDangNhap}' AND LoaiTaiKhoan = 'Customer'";
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