
namespace QuanLyNhaHang
{
    partial class FrmLoaiMA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoaiMA));
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtloaima = new System.Windows.Forms.TextBox();
            this.txtma = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btthoat = new System.Windows.Forms.Button();
            this.btluu = new System.Windows.Forms.Button();
            this.btsua = new System.Windows.Forms.Button();
            this.btxoa = new System.Windows.Forms.Button();
            this.btthem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(223, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "LOẠI MÓN ĂN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtloaima);
            this.groupBox1.Controls.Add(this.txtma);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(254, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loai MA";
            // 
            // txtloaima
            // 
            this.txtloaima.Location = new System.Drawing.Point(86, 61);
            this.txtloaima.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtloaima.Name = "txtloaima";
            this.txtloaima.Size = new System.Drawing.Size(151, 21);
            this.txtloaima.TabIndex = 3;
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(86, 28);
            this.txtma.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(151, 21);
            this.txtma.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại MA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(278, 41);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(297, 99);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loại Món Ăn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(282, 69);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btthoat
            // 
            this.btthoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btthoat.BackgroundImage")));
            this.btthoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btthoat.Location = new System.Drawing.Point(497, 162);
            this.btthoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(78, 37);
            this.btthoat.TabIndex = 4;
            this.btthoat.UseVisualStyleBackColor = true;
            // 
            // btluu
            // 
            this.btluu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btluu.BackgroundImage")));
            this.btluu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btluu.Location = new System.Drawing.Point(374, 162);
            this.btluu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btluu.Name = "btluu";
            this.btluu.Size = new System.Drawing.Size(78, 37);
            this.btluu.TabIndex = 3;
            this.btluu.UseVisualStyleBackColor = true;
            this.btluu.Click += new System.EventHandler(this.btluu_Click);
            // 
            // btsua
            // 
            this.btsua.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btsua.BackgroundImage")));
            this.btsua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btsua.Location = new System.Drawing.Point(249, 162);
            this.btsua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btsua.Name = "btsua";
            this.btsua.Size = new System.Drawing.Size(78, 37);
            this.btsua.TabIndex = 2;
            this.btsua.UseVisualStyleBackColor = true;
            this.btsua.Click += new System.EventHandler(this.btsua_Click);
            // 
            // btxoa
            // 
            this.btxoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btxoa.BackgroundImage")));
            this.btxoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btxoa.Location = new System.Drawing.Point(124, 162);
            this.btxoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(78, 37);
            this.btxoa.TabIndex = 1;
            this.btxoa.UseVisualStyleBackColor = true;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // btthem
            // 
            this.btthem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btthem.BackgroundImage")));
            this.btthem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btthem.Location = new System.Drawing.Point(13, 162);
            this.btthem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(78, 37);
            this.btthem.TabIndex = 0;
            this.btthem.UseVisualStyleBackColor = true;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // FrmLoaiMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(584, 218);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btluu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btsua);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btxoa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btthem);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmLoaiMA";
            this.Text = "FrmLoaiMA";
            this.Load += new System.EventHandler(this.FrmLoaiMA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtloaima;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btthoat;
        private System.Windows.Forms.Button btluu;
        private System.Windows.Forms.Button btsua;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.Button btthem;
    }
}