using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyLoaiTaiKhoanDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();
        public List<QuanLyLoaiTaiKhoanDTO> layDSLoaiTK()
        {
            return COFFEE_HOUSEEnts.LOAI_TAIKHOAN.Select(u => new QuanLyLoaiTaiKhoanDTO
            {
                MaLoai = u.MaLoai,
                TenLoai = u.TenLoai,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemLoaiTaiKhoan(QuanLyLoaiTaiKhoanDTO loaiTaiKhoanNew)
        {
            try
            {
                LOAI_TAIKHOAN loaiTK = new LOAI_TAIKHOAN()
                {
                    TenLoai = loaiTaiKhoanNew.TenLoai,
                    TrangThai = loaiTaiKhoanNew.TrangThai
                };

                COFFEE_HOUSEEnts.LOAI_TAIKHOAN.Add(loaiTK);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatLoaiTK(QuanLyLoaiTaiKhoanDTO loaiTKCapNhat)
        {
            try
            {
                LOAI_TAIKHOAN loaiTK = COFFEE_HOUSEEnts.LOAI_TAIKHOAN.SingleOrDefault(u => u.MaLoai == loaiTKCapNhat.MaLoai);

                loaiTK.TenLoai = loaiTKCapNhat.TenLoai;
                loaiTK.TrangThai = loaiTKCapNhat.TrangThai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaLoaiTK(int id)
        {
            try
            {
                LOAI_TAIKHOAN loaiTK = COFFEE_HOUSEEnts.LOAI_TAIKHOAN.SingleOrDefault(u => u.MaLoai == id);
                
                loaiTK.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
