using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

using System.Data.SqlClient; 
namespace Convenience_Store_Management.DAL // Namespace cần khớp với vị trí file
{
    public class ConnectDB // Giữ nguyên tên lớp ConnectDB
    {
        // Chuỗi kết nối của bạn
        public readonly string strCon = "Data Source=PHONG_LAP;Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True";

        // Khai báo các biến thành viên như DBMain mẫu
        public SqlConnection conn = null;
        public SqlCommand comm = null;
        public SqlDataAdapter da = null;

        public ConnectDB() // Constructor
        {
            conn = new SqlConnection(strCon);
            comm = conn.CreateCommand(); // Tạo SqlCommand một lần khi khởi tạo ConnectDB
        }

        public void OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (SqlException ex) // Bắt lỗi SQL cụ thể
            {
                throw new Exception("Lỗi khi mở kết nối cơ sở dữ liệu: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi mở kết nối: " + ex.Message, ex);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi đóng kết nối cơ sở dữ liệu: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi đóng kết nối: " + ex.Message, ex);
            }
        }

        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            try
            {
                conn.Open();
                comm.CommandText = strSQL;
                comm.CommandType = ct;
                comm.Connection = conn; // Đảm bảo SqlCommand dùng đúng SqlConnection

                da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi truy vấn dữ liệu: " + ex.Message, ex);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();

            try
            {
                conn.Open();
                comm.CommandText = strSQL;
                comm.CommandType = ct;
                comm.Connection = conn; // Đảm bảo SqlCommand dùng đúng SqlConnection

                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = "Lỗi không xác định: " + ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return f;
        }
    }
}
