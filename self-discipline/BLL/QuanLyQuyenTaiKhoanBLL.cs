using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyQuyenTaiKhoanBLL
    {
        private QuanLyQuyenTaiKhoanDAL Quyen = new QuanLyQuyenTaiKhoanDAL();

        public List<QuanLyQuyenTaiKhoanDTO> layDSQuyenTK()
        {
            return Quyen.layDSQuyenTK();
        }

        public bool ThemQuyenTK(QuanLyQuyenTaiKhoanDTO quyenTKNew)
        {
            return Quyen.ThemQuyenTK(quyenTKNew);
        }

        public bool CapNhatQuyenTK(QuanLyQuyenTaiKhoanDTO quyenTKCapNhat)
        {
            return Quyen.CapNhatQuyenTK(quyenTKCapNhat);
        }

        public bool XoaQuyenTK(int id)
        {
            return Quyen.XoaQuyenTK(id);
        }
    }
}
