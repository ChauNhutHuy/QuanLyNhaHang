using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyNhaHang
{
    class MonAn
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_ma = new DataSet();
        public DataTable Loadhoadon(int id)
        {
            da = new SqlDataAdapter("select * from HOADON where idtable=" + id, cnn);
            da.Fill(ds_ma, "HOADON");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_ma.Tables["HOADON"].Columns[0];

            ds_ma.Tables["HOADON"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_ma.Tables["HOADON"];
        }
    }
}
