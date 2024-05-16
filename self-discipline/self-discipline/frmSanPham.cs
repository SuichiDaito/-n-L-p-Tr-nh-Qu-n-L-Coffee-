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
    public partial class frmSanPham : Form
    {
        private QuanLySanPhamBLL spBLL = new QuanLySanPhamBLL();
        private QuanLyLoaiSanPhamBLL loaiSP = new QuanLyLoaiSanPhamBLL();

        public frmSanPham()
        {
            InitializeComponent();
            dtgvQLSP.AutoGenerateColumns = false;

            colLoaiSP.DataSource = loaiSP.layDSLoaiSP();
            colLoaiSP.DisplayMember = "TenLoai";
            colLoaiSP.ValueMember = "MaLoai";

            cbbLoaiSP.DataSource = loaiSP.layDSLoaiSP();
            cbbLoaiSP.DisplayMember = "TenLoai";
            cbbLoaiSP.ValueMember = "MaLoai";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            dtgvQLSP.DataSource = spBLL.layDSSP();
        }

        private void dtgvQLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaSP.Text = dtgvQLSP.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dtgvQLSP.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbbLoaiSP.SelectedValue = dtgvQLSP.Rows[e.RowIndex].Cells[2].Value;
                nbrGiaBan.Value = (int)dtgvQLSP.Rows[e.RowIndex].Cells[3].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(cbbLoaiSP.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTenSP.Text = txtTenSP.Text.TrimEnd();

            QuanLySanPhamDTO spNew = new QuanLySanPhamDTO();
            string text = nbrGiaBan.Text;
            decimal value = nbrGiaBan.Value;

            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
                nbrGiaBan.Text = text;
            }

            if (value != Math.Floor(value)) // Kiểm tra số chữ số thập phân khác 0
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbrGiaBan.Value = 0;
            }

            try
            {
                spNew.TenSP = txtTenSP.Text;
                spNew.LoaiSP = (int)cbbLoaiSP.SelectedValue;
                spNew.GiaBan = (int)nbrGiaBan.Value;
                spNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spBLL.ThemSanPham(spNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSanPham_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(cbbLoaiSP.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTenSP.Text = txtTenSP.Text.TrimEnd();

            QuanLySanPhamDTO spCapNhat = new QuanLySanPhamDTO();
            string text = nbrGiaBan.Text;
            decimal value = nbrGiaBan.Value;

            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
                nbrGiaBan.Text = text;
            }

            if (value != Math.Floor(value)) // Kiểm tra số chữ số thập phân khác 0
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbrGiaBan.Value = 0;
            }

            try
            {
                spCapNhat.MaSP = Convert.ToInt32(txtMaSP.Text);
                spCapNhat.TenSP = txtTenSP.Text;
                spCapNhat.LoaiSP = (int)cbbLoaiSP.SelectedValue;
                spCapNhat.GiaBan = (int)nbrGiaBan.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLySanPhamDTO spTT = spBLL.layDSSP().SingleOrDefault(u => u.MaSP == spCapNhat.MaSP);

            if (spTT == null)
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (spBLL.CapNhatSanPham(spCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSanPham_Load(sender, e);
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
                id = Convert.ToInt32(txtMaSP.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spBLL.XoaSanPham(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmSanPham_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            cbbLoaiSP.SelectedItem = null;
            nbrGiaBan.Value = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            cbbLoaiSP.SelectedItem = null;
            nbrGiaBan.Value = 0;
        }

        private void txtTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nbrGiaBan_ValueChanged(object sender, EventArgs e)
        {
            string text = nbrGiaBan.Text;
            decimal value = nbrGiaBan.Value;

            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
                nbrGiaBan.Text = text;
            }

            if (value != Math.Floor(value)) // Kiểm tra số chữ số thập phân khác 0
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbrGiaBan.Value = 0;
            }
        }
    }
}
