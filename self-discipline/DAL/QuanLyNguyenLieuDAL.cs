using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyNguyenLieuDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyNguyenLieuDTO> layDSNL()
        {
            return COFFEE_HOUSEEnts.NGUYENLIEUx.Select(u => new QuanLyNguyenLieuDTO
            {
                MaNL = u.MaNL,
                MaNCC = (int)u.MaNCC,
                TenNL = u.TenNL,
                LoaiNguyenLieu = (int)u.LoaiNL,
                SLTon = u.SLTon,
                DVT = u.DVT,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemNguyenLieu(QuanLyNguyenLieuDTO nguyenLieuNew)
        {
            try
            {
                NGUYENLIEU NL = new NGUYENLIEU()
                {
                    MaNCC = nguyenLieuNew.MaNCC,
                    TenNL = nguyenLieuNew.TenNL,
                    LoaiNL = nguyenLieuNew.LoaiNguyenLieu,
                    SLTon = nguyenLieuNew.SLTon,
                    DVT = nguyenLieuNew.DVT,
                    TrangThai = nguyenLieuNew.TrangThai
                };

                COFFEE_HOUSEEnts.NGUYENLIEUx.Add(NL);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CapNhatNguyenLieu(QuanLyNguyenLieuDTO nguyenlieuCapNhat)
        {
            try
            {
                NGUYENLIEU NL = COFFEE_HOUSEEnts.NGUYENLIEUx.SingleOrDefault(u => u.MaNL == nguyenlieuCapNhat.MaNL);

                NL.MaNCC = nguyenlieuCapNhat.MaNCC;
                NL.TenNL = nguyenlieuCapNhat.TenNL;
                NL.LoaiNL = nguyenlieuCapNhat.LoaiNguyenLieu;
                NL.SLTon = nguyenlieuCapNhat.SLTon;
                NL.DVT = nguyenlieuCapNhat.DVT;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch ( Exception e )
            {
                return false;
            }
        }


        public bool XoaNguyenLieu(int id)
        {
            try
            {
                NGUYENLIEU NL = COFFEE_HOUSEEnts.NGUYENLIEUx.SingleOrDefault(u => u.MaNL == id);

                NL.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
