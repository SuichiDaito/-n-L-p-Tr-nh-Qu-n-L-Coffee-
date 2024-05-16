using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using static DAL.COFFEE_HOUSEDataSet;

namespace BLL
{
    public class QuanLyKhuyenMaiBLL
    {
        DataProvider _providers = new DataProvider();
        private QuanLyKhuyenMaiDAL kmDAL = new QuanLyKhuyenMaiDAL();

        public List<QuanLyKhuyenMaiDTO> layDSKM()
        {
            return kmDAL.layDSKM();
        }

        public bool ThemKhuyenMai(QuanLyKhuyenMaiDTO khuyenMaiNew)
        {
            QuanLyKhuyenMaiDTO kmKT = kmDAL.layDSKM().SingleOrDefault(u => u.TenMaGiamGia == khuyenMaiNew.TenMaGiamGia);

            if (kmKT != null) return false;

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
        public double LayPhanTramKhuyenMai(int id)
        {
            double phantram = _providers.ExecuteScalar_KhuyenMai(id);
            return phantram;
        }
    }
}
