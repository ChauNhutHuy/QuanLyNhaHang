using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class DangKy
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from NGUOIDUNG;", cnn);
            da.Fill(ds_pn, "NGUOIDUNG");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["NGUOIDUNG"].Columns[0];

            ds_pn.Tables["NGUOIDUNG"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["NGUOIDUNG"];
        }
        public bool Themcc(string tendn, string pass,string quyen,string manv)
        {
            try
            {
                DataRow row = ds_pn.Tables["NGUOIDUNG"].NewRow();
                row["TenDangNhap"] = tendn;
                row["MatKhau"] = pass;
                row["Quyen"] = quyen;
                row["MANV"] = manv;
                ds_pn.Tables["NGUOIDUNG"].Rows.Add(row);
                string sql = "select * from NGUOIDUNG";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "NGUOIDUNG");
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
                DataRow rowdata = ds_pn.Tables["NGUOIDUNG"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "NGUOIDUNG");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(string tendn, string pass, string quyen, string manv)
        {
            try
            {
                DataRow row = ds_pn.Tables["NGUOIDUNG"].Rows.Find(tendn);
                row["MatKhau"] = pass;
                row["Quyen"] = quyen;
                row["MANV"] = manv;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "NGUOIDUNG");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
