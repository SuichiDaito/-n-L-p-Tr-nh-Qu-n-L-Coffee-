using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyQuyenTaiKhoanDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();
        public List<QuanLyQuyenTaiKhoanDTO> layDSQuyenTK()
        {
            return COFFEE_HOUSEEnts.TK_QUYEN.Select(u => new QuanLyQuyenTaiKhoanDTO
            {
                MaQuyen = u.MaQuyen,
                TenQuyen = u.TenQuyen,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemQuyenTK(QuanLyQuyenTaiKhoanDTO quyenTKNew)
        {
            try
            {
                TK_QUYEN quyenTK = new TK_QUYEN()
                {
                    TenQuyen = quyenTKNew.TenQuyen,
                    TrangThai = quyenTKNew.TrangThai
                };

                COFFEE_HOUSEEnts.TK_QUYEN.Add(quyenTK);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatQuyenTK(QuanLyQuyenTaiKhoanDTO quyenTKCapNhat)
        {
            try
            {
                TK_QUYEN quyenTK = COFFEE_HOUSEEnts.TK_QUYEN.SingleOrDefault(u => u.MaQuyen == quyenTKCapNhat.MaQuyen);

                quyenTK.TenQuyen = quyenTKCapNhat.TenQuyen;
                quyenTK.TrangThai = quyenTKCapNhat.TrangThai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaQuyenTK(int id)
        {
            try
            {
                TK_QUYEN quyenTK = COFFEE_HOUSEEnts.TK_QUYEN.SingleOrDefault(u => u.MaQuyen == id);

                quyenTK.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
