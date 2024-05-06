using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
