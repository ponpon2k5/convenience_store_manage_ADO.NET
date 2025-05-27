using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convenience_Store_Management
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void LoadSubForm(UserControl subForm)
        {
            pnlKhachHang.Controls.Clear(); // remove existing control(s)
            subForm.Dock = DockStyle.Fill; // fill the panel
            pnlKhachHang.Controls.Add(subForm); // add new control
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            LoadSubForm(new GUI.UC_ThanhVien_Khach());
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            LoadSubForm(new GUI.UC_GioHang_Khach());
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            LoadSubForm(new GUI.UC_HangHoa_Khach());
        }
    }
}
