
using System;
using System.Data;
using Convenience_Store_Management.DAL;

namespace QLBanHang_3Tang.BS_layer
{
    public class BLHangHoa
    {
        private ConnectDB db;

        public BLHangHoa()
        {
            db = new ConnectDB();
        }

        public DataSet LayHangHoa()
        {
            string sql = "SELECT MaSanPham, TenSP, SoLuong, Gia FROM HANG_HOA";
            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }
    }
}