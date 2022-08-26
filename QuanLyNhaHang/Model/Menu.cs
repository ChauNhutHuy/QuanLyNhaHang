using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyNhaHang.Model
{
    class Menu
    {
        public Menu(string foodName, int count, float price, float totalPrice = 0)
        {
            this.Tenma = foodName;
            this.Sl = count;
            this.Gia = price;
            this.Tongia = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.Tenma = row["TENMONAN"].ToString();
            this.Sl = (int)row["sl"];
            this.Gia = (float)Convert.ToDouble(row["DonGia"].ToString());
            this.Tongia = (float)Convert.ToDouble(row["TongTien"].ToString());
        }

        private float tonggia;

        public float Tongia
        {
            get { return tonggia; }
            set { tonggia = value; }
        }

        private float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private int sl;

        public int Sl
        {
            get { return sl; }
            set { sl = value; }
        }

        private string tenma;

        public string Tenma
        {
            get { return tenma; }
            set { tenma = value; }
        }
    }
}
