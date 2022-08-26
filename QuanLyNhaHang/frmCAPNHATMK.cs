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
using QuanLyNhaHang.DAO;
namespace QuanLyNhaHang
{
    public partial class frmCAPNHATMK : Form
    {
        DangKy d = new DangKy();
        public frmCAPNHATMK()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) From NGUOIDUNG where TenDangNhap=N'" + txtdn.Text + "' and MatKhau='" + txtmkcu.Text + "'",cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if(dt.Rows[0][0].ToString() =="1")
            {
                if(txtmkmoi.Text==txtmkmoi1.Text)
                {
                 
                    {
                        SqlDataAdapter da1 = new SqlDataAdapter("update NGUOIDUNG set MatKhau=N'" + txtmkmoi.Text + "' where TenDangNhap=N'" + txtdn.Text + "'and MatKhau='" + txtmkcu.Text + "'", cn);
                        DataTable dt1 = new DataTable();
                        da1.Fill(dt1);
                        MessageBox.Show("Đổi mật khẩu thành công !!!");
                    }
                    
                   
                }else
                {
                    errorProvider1.SetError(txtmkmoi, "Bạn chưa điển mật khẩu");
                    errorProvider1.SetError(txtmkmoi1, "Mật khẩu nhật lại chưa đúng");
                }
            }
            else
            {
                errorProvider1.SetError(txtdn, "Tên Đăng Nhập Không Chính Xác");
                errorProvider1.SetError(txtmkcu, "Mật Khẩu Cũ Không Đúng");
            }
        }
        private void frmCAPNHATMK_Load(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
