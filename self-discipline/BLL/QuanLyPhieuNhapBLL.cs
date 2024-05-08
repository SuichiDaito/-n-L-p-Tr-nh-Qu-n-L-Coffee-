using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class QuanLyPhieuNhapBLL
    {
        public QuanLyPhieuNhapDAL pnDAL = new QuanLyPhieuNhapDAL();

        public List<QuanLyPhieuNhapDTO> layDSPN()
        {
            return pnDAL.layDSPN();
        }

        public bool ThemPhieuNhap(QuanLyPhieuNhapDTO pnNew)
        {
            QuanLyPhieuNhapDTO pnKT = pnDAL.layDSPN().SingleOrDefault(u => u.MaNL == pnNew.MaNL);

            if (pnKT != null) return false;

            return pnDAL.ThemPhieuNhap(pnNew);
        }

        public bool CapNhatPhieuNhap(QuanLyPhieuNhapDTO pnCapNhat)
        {
            return pnDAL.CapNhatPhieuNhap(pnCapNhat);
        }

        public bool XoaPhieuNhap(int id)
        {
            return pnDAL.XoaPhieuNhap(id);
        }
    }
}
