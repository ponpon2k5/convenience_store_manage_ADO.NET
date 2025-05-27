namespace Convenience_Store_Management
{
    partial class FormKhachHang
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
            pnlKhachHang = new Panel();
            panelNhanVien = new Panel();
            btnExit = new Button();
            pictureBox1 = new PictureBox();
            btnGioHang = new Button();
            btnSanPham = new Button();
            btnThanhVien = new Button();
            panelNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlKhachHang
            // 
            pnlKhachHang.Location = new Point(196, 0);
            pnlKhachHang.Name = "pnlKhachHang";
            pnlKhachHang.Size = new Size(864, 547);
            pnlKhachHang.TabIndex = 5;
            // 
            // panelNhanVien
            // 
            panelNhanVien.BackColor = Color.Red;
            panelNhanVien.Controls.Add(btnThanhVien);
            panelNhanVien.Controls.Add(btnExit);
            panelNhanVien.Controls.Add(pictureBox1);
            panelNhanVien.Controls.Add(btnGioHang);
            panelNhanVien.Controls.Add(btnSanPham);
            panelNhanVien.Location = new Point(-1, -1);
            panelNhanVien.Name = "panelNhanVien";
            panelNhanVien.Size = new Size(195, 551);
            panelNhanVien.TabIndex = 4;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(26, 479);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(142, 45);
            btnExit.TabIndex = 5;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.convenience_store;
            pictureBox1.Location = new Point(26, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(142, 95);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnGioHang
            // 
            btnGioHang.Location = new Point(26, 238);
            btnGioHang.Name = "btnGioHang";
            btnGioHang.Size = new Size(142, 45);
            btnGioHang.TabIndex = 1;
            btnGioHang.Text = "Giỏ hàng";
            btnGioHang.UseVisualStyleBackColor = true;
            btnGioHang.Click += btnGioHang_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.Location = new Point(26, 169);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(142, 45);
            btnSanPham.TabIndex = 0;
            btnSanPham.Text = "Sản phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnThanhVien
            // 
            btnThanhVien.Location = new Point(26, 312);
            btnThanhVien.Name = "btnThanhVien";
            btnThanhVien.Size = new Size(142, 45);
            btnThanhVien.TabIndex = 6;
            btnThanhVien.Text = "Thành viên";
            btnThanhVien.UseVisualStyleBackColor = true;
            btnThanhVien.Click += btnThanhVien_Click;
            // 
            // FormKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 548);
            Controls.Add(pnlKhachHang);
            Controls.Add(panelNhanVien);
            Name = "FormKhachHang";
            Text = "FormKhachHang";
            panelNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKhachHang;
        private Panel panelNhanVien;
        private Button btnExit;
        private PictureBox pictureBox1;
        private Button btnThongKe;
        private Button btnTimKiem;
        private Button btnGioHang;
        private Button btnSanPham;
        private Button btnThanhVien;
    }
}