using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class LoaiMonAn
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from LOAIMA;", cnn);
            da.Fill(ds_pn, "LOAIMA");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["LOAIMA"].Columns[0];

            ds_pn.Tables["LOAIMA"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["LOAIMA"];
        }
        public bool Themcc(int id, string TenLoaiMA)
        {
            try
            {
                DataRow row = ds_pn.Tables["LOAIMA"].NewRow();
                row["id"] = id;
                row["TenLoaiMA"] = TenLoaiMA;
       
                ds_pn.Tables["LOAIMA"].Rows.Add(row);
                string sql = "select * from LOAIMA";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "LOAIMA");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoancc(int pMancc)
        {
            try
            {

                //1.Tao dong du lieu moi
                DataRow rowdata = ds_pn.Tables["LOAIMA"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "LOAIMA");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(int id, string TenLoaiMA)
        {
            try
            {
                DataRow row = ds_pn.Tables["LOAIMA"].Rows.Find(id);
                row["TenLoaiMA"] = TenLoaiMA;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "LOAIMA");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
