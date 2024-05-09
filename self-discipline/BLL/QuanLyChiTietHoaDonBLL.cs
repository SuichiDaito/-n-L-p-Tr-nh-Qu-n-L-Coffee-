using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyChiTietHoaDonBLL
    {
        QuanLyCTHD_DAL ChiTiet = new QuanLyCTHD_DAL();
        public List<QuanLyCTHoaDonDTO> LayDS()
        {
            return ChiTiet.LayDsChiTietHoaDon();
        }
        public bool ThemChiTiet(QuanLyCTHoaDonDTO ct)
        {
            if (ct.MaHD > 0)
            {
                ChiTiet.ThemChiTietHoaDon(ct);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
