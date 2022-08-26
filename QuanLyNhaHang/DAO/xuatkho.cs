using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class xuatkho
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from XUATKHO", cnn);
            da.Fill(ds_pn, "XUATKHO");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["XUATKHO"].Columns[0];

            ds_pn.Tables["XUATKHO"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["XUATKHO"];
        }
        public bool KTKC(string pMa)
        {
            DataRow rowData = ds_pn.Tables["XUATKHO"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Themcc(string maxk, string pngay,string manv,string tentp, int sl)
        {
            try
            {
                DataRow row = ds_pn.Tables["XUATKHO"].NewRow();
                row["MAXUATKHO"] = maxk;
                row["NgayXuatKho"] = pngay;
                row["MANV"] = manv;
                row["TenThucPham"] = tentp;
                row["SL"] = sl;
                ds_pn.Tables["XUATKHO"].Rows.Add(row);
                string sql = "select * from XUATKHO";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "XUATKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoancc(string pMancc)
        {
            try
            {

                //1.Tao dong du lieu moi
                DataRow rowdata = ds_pn.Tables["XUATKHO"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "XUATKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(string maxk, string pngay, string manv, string tentp, int sl)
        {
            try
            {
                DataRow row = ds_pn.Tables["XUATKHO"].Rows.Find(maxk);
                row["MAXUATKHO"] = maxk;
                row["NgayXuatKho"] = pngay;
                row["MANV"] = manv;
                row["TenThucPham"] = tentp;
                row["SL"] = sl;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "XUATKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
