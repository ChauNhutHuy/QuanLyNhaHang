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

    public partial class frmNhapKho : Form
    {
        clsdatabase c = new clsdatabase();
        nhapkho n = new nhapkho();
        public frmNhapKho()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtma.Enabled =  txtngay.Enabled =comboBox1.Enabled = true;
            btluu.Enabled = true;
            txtma.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                n.xoancc((txtma.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtma.Enabled= txtngay.Enabled =comboBox1.Enabled= true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Enabled == true)
            {
                if (n.Themcc((txtma.Text), comboBox1.Text,txtngay.Text, float.Parse(txtdongia.Text)) == true)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");

                }
                loaddata();
            }
            else
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string masua = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (n.suancc(masua, comboBox1.Text, txtngay.Text, float.Parse(txtdongia.Text)) == true)
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
            frmchitietnhapkho fr = new frmchitietnhapkho();
            fr.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtngay.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdongia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }
        public void loaddata()
        {
            txtdongia.Text = "0";
            c.loadcombobox(comboBox1, "select manv from NhanVien", 0);
            dataGridView1.DataSource = n.LoadNhacc();

            txtma.Enabled = txtngay.Enabled = txtdongia.Enabled = comboBox1.Enabled =txtdongia.Enabled= false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
