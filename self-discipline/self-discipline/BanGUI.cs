using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace self_discipline
{
    public partial class frmBan : Form
    {
        QuanLyBanBLL banBLL = new QuanLyBanBLL();
        QuanLyLoaiBanBLL loaiBanBLL= new QuanLyLoaiBanBLL();

        public frmBan()
        {
            InitializeComponent();
            dtgvQuanLyBan.AutoGenerateColumns = false;

            ColLoaiBan.DataSource = loaiBanBLL.layDSLoaiBan();
            ColLoaiBan.DisplayMember = "TenLoai";
            ColLoaiBan.ValueMember = "MaLoai";

            cbbLoaiBan.DataSource = loaiBanBLL.layDSLoaiBan();
            cbbLoaiBan.DisplayMember = "TenLoai";
            cbbLoaiBan.ValueMember = "MaLoai";
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            dtgvQuanLyBan.DataSource = banBLL.layDSBan();
        }

        private void dtgvQuanLyBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaBan.Text = dtgvQuanLyBan.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbLoaiBan.SelectedValue = dtgvQuanLyBan.Rows[e.RowIndex].Cells[1].Value;
                cbbTrangThai.SelectedIndex = (int)dtgvQuanLyBan.Rows[e.RowIndex].Cells[2].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbTrangThai.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyBanDTO banNew = new QuanLyBanDTO();

            try
            {
                banNew.LoaiBan = (int)cbbLoaiBan.SelectedValue;
                banNew.TrangThai = cbbTrangThai.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (banBLL.ThemBan(banNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmBan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            QuanLyBanDTO banCapNhat = new QuanLyBanDTO();

            try
            {
                banCapNhat.MaBan = Convert.ToInt32(txtMaBan.Text);
                banCapNhat.LoaiBan = (int)cbbLoaiBan.SelectedValue;
                banCapNhat.TrangThai = cbbTrangThai.SelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            QuanLyBanDTO banTT = banBLL.layDSBan().SingleOrDefault(u => u.MaBan == banCapNhat.MaBan);
            if(banTT == null)
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(banBLL.CapNhatBan(banCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmBan_Load(sender, e);
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
                id = Convert.ToInt32(txtMaBan.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (banBLL.XoaBan(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmBan_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMaBan.Text = string.Empty;
            cbbLoaiBan.SelectedIndex = 0;
            cbbTrangThai.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtMaBan.Text = string.Empty;
            cbbLoaiBan.SelectedIndex = 0;
            cbbTrangThai.SelectedIndex = 0;
        }
    }
}
