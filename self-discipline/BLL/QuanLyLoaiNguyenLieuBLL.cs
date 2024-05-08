using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyLoaiNguyenLieuBLL
    {
        private QuanLyLoaiNguyenLieuDAL loaiNL = new QuanLyLoaiNguyenLieuDAL();

        public List<QuanLyLoaiNguyenLieuDTO> layDSLoaiNL()
        {
            return  loaiNL.layDSLoaiNL();
        }

        public bool ThemLoaiNL(QuanLyLoaiNguyenLieuDTO loaiNLNew)
        {
            QuanLyLoaiNguyenLieuDTO loaiNLKT = loaiNL.layDSLoaiNL().SingleOrDefault(u => u.TenLoai == loaiNLNew.TenLoai);

            if(loaiNLKT != null) return false;

            return loaiNL.ThemLoaiNL(loaiNLNew);
        }

        public bool CapNhatLoaiNL(QuanLyLoaiNguyenLieuDTO loaiNLCapNhat)
        {
            return loaiNL.CapNhatLoaiNL(loaiNLCapNhat);
        }

        public bool XoaLoaiNL(int id)
        {
            return loaiNL.XoaLoaiNL(id);
        }
    }
}
