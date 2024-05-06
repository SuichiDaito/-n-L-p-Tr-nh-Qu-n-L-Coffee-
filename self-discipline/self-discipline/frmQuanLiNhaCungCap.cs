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
        QuanLyNhaCungCapBLL nCCBLL = new QuanLyNhaCungCapBLL();

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
            QuanLyNhaCungCapDTO nCCCapNhat = new QuanLyNhaCungCapDTO();

            try
            {
                nCCCapNhat.MaNCC = Convert.ToInt32(txtMaNCC.Text);
                nCCCapNhat.TenNCC = txtTenNCC.Text;
                nCCCapNhat.XuatXu = txtXuatXu.Text;
                nCCCapNhat.DiaChi = txtDiaChi.Text;
                nCCCapNhat.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nCCBLL.CapNhatNhaCungCap(nCCCapNhat))
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
            frmQuanLiNhaCungCap_Load(sender, e);
        }
    }
}
