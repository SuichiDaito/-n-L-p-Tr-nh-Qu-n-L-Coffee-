using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyLoaiSanPhamBLL
    {
        private QuanLyLoaiSanPhamDAL loaiSP = new QuanLyLoaiSanPhamDAL();
        private DataProvider _providers = new DataProvider();

        public List<QuanLyLoaiSanPhamDTO> layDSLoaiSP()
        {
            return loaiSP.layDSLSP();
        }

        public bool ThemLoaiSP(QuanLyLoaiSanPhamDTO loaiSPNew)
        {
            QuanLyLoaiSanPhamDTO loaiSPKT = loaiSP.layDSLSP().SingleOrDefault(u => u.TenLoai == loaiSPNew.TenLoai);

            if (loaiSPKT != null) return false;

            return loaiSP.ThemLoaiSanPham(loaiSPNew);
        }

        public bool CapNhatLoaiSP(QuanLyLoaiSanPhamDTO loaiSPCapNhat)
        {
            return loaiSP.CapNhatLoaiSP(loaiSPCapNhat);
        }

        public bool XoaLoaiSP(int id)
        {
            return loaiSP.XoaLoaiSP(id);
        }
         public DataTable LayDs()
        {
            DataTable table = new DataTable();

            table = _providers.ExecuteSelect("SELECT * FROM LOAI_SANPHAM");

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return new DataTable();
            }
        }
    }
}
