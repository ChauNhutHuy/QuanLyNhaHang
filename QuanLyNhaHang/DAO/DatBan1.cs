using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class DatBan1
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from DATBAN ", cnn);
            da.Fill(ds_pn, "DATBAN");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["DATBAN"].Columns[0];

            ds_pn.Tables["DATBAN"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["DATBAN"];
        }
        public bool KTKC(int pMa)
        {
            DataRow rowData = ds_pn.Tables["DATBAN"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Themcc(int pmancc, string ptenncc,int sl,string ngay, string id)
        {
            try
            {
                DataRow row = ds_pn.Tables["DATBAN"].NewRow();
                row["MaDatBan"] = pmancc;
                row["TenKhach"] = ptenncc;
                row["SOLUONGBAN"] = sl;
                row["NGAYGIOGOI"] = ngay;
                row["MANV"] = id;
                ds_pn.Tables["DATBAN"].Rows.Add(row);
                string sql = "select * from DATBAN";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "DATBAN");
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
                DataRow rowdata = ds_pn.Tables["DATBAN"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "DATBAN");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(int pmancc, string ptenncc, int sl, string ngay, string id)
        {
            try
            {
                DataRow row = ds_pn.Tables["DATBAN"].Rows.Find(pmancc);
                
                row["TenKhach"] = ptenncc;
                row["SOLUONGBAN"] = sl;
                row["NGAYGIOGOI"] = ngay;
                row["MANV"] = id;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "DATBAN");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
