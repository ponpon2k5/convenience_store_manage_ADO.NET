// BUS/BLTaiKhoan.cs
using System;
using System.Data;
using Convenience_Store_Management.DAL;

namespace QLBanHang_3Tang.BS_layer
{
    public class BLTaiKhoan
    {
        private ConnectDB db; //

        public BLTaiKhoan()
        {
            db = new ConnectDB(); //
        }

        public bool KiemTraDangNhap(string tenDangNhap, string matKhau, string loaiTaiKhoan, ref string error) //
        {
            string sql = ""; //
            string tableName = ""; //

            if (loaiTaiKhoan == "Employee") //
            {
                tableName = "DANG_NHAP_NHAN_VIEN"; //
            }
            else if (loaiTaiKhoan == "Customer") //
            {
                tableName = "DANG_NHAP_KHACH_HANG"; //
            }
            else //
            {
                error = "Loại tài khoản không hợp lệ."; //
                return false; //
            }

            sql = $"SELECT COUNT(*) FROM {tableName} WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}' AND MatKhau = '{matKhau.Replace("'", "''")}'"; //

            try //
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text); //
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) //
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0; //
                }
                return false; //
            }
            catch (Exception ex) //
            {
                error = "Lỗi khi kiểm tra đăng nhập: " + ex.Message; //
                return false; //
            }
        }

        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap, ref string error) //
        {
            string sqlEmployee = $"SELECT COUNT(*) FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'"; //
            string sqlCustomer = $"SELECT COUNT(*) FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'"; //

            try //
            {
                DataSet dsEmployee = db.ExecuteQueryDataSet(sqlEmployee, CommandType.Text); //
                if (dsEmployee != null && dsEmployee.Tables.Count > 0 && Convert.ToInt32(dsEmployee.Tables[0].Rows[0][0]) > 0) //
                {
                    return true; //
                }

                DataSet dsCustomer = db.ExecuteQueryDataSet(sqlCustomer, CommandType.Text); //
                if (dsCustomer != null && dsCustomer.Tables.Count > 0 && Convert.ToInt32(dsCustomer.Tables[0].Rows[0][0]) > 0) //
                {
                    return true; //
                }
                return false; //
            }
            catch (Exception ex) //
            {
                error = "Lỗi kiểm tra tên đăng nhập tồn tại: " + ex.Message; //
                return true; //
            }
        }

        public bool ThemTaiKhoan(string tenDangNhap, string matKhau, string loaiTaiKhoan, string identifier, ref string error) //
        {
            string sql = ""; //

            if (loaiTaiKhoan == "Employee") //
            {
                sql = $"INSERT INTO DANG_NHAP_NHAN_VIEN (TenDangNhap, MatKhau, MaNhanVien) VALUES ('{tenDangNhap.Replace("'", "''")}', '{matKhau.Replace("'", "''")}', '{identifier.Replace("'", "''")}')"; //
            }
            else if (loaiTaiKhoan == "Customer") //
            {
                sql = $"INSERT INTO DANG_NHAP_KHACH_HANG (TenDangNhap, MatKhau, SDTKhachHang) VALUES ('{tenDangNhap.Replace("'", "''")}', '{matKhau.Replace("'", "''")}', '{identifier.Replace("'", "''")}')"; //
            }
            else //
            {
                error = "Loại tài khoản không hợp lệ."; //
                return false; //
            }

            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error); //
        }

        public bool ThemNhanVien(string maNhanVien, string hoTenNV, string sdtNV, ref string error) //
        {
            string sql = $"INSERT INTO NHAN_VIEN (MaNhanVien, HoTenNV, SdtNV) VALUES ('{maNhanVien.Replace("'", "''")}', N'{hoTenNV.Replace("'", "''")}', '{sdtNV.Replace("'", "''")}')"; //
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error); //
        }

        public bool ThemKhachHang(string sdtKhachHang, string tenKH, DateTime? ngaySinh, ref string error) //
        {
            string ngaySinhStr = ngaySinh.HasValue ? $"'{ngaySinh.Value.ToString("yyyy-MM-dd")}'" : "NULL"; //
            string sql = $"INSERT INTO KHACH_HANG (SDT, TenKH, NgaySinh) VALUES ('{sdtKhachHang.Replace("'", "''")}', N'{tenKH.Replace("'", "''")}', {ngaySinhStr})"; //
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref error); //
        }

        public string LayMaNhanVienTuTenDangNhap(string tenDangNhap, ref string error) //
        {
            string sql = $"SELECT MaNhanVien FROM DANG_NHAP_NHAN_VIEN WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'"; //
            try //
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text); //
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["MaNhanVien"] != DBNull.Value) //
                {
                    return ds.Tables[0].Rows[0]["MaNhanVien"].ToString(); //
                }
                return null; //
            }
            catch (Exception ex) //
            {
                error = "Lỗi lấy mã nhân viên từ tài khoản: " + ex.Message; //
                return null; //
            }
        }

        public string LaySDTKhachHangTuTenDangNhap(string tenDangNhap, ref string error) //
        {
            string sql = $"SELECT SDTKhachHang FROM DANG_NHAP_KHACH_HANG WHERE TenDangNhap = '{tenDangNhap.Replace("'", "''")}'"; //
            try //
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text); //
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["SDTKhachHang"] != DBNull.Value) //
                {
                    return ds.Tables[0].Rows[0]["SDTKhachHang"].ToString(); //
                }
                return null; //
            }
            catch (Exception ex) //
            {
                error = "Lỗi lấy SĐT khách hàng từ tài khoản: " + ex.Message; //
                return null; //
            }
        }

        public string LayTenDangNhapTuSDTKhachHang(string sdtKhachHang, ref string error) //
        {
            string sql = $"SELECT TenDangNhap FROM DANG_NHAP_KHACH_HANG WHERE SDTKhachHang = '{sdtKhachHang.Replace("'", "''")}'"; //
            try //
            {
                DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text); //
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["TenDangNhap"] != DBNull.Value) //
                {
                    return ds.Tables[0].Rows[0]["TenDangNhap"].ToString(); //
                }
                return null; //
            }
            catch (Exception ex) //
            {
                error = "Lỗi lấy tên đăng nhập từ SĐT khách hàng: " + ex.Message; //
                return null; //
            }
        }

        // Phương thức cũ để cập nhật cả tên đăng nhập và mật khẩu (có thể giữ hoặc xóa tùy ý)
        public bool CapNhatTaiKhoanKhachHang(string sdtKhachHang, string oldUsername, string newUsername, string newPassword, ref string error) //
        {
            string sql = ""; //
            bool success = false; //

            db.BeginTransaction(); //
            try //
            {
                if (oldUsername != newUsername) //
                {
                    sql = $"UPDATE DANG_NHAP_KHACH_HANG SET TenDangNhap = '{newUsername.Replace("'", "''")}' WHERE SDTKhachHang = '{sdtKhachHang.Replace("'", "''")}' AND TenDangNhap = '{oldUsername.Replace("'", "''")}'"; //
                    success = db.MyExecuteNonQuery(sql, CommandType.Text, ref error); //
                    if (!success) //
                    {
                        db.RollbackTransaction(); //
                        error = "Không thể cập nhật tên đăng nhập: " + error; //
                        return false; //
                    }
                }
                else //
                {
                    success = true; //
                }

                sql = $"UPDATE DANG_NHAP_KHACH_HANG SET MatKhau = '{newPassword.Replace("'", "''")}' WHERE SDTKhachHang = '{sdtKhachHang.Replace("'", "''")}' AND TenDangNhap = '{newUsername.Replace("'", "''")}'"; //
                bool passwordUpdateSuccess = db.MyExecuteNonQuery(sql, CommandType.Text, ref error); //

                if (passwordUpdateSuccess && success) //
                {
                    db.CommitTransaction(); //
                    return true; //
                }
                else //
                {
                    db.RollbackTransaction(); //
                    error = "Không thể cập nhật mật khẩu: " + error; //
                    return false; //
                }
            }
            catch (Exception ex) //
            {
                db.RollbackTransaction(); //
                error = "Lỗi trong quá trình cập nhật tài khoản: " + ex.Message; //
                return false; //
            }
        }

        // NEW: Phương thức chỉ cập nhật mật khẩu khách hàng
        public bool CapNhatMatKhauKhachHang(string sdtKhachHang, string tenDangNhap, string newPassword, ref string error)
        {
            string sql = "";
            db.BeginTransaction(); //
            try
            {
                sql = $"UPDATE DANG_NHAP_KHACH_HANG SET MatKhau = '{newPassword.Replace("'", "''")}' WHERE SDTKhachHang = '{sdtKhachHang.Replace("'", "''")}' AND TenDangNhap = '{tenDangNhap.Replace("'", "''")}'"; //
                bool passwordUpdateSuccess = db.MyExecuteNonQuery(sql, CommandType.Text, ref error); //

                if (passwordUpdateSuccess)
                {
                    db.CommitTransaction(); //
                    return true;
                }
                else
                {
                    db.RollbackTransaction(); //
                    return false;
                }
            }
            catch (Exception ex)
            {
                db.RollbackTransaction(); //
                error = "Lỗi trong quá trình cập nhật mật khẩu: " + ex.Message;
                return false;
            }
        }
    }
}