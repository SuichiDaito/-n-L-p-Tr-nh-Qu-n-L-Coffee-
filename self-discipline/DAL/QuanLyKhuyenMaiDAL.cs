using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QuanLyKhuyenMaiDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyKhuyenMaiDTO> layDSKM()
        {
            return COFFEE_HOUSEEnts.KHUYENMAIs.Select(u => new QuanLyKhuyenMaiDTO
            {
                MaGiamGia = u.MaGiamGia,
                TenMaGiamGia = u.TenMaGiamGia,
                PhanTram = (float)u.PhanTram,
                SL = u.SoLuong,
                NgayBatDau = (DateTime)u.NgayBatDau,
                NgayKetThuc = (DateTime)u.NgayKetThuc,
                MoTa = u.Mota,
                TrangThai = (int)u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemKhuyenMai(QuanLyKhuyenMaiDTO khuyenMaiNew)
        {
            try
            {
                KHUYENMAI km = new KHUYENMAI()
                {
                    TenMaGiamGia = khuyenMaiNew.TenMaGiamGia,
                    PhanTram = khuyenMaiNew.PhanTram,
                    SoLuong = khuyenMaiNew.SL,
                    NgayBatDau = khuyenMaiNew.NgayBatDau,
                    NgayKetThuc = khuyenMaiNew.NgayKetThuc,
                    Mota = khuyenMaiNew.MoTa,
                    TrangThai = khuyenMaiNew.TrangThai
                };

                COFFEE_HOUSEEnts.KHUYENMAIs.Add(km);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatKhuyenMai(QuanLyKhuyenMaiDTO khuyenMaiCapNhat)
        {
            try
            {
                KHUYENMAI km = COFFEE_HOUSEEnts.KHUYENMAIs.SingleOrDefault(u => u.MaGiamGia == khuyenMaiCapNhat.MaGiamGia);

                km.TenMaGiamGia = khuyenMaiCapNhat.TenMaGiamGia;
                km.PhanTram = khuyenMaiCapNhat.PhanTram;
                km.SoLuong = khuyenMaiCapNhat.SL;
                km.NgayBatDau = khuyenMaiCapNhat.NgayBatDau;
                km.NgayKetThuc = khuyenMaiCapNhat.NgayKetThuc;
                km.Mota = khuyenMaiCapNhat.MoTa;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaKhuyenMai(int id)
        {
            try
            {
                KHUYENMAI km = COFFEE_HOUSEEnts.KHUYENMAIs.SingleOrDefault(u => u.MaGiamGia == id);

                km.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
      
    }
}
