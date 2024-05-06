using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuanLyBanBLL
    {
        private QuanLyBanDAL banDAL = new QuanLyBanDAL();

        public List<QuanLyBanDTO> layDSBan()
        {
            return banDAL.layDSBan();
        }

        public bool ThemBan(QuanLyBanDTO banNew)
        {
            return banDAL.ThemBan(banNew);
        }

        public bool CapNhatBan(QuanLyBanDTO banCapNhat)
        {
            return banDAL.CapNhatBan(banCapNhat);
        }

        public bool XoaBan(int id)
        {
            return banDAL.XoaBan(id);
        }
    }
}
