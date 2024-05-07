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
            QuanLyLoaiTaiKhoanDTO loaiTKKT = loaiTK.layDSLoaiTK().SingleOrDefault(u => u.TenLoai == loaiTKNew.TenLoai);

            if (loaiTKKT != null) return false;

            return loaiTK.ThemLoaiTaiKhoan(loaiTKNew);
        }

        public bool CapNhapLoaiTK(QuanLyLoaiTaiKhoanDTO loaiTKCapNhat)
        {
            QuanLyLoaiTaiKhoanDTO loaiTKKT = loaiTK.layDSLoaiTK().SingleOrDefault(u => u.TenLoai == loaiTKCapNhat.TenLoai);

            if (loaiTKKT != null) return false;

            return loaiTK.CapNhatLoaiTK(loaiTKCapNhat);
        }

        public bool XoaLoaiTK(int id)
        {
            return loaiTK.XoaLoaiTK(id);
        }
    }
}
