using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BLL;
using DTO;

namespace self_discipline
{
    public partial class frmQuanLiNhanVien : Form
    {
        private ThongTinNhanVienBLL nvBLL = new ThongTinNhanVienBLL();
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private KiemTraEmail ktEmail = new KiemTraEmail();

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
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtHo.Text) || string.IsNullOrEmpty(txtTen.Text) 
                || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtChucVu.Text)  
                || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text)
                || string.IsNullOrEmpty(cbbPhai.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTen.Text = txtTen.Text.TrimEnd();
            txtSDT.Text = txtSDT.Text.TrimEnd();
            txtEmail.Text = txtEmail.Text.TrimEnd();
            txtDiaChi.Text = txtDiaChi.Text.TrimEnd();
            txtHo.Text = txtHo.Text.TrimEnd();
            txtChucVu.Text = txtChucVu.Text.TrimEnd();

            NhanVienDTO nhanVienNew = new NhanVienDTO();
            DateTime now = DateTime.Now;

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

                if(now.Year - nhanVienNew.NgaySinh.Year < 18 || now.Year - nhanVienNew.NgaySinh.Year > 40)
                {
                    MessageBox.Show("Tuổi phải lớn hơn 18 và bé hơn 40!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (ktEmail.IsValidEmail(nhanVienNew.Email))
                {
                    MessageBox.Show("Email không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
            string username = LayData.Username;
            TaiKhoanDTO tk = tkBLL.layDSTK().SingleOrDefault(u => u.Username == username);
            NhanVienDTO nv = nvBLL.LayDsNhanVien().SingleOrDefault(u => u.MaNV == tk.MaNV);

            try
            {
                id = Convert.ToInt32(txtMaNV.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVienDTO nvXoa = nvBLL.LayDsNhanVien().SingleOrDefault(u => u.MaNV == id);

            if (nvXoa.MaNV == nv.MaNV)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nvBLL.XoaNhanVien(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNhanVien_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMaNV.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtHo.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            cbbPhai.SelectedItem = null;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHo.Text) || string.IsNullOrEmpty(txtTen.Text)
              || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtChucVu.Text)
              || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text)
              || string.IsNullOrEmpty(cbbPhai.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTen.Text = txtTen.Text.TrimEnd();
            txtSDT.Text = txtSDT.Text.TrimEnd();
            txtEmail.Text = txtEmail.Text.TrimEnd();
            txtDiaChi.Text = txtDiaChi.Text.TrimEnd();
            txtHo.Text = txtHo.Text.TrimEnd();
            txtChucVu.Text = txtChucVu.Text.TrimEnd();

            NhanVienDTO nhanVienCapNhat = new NhanVienDTO();
            DateTime now = DateTime.Now;

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

                if (now.Year - nhanVienCapNhat.NgaySinh.Year < 18 || now.Year - nhanVienCapNhat.NgaySinh.Year > 40)
                {
                    MessageBox.Show("Tuổi phải lớn hơn 18 và bé hơn 40!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (ktEmail.IsValidEmail(nhanVienCapNhat.Email))
                {
                    MessageBox.Show("Email không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVienDTO nvTT = nvBLL.LayDsNhanVien().SingleOrDefault(u => u.MaNV == nhanVienCapNhat.MaNV);

            if (nvTT == null)
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(nvBLL.CapNhatNhanVien(nhanVienCapNhat))
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
            txtMaNV.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtHo.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            cbbPhai.SelectedItem = null;
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChucVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
