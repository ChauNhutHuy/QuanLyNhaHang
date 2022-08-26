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
using QuanLyNhaHang.Model;
namespace QuanLyNhaHang
{
    public partial class frmcthd : Form
    {
        clsdatabase c = new clsdatabase();
        cthoadon ct = new cthoadon();
        HoaDon h = new HoaDon();
        MonAn1 m = new MonAn1();
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-JFSJJDK\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True");
        SqlDataReader docdulieu;
        SqlCommand thuchien;
        public frmcthd()
        {
            InitializeComponent();
        }

        private void txtthucpham_TextChanged(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtid.Enabled = txtdongia.Enabled = txtsluong.Enabled = cbmahd.Enabled =cbmamon.Enabled = true;
            btluu.Enabled = true;
            txtid.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                ct.xoancc(int.Parse(txtid.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtdongia.Enabled = txtsluong.Enabled = cbmahd.Enabled = cbmamon.Enabled = txtthanhtien.Enabled = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtid.Enabled == true)
            {
                if(kttrong())
                {
                    if (ct.Themcc(int.Parse(txtid.Text), int.Parse(cbmahd.Text), int.Parse(label8.Text), int.Parse(txtsluong.Text), float.Parse(txtdongia.Text), float.Parse(txtthanhtien.Text)) == true)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else if (ct.KTKC(int.Parse(txtid.Text)) == false)
                    {
                        MessageBox.Show("Trùng id bạn ơi");
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
                    if (ct.suancc(masua, int.Parse(cbmahd.Text), int.Parse(label8.Text), int.Parse(txtsluong.Text), float.Parse(txtdongia.Text), float.Parse(txtthanhtien.Text)) == true)
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
        private Boolean kttrong()
        {
            if(txtid.Text=="")
            {
                MessageBox.Show("Chưa nhập id bạn ơi");
                return false;
            }
            if(txtsluong.Text=="")
            {
                MessageBox.Show("Chưa nhập id bạn ơi");
                return false;
            }
            if (txtdongia.Text == "")
            {
                MessageBox.Show("Chưa nhập đơn giá bạn ơi");
                return false;
            }
            if(cbmamon.Text=="")
            {
                MessageBox.Show("Chưa nhập mã món bạn ơi");
                return false;
            }
            if (cbmahd.Text == "")
            {
                MessageBox.Show("Chưa nhập mã hóa đơn bạn ơi");
                return false;
            }
            return true;
        }
        private void btthoat_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbmahd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbmamon.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtsluong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdongia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtthanhtien.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }

        private void frmcthd_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        public void loaddata()
        {
            c.loadcombobox(cbmahd, "select MAHD from HOADON", 0);
            cbmamon.DataSource = m.LoadNhacc();
            cbmamon.DisplayMember = "TENMONAN";
            cbmamon.ValueMember = "MaMon";
            dataGridView1.DataSource = ct.LoadNhacc();
            txtid.Enabled = txtdongia.Enabled = txtsluong.Enabled = cbmahd.Enabled = cbmamon.Enabled= txtthanhtien.Enabled = false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        string lenh;
        private void cbmamon_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            label8.Text = cbmamon.SelectedValue.ToString();
         
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
