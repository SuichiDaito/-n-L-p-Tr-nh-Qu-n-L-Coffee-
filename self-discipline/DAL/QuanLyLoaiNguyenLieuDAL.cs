using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyLoaiNguyenLieuDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyLoaiNguyenLieuDTO> layDSLoaiNL()
        {
            return COFFEE_HOUSEEnts.LOAI_NGUYENLIEU.Select(u => new QuanLyLoaiNguyenLieuDTO
            {
                MaLoai = u.MaLoai,
                TenLoai = u.Tenloai,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemLoaiNL(QuanLyLoaiNguyenLieuDTO loaiNLNew)
        {
            try
            {
                LOAI_NGUYENLIEU loaiNL = new LOAI_NGUYENLIEU()
                {
                    Tenloai = loaiNLNew.TenLoai,
                    TrangThai = loaiNLNew.TrangThai
                };

                COFFEE_HOUSEEnts.LOAI_NGUYENLIEU.Add(loaiNL);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatLoaiNL(QuanLyLoaiNguyenLieuDTO loaiNLCapNhat)
        {
            try
            {
                LOAI_NGUYENLIEU loaiNL = COFFEE_HOUSEEnts.LOAI_NGUYENLIEU.SingleOrDefault(u => u.MaLoai == loaiNLCapNhat.MaLoai);

                loaiNL.Tenloai = loaiNLCapNhat.TenLoai;
                loaiNL.TrangThai = loaiNLCapNhat.TrangThai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaLoaiNL(int id)
        {
            try
            {
                LOAI_NGUYENLIEU loaiNL = COFFEE_HOUSEEnts.LOAI_NGUYENLIEU.SingleOrDefault(u => u.MaLoai == id);

                loaiNL.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
