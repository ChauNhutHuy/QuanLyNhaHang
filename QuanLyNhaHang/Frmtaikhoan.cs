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
    public partial class Frmtaikhoan : Form
    {
        DangKy d = new DangKy();
        NhanVien n = new NhanVien();
        public Frmtaikhoan()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtdn.Enabled = txtmk.Enabled = cbquyen.Enabled = comboBox1.Enabled = true;
            btluu.Enabled = true;
            txtdn.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                d.xoancc((txtdn.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtmk.Enabled = cbquyen.Enabled = comboBox1.Enabled = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtdn.Enabled == true)
            {
                if (d.Themcc((txtdn.Text), txtmk.Text, cbquyen.Text,comboBox1.Text) == true)
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
                    if (d.suancc(masua, txtmk.Text, cbquyen.Text, comboBox1.Text) == true)
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
        public void loaddata()
        {
            comboBox1.DataSource = n.LoadNhacc();
            comboBox1.DisplayMember = "hoten";
            comboBox1.ValueMember = "MANV";
            dataGridView1.DataSource = d.LoadNhacc();
            txtdn.Enabled = txtmk.Enabled = cbquyen.Enabled = comboBox1.Enabled = false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdn.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtmk.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbquyen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdn.Enabled = false;
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }

        private void Frmtaikhoan_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
