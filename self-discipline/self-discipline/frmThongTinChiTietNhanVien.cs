using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace self_discipline
{
    public partial class frmQuanLiNhanVien : Form
    {
        private ThongTinNhanVienBLL nvBLL = new ThongTinNhanVienBLL();

        public frmQuanLiNhanVien()
        {
            InitializeComponent();
            dtgvQLNV.AutoGenerateColumns = false;
        }

        private void frmQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            dtgvQLNV.DataSource = nvBLL.LayDsNhanVien();
        }

        private void dtgvQLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaNV.Text = dtgvQLNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHo.Text = dtgvQLNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTen.Text = dtgvQLNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbbPhai.SelectedItem = dtgvQLNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtChucVu.Text = dtgvQLNV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEmail.Text = dtgvQLNV.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtpNgaySinh.Value = (DateTime)dtgvQLNV.Rows[e.RowIndex].Cells[6].Value;
                txtSDT.Text = dtgvQLNV.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtDiaChi.Text = dtgvQLNV.Rows[e.RowIndex].Cells[8].Value.ToString();
                cbbTrangThai.SelectedIndex = (int)dtgvQLNV.Rows[e.RowIndex].Cells[9].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVienNew = new NhanVienDTO();

            try
            {
                nhanVienNew.Ho = txtHo.Text;
                nhanVienNew.Ten = txtTen.Text;
                nhanVienNew.Phai = (string)cbbPhai.SelectedItem;
                nhanVienNew.ChucVu = txtChucVu.Text;
                nhanVienNew.NgaySinh = dtpNgaySinh.Value;
                nhanVienNew.SDT = txtSDT.Text;
                nhanVienNew.Email = txtEmail.Text;
                nhanVienNew.DiaChi = txtDiaChi.Text;
                nhanVienNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nvBLL.ThemNhanVien(nhanVienNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhanVien_Load(sender, e);
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
                id = Convert.ToInt32(txtMaNV.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nvBLL.XoaNhanVien(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhanVien_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NhanVienDTO nhanVienCapNhat = new NhanVienDTO();

            try
            {
                nhanVienCapNhat.MaNV = Convert.ToInt32(txtMaNV.Text);
                nhanVienCapNhat.Ho = txtHo.Text;
                nhanVienCapNhat.Ten = txtTen.Text;
                nhanVienCapNhat.Phai = (string)cbbPhai.SelectedItem;
                nhanVienCapNhat.ChucVu = txtChucVu.Text;
                nhanVienCapNhat.NgaySinh = dtpNgaySinh.Value;
                nhanVienCapNhat.SDT = txtSDT.Text;
                nhanVienCapNhat.Email = txtEmail.Text;
                nhanVienCapNhat.DiaChi = txtDiaChi.Text;
                nhanVienCapNhat.TrangThai = cbbTrangThai.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nvBLL.CapNhatNhanVien(nhanVienCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhanVien_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            frmQuanLiNhanVien_Load(sender, e);
        }
    }
}
