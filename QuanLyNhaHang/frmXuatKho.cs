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
using QuanLyNhaHang.Model;
namespace QuanLyNhaHang
{
    public partial class frmXuatKho : Form
    {
        clsdatabase c = new clsdatabase();
        xuatkho x = new xuatkho();
        public frmXuatKho()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtma.Enabled = txtsl.Enabled = txtngay.Enabled = txttentp.Enabled = comboBox1.Enabled = true;
            btluu.Enabled = true;
            txtma.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                x.xoancc((txtma.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
             txtsl.Enabled = txtngay.Enabled = txttentp.Enabled = comboBox1.Enabled = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Enabled == true)
            {
                if (x.Themcc((txtma.Text), txtngay.Text, comboBox1.Text,txttentp.Text,int.Parse(txtsl.Text)) == true)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");

                }
                //loaddata();
            }
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string masua = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (x.suancc(masua, txtngay.Text, comboBox1.Text, txttentp.Text, int.Parse(txtsl.Text)) == true)
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

        private void btthoat_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtngay.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttentp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtsl.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtma.Enabled = false;
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }
        public void loaddata()
        {
            c.loadcombobox(comboBox1, "select manv from NhanVien", 0);
            dataGridView1.DataSource = x.LoadNhacc();
            txtma.Enabled = txtsl.Enabled = txtngay.Enabled = txttentp.Enabled = comboBox1.Enabled = false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void frmXuatKho_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
