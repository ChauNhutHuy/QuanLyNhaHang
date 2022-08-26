using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QuanLyNhaHang
{
    public partial class Form1 : Form
    {
        Clsdatabase cls = new Clsdatabase();
        private SqlConnection Con = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.username;
            textBox2.Text = Properties.Settings.Default.password;
            if (Properties.Settings.Default.username != "")
            {
                checkBox1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True";
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) From NGUOIDUNG where TenDangNhap=N'" + textBox1.Text + "' and MatKhau='" + textBox2.Text + "'", Con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {           
                Con.Open();
                string select = "Select * From NGUOIDUNG where TenDangNhap='" + textBox1.Text + "' and MatKhau='" + textBox2.Text + "' and Quyen='Admin'";
                SqlCommand cmd = new SqlCommand(select, Con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Read();
                    MessageBox.Show("Đăng Nhập Vào Hệ Thống (Quyền Admin) !", "Thông báo !");
                    FormMain frm = new FormMain();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Vào Hệ Thống (Quyền user) !", "Thông báo !");
                    FrmUser frm = new FrmUser();
                    this.Hide();
                    frm.Show();
                }


            }
            else
            {
                MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng!", "Thông báo !");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text !="")
            {
                if (checkBox1.Checked == true)
                {
                    string usernam1 = textBox1.Text;
                    string password1 = textBox2.Text;
                    Properties.Settings.Default.username = usernam1;
                    Properties.Settings.Default.password = password1;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
