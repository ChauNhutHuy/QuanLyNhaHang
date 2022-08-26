using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class nhapkho
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from NHAPKHO;", cnn);
            da.Fill(ds_pn, "NHAPKHO");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["NHAPKHO"].Columns[0];

            ds_pn.Tables["NHAPKHO"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["NHAPKHO"];
        }
        public bool KTKC(int pMa)
        {
            DataRow rowData = ds_pn.Tables["NHAPKHO"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Themcc(string pmancc, string pmanv,string ngay,float dongia)
        {
            try
            {
                DataRow row = ds_pn.Tables["NHAPKHO"].NewRow();
                row["MaNhapKho"] = pmancc;
                row["MANV"] = pmanv;
                row["NGAYNHAPKHO"] = ngay;
                row["Dongia_NhapKho"] = dongia;
                ds_pn.Tables["NhapKho"].Rows.Add(row);
                string sql = "select * from NHAPKHO";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "NHAPKHO");
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
                DataRow rowdata = ds_pn.Tables["NHAPKHO"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "NHAPKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(string pmancc, string pmanv, string ngay, float dongia)
        {
            try
            {
                DataRow row = ds_pn.Tables["NHAPKHO"].Rows.Find(pmancc);
                row["MANV"] = pmanv;
                row["NGAYNHAPKHO"] = ngay;
                row["Dongia_NhapKho"] = dongia;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "NHAPKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
