namespace Convenience_Store_Management.GUI
{
    partial class UC_GioHang_Khach
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
            btnXoaGioHang = new Button();
            button1 = new Button();
            label1 = new Label();
            dgvGioHang = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            SuspendLayout();
            // 
            // btnXoaGioHang
            // 
            btnXoaGioHang.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoaGioHang.Location = new Point(437, 479);
            btnXoaGioHang.Name = "btnXoaGioHang";
            btnXoaGioHang.Size = new Size(197, 37);
            btnXoaGioHang.TabIndex = 20;
            btnXoaGioHang.Text = "Xóa khỏi giỏ hàng";
            btnXoaGioHang.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(679, 479);
            button1.Name = "button1";
            button1.Size = new Size(128, 37);
            button1.TabIndex = 21;
            button1.Text = "Thanh toán";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 68);
            label1.Name = "label1";
            label1.Size = new Size(127, 39);
            label1.TabIndex = 22;
            label1.Text = "Giỏ hàng:";
            // 
            // dgvGioHang
            // 
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Location = new Point(3, 110);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.Size = new Size(852, 347);
            dgvGioHang.TabIndex = 23;
            // 
            // UC_GioHang_Khach
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvGioHang);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnXoaGioHang);
            Name = "UC_GioHang_Khach";
            Size = new Size(858, 541);
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnXoaGioHang;
        private Button button1;
        private Label label1;
        private DataGridView dgvGioHang;
    }
}
