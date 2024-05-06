using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return nCCDAL.ThemNhaCungCap(nCCNew);
        }

        public bool CapNhatNhaCungCap(QuanLyNhaCungCapDTO nCCCapNhat)
        {
            return nCCDAL.CapNhatNhaCungCap(nCCCapNhat);
        }

        public bool XoaNhaCungCap(int id)
        {
            return nCCDAL.XoaNhaCungCap(id);
        }
    }
}
