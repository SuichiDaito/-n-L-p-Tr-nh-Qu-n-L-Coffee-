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
    public partial class frmLoaiTaiKhoan : Form
    {
        private QuanLyLoaiTaiKhoanBLL loaiTKBLL = new QuanLyLoaiTaiKhoanBLL();

        public frmLoaiTaiKhoan()
        {
            InitializeComponent();
            dtgvLoaiTK.AutoGenerateColumns = false;
        }

        private void frmLoaiTaiKhoan_Load(object sender, EventArgs e)
        {
            dtgvLoaiTK.DataSource = loaiTKBLL.layDSLoaiTK();
        }

        private void dtgvLoaiTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                txtMaLoaiTaiKhoan.Text = dtgvLoaiTK.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenLoaiTaiKhoan.Text = dtgvLoaiTK.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTenLoaiTaiKhoan.Text = txtTenLoaiTaiKhoan.Text.TrimEnd();

            QuanLyLoaiTaiKhoanDTO loaiTKNew = new QuanLyLoaiTaiKhoanDTO();

            try
            {
                loaiTKNew.TenLoai = txtTenLoaiTaiKhoan.Text;
                loaiTKNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loaiTKBLL.ThemLoaiTaikhoan(loaiTKNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiTaiKhoan_Load(sender, e);
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
                id = Convert.ToInt32(txtMaLoaiTaiKhoan.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loaiTKBLL.XoaLoaiTK(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiTaiKhoan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMaLoaiTaiKhoan.Text = string.Empty;
            txtTenLoaiTaiKhoan.Text = string.Empty;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTenLoaiTaiKhoan.Text = txtTenLoaiTaiKhoan.Text.TrimEnd();

            QuanLyLoaiTaiKhoanDTO loaiTKCapNhat = new QuanLyLoaiTaiKhoanDTO();

            try
            {
                loaiTKCapNhat.MaLoai = Convert.ToInt32(txtMaLoaiTaiKhoan.Text);
                loaiTKCapNhat.TenLoai = txtTenLoaiTaiKhoan.Text;
                loaiTKCapNhat.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyLoaiTaiKhoanDTO loaiTKTT = loaiTKBLL.layDSLoaiTK().SingleOrDefault(u => u.MaLoai == loaiTKCapNhat.MaLoai);

            if (loaiTKTT == null)
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(loaiTKBLL.CapNhapLoaiTK(loaiTKCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiTaiKhoan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaLoaiTaiKhoan.Text = string.Empty;
            txtTenLoaiTaiKhoan.Text = string.Empty;
        }

        private void txtTenLoaiTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
