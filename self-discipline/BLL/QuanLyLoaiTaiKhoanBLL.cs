using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyLoaiTaiKhoanBLL
    {
        QuanLyLoaiTaiKhoanDAL loaiTK = new QuanLyLoaiTaiKhoanDAL();

        public List<QuanLyLoaiTaiKhoanDTO> layDSLoaiTK()
        {
            return loaiTK.layDSLoaiTK();
        }

        public bool ThemLoaiTaikhoan(QuanLyLoaiTaiKhoanDTO loaiTKNew)
        {
            return loaiTK.ThemLoaiTaiKhoan(loaiTKNew);
        }

        public bool CapNhapLoaiTK(QuanLyLoaiTaiKhoanDTO loaiTKCapNhat)
        {
            return loaiTK.CapNhatLoaiTK(loaiTKCapNhat);
        }

        public bool XoaLoaiTK(int id)
        {
            return loaiTK.XoaLoaiTK(id);
        }
    }
}
