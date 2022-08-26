using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhaHang.DAO
{
    class Database
    {
        SqlConnection sqlconn;
        DataSet ds;
        SqlDataAdapter da;

        public Database()
        {
            string connStr;
            connStr = @"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True";
            //connStr = @"Data Source=QUOCKHANH-PC\SQLEXPRESS;Initial Catalog=QLBS;Integrated Security=True";
            sqlconn = new SqlConnection(connStr);

        }
        public DataTable Execute(string strQuery)
        {
            da = new SqlDataAdapter(strQuery, sqlconn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExecuteNonQuery(string strquery)
        {
            SqlCommand sqlcom = new SqlCommand(strquery, sqlconn);
            sqlconn.Open();
            sqlcom.ExecuteNonQuery();
            sqlconn.Close();
        }
        public void Update(string strQuery, DataTable table)
        {
            da = new SqlDataAdapter(strQuery, sqlconn);
            SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
            da.Update(table);
        }
    }
}
