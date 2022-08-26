using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class MonAn1
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from MONAN", cnn);
            da.Fill(ds_pn, "MONAN");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["MONAN"].Columns[0];

            ds_pn.Tables["MONAN"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["MONAN"];
        }
        public bool KTKC(int pMa)
        {
            DataRow rowData = ds_pn.Tables["MonAn"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Themcc(int pmancc, string ptenncc,float dongia,int id)
        {
            try
            {
                DataRow row = ds_pn.Tables["MonAn"].NewRow();
                row["MaMon"] = pmancc;
                row["TenMonAn"] = ptenncc;
                row["DonGia"] = dongia;
                row["LoaiMonAn"] = id;
                ds_pn.Tables["MonAn"].Rows.Add(row);
                string sql = "select * from MonAn";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "MonAn");
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
                DataRow rowdata = ds_pn.Tables["MonAn"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "MonAn");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(int mancc, string pTenncc,float dongia,int id)
        {
            try
            {
                DataRow row = ds_pn.Tables["MonAn"].Rows.Find(mancc);
                row["TenMonAn"] = pTenncc;
                row["DonGia"] = dongia;
                row["LoaiMonAn"] = id;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "MonAn");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
