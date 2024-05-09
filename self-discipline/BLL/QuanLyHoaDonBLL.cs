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
        public bool ThemHoaDon(QuanLyHoaDonDTO hd)
        {
            return HoaDon.ThemHoaDon(hd);

        }
        public bool CapNhatHoaDon(int tongtien, QuanLyHoaDonDTO hoadon)
        {
            if (tongtien > 100)
            {
                return HoaDon.CapNhatKhuyenMai(hoadon);
            }
            else return false;

        }
        public int LayMaHoaDon()
        {
            string query = "SELECT MAX(MAHD) FROM HOADON";
            int id = _provider.ExecuteScalar(query);
            return id;
        }

    }
}
