using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.COFFEE_HOUSEDataSet;

namespace BLL
{
    public class QuanLyNhaCungCapBLL
    {
        private QuanLyNhaCungCapDAL nCCDAL = new QuanLyNhaCungCapDAL();

        public List<QuanLyNhaCungCapDTO> layDSNCC()
        {
            return nCCDAL.layDSNCC();
        }

        public bool ThemNhaCungCap(QuanLyNhaCungCapDTO nCCNew)
        {
            QuanLyNhaCungCapDTO nccKT = nCCDAL.layDSNCC().SingleOrDefault(u => u.TenNCC == nCCNew.TenNCC);

            if (nccKT != null) return false;

            return nCCDAL.ThemNhaCungCap(nCCNew);
        }

        public bool CapNhatNhaCungCap(QuanLyNhaCungCapDTO nCCCapNhat)
        {
            QuanLyNhaCungCapDTO nccKT = nCCDAL.layDSNCC().SingleOrDefault(u => u.TenNCC == nCCCapNhat.TenNCC);

            if (nccKT != null) return false;

            return nCCDAL.CapNhatNhaCungCap(nCCCapNhat);
        }

        public bool XoaNhaCungCap(int id)
        {
            return nCCDAL.XoaNhaCungCap(id);
        }
    }
}
