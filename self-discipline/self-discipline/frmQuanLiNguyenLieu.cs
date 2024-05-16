using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace self_discipline
{
    public partial class frmQuanLiNguyenLieu : Form
    {
        private QuanLyNguyenLieuBLL nLBLL = new QuanLyNguyenLieuBLL();
        private QuanLyNhaCungCapBLL nCCBLL = new QuanLyNhaCungCapBLL();
        private QuanLyLoaiNguyenLieuBLL loaiNLBLL = new QuanLyLoaiNguyenLieuBLL();

        public frmQuanLiNguyenLieu()
        {
            InitializeComponent();
            dtgvQLNL.AutoGenerateColumns = false;

            colMaNCC.DataSource = nCCBLL.layDSNCC();
            colMaNCC.DisplayMember = "TenNCC";
            colMaNCC.ValueMember = "MaNCC";

            cbbTenNCC.DataSource = nCCBLL.layDSNCC();
            cbbTenNCC.DisplayMember = "TenNCC";
            cbbTenNCC.ValueMember = "MaNCC";

            colTenLoaiNL.DataSource = loaiNLBLL.layDSLoaiNL();
            colTenLoaiNL.DisplayMember = "TenLoai";
            colTenLoaiNL.ValueMember = "MaLoai";

            cbbTenLoaiNL.DataSource = loaiNLBLL.layDSLoaiNL();
            cbbTenLoaiNL.DisplayMember = "TenLoai";
            cbbTenLoaiNL.ValueMember = "MaLoai";
        }

        private void frmQuanLiNguyenLieu_Load(object sender, EventArgs e)
        {
            dtgvQLNL.DataSource = nLBLL.layDSNL();
        }

        private void dtgvQLNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaNL.Text = dtgvQLNL.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNL.Text = dtgvQLNL.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbbTenLoaiNL.SelectedValue = dtgvQLNL.Rows[e.RowIndex].Cells[2].Value;
                cbbTenNCC.SelectedValue = dtgvQLNL.Rows[e.RowIndex].Cells[3].Value;
                nbrSLTon.Value = (int)dtgvQLNL.Rows[e.RowIndex].Cells[4].Value;
                txtDVT.Text = dtgvQLNL.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenNL.Text) || string.IsNullOrEmpty(txtDVT.Text) 
                || string.IsNullOrEmpty(cbbTenLoaiNL.Text) || string.IsNullOrEmpty(cbbTenNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTenNL.Text = txtTenNL.Text.TrimEnd();
            txtDVT.Text = txtDVT.Text.TrimEnd();

            QuanLyNguyenLieuDTO nlNew = new QuanLyNguyenLieuDTO();
            string text = nbrSLTon.Text;
            decimal value = nbrSLTon.Value;

            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
                nbrSLTon.Text = text;
            }

            if (value != Math.Floor(value)) // Kiểm tra số chữ số thập phân khác 0
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbrSLTon.Value = 0;
                return;
            }

            try
            {
                nlNew.TenNL = txtTenNL.Text;
                nlNew.LoaiNguyenLieu = (int)cbbTenLoaiNL.SelectedValue;
                nlNew.MaNCC = (int)cbbTenNCC.SelectedValue;
                nlNew.SLTon = (int)nbrSLTon.Value;
                nlNew.DVT = txtDVT.Text;
                nlNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nLBLL.ThemNguyenLieu(nlNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNguyenLieu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNL.Text) || string.IsNullOrEmpty(txtDVT.Text)
               || string.IsNullOrEmpty(cbbTenLoaiNL.Text) || string.IsNullOrEmpty(cbbTenNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            txtTenNL.Text = txtTenNL.Text.TrimEnd();
            txtDVT.Text = txtDVT.Text.TrimEnd();

            QuanLyNguyenLieuDTO nlCapNhat = new QuanLyNguyenLieuDTO();
            string text = nbrSLTon.Text;
            decimal value = nbrSLTon.Value;

            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
                nbrSLTon.Text = text;
            }

            if (value != Math.Floor(value)) // Kiểm tra số chữ số thập phân khác 0
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbrSLTon.Value = 0;
                return;
            }

            try
            {
                nlCapNhat.MaNL = Convert.ToInt32(txtMaNL.Text);
                nlCapNhat.TenNL = txtTenNL.Text;
                nlCapNhat.LoaiNguyenLieu = (int)cbbTenLoaiNL.SelectedValue;
                nlCapNhat.MaNCC = (int)cbbTenNCC.SelectedValue;
                nlCapNhat.SLTon = (int)nbrSLTon.Value;
                nlCapNhat.DVT = txtDVT.Text;
                nlCapNhat.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyNguyenLieuDTO nlTT = nLBLL.layDSNL().SingleOrDefault(u => u.MaNL == nlCapNhat.MaNL);

            if (nlTT == null)
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (nLBLL.CapNhatNguyenLieu(nlCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNguyenLieu_Load(sender, e);
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
               id = Convert.ToInt32(txtMaNL.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nLBLL.XoaNguyenLieu(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLiNguyenLieu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMaNL.Text = string.Empty;
            txtTenNL.Text = string.Empty;
            txtDVT.Text = string.Empty;
            cbbTenLoaiNL.SelectedItem = null;
            cbbTenNCC.SelectedItem = null;
            nbrSLTon.Value = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaNL.Text = string.Empty;
            txtTenNL.Text = string.Empty;
            txtDVT.Text = string.Empty;
            cbbTenLoaiNL.SelectedItem = null;
            cbbTenNCC.SelectedItem = null;
            nbrSLTon.Value = 0;
        }

        private void txtTenNL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void nbrSLTon_ValueChanged(object sender, EventArgs e)
        {
            string text = nbrSLTon.Text;
            decimal value = nbrSLTon.Value;

            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
                nbrSLTon.Text = text;
            }

            if (value != Math.Floor(value)) // Kiểm tra số chữ số thập phân khác 0
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nbrSLTon.Value = 0;
            }
        }
    }
}
