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
    public partial class DatBan : Form
    {
        DatBan1 d = new DatBan1();
        clsdatabase c = new clsdatabase();
        public DatBan()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmadb.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txttenkhach.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsl.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtngay.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtmadb.Enabled = txtngay.Enabled = txttenkhach.Enabled = txtsl.Enabled=comboBox1.Enabled= true;
            btluu.Enabled = true;
            txtmadb.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                d.xoancc(int.Parse(txtmadb.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtngay.Enabled = txtsl.Enabled = txttenkhach.Enabled =comboBox1.Enabled =true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtmadb.Enabled == true)
            {
                if(kt())
                { 
                    if (d.Themcc(int.Parse(txtmadb.Text), txttenkhach.Text, int.Parse(txtsl.Text), txtngay.Text,(comboBox1.Text)) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                    }else if(d.KTKC(int.Parse(txtmadb.Text))==false)
                    {
                        MessageBox.Show("Trùng khóa chính !!!");
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
                    if (d.suancc(masua, txttenkhach.Text, int.Parse(txtsl.Text), txtngay.Text, (comboBox1.Text)) == true)
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
        public void load()
        {
            c.loadcombobox(comboBox1, "select manv from NhanVien", 0);
            dataGridView1.DataSource = d.LoadNhacc();
            txtmadb.Enabled = txtngay.Enabled = txtsl.Enabled = txttenkhach.Enabled = comboBox1.Enabled= false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void DatBan_Load(object sender, EventArgs e)
        {
            load();
        }
        private Boolean kt()
        {
            if (txtmadb.Text == "")
            {
                MessageBox.Show("Chưa nhập mã");
                return false;
            }
            if(txtngay.Text=="")
            {
                MessageBox.Show("Chưa nhập ngày");
                return false;
            }

            if (txtsl.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng");
                return false;
            }
            if(comboBox1.Text=="")
            {
                MessageBox.Show("Chưa nhâp mã nhân viên");
                return false;
            }
            if(txttenkhach.Text=="")
            {
                MessageBox.Show("Chưa nhập tên khách");
                return false;
            }
            return true;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
