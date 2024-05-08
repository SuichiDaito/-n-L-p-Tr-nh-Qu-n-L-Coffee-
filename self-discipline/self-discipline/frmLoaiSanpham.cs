using BLL;
using DTO;
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
    public partial class frmLoaiSanpham : Form
    {
        private QuanLyLoaiSanPhamBLL loaiSPBLL = new QuanLyLoaiSanPhamBLL();
        private KiemTraTrangThai ktTT = new KiemTraTrangThai();

        public frmLoaiSanpham()
        {
            InitializeComponent();
            dtgvQuanLyLoaiSanPham.AutoGenerateColumns = false;
        }

        private void frmLoaiSanpham_Load(object sender, EventArgs e)
        {
            dtgvQuanLyLoaiSanPham.DataSource = loaiSPBLL.layDSLoaiSP();
        }

        private void dtgvQuanLyLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaLoaiSanPham.Text = dtgvQuanLyLoaiSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenLoaiSanPham.Text = dtgvQuanLyLoaiSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiSanPham.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyLoaiSanPhamDTO loaiSPNew = new QuanLyLoaiSanPhamDTO();

            try
            {
                loaiSPNew.TenLoai = txtTenLoaiSanPham.Text;
                loaiSPNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loaiSPBLL.ThemLoaiSP(loaiSPNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiSanpham_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(txtMaLoaiSanPham.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loaiSPBLL.XoaLoaiSP(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiSanpham_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiSanPham.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyLoaiSanPhamDTO loaiSPCapNhat = new QuanLyLoaiSanPhamDTO();

            try
            {
                loaiSPCapNhat.MaLoai = Convert.ToInt32(txtMaLoaiSanPham.Text);
                loaiSPCapNhat.TenLoai = txtTenLoaiSanPham.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ktTT.KiemTraLSanPham(loaiSPCapNhat))
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (loaiSPBLL.CapNhatLoaiSP(loaiSPCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiSanpham_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaLoaiSanPham.Text = string.Empty;
            txtTenLoaiSanPham.Text = string.Empty;
        }

        private void txtTenLoaiSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
