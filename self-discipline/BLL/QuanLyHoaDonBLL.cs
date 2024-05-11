using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyHoaDonBLL
    {

        DataProvider _provider = new DataProvider();
        QuanLyHoaDonDAL HoaDon = new QuanLyHoaDonDAL();
       
        public List<QuanLyHoaDonDTO> LayDs()
        {
            return HoaDon.LayDSHoaDon();
        }
     
        public bool ThemHoaDon(QuanLyHoaDonDTO hd)
        {
            return HoaDon.ThemHoaDon(hd);

        }
        public bool CapNhatHoaDon(QuanLyHoaDonDTO hoadon)
        {
            return HoaDon.CapNhatKhuyenMai(hoadon);
        }

        public int LayMaHoaDon()
        {
            int id = _provider.ExecuteScalar();
            return id;
        }
         public bool KiemTraHoaDon(int tongtien)
        {
            if(tongtien > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
