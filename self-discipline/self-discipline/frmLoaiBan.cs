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
    public partial class frmLoaiBan : Form
    {
        private QuanLyLoaiBanBLL loaiBanBLL = new QuanLyLoaiBanBLL();

        public frmLoaiBan()
        {
            InitializeComponent();
            dtgvLoaiBan.AutoGenerateColumns = false;
        }

        private void frmLoaiBan_Load(object sender, EventArgs e)
        {
            dtgvLoaiBan.DataSource = loaiBanBLL.layDSLoaiBan();
        }

        private void dtgvLoaiBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaLoaiBan.Text = dtgvLoaiBan.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenLoaiBan.Text = dtgvLoaiBan.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbbTrangThai.SelectedIndex = (int)dtgvLoaiBan.Rows[e.RowIndex].Cells[2].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLyLoaiBanDTO loaiBanNew = new QuanLyLoaiBanDTO();

            try
            {
                loaiBanNew.TenLoai = txtTenLoaiBan.Text;
                loaiBanNew.TrangThai = cbbTrangThai.SelectedIndex;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loaiBanBLL.ThemLoaiBan(loaiBanNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiBan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            QuanLyLoaiBanDTO loaiBanCaphat = new QuanLyLoaiBanDTO();

            try
            {
                loaiBanCaphat.MaLoai = Convert.ToInt32(txtMaLoaiBan.Text);
                loaiBanCaphat.TenLoai = txtTenLoaiBan.Text;
                loaiBanCaphat.TrangThai = cbbTrangThai.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (loaiBanBLL.CapNhatLoaiBan(loaiBanCaphat))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiBan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id;

            try
            {
                id = Convert.ToInt32(txtMaLoaiBan.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (loaiBanBLL.XoaLoaiBan(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLoaiBan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmLoaiBan_Load(sender, e);
        }
    }
}
