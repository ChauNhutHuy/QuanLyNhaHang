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
    public partial class FrmQLKHO : Form
    {
        clsdatabase c = new clsdatabase();
        nhapkho n = new nhapkho();
        ctnk m = new ctnk();
        xuatkho x = new xuatkho();
        updatectnk u = new updatectnk();
        public FrmQLKHO()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FrmQLKHO_Load(object sender, EventArgs e)
        {
            loaddata();
            loaddata1();
            loaddata2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtngay.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdongia.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btxoa.Enabled = true;
            btsua.Enabled = true;
            txtma.Enabled = false;
        }
        public void loaddata()
        {
            txtdongia.Text = "0";
            c.loadcombobox(comboBox1, "select manv from NhanVien", 0);
            dataGridView1.DataSource = n.LoadNhacc();

            txtma.Enabled = txtngay.Enabled = txtdongia.Enabled = comboBox1.Enabled = txtdongia.Enabled = false;
            btxoa.Enabled = btsua.Enabled = btluu.Enabled = false;
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            txtma.Enabled = txtngay.Enabled = comboBox1.Enabled = true;
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
            txtma.Enabled = txtngay.Enabled = comboBox1.Enabled = true;
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Enabled == true)
            {
                if (n.Themcc((txtma.Text), comboBox1.Text, txtngay.Text, float.Parse(txtdongia.Text)) == true)
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtthucpham.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtsl.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtdg.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtthanhtien.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Enabled = false;
            btxoa1.Enabled = true;
            btsua1.Enabled = true;
        }
        public void loaddata1()
        {
            c.loadcombobox(comboBox2, "select MaNhapKho from NHAPKHO", 0);
            dataGridView2.DataSource = m.LoadNhacc();
            txtdg.Enabled = txtsl.Enabled = txtthucpham.Enabled = comboBox2.Enabled = txtthanhtien.Enabled = false;
            btxoa1.Enabled = btsua1.Enabled = btluu1.Enabled = false;
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            txtthucpham.Enabled = txtdg.Enabled = txtsl.Enabled = comboBox2.Enabled = true;
            btluu1.Enabled = true;
            comboBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                m.xoancc((comboBox2.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btluu1.Enabled = true;
            txtdg.Enabled = txtsl.Enabled = true;
        }
        private Boolean kt()
        {
            if (txtdg.Text == "")
            {
                MessageBox.Show("Chưa nhập đơn giá");
                return false;
            }
            if (txtsl.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng");
                return false;
            }
            if (txtthucpham.Text == "")
            {
                MessageBox.Show("Chưa nhập thực phẩm");
                return false;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Chưa nhập mã nhập kho");
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Enabled == true)
            {
                if (kt())
                {
                    if (m.Themcc((comboBox2.Text), txtthucpham.Text, int.Parse(txtsl.Text), float.Parse(txtdg.Text), float.Parse(txtthanhtien.Text)) == true)
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
                if (dataGridView2.CurrentRow != null)
                {
                    string masua = (dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    if (m.suancc(masua, txtthucpham.Text, int.Parse(txtsl.Text), float.Parse(txtdg.Text), float.Parse(txtthanhtien.Text)) == true)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaxk2.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txtngayxk2.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            cbmanv2.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            cbtentp2.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            txtsl2.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            btxoa2.Enabled = true;
            btsua2.Enabled = true;
        }
        public void loaddata2()
        {
            c.loadcombobox(cbmanv2, "select manv from NhanVien", 0);
            c.loadcombobox(cbtentp2, "select TenThucPham from CTNHAPKHO", 0);
            dataGridView3.DataSource = x.LoadNhacc();
            txtmaxk2.Enabled = txtsl2.Enabled = cbtentp2.Enabled = txtngayxk2.Enabled = cbmanv2.Enabled = false;
            btxoa2.Enabled = btsua2.Enabled = btluu2.Enabled = false;


        }
        private void btthem2_Click(object sender, EventArgs e)
        {
            txtmaxk2.Enabled = txtsl2.Enabled = cbtentp2.Enabled = txtngayxk2.Enabled = cbmanv2.Enabled = true;
            btluu2.Enabled = true;
            txtmaxk2.Focus();
        }

        private void btxoa2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                x.xoancc((txtmaxk2.Text));
                MessageBox.Show("Xoa thanh cong");
            }
        }

        private void btsua2_Click(object sender, EventArgs e)
        {
            btluu2.Enabled = true;
            txtsl2.Enabled = cbtentp2.Enabled = txtngayxk2.Enabled = cbmanv2.Enabled = true;
        }

        private void btluu2_Click(object sender, EventArgs e)
        {
            if (txtmaxk2.Enabled == true)
            {    
                if (dataGridView2.CurrentRow.Cells[1].Value.ToString() == cbtentp2.Text)
                {
                    if (Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value.ToString()) - Convert.ToInt32(txtsl2.Text) >= 0)
                    {
                        if (kt())
                        {
                            if (x.Themcc((txtmaxk2.Text), txtngayxk2.Text, cbmanv2.Text, cbtentp2.Text, int.Parse(txtsl2.Text)) == true)
                            {
                                u.Capnhap(cbtentp2.Text, int.Parse(txtsl2.Text));
                                MessageBox.Show("Thêm thành công");
                                loaddata2();
                                loaddata1();
                            }
                            else if (x.KTKC(txtmaxk2.Text) == false)
                            {
                                MessageBox.Show("Mã xuất kho đã có !!!");
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số lượng trong kho k đủ, chỉ còn " + dataGridView2.CurrentRow.Cells[2].Value.ToString());
                    }
                }
                     //loaddata();
            }
            else
            {
                if (dataGridView3.CurrentRow != null)
                {
                    string masua = (dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    if (x.suancc(masua, txtngayxk2.Text, cbmanv2.Text, cbtentp2.Text, int.Parse(txtsl2.Text)) == true)
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
        private Boolean kt2()
        {
            if(txtmaxk2.Text=="")
            {
                MessageBox.Show("Chưa nhập mã xuất kho !!!");
                return false;
            }
            if(txtngayxk2.Text=="")
            {
                MessageBox.Show("Chưa nhập ngày xuất kho !!!");
                return false;
            }
            if(cbtentp2.Text=="")
            {
                MessageBox.Show("Chưa nhập tên thực phẩm xuất kho !!!");
                return false;
            }
            return true;
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
