// BUS/BLTaiKhoan.cs
using System;
using System.Data;
using Convenience_Store_Management.DAL; // Ensure this namespace is correct

namespace QLBanHang_3Tang.BS_layer
{
    public class BLTaiKhoan
    {
        private ConnectDB db;

        public BLTaiKhoan()
        {
            db = new ConnectDB();
        }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, string loaiTaiKhoan, ref string error)
        {
            string sql = $"SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = '{tenDangNhap}' AND MatKhau = '{matKhau}' AND LoaiTaiKhoan = '{loaiTaiKhoan}'";
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

        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string loaiTaiKhoan, ref string error)
        {
            string sql = $"INSERT INTO TaiKhoan (TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES ('{tenDangNhap}', '{matKhau}', '{loaiTaiKhoan}')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        public bool ThemNhanVien(string maNhanVien, string tenDangNhap, string tenNhanVien, DateTime? ngaySinh, string gioiTinh, string diaChi, string soDienThoai, ref string error)
        {
            string ngaySinhStr = ngaySinh.HasValue ? $"'{ngaySinh.Value.ToString("yyyy-MM-dd")}'" : "NULL";
            string sql = $"INSERT INTO NhanVien (MaNhanVien, TenDangNhap, TenNhanVien, NgaySinh, GioiTinh, DiaChi, SoDienThoai) VALUES ('{maNhanVien}', '{tenDangNhap}', N'{tenNhanVien}', {ngaySinhStr}, N'{gioiTinh}', N'{diaChi}', '{soDienThoai}')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        public bool ThemKhachHang(string sdtKhachHang, string tenDangNhap, string tenKhachHang, string diaChi, ref string error)
        {
            string sql = $"INSERT INTO KhachHang (SDTKhachHang, TenDangNhap, TenKhachHang, DiaChi) VALUES ('{sdtKhachHang}', '{tenDangNhap}', N'{tenKhachHang}', N'{diaChi}')";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap, ref string error)
        {
            string sql = $"SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = '{tenDangNhap}'";
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
                return true; // Assume exists to prevent duplicate creation on error
            }
        }

        public string LayMaNhanVienTuTenDangNhap(string tenDangNhap, ref string error)
        {
            string sql = $"SELECT MaNhanVien FROM NhanVien WHERE TenDangNhap = '{tenDangNhap}'";
            try
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["MaNhanVien"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                error = "Lỗi lấy mã nhân viên: " + ex.Message;
                return null;
            }
        }
    }
}