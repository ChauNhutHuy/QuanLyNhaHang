using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class NhanVien
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from NhanVien;", cnn);
            da.Fill(ds_pn, "NhanVien");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["NhanVien"].Columns[0];

            ds_pn.Tables["NhanVien"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["NhanVien"];
        }
        public bool KTKC(string pMa)
        {
            DataRow rowData = ds_pn.Tables["NhanVien"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Themcc(string pmanv, string photen, string diachi,string gioitinh,string ngaysinh,string hinhanh)
        {
            try
            {
                DataRow row = ds_pn.Tables["NhanVien"].NewRow();
                row["MaNV"] = pmanv;
                row["hoten"] = photen;
                row["diachi"] = diachi;
                row["gioitinh"] = gioitinh;
                row["ngaysinh"] = ngaysinh;
                row["hinhanh"] = hinhanh;
                ds_pn.Tables["NhanVien"].Rows.Add(row);
                string sql = "select * from NhanVien";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "NhanVien");
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
                DataRow rowdata = ds_pn.Tables["NhanVien"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "NhanVien");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(string manv, string photen,string diachi,string gioitinh,string ngaysinh,string hinhanh)
        {
            try
            {
                DataRow row = ds_pn.Tables["NhanVien"].Rows.Find(manv);
                row["MaNV"] = manv;
                row["hoten"] = photen;
                row["diachi"] = diachi;
                row["gioitinh"] = gioitinh;
                row["ngaysinh"] = ngaysinh;
                row["hinhanh"] = hinhanh;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "NhanVien");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
