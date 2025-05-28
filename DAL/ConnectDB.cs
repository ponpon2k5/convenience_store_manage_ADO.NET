using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Convenience_Store_Management.DAL
{
    public class ConnectDB
    {
        public readonly string strCon = "Data Source=.;Initial Catalog=doanwinform;Integrated Security=True";
        public SqlConnection sqlCon = null;
        SqlCommand cmd = null;

        public void OpenConnection()
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
            }
            catch
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
