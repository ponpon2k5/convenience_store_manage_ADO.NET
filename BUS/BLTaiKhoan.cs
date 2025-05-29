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
                sql = $"SELECT COUNT(*) FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap}' AND MatKhau = '{matKhau}'";
            }
            else if (loaiTaiKhoan == "Customer")
            {
                sql = $"SELECT COUNT(*) FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap}' AND MatKhau = '{matKhau}'";
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

        // Phương thức kiểm tra tên đăng nhập đã tồn tại chưa (trong cả 2 bảng)
        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap, ref string error)
        {
            string sqlEmployee = $"SELECT COUNT(*) FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap}'";
            string sqlCustomer = $"SELECT COUNT(*) FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap}'";

            try
            {
                DataSet dsEmployee = db.ExecuteQueryDataSet(sqlEmployee, CommandType.Text);
                if (dsEmployee != null && dsEmployee.Tables.Count > 0 && dsEmployee.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsEmployee.Tables[0].Rows[0][0]) > 0)
                {
                    return true;
                }

                DataSet dsCustomer = db.ExecuteQueryDataSet(sqlCustomer, CommandType.Text);
                if (dsCustomer != null && dsCustomer.Tables.Count > 0 && dsCustomer.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsCustomer.Tables[0].Rows[0][0]) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi kiểm tra tên đăng nhập tồn tại: " + ex.Message;
                return true; // Giả định là tồn tại để ngăn chặn tạo trùng lặp khi có lỗi
            }
        }

        // Phương thức thêm tài khoản vào bảng DANG_NHAP_NHAN_VIEN hoặc DANG_NHAP_KHACH_HANG
        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string loaiTaiKhoan, string identifier, ref string error)
        {
            string sql = "";
            if (loaiTaiKhoan == "Employee")
            {
                sql = $"INSERT INTO DANG_NHAP_NHAN_VIEN (TenDangNhap, MatKhau, MaNhanVien) VALUES ('{tenDangNhap}', '{matKhau}', '{identifier}')";
            }
            else if (loaiTaiKhoan == "Customer")
            {
                sql = $"INSERT INTO DANG_NHAP_KHACH_HANG (TenDangNhap, MatKhau, SDTKhachHang) VALUES ('{tenDangNhap}', '{matKhau}', '{identifier}')";
            }
            else
            {
                error = "Loại tài khoản không hợp lệ.";
                return false;
            }
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
            string sql = $"SELECT MaNhanVien FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap}'";
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
            string sql = $"SELECT SDTKhachHang FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap}'";
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