namespace Convenience_Store_Management
{
    partial class FormNhanVien
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
            pnlNhanVien = new Panel();
            panelNhanVien = new Panel();
            pictureBox1 = new PictureBox();
            btnThongKe = new Button();
            btnTimKiem = new Button();
            btnHoaDon = new Button();
            btnSanPham = new Button();
            btnExit = new Button();
            panelNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlNhanVien
            // 
            pnlNhanVien.Location = new Point(194, 2);
            pnlNhanVien.Name = "pnlNhanVien";
            pnlNhanVien.Size = new Size(864, 547);
            pnlNhanVien.TabIndex = 3;
            // 
            // panelNhanVien
            // 
            panelNhanVien.BackColor = Color.Red;
            panelNhanVien.Controls.Add(btnExit);
            panelNhanVien.Controls.Add(pictureBox1);
            panelNhanVien.Controls.Add(btnThongKe);
            panelNhanVien.Controls.Add(btnTimKiem);
            panelNhanVien.Controls.Add(btnHoaDon);
            panelNhanVien.Controls.Add(btnSanPham);
            panelNhanVien.Location = new Point(-3, 1);
            panelNhanVien.Name = "panelNhanVien";
            panelNhanVien.Size = new Size(195, 551);
            panelNhanVien.TabIndex = 2;
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
            // btnThongKe
            // 
            btnThongKe.Location = new Point(26, 380);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(142, 45);
            btnThongKe.TabIndex = 3;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(26, 307);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(142, 45);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnHoaDon
            // 
            btnHoaDon.Location = new Point(26, 238);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Size = new Size(142, 45);
            btnHoaDon.TabIndex = 1;
            btnHoaDon.Text = "Hóa đơn";
            btnHoaDon.UseVisualStyleBackColor = true;
            btnHoaDon.Click += btnHoaDon_Click;
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
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 552);
            Controls.Add(pnlNhanVien);
            Controls.Add(panelNhanVien);
            Name = "FormNhanVien";
            Text = "FormNhanVien";
            panelNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNhanVien;
        private Panel panelNhanVien;
        private Button btnThongKe;
        private Button btnTimKiem;
        private Button btnHoaDon;
        private Button btnSanPham;
        private PictureBox pictureBox1;
        private Button btnExit;
    }
}