using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.COFFEE_HOUSEDataSet;

namespace BLL
{
    public class QuanLyNguyenLieuBLL
    {
        QuanLyNguyenLieuDAL NLDAL = new QuanLyNguyenLieuDAL();

        public List<QuanLyNguyenLieuDTO> layDSNL()
        {
            return NLDAL.layDSNL();
        }

        public bool ThemNguyenLieu(QuanLyNguyenLieuDTO nguyenLieuNew)
        {
            QuanLyNguyenLieuDTO nLKT = NLDAL.layDSNL().SingleOrDefault(u => u.TenNL == nguyenLieuNew.TenNL);

            if(nLKT != null) return false;

            return NLDAL.ThemNguyenLieu(nguyenLieuNew);
        }

        public bool CapNhatNguyenLieu(QuanLyNguyenLieuDTO nguyenLieuCapNhat)
        {
            return NLDAL.CapNhatNguyenLieu(nguyenLieuCapNhat);
        }

        public bool XoaNguyenLieu(int id)
        {
            return NLDAL.XoaNguyenLieu(id);
        }
    }
}
