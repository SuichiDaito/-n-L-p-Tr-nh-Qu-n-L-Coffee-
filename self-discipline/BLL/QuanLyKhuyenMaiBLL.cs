using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class QuanLyKhuyenMaiBLL
    {
        private QuanLyKhuyenMaiDAL kmDAL = new QuanLyKhuyenMaiDAL();

        public List<QuanLyKhuyenMaiDTO> layDSKM()
        {
            return kmDAL.layDSKM();
        }

        public bool ThemKhuyenMai(QuanLyKhuyenMaiDTO khuyenMaiNew)
        {
            return kmDAL.ThemKhuyenMai(khuyenMaiNew);
        }

        public bool CapNhatKhuyenMai(QuanLyKhuyenMaiDTO khuyenMaiCapNhat)
        {
            return kmDAL.CapNhatKhuyenMai(khuyenMaiCapNhat);
        }

        public bool XoaKhuyenMai(int id)
        {
            return kmDAL.XoaKhuyenMai(id);
        }
    }
}
