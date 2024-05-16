using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyBanDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyBanDTO> layDSBan()
        {
            return COFFEE_HOUSEEnts.BAN.Select(u => new QuanLyBanDTO
            {
                MaBan = u.MaBan,
                LoaiBan = (int)u.LoaiBan,
                TrangThai = u.TrangThai
            }).ToList();
        }

        public bool ThemBan(QuanLyBanDTO banNew)
        {
            try
            {
                BAN ban = new BAN()
                {
                    LoaiBan = banNew.LoaiBan,
                    TrangThai = banNew.TrangThai
                };

                COFFEE_HOUSEEnts.BAN.Add(ban);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatBan(QuanLyBanDTO banCapNhat)
        {
            try
            {
                BAN ban = COFFEE_HOUSEEnts.BAN.SingleOrDefault(u => u.MaBan == banCapNhat.MaBan);

                ban.LoaiBan = banCapNhat.LoaiBan;
                ban.TrangThai = banCapNhat.TrangThai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaBan(int id)
        {
            try
            {
                BAN ban = COFFEE_HOUSEEnts.BAN.SingleOrDefault(u => u.MaBan == id);

                ban.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
