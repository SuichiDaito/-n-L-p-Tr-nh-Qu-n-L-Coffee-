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
    public partial class frmChiTietQuanLy : Form
    {
        public frmChiTietQuanLy()
        {
            InitializeComponent();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            frmQuanLiNhanVien frmQuanLiNhanVien = new frmQuanLiNhanVien();
            frmQuanLiNhanVien.ShowDialog();
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            frmQuanLiNhaCungCap frmQuanLiNhaCungCap = new frmQuanLiNhaCungCap();
            frmQuanLiNhaCungCap.ShowDialog();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            frmQuanLiTaiKhoan frmQuanLiTaiKhoan = new frmQuanLiTaiKhoan();
            frmQuanLiTaiKhoan.ShowDialog();
        }

        private void btnQLLoaiTK_Click(object sender, EventArgs e)
        {
            frmLoaiTaiKhoan frmLoaiTK = new frmLoaiTaiKhoan();
            frmLoaiTK.ShowDialog();
        }

        private void btnQLQuyen_Click(object sender, EventArgs e)
        {
            frmQuanLiQuyenTaiKhoan frmQuanLiQuyenTaiKhoan = new frmQuanLiQuyenTaiKhoan();
            frmQuanLiQuyenTaiKhoan.ShowDialog();
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            frmSanPham frmSanPham = new frmSanPham();
            frmSanPham.ShowDialog();
        }

        private void btnQLLSP_Click(object sender, EventArgs e)
        {
            frmLoaiSanpham frmLoaiSanpham = new frmLoaiSanpham();
            frmLoaiSanpham.ShowDialog();
        }

        private void btnQLNL_Click(object sender, EventArgs e)
        {
            frmQuanLiNguyenLieu frmQuanLiNguyenLieu = new frmQuanLiNguyenLieu();
            frmQuanLiNguyenLieu.ShowDialog();
        }

        private void btnQLLNL_Click(object sender, EventArgs e)
        {
            frmLoaiNguyenLieu frmLoaiNguyenLieu = new frmLoaiNguyenLieu();
            frmLoaiNguyenLieu.ShowDialog();
        }

        private void btnQLKM_Click(object sender, EventArgs e)
        {
            frmKhuyenMai frmKhuyenMai = new frmKhuyenMai();
            frmKhuyenMai.ShowDialog();
        }

        private void btnQLBan_Click(object sender, EventArgs e)
        {
            frmBan frmBan = new frmBan();
            frmBan.ShowDialog();
        }

        private void btnQLLoaiBan_Click(object sender, EventArgs e)
        {
            frmLoaiBan frmLoaiBan = new frmLoaiBan();
            frmLoaiBan.ShowDialog();
        }
    }
}
