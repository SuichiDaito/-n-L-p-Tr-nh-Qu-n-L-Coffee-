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
    public partial class frmLoaiNguyenLieu : Form
    {
        private QuanLyLoaiNguyenLieuBLL loaiNLBLL = new QuanLyLoaiNguyenLieuBLL();
        private KiemTraTrangThai ktTT = new KiemTraTrangThai();

        public frmLoaiNguyenLieu()
        {
            InitializeComponent();
            dtgvLoaiNguyenLieu.AutoGenerateColumns = false;
        }

        private void frmLoaiNguyenLieu_Load(object sender, EventArgs e)
        {
            dtgvLoaiNguyenLieu.DataSource = loaiNLBLL.layDSLoaiNL();
        }

        private void dtgvLoaiNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( e.RowIndex >= 0)
            {
                txtMaLoaiNguyenLieu.Text = dtgvLoaiNguyenLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenLoaiNguyenLieu.Text = dtgvLoaiNguyenLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyLoaiNguyenLieuDTO loaiNLNew = new QuanLyLoaiNguyenLieuDTO();

            try
            {
                loaiNLNew.TenLoai = txtTenLoaiNguyenLieu.Text;
                loaiNLNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loaiNLBLL.ThemLoaiNL(loaiNLNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiNguyenLieu_Load(sender, e);
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
                id = Convert.ToInt32(txtMaLoaiNguyenLieu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loaiNLBLL.XoaLoaiNL(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiNguyenLieu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiNguyenLieu.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyLoaiNguyenLieuDTO loaiNLCapNhat = new QuanLyLoaiNguyenLieuDTO();

            try
            {
                loaiNLCapNhat.MaLoai = Convert.ToInt32(txtMaLoaiNguyenLieu.Text);
                loaiNLCapNhat.TenLoai = txtTenLoaiNguyenLieu.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ktTT.KiemTraLNguyenLieu(loaiNLCapNhat))
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (loaiNLBLL.CapNhatLoaiNL(loaiNLCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiNguyenLieu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaLoaiNguyenLieu.Text = string.Empty;
            txtTenLoaiNguyenLieu.Text = string.Empty;
        }
    }
}
