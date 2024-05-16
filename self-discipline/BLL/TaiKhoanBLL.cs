using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.COFFEE_HOUSEDataSet;

namespace BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();

        public List<TaiKhoanDTO> layDSTK()
        {
            return taiKhoanDAL.layDSTK();
        }

        public bool ThemTaiKhoan(TaiKhoanDTO taiKhoanNew)
        {
            TaiKhoanDTO tkKT = taiKhoanDAL.layDSTK().SingleOrDefault(u => u.MaNV == taiKhoanNew.MaNV);

            if (tkKT != null) return false;

            return taiKhoanDAL.ThemTaiKhoan(taiKhoanNew);
        }

        public bool CapNhapTaiKhoan(TaiKhoanDTO taiKhoanCapNhat)
        {
            return taiKhoanDAL.CapNhatTaiKhoan(taiKhoanCapNhat);
        }

        public bool XoaTaiKhoan(int id)
        {
            return taiKhoanDAL.XoaTaiKhoan(id);
        }
        public int TimMaNhanVien(string username)
        {
            int ID = taiKhoanDAL.TimNhanVienTheoUsername(username);
            return ID;
        }
    }
}
