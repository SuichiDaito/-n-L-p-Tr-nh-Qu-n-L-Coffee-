using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace self_discipline
{
    public partial class BillList : Form
    {
        QuanLyHoaDonBLL HoaDon = new QuanLyHoaDonBLL();
        ThongTinNhanVienBLL NhanVien = new ThongTinNhanVienBLL();
        QuanLyBanBLL ban = new QuanLyBanBLL();
        QuanLyKhuyenMaiBLL KhuyenMai = new QuanLyKhuyenMaiBLL();


    
        public BillList()
        {
            
            InitializeComponent();
            dgvBillList.AutoGenerateColumns = false;
        }

        private void BillList_Load(object sender, EventArgs e)
        {
            colMaNV.DataSource = NhanVien.LayDsNhanVien();
            colMaNV.DisplayMember = "Ten";
            colMaNV.ValueMember = "MaNV";

            dgvBillList.DataSource = HoaDon.LayDs();
           

        }
    }
}
