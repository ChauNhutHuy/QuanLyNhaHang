using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    class ctnk
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds_pn = new DataSet();
        public DataTable LoadNhacc()
        {
            da = new SqlDataAdapter("select * from CTNHAPKHO;", cnn);
            da.Fill(ds_pn, "CTNHAPKHO");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds_pn.Tables["CTNHAPKHO"].Columns[0];

            ds_pn.Tables["CTNHAPKHO"].PrimaryKey = key;
            // trả dữ liệu cho phương thức
            return ds_pn.Tables["CTNHAPKHO"];
        }
        public bool KTKC(string pMa)
        {
            DataRow rowData = ds_pn.Tables["CTNHAPKHO"].Rows.Find(pMa);
            if (rowData != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool Themcc(string pmank, string ptentp,int sl,float giatien,float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["CTNHAPKHO"].NewRow();
                row["MaNhapKho"] = pmank;
                row["TenThucPham"] = ptentp;
                row["SL"] = sl;
                row["GiaTien"] =giatien;
                row["TongTien"] = tongtien;
                ds_pn.Tables["CTNHAPKHO"].Rows.Add(row);
                string sql = "select * from CTNHAPKHO";
                da = new SqlDataAdapter(sql, cnn);
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "CTNHAPKHO");
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
                DataRow rowdata = ds_pn.Tables["CTNHAPKHO"].Rows.Find(pMancc);
                //2.Xoa dong khoi dataset
                rowdata.Delete();
                //4.update vao database
                SqlCommandBuilder build = new SqlCommandBuilder(da);
                //5.update vao DB
                da.Update(ds_pn, "CTNHAPKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suancc(string pmank, string ptentp, int sl, float giatien, float tongtien)
        {
            try
            {
                DataRow row = ds_pn.Tables["CTNHAPKHO"].Rows.Find(pmank);
                row["TenThucPham"] = ptentp;
                row["SL"] = sl;
                row["GiaTien"] = giatien;
                row["TongTien"] = tongtien;
                SqlCommandBuilder buid = new SqlCommandBuilder(da);
                da.Update(ds_pn, "CTNHAPKHO");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
