using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.Model;
namespace QuanLyNhaHang
{
    public partial class FrmMonAn : Form
    {
        clsdatabase c = new clsdatabase();
        MonAn1 m = new MonAn1();
        LoaiMonAn l = new LoaiMonAn();
        public FrmMonAn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmMonAn_Load(object sender, EventArgs e)
        {
           loaddata();  
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        public void loaddata()
        {
            comboBox1.DataSource = l.LoadNhacc();
            comboBox1.DisplayMember = "TenLoaiMA";
            comboBox1.ValueMember = "id";
            dataGridView1.DataSource = m.LoadNhacc();
            txtmamon.Enabled = txtdongia.Enabled = txttenma.Enabled =false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            //if(open.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBox1.Image = Image.FromFile(open.FileName);
            //    this.Text = open.FileName;
            //}
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            txtmamon.Enabled = txtdongia.Enabled = txttenma.Enabled = true;
            btluu.Enabled = true;
            txtmamon.Focus();           
        }
        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                m.xoancc(int.Parse(txtmamon.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmamon.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txttenma.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtdongia.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtmamon.Enabled = false;
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }
        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtdongia.Enabled = txttenma.Enabled = true;
        }
        private Boolean kt()
        {
            //if(txtmamon.Text=="")
            //{
            //    MessageBox.Show("chua nhập mã món");
            //    return false;
            //}
            if(txttenma.Text=="")
            {
                MessageBox.Show("chua nhập tên món ăn");
                return false;
            }
            if (txtdongia.Text == "")
            {
                MessageBox.Show("chưa nhập giá tiền");
                return false;
            }
            if(comboBox1.Text=="")
            {
                MessageBox.Show("Chưa nhập loại món ăn");
                return false;
            }
            return true;
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            
            if (txtmamon.Enabled == true)
            {
                if(kt())
                {
            
                    if (m.Themcc(int.Parse(txtmamon.Text), txttenma.Text, float.Parse(txtdongia.Text), int.Parse(label3.Text)) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                    }else if(m.KTKC(int.Parse(txtmamon.Text))==false)
                    {
                        MessageBox.Show("Mã món đã có");
                    } 
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }   
                //loaddata();
            }
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int masua = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (m.suancc(masua,txttenma.Text, float.Parse(txtdongia.Text), int.Parse(label3.Text)) == true)
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = comboBox1.SelectedValue.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLoaiMA fr = new FrmLoaiMA();
            fr.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttenma_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmamon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
 