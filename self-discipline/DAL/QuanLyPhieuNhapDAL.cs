using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QuanLyPhieuNhapDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyPhieuNhapDTO> layDSPN()
        {
            return COFFEE_HOUSEEnts.CTPHIEUNHAPs.Select(u => new QuanLyPhieuNhapDTO
            {
                MaPN = u.MaPN,
                MaNL = (int)u.MaNL,
                MaDon = (int)u.MaDon,
                SL = (int)u.SL,
                DVT = u.DVT,
                GiaNhap = (float)u.GiaNhap,
                GiamGia = (float)u.GiamGia,
                //TrangThai = (int)u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemPhieuNhap(QuanLyPhieuNhapDTO pnNew)
        {
            try
            {
                CTPHIEUNHAP pn = new CTPHIEUNHAP()
                {
                    MaNL = pnNew.MaNL,
                    MaDon = pnNew.MaDon,
                    SL = pnNew.SL,
                    DVT = pnNew.DVT,
                    GiaNhap = pnNew.GiaNhap,
                    GiamGia = pnNew.GiamGia,
                    TrangThai = pnNew.TrangThai
                };

                COFFEE_HOUSEEnts.CTPHIEUNHAPs.Add(pn);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatPhieuNhap(QuanLyPhieuNhapDTO pnCapNhat)
        {
            try
            {
                CTPHIEUNHAP pn = COFFEE_HOUSEEnts.CTPHIEUNHAPs.SingleOrDefault(u => u.MaPN == pnCapNhat.MaPN);

                pn.MaNL = pnCapNhat.MaNL;
                pn.MaDon = pnCapNhat.MaDon;
                pn.SL = pnCapNhat.SL;
                pn.DVT = pnCapNhat.DVT;
                pn.GiaNhap = pnCapNhat.GiaNhap;
                pn.GiamGia = pnCapNhat.GiamGia;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaPhieuNhap(int id)
        {
            try
            {
                CTPHIEUNHAP pn = COFFEE_HOUSEEnts.CTPHIEUNHAPs.SingleOrDefault(u => u.MaPN == id);

                pn.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
