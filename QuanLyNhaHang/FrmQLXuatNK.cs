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
    public partial class FrmQLXuatNK : Form
    {
        public FrmQLXuatNK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNhapKho fr = new frmNhapKho();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmXuatKho fr = new frmXuatKho();
            fr.ShowDialog();
        }
    }
}
