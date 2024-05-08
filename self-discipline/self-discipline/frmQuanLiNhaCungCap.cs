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
    public partial class frmQuanLiNhaCungCap : Form
    {
        private QuanLyNhaCungCapBLL nCCBLL = new QuanLyNhaCungCapBLL();
        private KiemTraTrangThai ktTT = new KiemTraTrangThai();

        public frmQuanLiNhaCungCap()
        {
            InitializeComponent();
            dtgvQLNCC.AutoGenerateColumns = false;
        }

        private void frmQuanLiNhaCungCap_Load(object sender, EventArgs e)
        {
            dtgvQLNCC.DataSource = nCCBLL.layDSNCC();
        }

        private void dtgvQLNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaNCC.Text = dtgvQLNCC.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNCC.Text = dtgvQLNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtXuatXu.Text = dtgvQLNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = dtgvQLNCC.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtXuatXu.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyNhaCungCapDTO nCCNew = new QuanLyNhaCungCapDTO();

            try
            {
                nCCNew.TenNCC = txtTenNCC.Text;
                nCCNew.XuatXu = txtXuatXu.Text;
                nCCNew.DiaChi = txtDiaChi.Text;
                nCCNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nCCBLL.ThemNhaCungCap(nCCNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhaCungCap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtXuatXu.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyNhaCungCapDTO nCCCapNhat = new QuanLyNhaCungCapDTO();

            try
            {
                nCCCapNhat.MaNCC = Convert.ToInt32(txtMaNCC.Text);
                nCCCapNhat.TenNCC = txtTenNCC.Text;
                nCCCapNhat.XuatXu = txtXuatXu.Text;
                nCCCapNhat.DiaChi = txtDiaChi.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ktTT.KiemTraNhaCungCap(nCCCapNhat))
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nCCBLL.CapNhatNhaCungCap(nCCCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhaCungCap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(txtMaNCC.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nCCBLL.XoaNhaCungCap(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhaCungCap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtTenNCC.Text = string.Empty;
            txtMaNCC.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtXuatXu.Text = string.Empty;
        }

        private void txtTenNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
