using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace QuanLyNhaHang
{
    public partial class Frmthongke : Form
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        public Frmthongke()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(rdmhnhieu1.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select TOP(5)TENMONAN,count([TENMONAN]) as SLBan from [dbo].[CHITIETHD] c,monan m where c.MaMon=m.mamon group by TENMONAN order by count([TENMONAN]) desc", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            if(rdthongketheongay.Checked==true)
            {
                 cnn.Open();
                SqlCommand cmd = new SqlCommand("select * from Hoadon where NgayLap ='" + txttheongay.Text + "'", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();

            }
            if(rd1.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select * from Hoadon where NgayLap >'" + txtngaybd.Text + "' and NgayLap < '" + txtngaykt.Text + "'", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            if(rdthongketheothang.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from HOADON where MONTH(ngaylap)= '" + cbtheothang.Text + "' and year(ngaylap)='" + txtnam.Text + "' ", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            if(rdthongketheonam.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from HOADON where year(ngaylap)='" + txtthongketheonam.Text + "' ", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
    
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(rddtngay.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select sum(tongtien) as TongTien from HOADON where ngaylap='" + txtdtngay.Text + "'", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            if(rddtthang.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select sum(tongtien) as TongTien from HOADON where MONTH(ngaylap)= '" + cbdtthang.Text + "' and year(ngaylap)='" + txtdtthang.Text + "'", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            if(rddtnam.Checked==true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("select sum(tongtien) as TongTien from HOADON where year(ngaylap)='" + txtdtnam.Text + "'", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
