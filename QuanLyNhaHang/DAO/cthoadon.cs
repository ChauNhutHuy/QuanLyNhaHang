using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class cthoadon
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from CHITIETHD", cnn);
            da.Fill(ds_pn, "CHITIETHD");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["CHITIETHD"].Columns[0];

            ds_pn.Tables["CHITIETHD"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["CHITIETHD"];
        }
        public bool Themcc(int id, int idhd, int mamon, int sl, float dongia, float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["CHITIETHD"].NewRow();
                row["id"] = id;
                row["mahd"] = idhd;
                row["MaMon"] = mamon;
                row["sl"] = sl;
                row["dongia"] = dongia;
                row["ThanhTien"] = tongtien;
                ds_pn.Tables["CHITIETHD"].Rows.Add(row);
                string sql = "select * from CHITIETHD";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "CHITIETHD");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Themcc1(int id,int idhd, int mamon,int sl,float dongia,float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["CHITIETHD"].NewRow();
                row["id"] = id;
                row["mahd"] = idhd;
                row["MaMon"] = mamon;
                row["sl"] = sl;
                row["dongia"] = dongia;
                row["ThanhTien"] = tongtien;
                ds_pn.Tables["CHITIETHD"].Rows.Add(row);
                string sql = "select * from CHITIETHD";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "CHITIETHD");
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
                DataRow rowdata = ds_pn.Tables["CHITIETHD"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "CHITIETHD");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KTKC(int pMa)
        {
            DataRow rowData = ds_pn.Tables["HoaDon"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool suancc(int id, int idhd, int mamon, int sl, float dongia, float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["CHITIETHD"].Rows.Find(id);
                row["mahd"] = idhd;
                row["MaMon"] = mamon;
                row["sl"] = sl;
                row["dongia"] = dongia;
                row["ThanhTien"] = tongtien;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "CHITIETHD");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
