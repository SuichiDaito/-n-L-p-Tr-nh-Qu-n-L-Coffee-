using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KiemTraTrangThai
    {
        private QuanLyKhuyenMaiDAL kmDAL = new QuanLyKhuyenMaiDAL();

        public bool KiemTraKM(QuanLyKhuyenMaiDTO kMKT)
        {
            if(kMKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraLBan(QuanLyLoaiBanDTO loaiBanKT)
        {
            if (loaiBanKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraLNguyenLieu(QuanLyLoaiNguyenLieuDTO loaiNLKT)
        {
            if (loaiNLKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraLSanPham(QuanLyLoaiSanPhamDTO loaiSP)
        {
            if (loaiSP.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraLTaiKhoan(QuanLyLoaiTaiKhoanDTO loaiTK)
        {
            if (loaiTK.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraNguyenLieu(QuanLyNguyenLieuDTO nlKT)
        {
            if (nlKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraNhaCungCap(QuanLyNhaCungCapDTO nccKT)
        {
            if (nccKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraQuyenTK(QuanLyQuyenTaiKhoanDTO quyenKT)
        {
            if (quyenKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraTaiKhoan(TaiKhoanDTO tkKT)
        {
            if (tkKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraSanPham(QuanLySanPhamDTO spKT)
        {
            if (spKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }

        public bool KiemTraNhanVien(NhanVienDTO nvKT)
        {
            if (nvKT.TrangThai != 0)
            {
                return true;
            }

            return false;
        }
    }
}
