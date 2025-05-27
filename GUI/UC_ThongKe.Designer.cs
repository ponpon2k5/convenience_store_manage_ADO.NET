namespace Convenience_Store_Management.GUI
{
    partial class UC_ThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            label2 = new Label();
            cbHangHoa = new ComboBox();
            dgvHHDaBan = new DataGridView();
            dgvLoiNhuan = new DataGridView();
            cbLoiNhuan = new ComboBox();
            label1 = new Label();
            dgvDoanhThu = new DataGridView();
            cbDoanhThu = new ComboBox();
            label3 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHHDaBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoiNhuan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(858, 541);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvDoanhThu);
            tabPage1.Controls.Add(cbDoanhThu);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(850, 507);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Doanh thu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvLoiNhuan);
            tabPage2.Controls.Add(cbLoiNhuan);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(850, 507);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lợi nhuận";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvHHDaBan);
            tabPage3.Controls.Add(cbHangHoa);
            tabPage3.Controls.Add(label2);
            tabPage3.Location = new Point(4, 30);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(850, 507);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Các mặt hàng đã bán";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 39);
            label2.TabIndex = 13;
            label2.Text = "Lọc theo:";
            // 
            // cbHangHoa
            // 
            cbHangHoa.FormattingEnabled = true;
            cbHangHoa.Items.AddRange(new object[] { "Tuần", "Tháng" });
            cbHangHoa.Location = new Point(138, 126);
            cbHangHoa.Name = "cbHangHoa";
            cbHangHoa.Size = new Size(121, 29);
            cbHangHoa.TabIndex = 14;
            // 
            // dgvHHDaBan
            // 
            dgvHHDaBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHHDaBan.Location = new Point(6, 260);
            dgvHHDaBan.Name = "dgvHHDaBan";
            dgvHHDaBan.Size = new Size(838, 241);
            dgvHHDaBan.TabIndex = 15;
            // 
            // dgvLoiNhuan
            // 
            dgvLoiNhuan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoiNhuan.Location = new Point(6, 260);
            dgvLoiNhuan.Name = "dgvLoiNhuan";
            dgvLoiNhuan.Size = new Size(838, 241);
            dgvLoiNhuan.TabIndex = 18;
            // 
            // cbLoiNhuan
            // 
            cbLoiNhuan.FormattingEnabled = true;
            cbLoiNhuan.Items.AddRange(new object[] { "Tuần", "Tháng" });
            cbLoiNhuan.Location = new Point(138, 126);
            cbLoiNhuan.Name = "cbLoiNhuan";
            cbLoiNhuan.Size = new Size(121, 29);
            cbLoiNhuan.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 120);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 39);
            label1.TabIndex = 16;
            label1.Text = "Lọc theo:";
            // 
            // dgvDoanhThu
            // 
            dgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoanhThu.Location = new Point(6, 260);
            dgvDoanhThu.Name = "dgvDoanhThu";
            dgvDoanhThu.Size = new Size(838, 241);
            dgvDoanhThu.TabIndex = 18;
            // 
            // cbDoanhThu
            // 
            cbDoanhThu.FormattingEnabled = true;
            cbDoanhThu.Items.AddRange(new object[] { "Tuần", "Tháng" });
            cbDoanhThu.Location = new Point(138, 126);
            cbDoanhThu.Name = "cbDoanhThu";
            cbDoanhThu.Size = new Size(121, 29);
            cbDoanhThu.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(8, 120);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 39);
            label3.TabIndex = 16;
            label3.Text = "Lọc theo:";
            // 
            // UC_ThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "UC_ThongKe";
            Size = new Size(858, 541);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHHDaBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoiNhuan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoanhThu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label2;
        private DataGridView dgvDoanhThu;
        private ComboBox cbDoanhThu;
        private Label label3;
        private DataGridView dgvLoiNhuan;
        private ComboBox cbLoiNhuan;
        private Label label1;
        private DataGridView dgvHHDaBan;
        private ComboBox cbHangHoa;
    }
}
