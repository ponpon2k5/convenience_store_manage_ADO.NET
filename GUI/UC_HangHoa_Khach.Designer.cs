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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 102);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(851, 324);
            dataGridView1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(5, 60);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(140, 39);
            label3.TabIndex = 17;
            label3.Text = "Sản phẩm:";
            // 
            // btnThemGioHang
            // 
            btnThemGioHang.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemGioHang.Location = new Point(617, 469);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.Size = new Size(197, 37);
            btnThemGioHang.TabIndex = 18;
            btnThemGioHang.Text = "Thêm vào giỏ hàng";
            btnThemGioHang.UseVisualStyleBackColor = true;
            // 
            // UC_HangHoa_Khach
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnThemGioHang);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Name = "UC_HangHoa_Khach";
            Size = new Size(858, 541);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label3;
        private Button btnThemGioHang;
    }
}
