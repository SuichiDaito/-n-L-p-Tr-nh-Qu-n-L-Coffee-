using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace self_discipline
{
    public partial class frmQuanLyPhieuNhap : Form
    {
        private QuanLyPhieuNhapBLL pnBLL = new QuanLyPhieuNhapBLL();
        private QuanLyNguyenLieuBLL nlBLL = new QuanLyNguyenLieuBLL();
        private KiemTraTrangThai ktTT = new KiemTraTrangThai();

        public frmQuanLyPhieuNhap()
        {
            InitializeComponent();
            dtgvPhieuNhap.AutoGenerateColumns = false;

            colMaNL.DataSource = nlBLL.layDSNL();
            colMaNL.DisplayMember = "TenNL";
            colMaNL.ValueMember = "MaNL";

            cbbTenNL.DataSource = nlBLL.layDSNL();
            cbbTenNL.DisplayMember = "TenNL";
            cbbTenNL.ValueMember = "MaNL";
        }

        private void frmQuanLyPhieuNhap_Load(object sender, EventArgs e)
        {
            dtgvPhieuNhap.DataSource = pnBLL.layDSPN();
        }

        private void dtgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaPN.Text = dtgvPhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbTenNL.SelectedValue = dtgvPhieuNhap.Rows[e.RowIndex].Cells[1].Value;
                txtMaDon.Text = dtgvPhieuNhap.Rows[e.RowIndex].Cells[2].Value.ToString();
                nbrSL.Value = (int)dtgvPhieuNhap.Rows[e.RowIndex].Cells[3].Value;
                txtDVT.Text = dtgvPhieuNhap.Rows[e.RowIndex].Cells[4].Value.ToString();
                nbrGiaNhap.Value = (decimal)(float)dtgvPhieuNhap.Rows[e.RowIndex].Cells[5].Value;
                nbrGiamGia.Value = (decimal)(float)dtgvPhieuNhap.Rows[e.RowIndex].Cells[6].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaDon.Text) || string.IsNullOrEmpty(txtDVT.Text) || string.IsNullOrEmpty(cbbTenNL.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyPhieuNhapDTO pnNew = new QuanLyPhieuNhapDTO();

            try
            {
                pnNew.MaNL = (int)cbbTenNL.SelectedValue;
                pnNew.MaDon = Convert.ToInt32(txtMaDon.Text);
                pnNew.SL = (int)nbrSL.Value;
                pnNew.DVT = txtDVT.Text;
                pnNew.GiaNhap = (float)nbrGiaNhap.Value;
                pnNew.GiamGia = (float)nbrGiamGia.Value;
                pnNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pnBLL.ThemPhieuNhap(pnNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLyPhieuNhap_Load(sender, e);
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
                id = Convert.ToInt32(txtMaPN.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pnBLL.XoaPhieuNhap(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLyPhieuNhap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDon.Text) || string.IsNullOrEmpty(txtDVT.Text) || string.IsNullOrEmpty(cbbTenNL.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyPhieuNhapDTO pnCapNhat = new QuanLyPhieuNhapDTO();

            try
            {
                pnCapNhat.MaNL = (int)cbbTenNL.SelectedValue;
                pnCapNhat.MaDon = Convert.ToInt32(txtMaDon.Text);
                pnCapNhat.SL = (int)nbrSL.Value;
                pnCapNhat.DVT = txtDVT.Text;
                pnCapNhat.GiaNhap = (float)nbrGiaNhap.Value;
                pnCapNhat.GiamGia = (float)nbrGiamGia.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ktTT.KiemTraPhieuNhap(pnCapNhat))
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (pnBLL.CapNhatPhieuNhap(pnCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmQuanLyPhieuNhap_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaPN.Text = string.Empty;
            txtMaDon.Text = string.Empty;
            txtDVT.Text = string.Empty;
            cbbTenNL.SelectedItem = null;
            nbrGiamGia.Value = 0;
            nbrGiaNhap.Value = 0;
        }

        private void txtDVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
