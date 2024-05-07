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
        private KiemTraTrangThai ktTT = new KiemTraTrangThai();

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

            QuanLySanPhamDTO spNew = new QuanLySanPhamDTO();

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

            QuanLySanPhamDTO spCapNhat = new QuanLySanPhamDTO();

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

            if (!ktTT.KiemTraSanPham(spCapNhat))
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
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            cbbLoaiSP.SelectedItem = null;
            nbrGiaBan.Value = 0;
        }
    }
}
