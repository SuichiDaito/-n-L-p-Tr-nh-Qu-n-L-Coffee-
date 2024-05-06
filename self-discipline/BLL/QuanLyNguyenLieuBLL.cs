using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyNguyenLieuBLL
    {
        QuanLyNguyenLieuDAL NLDAL = new QuanLyNguyenLieuDAL();

        public List<QuanLyNguyenLieuDTO> layDSNL()
        {
            return NLDAL.layDSNL();
        }

        public bool ThemNguyenLieu(QuanLyNguyenLieuDTO nguyenLieuNew)
        {
            return NLDAL.ThemNguyenLieu(nguyenLieuNew);
        }

        public bool CapNhatNguyenLieu(QuanLyNguyenLieuDTO nguyenLieuCapNhat)
        {
            return NLDAL.CapNhatNguyenLieu(nguyenLieuCapNhat);
        }

        public bool XoaNguyenLieu(int id)
        {
            return NLDAL.XoaNguyenLieu(id);
        }
    }
}
