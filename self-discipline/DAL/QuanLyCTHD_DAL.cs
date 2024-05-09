using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyCTHD_DAL
    {

        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();
        public List<QuanLyCTHoaDonDTO> LayDsChiTietHoaDon()
        {
            return COFFEE_HOUSEEnts.CTHDs.Select(u => new QuanLyCTHoaDonDTO
            {
                MaCT = u.MaCT,
                MaHD = u.MaHD.Value,
                MaSP = u.MaSP.Value,
                SL = u.SL,
            }).ToList();

        }
        public bool ThemChiTietHoaDon(QuanLyCTHoaDonDTO ct)
        {
            CTHD CT = new CTHD();
            CT.MaHD = ct.MaHD;
            CT.MaSP = ct.MaSP;
            CT.SL = ct.SL;
            COFFEE_HOUSEEnts.CTHDs.Add(CT);
            return COFFEE_HOUSEEnts.SaveChanges() == 1;
        }

    }
}
