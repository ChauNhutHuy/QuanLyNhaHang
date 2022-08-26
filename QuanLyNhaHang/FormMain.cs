using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FormMain : Form
    {
        private Form activeForm;
        public FormMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien n = new FrmNhanVien();
            n.ShowDialog();
        }
        private void Open(Form fr,object btnSender)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            fr.Dock = DockStyle.Fill;
            fr.TopLevel = false;
            fr.FormBorderStyle = FormBorderStyle.None;
            this.pndestop.Controls.Add(fr);
            this.pndestop.Tag = fr;
            fr.BringToFront();
            fr.Show();
            lbtitle.Text = fr.Text;
        }
            
        private void bànĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {          

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Open(new frmhoadon(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open(new Frmtaikhoan(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open(new FrmNhanVien(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Open(new FrmQLKHO(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Open(new FrmMonAn(), sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Open(new Frmsetting(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Open(new Frmthongke(), sender);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pndestop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
