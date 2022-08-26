using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DAO;
using System.Data.SqlClient;
namespace QuanLyNhaHang
{
    public partial class FrmNhanVien : Form
    {
        NhanVien n = new NhanVien();
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtmanv.Enabled = txtdiachi.Enabled = txtngaysinh.Enabled = txtten.Enabled = true;
            btluu.Enabled = true;
            txtmanv.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                n.xoancc((txtmanv.Text));
                MessageBox.Show("Xóa thành công");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtdiachi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtngaysinh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Byte[] i = (byte[])dataGridView1[5, 0].Value;
            MemoryStream stmBLOBData = new MemoryStream(i);
            pictureBox1.Image = Image.FromStream(stmBLOBData);
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }
        public void load()
        {
            dataGridView1.DataSource = n.LoadNhacc();
            //cnn.Open();
            //SqlCommand cmd = new SqlCommand("select * from nhanvien",cnn);
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //cnn.Close();
            txtmanv.Enabled = txtngaysinh.Enabled = txtdiachi.Enabled = txtten.Enabled =false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            load();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        Image ByteArray(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m   );
        }
        string gioitinh;
        private void btluu_Click(object sender, EventArgs e)
        {
          
            var Anh = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
           
            byte[] b = ImageToByteArray(pictureBox1.Image);
       
            if (rdnam.Checked == true)
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            if (txtmanv.Enabled == true)
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("insert into NhanVien values(@manv,@hoten,@diachi,@gioitinh,@ngaysinh,@hinhanh)", cnn);
                cmd.Parameters.Add("@manv", txtmanv.Text);
                cmd.Parameters.Add("@hoten", txtten.Text);
                cmd.Parameters.Add("@diachi", txtdiachi.Text);
                cmd.Parameters.Add("@gioitinh", gioitinh);
                cmd.Parameters.Add("@ngaysinh", txtngaysinh.Text);
                cmd.Parameters.Add("@hinhanh",b);
                cmd.ExecuteNonQuery();
                cnn.Close();
                load();
                //loaddata();
            }
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string masua = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (n.suancc(masua, txtten.Text, (txtdiachi.Text), gioitinh, txtngaysinh.Text,Anh.ToString()) == true)
                    {
                        MessageBox.Show("Sửa thành công !");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtdiachi.Enabled = txtngaysinh.Enabled = txtten.Enabled=true;
        }
    }
}
