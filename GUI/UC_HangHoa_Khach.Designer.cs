namespace Convenience_Store_Management.GUI
{
    partial class UC_HangHoa_Khach
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
            dataGridView1 = new DataGridView();
            label3 = new Label();
            btnThemGioHang = new Button();
            tensanpham_label = new Label();
            soluongText = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //
            // dataGridView1
            //
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 113);
            dataGridView1.Margin = new Padding(2, 3, 2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(681, 399);
            dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick); // THÊM DÒNG NÀY
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 26);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(125, 68);
            label3.TabIndex = 17;
            label3.Text = "Sản phẩm:";
            //
            // btnThemGioHang
            //
            btnThemGioHang.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemGioHang.Location = new Point(514, 26);
            btnThemGioHang.Margin = new Padding(2, 3, 2, 3);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.Size = new Size(158, 50);
            btnThemGioHang.TabIndex = 18;
            btnThemGioHang.Text = "Thêm vào giỏ hàng";
            btnThemGioHang.UseVisualStyleBackColor = true;
            btnThemGioHang.Click += btnThemGioHang_Click;
            //
            // tensanpham_label
            //
            tensanpham_label.AutoSize = true;
            tensanpham_label.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tensanpham_label.Location = new Point(113, 26);
            tensanpham_label.Margin = new Padding(4, 0, 4, 0);
            tensanpham_label.Name = "tensanpham_label";
            tensanpham_label.Size = new Size(155, 68);
            tensanpham_label.TabIndex = 19;
            tensanpham_label.Text = "Tên sản phẩm";
            //
            // soluongText
            //
            soluongText.Location = new Point(361, 40);
            soluongText.Name = "soluongText";
            soluongText.Size = new Size(104, 27);
            soluongText.TabIndex = 20;
            //
            // UC_HangHoa_Khach
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(soluongText);
            Controls.Add(tensanpham_label);
            Controls.Add(btnThemGioHang);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Margin = new Padding(2, 3, 2, 3);
            Name = "UC_HangHoa_Khach";
            Size = new Size(686, 515);
            Load += UC_HangHoa_Khach_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label3;
        private Button btnThemGioHang;
        private Label tensanpham_label;
        private TextBox soluongText;
    }
}