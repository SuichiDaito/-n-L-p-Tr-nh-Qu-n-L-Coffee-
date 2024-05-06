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
            return loaiSP.ThemLoaiSanPham(loaiSPNew);
        }

        public bool CapNhatLoaiSP(QuanLyLoaiSanPhamDTO loaiSPCapNhat)
        {
            return loaiSP.CapNhatLoaiSP(loaiSPCapNhat);
        }

        public bool XoaLoaiSP(int id)
        {
            return loaiSP.XoaLoaiSP(id);
        }
    }
}
