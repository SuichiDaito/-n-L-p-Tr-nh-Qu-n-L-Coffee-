
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
using System.Windows.Forms;

namespace self_discipline
{
    public partial class frmQuanLy : Form
    {
        TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        ThongTinNhanVienBLL nvBLL = new ThongTinNhanVienBLL();

        public frmQuanLy()
        {
            InitializeComponent();

            string username = LayData.Username;
            TaiKhoanDTO tk = tkBLL.layDSTK().SingleOrDefault(u => u.Username == username && u.Quyen == 2);
            TaiKhoanDTO tkTT = tkBLL.layDSTK().SingleOrDefault(u => u.Username == username);
            NhanVienDTO nv = nvBLL.LayDsNhanVien().SingleOrDefault(u => u.MaNV == tkTT.MaNV);

            if (tk != null)
            {
                btnQuanLi.Enabled = false;
                btnQuanLi.FillColor = Color.Gray;
                btnThongKe.Enabled = false;
                btnBieuDo.Enabled = false;
            }

            string hoTen = nv.Ho + " " + nv.Ten;
            lblTenNVDangNhap.Text = hoTen;
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongTinNhanVien());

            // Lấy kích thước của màn hình làm khung làm việc
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // Đặt kích thước của Form sao cho vừa với màn hình
            this.Width = workingArea.Width;
            this.Height = workingArea.Height;

            // Đặt vị trí của Form để nó bắt đầu từ góc trên cùng bên trái
            this.Location = new Point(workingArea.Left, workingArea.Top);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
            this.Close();
        }

        //Biến childForm
        private Form currentFormChild;

        //Sự kiện mở childForm
        public void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panBody.Controls.Add(childForm);
            panBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongTinNhanVien());
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang banHang = new frmBanHang();
            banHang.ShowDialog();
            this.Hide();
        }

        private void btnQuanLi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietQuanLy());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietThongKe());
        }
    }
}
