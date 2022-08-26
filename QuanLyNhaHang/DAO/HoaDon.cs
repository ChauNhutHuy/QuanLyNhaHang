using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class HoaDon
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();

        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from HoaDon", cnn);
            da.Fill(ds_pn, "HoaDon");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["HoaDon"].Columns[0];

            ds_pn.Tables["HoaDon"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["HoaDon"];
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
        public List<string> Loadmanv()
        {
            List<string> ds = new List<string>();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                string sql = "select * from NhanVien";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string makhoa = dr["Manv"].ToString();
                    ds.Add(makhoa);
                }
                dr.Close();
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                return ds;
            }
            catch
            {
                return null;

            }
        }
        public bool Themcc(int id,string ngaylap,string manv, int idtable,string tt, float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["HoaDon"].NewRow();
                row["MAHD"] = id;
                row["NgayLap"] = ngaylap;
                row["MANV"] = manv;
                row["idtable"] = idtable;
                row["tinhtrang"] = tt;
                row["TongTien"] = tongtien;
                ds_pn.Tables["HoaDon"].Rows.Add(row);
                string sql = "select * from HoaDon";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "HoaDon");
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
                DataRow rowdata = ds_pn.Tables["HoaDon"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "HoaDon");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(int id, string ngaylap, string manv, int idtable, string tt, float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["HoaDon"].Rows.Find(id);
                row["NgayLap"] = ngaylap;
                row["MANV"] = manv;
                row["idtable"] = idtable;
                row["tinhtrang"] = tt;
                row["TongTien"] = tongtien;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "HoaDon");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
