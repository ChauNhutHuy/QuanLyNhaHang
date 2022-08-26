using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyNhaHang.Model
{
    class banan
    {
        public banan(int id, string ten, string tinhtrang)
        {
            this.ID = id;
            this.Ten = ten;
            this.Tinhtrang = tinhtrang;
        }

        public banan(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Ten = row["ten"].ToString();
            this.Tinhtrang = row["tinhtrang"].ToString();
        }

        private string tinhtrang;

        public string Tinhtrang
        {
            get { return tinhtrang; }
            set { tinhtrang = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
