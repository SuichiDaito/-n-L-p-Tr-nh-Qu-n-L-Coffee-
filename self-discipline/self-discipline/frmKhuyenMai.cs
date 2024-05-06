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
    public partial class frmKhuyenMai : Form
    {
        private QuanLyKhuyenMaiBLL kmBLL = new QuanLyKhuyenMaiBLL();

        public frmKhuyenMai()
        {
            InitializeComponent();
            dtgvQLKM.AutoGenerateColumns = false;
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            dtgvQLKM.DataSource = kmBLL.layDSKM();
        }

        private void dtgvQLKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtMaGG.Text = dtgvQLKM.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKM.Text = dtgvQLKM.Rows[e.RowIndex].Cells[1].Value.ToString();
                nbrPhanTram.Value = (decimal)(float)dtgvQLKM.Rows[e.RowIndex].Cells[2].Value;
                nbrSL.Value = (int)dtgvQLKM.Rows[e.RowIndex].Cells[3].Value;
                dtpNgayBatDau.Value = (DateTime)dtgvQLKM.Rows[e.RowIndex].Cells[4].Value;
                dtpNgayKetThuc.Value = (DateTime)dtgvQLKM.Rows[e.RowIndex].Cells[5].Value;
                txtMoTa.Text = dtgvQLKM.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLyKhuyenMaiDTO kmNew = new QuanLyKhuyenMaiDTO();

            try
            {
                kmNew.TenMaGiamGia = txtTenKM.Text;
                kmNew.PhanTram = (float)nbrPhanTram.Value;
                kmNew.SL = (int)nbrSL.Value;
                kmNew.NgayBatDau = (DateTime)dtpNgayBatDau.Value;
                kmNew.NgayKetThuc = (DateTime)dtpNgayKetThuc.Value;
                kmNew.MoTa = txtMoTa.Text;
                kmNew.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kmBLL.ThemKhuyenMai(kmNew))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmKhuyenMai_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            QuanLyKhuyenMaiDTO kmCapNhat = new QuanLyKhuyenMaiDTO();

            try
            {
                kmCapNhat.MaGiamGia = Convert.ToInt32(txtMaGG.Text);
                kmCapNhat.TenMaGiamGia = txtTenKM.Text;
                kmCapNhat.PhanTram = (float)nbrPhanTram.Value;
                kmCapNhat.SL = (int)nbrSL.Value;
                kmCapNhat.NgayBatDau = (DateTime)dtpNgayBatDau.Value;
                kmCapNhat.NgayKetThuc = (DateTime)dtpNgayKetThuc.Value;
                kmCapNhat.MoTa = txtMoTa.Text;
                kmCapNhat.TrangThai = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kmBLL.CapNhatKhuyenMai(kmCapNhat))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmKhuyenMai_Load(sender, e);
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
                id = Convert.ToInt32(txtMaGG.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kmBLL.XoaKhuyenMai(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmKhuyenMai_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmKhuyenMai_Load(sender, e);
        }
    }
}
