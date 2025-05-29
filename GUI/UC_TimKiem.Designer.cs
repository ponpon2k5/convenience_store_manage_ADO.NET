namespace Convenience_Store_Management.GUI
{
    partial class UC_TimKiem
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
            btnTimHH = new Button();
            label5 = new Label();
            txtMaHH = new TextBox();
            dataGridView1 = new DataGridView();
            tabPage3 = new TabPage();
            btnTimHD = new Button();
            label1 = new Label();
            txtMaHD = new TextBox();
            dataGridView3 = new DataGridView();
            tabPage4 = new TabPage();
            btnTimKH = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            dataGridView4 = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(858, 541);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnTimHH);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtMaHH);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(850, 507);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Hàng hóa";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTimHH
            // 
            btnTimHH.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimHH.Location = new Point(212, 182);
            btnTimHH.Name = "btnTimHH";
            btnTimHH.Size = new Size(117, 45);
            btnTimHH.TabIndex = 10;
            btnTimHH.Text = "Tìm kiếm";
            btnTimHH.UseVisualStyleBackColor = true;
            btnTimHH.Click += btnTimHH_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 74);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(171, 39);
            label5.TabIndex = 9;
            label5.Text = "Mã hàng hóa:";
            // 
            // txtMaHH
            // 
            txtMaHH.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMaHH.Location = new Point(212, 66);
            txtMaHH.Margin = new Padding(5, 7, 5, 7);
            txtMaHH.Name = "txtMaHH";
            txtMaHH.Size = new Size(342, 47);
            txtMaHH.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 260);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(838, 241);
            dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnTimHD);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(txtMaHD);
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Location = new Point(4, 30);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(850, 507);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Hóa đơn";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnTimHD
            // 
            btnTimHD.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimHD.Location = new Point(210, 181);
            btnTimHD.Name = "btnTimHD";
            btnTimHD.Size = new Size(117, 45);
            btnTimHD.TabIndex = 13;
            btnTimHD.Text = "Tìm kiếm";
            btnTimHD.UseVisualStyleBackColor = true;
            btnTimHD.Click += btnTimHD_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 73);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(152, 39);
            label1.TabIndex = 12;
            label1.Text = "Mã hóa đơn";
            // 
            // txtMaHD
            // 
            txtMaHD.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMaHD.Location = new Point(210, 65);
            txtMaHD.Margin = new Padding(5, 7, 5, 7);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(342, 47);
            txtMaHD.TabIndex = 11;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(6, 260);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(838, 241);
            dataGridView3.TabIndex = 1;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnTimKH);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(textBox1);
            tabPage4.Controls.Add(dataGridView4);
            tabPage4.Location = new Point(4, 30);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(850, 507);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Khách hàng";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnTimKH
            // 
            btnTimKH.Font = new Font("Sans Serif Collection", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimKH.Location = new Point(252, 185);
            btnTimKH.Name = "btnTimKH";
            btnTimKH.Size = new Size(117, 45);
            btnTimKH.TabIndex = 13;
            btnTimKH.Text = "Tìm kiếm";
            btnTimKH.UseVisualStyleBackColor = true;
            btnTimKH.Click += btnTimKH_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(34, 78);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(217, 39);
            label2.TabIndex = 12;
            label2.Text = "SDT khách hàng:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(252, 70);
            textBox1.Margin = new Padding(5, 7, 5, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(342, 47);
            textBox1.TabIndex = 11;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(6, 260);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(838, 244);
            dataGridView4.TabIndex = 1;
            // 
            // UC_TimKiem
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "UC_TimKiem";
            Size = new Size(864, 547);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private TabPage tabPage3;
        private DataGridView dataGridView3;
        private TabPage tabPage4;
        private DataGridView dataGridView4;
        private Button btnTimHH;
        private Label label5;
        private TextBox txtMaHH;
        private Button btnTimHD;
        private Label label1;
        private TextBox txtMaHD;
        private Button btnTimKH;
        private Label label2;
        private TextBox textBox1;
    }
}
