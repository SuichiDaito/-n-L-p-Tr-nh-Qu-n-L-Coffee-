using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();
        public List<NhanVienDTO> dsNhanVien()
        {
            return COFFEE_HOUSEEnts.NHANVIEN.Select(u => new NhanVienDTO
            {
                MaNV = u.MaNV,
                Ho = u.Ho,
                Ten = u.Ten,
                Phai = u.Phai,
                Email = u.Email,
                NgaySinh = u.NgaySinh,
                DiaChi = u.DiaChi,
                SDT = u.SDT,
                ChucVu = u.ChucVu,
                TrangThai = u.TrangThai,
            }).Where(u => u.TrangThai != 0).ToList(); 
        }

        public bool ThemNhanVien(NhanVienDTO nhanVienNew)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN
                {
                    Ho = nhanVienNew.Ho,
                    Ten = nhanVienNew.Ten,
                    Phai = nhanVienNew.Phai,
                    NgaySinh = nhanVienNew.NgaySinh,
                    DiaChi = nhanVienNew.DiaChi,
                    SDT = nhanVienNew.SDT,
                    Email = nhanVienNew.Email,
                    ChucVu = nhanVienNew.ChucVu,
                    TrangThai = nhanVienNew.TrangThai,
                };

                COFFEE_HOUSEEnts.NHANVIEN.Add(nv);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatNhanVien(NhanVienDTO nhanVienCapNhat)
        {
            try
            {
                NHANVIEN nv = COFFEE_HOUSEEnts.NHANVIEN.SingleOrDefault(u => u.MaNV == nhanVienCapNhat.MaNV);

                nv.Ho = nhanVienCapNhat.Ho;
                nv.Ten = nhanVienCapNhat.Ten;
                nv.Phai = nhanVienCapNhat.Phai;
                nv.NgaySinh = nhanVienCapNhat.NgaySinh;
                nv.DiaChi = nhanVienCapNhat.DiaChi;
                nv.SDT = nhanVienCapNhat.SDT;
                nv.Email = nhanVienCapNhat.Email;
                
                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaNhanVien(int MaNV)
        {
            try
            {
                NHANVIEN nv = COFFEE_HOUSEEnts.NHANVIEN.SingleOrDefault(u => u.MaNV == MaNV);

                nv.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
