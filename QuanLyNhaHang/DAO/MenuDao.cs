using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.Model;
using System.Data;
namespace QuanLyNhaHang.DAO
{
    class MenuDao
    {
        private static MenuDao instance;

        public static MenuDao Instance
        {
            get { if (instance == null) instance = new MenuDao(); return MenuDao.instance; }
            private set { MenuDao.instance = value; }
        }

        private MenuDao() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "select [TENMONAN],[DonGia],c.sl,c.sl*m.DONGIA as TongTien from MONAN m,HOADON h,CHITIETHD c where h.MAHD=c.idhd and c.MaMon=m.MaMon and tinhtrang=0 and idtable = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
