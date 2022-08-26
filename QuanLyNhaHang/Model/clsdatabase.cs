using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.Model
{
    class clsdatabase
    {
        private string connectionSTR = @"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True";
        SqlConnection sqlcon;
        SqlCommand sqlcom;

        SqlDataReader sqldr;
        DataSet ds = new DataSet();
        void ketnoi()
        {
            sqlcon = new SqlConnection(connectionSTR);
            sqlcon.Open();
        }
        void ngatketnoi()
        {
            sqlcon.Close();
        }

        public void loadcombobox(ComboBox cb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Items.Add(sqldr[chiso].ToString());
            }
            ngatketnoi();
        }
    }
}
