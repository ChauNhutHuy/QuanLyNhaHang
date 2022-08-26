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
    public partial class Frmsetting : Form
    {
        public Frmsetting()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmdangkitk fr = new frmdangkitk();
            fr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCAPNHATMK fr = new frmCAPNHATMK();
            fr.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormMain fr = new FormMain();
            fr.Close();
            this.Close();
            Form1 f = new Form1();
        
            f.ShowDialog();
        }
    }
}
