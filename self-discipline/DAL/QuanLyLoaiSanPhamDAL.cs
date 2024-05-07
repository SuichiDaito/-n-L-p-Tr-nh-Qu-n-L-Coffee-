using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyLoaiSanPhamDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyLoaiSanPhamDTO> layDSLSP()
        {
            return COFFEE_HOUSEEnts.LOAI_SANPHAM.Select(u => new QuanLyLoaiSanPhamDTO
            {
                MaLoai = u.MaLoai,
                TenLoai = u.TenLoai,
                TrangThai = u.TrangThai,
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemLoaiSanPham(QuanLyLoaiSanPhamDTO loaiSanPhamNew)
        {
            try
            {
                LOAI_SANPHAM loaiSP = new LOAI_SANPHAM()
                {
                    TenLoai = loaiSanPhamNew.TenLoai,
                    TrangThai = loaiSanPhamNew.TrangThai
                };
                
                COFFEE_HOUSEEnts.LOAI_SANPHAM.Add(loaiSP);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CapNhatLoaiSP(QuanLyLoaiSanPhamDTO loaiSanPhamCapNhat)
        {
            try
            {
                LOAI_SANPHAM loaiSP = COFFEE_HOUSEEnts.LOAI_SANPHAM.SingleOrDefault(u => u.MaLoai == loaiSanPhamCapNhat.MaLoai);

                loaiSP.TenLoai = loaiSanPhamCapNhat.TenLoai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaLoaiSP(int id)
        {
            try
            {
                LOAI_SANPHAM loaiSP = COFFEE_HOUSEEnts.LOAI_SANPHAM.SingleOrDefault(u => u.MaLoai == id);

                loaiSP.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
