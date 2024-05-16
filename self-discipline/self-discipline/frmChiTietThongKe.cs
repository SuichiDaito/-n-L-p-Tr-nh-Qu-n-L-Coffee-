using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace self_discipline
{
    public partial class frmChiTietThongKe : Form
    {
        public frmChiTietThongKe()
        {
            InitializeComponent();
        }

        private void btnThongKeSanPham_Click(object sender, EventArgs e)
        {
            ReportHoaDon hoadon = new ReportHoaDon();
            hoadon.Show();
            this.Hide();
        }

        private void btnThongKePhieuNhap_Click(object sender, EventArgs e)
        {
            ReportPhieuNhap phieunhap = new ReportPhieuNhap();
           phieunhap.Show();
            this.Hide();
        }
    }
}
