using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DAO;
namespace QuanLyNhaHang
{
    public partial class frmdangkitk : Form
    {
        DangKy d = new DangKy();
        public frmdangkitk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtmk.Text==txtmk1.Text)
            {
                if(d.Themcc(txttendn.Text,txtmk.Text,"User",txtmanv.Text))
                {
                    MessageBox.Show("Đăng kí tài khoản thành công !!!");
                }else
                {
                    MessageBox.Show("Đăng kí thất bại!!!");
                }
            }else
            {
                MessageBox.Show("Mật khẩu chưa chính xác");
            }
        }

        private void frmdangkitk_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = d.LoadNhacc();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
