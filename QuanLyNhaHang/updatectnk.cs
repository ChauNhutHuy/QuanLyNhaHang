using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DAO;
namespace QuanLyNhaHang
{
    class updatectnk
    {
        Database db;
        public updatectnk()
        {
            db = new Database();
        }
        public void Capnhap(string tentp,int soluong)
        {
            string str = string.Format("update CTNHAPKHO SET SL=SL-{0} WHERE TenThucPham='{1}'",soluong,tentp);
            db.ExecuteNonQuery(str);
        }
        public DataTable LayDSMaSach()
        {
            return db.Execute("select * from SACH");
        }
        public DataTable Tim(string strValue,int sl)
        {
            return db.Execute("select sl from [dbo].[CTNHAPKHO] where TenThucPham=N"+strValue+"");
        }
    }
}
