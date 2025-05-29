// DAL/ConnectDB.cs
using System;
using System.Data;
using Microsoft.Data.SqlClient; // Required for SqlTransaction

namespace Convenience_Store_Management.DAL
{
    public class ConnectDB
    {
        public readonly string strCon = "Data Source=(local);Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True";

        public SqlConnection conn = null;
        public SqlCommand comm = null;
        public SqlDataAdapter da = null;
        public SqlTransaction tran = null; // Add SqlTransaction object here

        public ConnectDB()
        {
            conn = new SqlConnection(strCon);
            comm = conn.CreateCommand();
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
            catch (SqlException ex)
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

        // Method to begin a transaction
        public void BeginTransaction()
        {
            OpenConnection(); // Ensure connection is open
            tran = conn.BeginTransaction();
            comm.Transaction = tran; // Associate command with the transaction
        }

        // Method to commit the transaction
        public void CommitTransaction()
        {
            if (tran != null)
            {
                tran.Commit();
                tran = null; // Reset transaction object
            }
            CloseConnection(); // Close connection after commit
        }

        // Method to rollback the transaction
        public void RollbackTransaction()
        {
            if (tran != null)
            {
                tran.Rollback();
                tran = null; // Reset transaction object
            }
            CloseConnection(); // Close connection after rollback
        }

        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            // Note: DataAdapter operations implicitly handle connections or require them to be open.
            // For transaction safety, consider if this method needs to be part of a transaction.
            // For simple reads, it's usually fine without an explicit transaction here.
            // If you call this during an active transaction, ensure the connection is passed.
            if (conn.State == ConnectionState.Open && tran != null)
            {
                // If there's an active transaction, use it for SELECTs within the transaction scope
                comm.CommandText = strSQL;
                comm.CommandType = ct;
                // comm.Connection and comm.Transaction are already set by BeginTransaction()
                da = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            else
            {
                // For non-transactional reads
                OpenConnection();
                try
                {
                    comm.CommandText = strSQL;
                    comm.CommandType = ct;
                    comm.Connection = conn;
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
                    CloseConnection();
                }
            }
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool f = false;
            // The connection and transaction state will be managed by Begin/Commit/RollbackTransaction in BLL
            // No need to open/close connection here if it's part of a transaction
            try
            {
                comm.CommandText = strSQL;
                comm.CommandType = ct;
                // Connection and Transaction are already set if BeginTransaction was called
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
            return f; // Connection remains open, BLL handles commit/rollback and close
        }
    }
}