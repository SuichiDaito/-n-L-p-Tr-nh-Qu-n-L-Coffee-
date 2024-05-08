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
    public partial class frmQuanLiTaiKhoan : Form
    {
        private TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        private QuanLyLoaiTaiKhoanBLL loaiTK = new QuanLyLoaiTaiKhoanBLL();
        private QuanLyQuyenTaiKhoanBLL quyenTK = new QuanLyQuyenTaiKhoanBLL();
        private md5 md5 = new md5();
        private KiemTraTrangThai ktTT = new KiemTraTrangThai();

        public frmQuanLiTaiKhoan()
        {
            InitializeComponent();
            dtgvQuanLyTaiKhoan.AutoGenerateColumns = false;

            cbbLoaiTK.DataSource = loaiTK.layDSLoaiTK();
            cbbLoaiTK.DisplayMember = "TenLoai";
            cbbLoaiTK.ValueMember = "MaLoai";

            cbbQuyen.DataSource = quyenTK.layDSQuyenTK();
            cbbQuyen.DisplayMember = "TenQuyen";
            cbbQuyen.ValueMember = "MaQuyen";

            colTenLoai_TaiKhoan.DataSource = loaiTK.layDSLoaiTK();
            colTenLoai_TaiKhoan.DisplayMember = "TenLoai";
            colTenLoai_TaiKhoan.ValueMember = "MaLoai";

            colQuyen_TaiKhoan.DataSource = quyenTK.layDSQuyenTK();
            colQuyen_TaiKhoan.DisplayMember = "TenQuyen";
            colQuyen_TaiKhoan.ValueMember = "MaQuyen";
        }

        private void frmQuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            dtgvQuanLyTaiKhoan.DataSource = taiKhoanBLL.layDSTK();
        }

        private void dtgvQuanLyTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaTK.Text = dtgvQuanLyTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaNV.Text = dtgvQuanLyTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUsername.Text = dtgvQuanLyTaiKhoan.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPassword.Text = dtgvQuanLyTaiKhoan.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbbLoaiTK.SelectedValue = dtgvQuanLyTaiKhoan.Rows[e.RowIndex].Cells[4].Value;
                cbbQuyen.SelectedValue = dtgvQuanLyTaiKhoan.Rows[e.RowIndex].Cells[5].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtUsername.Text) 
                || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cbbLoaiTK.Text) 
                || string.IsNullOrEmpty(cbbQuyen.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoanDTO tkNew = new TaiKhoanDTO();

            try
            {
                tkNew.MaNV = Convert.ToInt32(txtMaNV.Text);
                tkNew.Username = txtUsername.Text;
                tkNew.Password = md5.CalculateMD5Hash(txtPassword.Text);
                tkNew.LoaiTK = (int)cbbLoaiTK.SelectedValue;
                tkNew.Quyen = (int)cbbQuyen.SelectedValue;
                tkNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (taiKhoanBLL.ThemTaiKhoan(tkNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiTaiKhoan_Load(sender, e);
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
                id = Convert.ToInt32(txtMaTK.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (taiKhoanBLL.XoaTaiKhoan(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiTaiKhoan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtUsername.Text)
               || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(cbbLoaiTK.Text)
               || string.IsNullOrEmpty(cbbQuyen.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiKhoanDTO tkCapNhat = new TaiKhoanDTO();

            try
            {
                tkCapNhat.MaTK = Convert.ToInt32(txtMaTK.Text);
                tkCapNhat.MaNV = Convert.ToInt32(txtMaNV.Text);
                tkCapNhat.Username = txtUsername.Text;
                tkCapNhat.Password = md5.CalculateMD5Hash(txtPassword.Text);
                tkCapNhat.LoaiTK = (int)cbbLoaiTK.SelectedValue;
                tkCapNhat.Quyen = (int)cbbQuyen.SelectedValue;
                tkCapNhat.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ktTT.KiemTraTaiKhoan(tkCapNhat))
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (taiKhoanBLL.CapNhapTaiKhoan(tkCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiTaiKhoan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaTK.Text = string.Empty;
            txtMaNV.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Text = string.Empty;
            cbbLoaiTK.SelectedItem = null;
            cbbQuyen.SelectedItem = null;
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
