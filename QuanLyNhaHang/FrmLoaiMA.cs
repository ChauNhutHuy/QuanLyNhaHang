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
    public partial class FrmLoaiMA : Form
    {
        LoaiMonAn l = new LoaiMonAn();
        public FrmLoaiMA()
        {
            InitializeComponent();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            txtma.Enabled = txtloaima.Enabled = true;
            btluu.Enabled = true;
            txtma.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                l.xoancc(int.Parse(txtma.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            btluu.Enabled = true;
            txtloaima.Enabled = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Enabled == true)
            {
                if (l.Themcc(int.Parse(txtma.Text), txtloaima.Text) == true)
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
                     int masua = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (l.suancc(masua,txtloaima.Text) == true)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtloaima.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
        }
        public void loaddata()
        {
    
            dataGridView1.DataSource = l.LoadNhacc();
            txtma.Enabled = txtloaima.Enabled = false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void FrmLoaiMA_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
