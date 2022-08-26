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
   
    public partial class frmchitietnhapkho : Form
    {
        clsdatabase c = new clsdatabase();
        ctnk m = new ctnk();
        public frmchitietnhapkho()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtthucpham.Enabled = txtdongia.Enabled = txtsl.Enabled = comboBox1.Enabled = true;
            btluu.Enabled = true;
            comboBox1.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                m.xoancc((comboBox1.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtdongia.Enabled = txtsl.Enabled = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (comboBox1.Enabled == true)
            {
                if(kt())
                {
                    if (m.Themcc((comboBox1.Text), txtthucpham.Text, int.Parse(txtsl.Text), float.Parse(txtdongia.Text), float.Parse(txtthanhtien.Text)) == true)
                    {
                        MessageBox.Show("Thêm thành công");
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
                    string masua = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (m.suancc(masua, txtthucpham.Text, int.Parse(txtsl.Text), float.Parse(txtdongia.Text), float.Parse(txtthanhtien.Text)) == true)
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
        private Boolean kt()
        {
            if(txtdongia.Text=="")
            {
                MessageBox.Show("Chưa nhập đơn giá");
                return false;
            }
            if(txtsl.Text=="")
            {
                MessageBox.Show("Chưa nhập số lượng");
                return false;
            }
            if(txtthucpham.Text=="")
            {
                MessageBox.Show("Chưa nhập thực phẩm");
                return false;
            }
            if(comboBox1.Text=="")
            {
                MessageBox.Show("Chưa nhập mã nhập kho");
                return false;
            }
            return true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtthucpham.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsl.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdongia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtthanhtien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }

        private void frmchitietnhapkho_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            c.loadcombobox(comboBox1, "select MaNhapKho from NHAPKHO", 0);
            dataGridView1.DataSource = m.LoadNhacc();
            txtdongia.Enabled = txtsl.Enabled = txtthucpham.Enabled = comboBox1.Enabled =txtthanhtien.Enabled= false ;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
    }
}
