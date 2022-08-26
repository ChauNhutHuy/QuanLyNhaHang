using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.Model
{
    class Monan
    {
        public Monan(int id, string name, float price,int categoryID)
        {
            this.Mamon = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }
        public Monan(DataRow row)
        {
            this.Mamon = (int)row["MaMon"];
            this.Name = row["TENMONAN"].ToString();
            this.Price = (float)Convert.ToDouble(row["dongia"].ToString());
            this.CategoryID = (int)row["idloaima"];        
        }

        private float donGia;

        public float Price
        {
            get { return donGia; }
            set { donGia = value; }
        }

        private int idloaima;

        public int CategoryID
        {
            get { return idloaima; }
            set { idloaima = value; }
        }

        private string TENMONAN;

        public string Name
        {
            get { return TENMONAN; }
            set { TENMONAN = value; }
        }

        private int mamon;

        public int Mamon
        {
            get { return mamon; }
            set { mamon = value; }
        }
    }
}
