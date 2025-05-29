
using System;
using System.Data;
using Convenience_Store_Management.DAL;

namespace QLBanHang_3Tang.BS_layer
{
    public class BLHoaDonBan
    {
        private ConnectDB db;

        public BLHoaDonBan()
        {
            db = new ConnectDB();
        }

        public bool ThemHoaDonBan(string maHoaDonBan, string maNhanVien, string sdtKhachHang, DateTime ngayBan, ref string error)
        {
            string sql;
            if (string.IsNullOrEmpty(sdtKhachHang))
            {
                sql = $"INSERT INTO HOA_DON_BAN (MaHoaDonBan, MaNhanVien, SDTKhachHang, NgayBan) VALUES ('{maHoaDonBan}', '{maNhanVien}', NULL, '{ngayBan.ToString("yyyy-MM-dd")}')";
            }
            else
            {
                sql = $"INSERT INTO HOA_DON_BAN (MaHoaDonBan, MaNhanVien, SDTKhachHang, NgayBan) VALUES ('{maHoaDonBan}', '{maNhanVien}', '{sdtKhachHang}', '{ngayBan.ToString("yyyy-MM-dd")}')";
            }
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        public bool ThemChiTietBan(string maHoaDonBan, string maSanPham, int soLuong, decimal giaBan, decimal thanhTien, ref string error)
        {
            string giaBanStr = giaBan.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string thanhTienStr = thanhTien.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string sql = $"INSERT INTO CHI_TIET_BAN (MaHoaDonBan, MaSanPham, SoLuong, GiaBan, ThanhTien) VALUES ('{maHoaDonBan}', '{maSanPham}', {soLuong}, {giaBanStr}, {thanhTienStr})";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }

        public bool CapNhatSoLuongHangHoa(string maSanPham, int soLuongThayDoi, ref string error)
        {
            string sql = $"UPDATE HANG_HOA SET SoLuong = SoLuong + {soLuongThayDoi} WHERE MaSanPham = '{maSanPham}'";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error);
        }
    }
}