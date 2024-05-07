using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
using static DAL.COFFEE_HOUSEDataSet;

namespace BLL
{
    public class QuanLySanPhamBLL
    {
        private QuanLySanPhamDAL spDAL = new QuanLySanPhamDAL();
        DataProvider _providers = new DataProvider();

        public List<QuanLySanPhamDTO> layDSSP()
        {
            return spDAL.layDSSP();
        }

        public bool ThemSanPham(QuanLySanPhamDTO sanPhamNew)
        {
            QuanLySanPhamDTO spKT = spDAL.layDSSP().SingleOrDefault(u => u.TenSP == sanPhamNew.TenSP);

            if (spKT != null) return false;

            return spDAL.ThemSanPham(sanPhamNew);
        }

        public bool CapNhatSanPham(QuanLySanPhamDTO sanPhamCapNhat)
        {
            QuanLySanPhamDTO spKT = spDAL.layDSSP().SingleOrDefault(u => u.TenSP == sanPhamCapNhat.TenSP);

            if (spKT != null) return false;

            return spDAL.CapNhatSanPham(sanPhamCapNhat);
        }

        public bool XoaSanPham(int id)
        {
            return spDAL.XoaSanPham(id);
        }

        public DataTable LayDS()
        {
            DataTable table = new DataTable();

            table = _providers.ExecuteSelect("SELECT * FROM SANPHAM");

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
