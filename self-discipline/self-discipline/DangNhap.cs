
using DTO;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace self_discipline
{
    public partial class frmDangNhap : Form
    {
        private TaiKhoanBLL tkBLL = new TaiKhoanBLL();
        private md5 md5 = new md5();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        { 
            // Lấy kích thước màn hình chính
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Tính toán kích thước mong muốn (ví dụ: 50% của chiều rộng và 66% của chiều cao của màn hình)
            var desiredWidth = (int)(screenWidth * 0.3);
            var desiredHeight = (int)(screenHeight * 0.66);

            // Đặt kích thước cho Form
            this.Size = new Size(desiredWidth, desiredHeight);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Lấy tài khoản mật khẩu
            string Username = txtUsername_Login.Text;
            string Password = txtPassword_Login.Text;

            LayData.Username = Username;
            LayData.Password = Password;

            if (string.IsNullOrEmpty(txtUsername_Login.Text) || string.IsNullOrEmpty(txtPassword_Login.Text))
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mk = md5.CalculateMD5Hash(txtPassword_Login.Text);
            TaiKhoanDTO tk = tkBLL.layDSTK().SingleOrDefault(u => u.Username == txtUsername_Login.Text && u.Password == mk);

            if (tk != null)
            {
                frmQuanLy frmQuanLy = new frmQuanLy();
                frmQuanLy.Show();
                
                this.Hide();        
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
