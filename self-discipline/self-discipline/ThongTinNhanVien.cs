
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace self_discipline
{
    public partial class frmThongTinNhanVien : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        ThongTinNhanVienBLL nvBLL= new ThongTinNhanVienBLL();

        public frmThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongTinNhanVien_Load_1(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = Application.OpenForms.OfType<frmDangNhap>().FirstOrDefault();
            string username = frmDangNhap.Username;
            TaiKhoanDTO tk = tkBLL.layDSTK().SingleOrDefault(u => u.Username == username && u.Quyen == 2);

            if(tk != null)
            {
                btnThongTinChiTiet.Enabled = false;
                btnThongTinChiTiet.FillColor = Color.Gray;
            }

            TaiKhoanDTO ttTK = tkBLL.layDSTK().SingleOrDefault(u => u.Username == username);
            NhanVienDTO nv = nvBLL.LayDsNhanVien().Single(u => u.MaNV == ttTK.MaNV);

            string hoTen = nv.Ho + " " + nv.Ten;

            lblHoTen.Text = hoTen;
            lblGioiTinh.Text = nv.Phai;
            lblNgaySinh.Text = nv.NgaySinh.ToString("dd/MM/yyyy");
            lblSDT.Text = nv.SDT;
            lblChucVu.Text = nv.ChucVu;
            if(nv.TrangThai == 1)
            {
                lblTrangThai.Text = "Hoạt động";
            }
            else
            {
                lblTrangThai.Text = "Ngưng Hoạt động";
            }
        }

        private void btnThongTinChiTiet_Click(object sender, EventArgs e)
        {
            frmQuanLiNhanVien frmQuanLiNhanVien = new frmQuanLiNhanVien();
            frmQuanLiNhanVien.ShowDialog();
        }
    }
}
