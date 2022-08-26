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
    public partial class frmhoadon : Form
    {
        clsdatabase c = new clsdatabase();
        HoaDon h = new HoaDon();
        NhanVien n = new NhanVien();
        public frmhoadon()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtma.Enabled = txtngaylap.Enabled = cbmanv.Enabled = cbidba.Enabled = true;
            btluu.Enabled = true;
            txtma.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                h.xoancc(int.Parse(txtma.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btluu_Click(object sender, EventArgs e)
        {
                if (txtma.Enabled == true)
                {
                    if(kttrong())
                    {
                        if (h.Themcc(int.Parse(txtma.Text), txtngaylap.Text, cbmanv.Text, int.Parse(cbidba.Text), "0", float.Parse(txtthanhtien.Text)) == true)
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        else if(h.KTKC(int.Parse(txtma.Text))==false)
                        {
                            MessageBox.Show("Trung khóa chinh");
                        }else
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
                        if (h.suancc(int.Parse(txtma.Text), txtngaylap.Text, label3.Text, int.Parse(cbidba.Text), "0", float.Parse(txtthanhtien.Text)) == true)
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
            txtngaylap.Enabled = cbmanv.Enabled = cbidba.Enabled = true;
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            frmcthd fr = new frmcthd();
            fr.ShowDialog();
        }
        public void loaddata()
        {
            //c.loadcombobox(cbmanv, "select manv from NhanVien", 0);
            
            c.loadcombobox(cbidba, "select id from banan", 0);
            dataGridView1.DataSource = h.LoadNhacc();
            txtma.Enabled = txtngaylap.Enabled = cbmanv.Enabled = cbidba.Enabled = txtthanhtien.Enabled=false ;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void frmhoadon_Load(object sender, EventArgs e)
        {
            cbmanv.DataSource = n.LoadNhacc();
            cbmanv.DisplayMember = "HOTEN";
            cbmanv.ValueMember = "MaNV";
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtngaylap.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbmanv.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbidba.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtthanhtien.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
            txtma.Enabled = false;
        }
        private Boolean kttrong()
        {
            if (txtma.Text == "")
            {
                MessageBox.Show("Nhap ma bn oi!!!!");
                return false;
            }
            if (txtngaylap.Text == "")
            {
                MessageBox.Show("Chua nhap ngay bn oi!!!!");
                return false;
            }
            if (txtthanhtien.Text == "")
            {
                MessageBox.Show("Chua nhap thanh tien bn oi!!!!");
                return false;
            }
                
            if (cbmanv.Text == "")
            {
                MessageBox.Show("Chua Nhap ma bn oi!!!!");
                return false;
            }
            if (cbidba.Text == "")
            {
                MessageBox.Show("Chua nhap ban an  bn oi!!!!");
                return false;
            }
            return true; 
        }
        private void cbmanv_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = cbmanv.SelectedValue.ToString();
        }
    }
}
