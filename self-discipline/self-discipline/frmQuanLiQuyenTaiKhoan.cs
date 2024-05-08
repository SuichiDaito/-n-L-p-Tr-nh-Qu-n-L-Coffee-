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
    public partial class frmQuanLiQuyenTaiKhoan : Form
    {
        private QuanLyQuyenTaiKhoanBLL quyenBLL = new QuanLyQuyenTaiKhoanBLL();

        public frmQuanLiQuyenTaiKhoan()
        {
            InitializeComponent();
            dtgvQuyenTK.AutoGenerateColumns = false;
        }

        private void frmQuanLiQuyenTaiKhoan_Load(object sender, EventArgs e)
        {
            dtgvQuyenTK.DataSource = quyenBLL.layDSQuyenTK();
        }

        private void dtgvQuyenTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaQuyen.Text = dtgvQuyenTK.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenQuyen.Text = dtgvQuyenTK.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenQuyen.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            QuanLyQuyenTaiKhoanDTO quyenNew = new QuanLyQuyenTaiKhoanDTO();

            try
            {
                quyenNew.TenQuyen = txtTenQuyen.Text;
                quyenNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quyenBLL.ThemQuyenTK(quyenNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiQuyenTaiKhoan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenQuyen.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyQuyenTaiKhoanDTO quyenCapNhat = new QuanLyQuyenTaiKhoanDTO();

            try
            {
                quyenCapNhat.MaQuyen = Convert.ToInt32(txtMaQuyen.Text);
                quyenCapNhat.TenQuyen = txtTenQuyen.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyQuyenTaiKhoanDTO quyenTT = quyenBLL.layDSQuyenTK().SingleOrDefault(u => u.MaQuyen == quyenCapNhat.MaQuyen);

            if (quyenTT == null)
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (quyenBLL.CapNhatQuyenTK(quyenCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiQuyenTaiKhoan_Load(sender, e);
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
                id = Convert.ToInt32(txtMaQuyen.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (quyenBLL.XoaQuyenTK(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiQuyenTaiKhoan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaQuyen.Text = string.Empty;
            txtTenQuyen.Text = string.Empty;
        }

        private void txtTenQuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
