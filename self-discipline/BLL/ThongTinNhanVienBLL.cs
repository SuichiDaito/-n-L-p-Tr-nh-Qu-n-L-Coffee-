using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThongTinNhanVienBLL
    {
        NhanVienDAL nv = new NhanVienDAL();
        public List<NhanVienDTO> LayDsNhanVien()
        {
            return nv.dsNhanVien();
        }
     
        public bool ThemNhanVien(NhanVienDTO nhanVienNew)
        {
            return nv.ThemNhanVien(nhanVienNew);
        }

        public bool CapNhatNhanVien(NhanVienDTO nhanVienCapNhat)
        {
            return nv.CapNhatNhanVien(nhanVienCapNhat);
        }

        public bool XoaNhanVien(int id)
        {
            return nv.XoaNhanVien(id);
        }
    }
}
