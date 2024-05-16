using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyHoaDonDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();
      public  List<QuanLyHoaDonDTO> LayDSHoaDon()
        {
            return COFFEE_HOUSEEnts.HOADONs.Select(u => (new QuanLyHoaDonDTO
            {
                MaHD = u.MaHD,
                MaBan = u.MaBan.Value,
                MaNV = u.MaNV.Value,
                NgayLap = u.NgayLap,
                TrangThai = u.TrangThai
            })).Where( v => v.TrangThai == true).ToList();
        }
        public bool ThemHoaDon(QuanLyHoaDonDTO HoaDon)
        {
            try
            {
                HOADON HD = new HOADON();
                {
                    HD.MaBan = HoaDon.MaBan;
                    HD.MaNV = HoaDon.MaNV;
                    HD.MaKhuyenMai = null;
                    HD.NgayLap = DateTime.Now;
                    HD.TrangThai = true;
                };
                COFFEE_HOUSEEnts.HOADONs.Add(HD);
                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex) { return false; }

        }


        public bool CapNhatKhuyenMai(QuanLyHoaDonDTO hoadon)
        {
            try
            {
                HOADON HD = COFFEE_HOUSEEnts.HOADONs.SingleOrDefault(u => u.MaHD == hoadon.MaHD);
                HD.MaKhuyenMai = hoadon.MaKhuyenMai;
                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex) { return false; }

        }


        public bool XoaHoaDon(QuanLyHoaDonDTO HoaDon)
        {
            try
            {

                HOADON HD = COFFEE_HOUSEEnts.HOADONs.SingleOrDefault(u => u.MaHD == HoaDon.MaHD);
                HD.TrangThai = false;
                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex) { return false; }
        }



    }
}
