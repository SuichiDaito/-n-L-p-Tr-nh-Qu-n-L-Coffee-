using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyLoaiBanBLL
    {
        private QuanLyLoaiBanDAL loaiBan = new QuanLyLoaiBanDAL();

        public List<QuanLyLoaiBanDTO> layDSLoaiBan()
        {
            return loaiBan.layDSLoaiBan();
        }

        public bool ThemLoaiBan(QuanLyLoaiBanDTO loaiBanNew)
        {
            QuanLyLoaiBanDTO loaiBanKT = loaiBan.layDSLoaiBan().SingleOrDefault(u => u.TenLoai == loaiBanNew.TenLoai);

            if (loaiBanKT != null) return false;

            return loaiBan.ThemLoaiBan(loaiBanNew);
        }

        public bool CapNhatLoaiBan(QuanLyLoaiBanDTO loaiBanCapNhat)
        {
            return loaiBan.CapNhatLoaiBan(loaiBanCapNhat);
        }

        public bool XoaLoaiBan(int id)
        {
            return loaiBan.XoaLoaiBan(id);
        }
    }
}
