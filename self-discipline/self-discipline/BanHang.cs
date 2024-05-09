
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace self_discipline
{
    public partial class frmBanHang : Form
    {
        QuanLySanPhamDTO quanLySanPhamDTO = new QuanLySanPhamDTO();
        QuanLySanPhamBLL quanLySanPhamBLL = new QuanLySanPhamBLL();
        QuanLyLoaiSanPhamBLL quanLyLoaiSanPhamBLL = new QuanLyLoaiSanPhamBLL();
        QuanLyLoaiSanPhamDTO quanLyloaiSanPhamDTO = new QuanLyLoaiSanPhamDTO();
        QuanLyKhuyenMaiBLL quanLyKhuyenMaiBLL = new QuanLyKhuyenMaiBLL();
        /// <summary>
        /// QuanLyHoaDonBLL HoaDonBLL = new QuanLyHoaDonBLL();
        /// </summary>
        QuanLyHoaDonBLL HoaDonBLL = new QuanLyHoaDonBLL();
        /// <summary>
        ///  TaiKhoanDTO tk = new TaiKhoanDTO();
        /// </summary>
        TaiKhoanDTO tk = new TaiKhoanDTO();
        /// <summary>
        ///  TaiKhoanBLL TaiKhoanBll = new TaiKhoanBLL();
        /// </summary>
        TaiKhoanBLL TaiKhoanBll = new TaiKhoanBLL();
        /// <summary>
        ///       QuanLyCTHDBLL CTHoaDon = new QuanLyCTHDBLL();
        /// </summary>
        QuanLyChiTietHoaDonBLL ChiTiet = new QuanLyChiTietHoaDonBLL();

        string username;
        public int MainID = 0;
        public string OrderType;

        public frmBanHang()
        {
            InitializeComponent();
        }
        private void frmBanHang_Load_1(object sender, EventArgs e)
        {
           
            string username = LayData.Username;
            lblTenTaiKhoan.Text = username;
            LoadProducts();
            cbbKhuyenMai.DataSource = quanLyKhuyenMaiBLL.layDSKM();
            cbbKhuyenMai.DisplayMember = "TenMaGiamGia";
            cbbKhuyenMai.ValueMember = "MaGiamGia";

        }
        private void AddItem(string id, string name, string cat, string price, Image Pimage)
        {
            double tot = 0;
            ucSanPham w = new ucSanPham()
            {
                TenMon = name,
                Price = price,
                PCategory = cat,
                id = Convert.ToInt32(id),
                AnhMon = Pimage
            };

            Products_panel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucSanPham)ss;

                foreach (DataGridViewRow item in dgvHoaDonBanHang.Rows)
                {
                    if (Convert.ToInt32(item.Cells["colId"].Value) == wdg.id)
                    {
                        item.Cells["colSoLuong"].Value = int.Parse(item.Cells["colSoLuong"].Value.ToString()) + 1;
                        item.Cells["colThanhTien"].Value = int.Parse(item.Cells["colSoLuong"].Value.ToString()) * Double.Parse(item.Cells["colGia"].Value.ToString());
                        GetTotal();
                        return;

                    }       
                }
                dgvHoaDonBanHang.Rows.Add(new object[] { 0, wdg.id, wdg.TenMon, 1, wdg.Price, wdg.Price });
                GetTotal();
            };
        }
        private void LoadProducts()
        {
            DataTable table = new DataTable();
            table = quanLySanPhamBLL.LayDS();

            foreach (DataRow item in table.Rows)
            {
                string path = Application.StartupPath + "//..//..//Resources//" + item["Avatar"].ToString();
                Image anh = Image.FromFile(path);

                AddItem(item["MaSP"].ToString(), item["TenSP"].ToString(), item["LoaiSP"].ToString(), item["GiaBan"].ToString(),anh);
            
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTimKiemMon_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(txtTimKiemMon.Text.Trim().ToLower());
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void GetTotal()
        {
            double tot = 0;

            foreach (DataGridViewRow item in dgvHoaDonBanHang.Rows)
            {
                if (item.Cells["colThanhTien"].Value != null)
                {


                    tot += Double.Parse(item.Cells["colThanhTien"].Value.ToString());
                }
            }

            lblTotal.Text  = tot.ToString();

        }
        private void btnfrmQuanLy_Click(object sender, EventArgs e)
        {
            frmQuanLy frm = new frmQuanLy();
            frm.Show();
            this.Hide();
        }

        private void btnTraSua_Click(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(btnTraSua.Text.Trim().ToLower());
            }
        }

        private void btnTraOlong_Click(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(btnTraOlong.Text.Trim().ToLower());
            }
        }

        private void btnCoffee_Click(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(btnCoffee.Text.Trim().ToLower());
            }
        }

        private void btnCoffeeDuongDen_Click(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(btnCoffeeDuongDen.Text.Trim().ToLower());
            }
        }

        private void btnYogurt_Click(object sender, EventArgs e)
        {
            foreach (var item in Products_panel.Controls)
            {
                var sp = (ucSanPham)item;
                sp.Visible = sp.TenMon.ToLower().Contains(btnYogurt.Text.Trim().ToLower());
            }
        }

        private void picCategoryMon_Click(object sender, EventArgs e)
        {
            Products_panel.Controls.Clear();
            frmBanHang_Load_1(sender, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string date;
            date = DateTime.Now.ToString();
            txtThoiGian.Text = date;
        }

        private void btnBillMoi_Click(object sender, EventArgs e)
        {
            dgvHoaDonBanHang.Rows.Clear();
            txtTienGiam.Text = "";
            txtTienKhachDua.Text = "";
            txtTienThua.Text = "";
            txtBan.Visible = true;
            cbbKhuyenMai.SelectedIndex = -1;
            lblTotal.Text = "0.00";
            MainID = 0;
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            txtTienGiam.Text = "";
            txtTienKhachDua.Text = "";
            txtTienThua.Text = "";
            txtBan.Visible = true;
            cbbKhuyenMai.SelectedIndex = -1;
            lblTotal.Text = "0.00";
            MainID = 0;
            OrderType = "TakeAway";
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            frmDatBan frm = new frmDatBan();
            frm.SendIdTable += Frm_SendIdTable;
            frm.ShowDialog();
        }
        private void Frm_SendIdTable(string value)
        {
            txtBan.Text = value;
        }

        private void dgvHoaDonBanHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            int count = 0;
            foreach (DataGridViewRow row in dgvHoaDonBanHang.Rows)
            {
                if (row.Cells.Count > 0)
                {
                    count++;
                    row.Cells["colSTT"].Value = count;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtBan.Text))
            {
                MessageBox.Show("Mã bàn chưa được chọn", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string username = lblTenTaiKhoan.Text;
                int id = TaiKhoanBll.TimMaNhanVien(username);

                if (id != null)
                {
                    QuanLyHoaDonDTO hoadon = new QuanLyHoaDonDTO();
                    hoadon.MaNV = id;
                    hoadon.MaBan = Convert.ToInt32(txtBan.Text);
                    hoadon.MaKhuyenMai = Convert.ToInt32(cbbKhuyenMai.SelectedValue.ToString());
                    int tongtien = Convert.ToInt32(lblTotal.Text);

                    if (HoaDonBLL.ThemHoaDon(hoadon) == true )
                    {
                        int MaHD = HoaDonBLL.LayMaHoaDon();
                        QuanLyCTHoaDonDTO ct = new QuanLyCTHoaDonDTO();
                        foreach (DataGridViewRow row in dgvHoaDonBanHang.Rows)
                        {
                            ct.MaHD = MaHD;
                            ct.MaSP = Convert.ToInt32(row.Cells["colId"].Value.ToString());
                            ct.SL = Convert.ToInt32(row.Cells["colSoLuong"].Value.ToString());
                            ChiTiet.ThemChiTiet(ct);
                             
                        }
                        DialogResult dl = MessageBox.Show("Thêm Hoá Đơn Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult dl = MessageBox.Show("Thêm Hoá Đơn Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }
        }
    }
}
