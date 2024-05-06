using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QuanLySanPhamDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLySanPhamDTO> layDSSP()
        {
            return COFFEE_HOUSEEnts.SANPHAMs.Select(u => new QuanLySanPhamDTO
            {
                MaSP = u.MaSP,
                TenSP = u.TenSP,
                LoaiSP = (int)u.LoaiSP,
                GiaBan = (int)u.GiaBan,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemSanPham(QuanLySanPhamDTO sanPhamNew)
        {
            try
            {
                SANPHAM sp = new SANPHAM()
                {
                    TenSP = sanPhamNew.TenSP,
                    LoaiSP = sanPhamNew.LoaiSP,
                    GiaBan = sanPhamNew.GiaBan,
                    TrangThai = sanPhamNew.TrangThai
                };

                COFFEE_HOUSEEnts.SANPHAMs.Add(sp);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CapNhatSanPham(QuanLySanPhamDTO sanPhamCapNhat)
        {
            try
            {
                SANPHAM sp = COFFEE_HOUSEEnts.SANPHAMs.SingleOrDefault(u => u.MaSP == sanPhamCapNhat.MaSP);

                sp.TenSP = sanPhamCapNhat.TenSP;
                sp.LoaiSP = sanPhamCapNhat.LoaiSP;
                sp.GiaBan = sanPhamCapNhat.GiaBan;
                sp.TrangThai = sanPhamCapNhat.TrangThai;
             
                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaSanPham(int id)
        {
            try
            {
                SANPHAM sp = COFFEE_HOUSEEnts.SANPHAMs.SingleOrDefault(u => u.MaSP == id);

                sp.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
