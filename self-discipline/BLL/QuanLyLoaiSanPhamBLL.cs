using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyLoaiSanPhamBLL
    {
        private QuanLyLoaiSanPhamDAL loaiSP = new QuanLyLoaiSanPhamDAL();

        public List<QuanLyLoaiSanPhamDTO> layDSLoaiSP()
        {
            return loaiSP.layDSLSP();
        }

        public bool ThemLoaiSP(QuanLyLoaiSanPhamDTO loaiSPNew)
        {
            QuanLyLoaiSanPhamDTO loaiSPKT = loaiSP.layDSLSP().SingleOrDefault(u => u.TenLoai == loaiSPNew.TenLoai);

            if (loaiSPKT != null) return false;

            return loaiSP.ThemLoaiSanPham(loaiSPNew);
        }

        public bool CapNhatLoaiSP(QuanLyLoaiSanPhamDTO loaiSPCapNhat)
        {
            QuanLyLoaiSanPhamDTO loaiSPKT = loaiSP.layDSLSP().SingleOrDefault(u => u.TenLoai == loaiSPCapNhat.TenLoai);

            if (loaiSPKT != null) return false;

            return loaiSP.CapNhatLoaiSP(loaiSPCapNhat);
        }

        public bool XoaLoaiSP(int id)
        {
            return loaiSP.XoaLoaiSP(id);
        }
    }
}
