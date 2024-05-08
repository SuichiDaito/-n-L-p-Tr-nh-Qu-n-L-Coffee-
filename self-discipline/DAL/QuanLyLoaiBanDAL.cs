using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyLoaiBanDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyLoaiBanDTO> layDSLoaiBan()
        {
            return COFFEE_HOUSEEnts.LOAI_BAN.Select(u => new QuanLyLoaiBanDTO
            {
                MaLoai = u.MaLoai,
                TenLoai = u.TenLoai,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemLoaiBan(QuanLyLoaiBanDTO loaiBanNew)
        {
            try
            {
                LOAI_BAN loaiBan = new LOAI_BAN()
                {
                    TenLoai = loaiBanNew.TenLoai,
                    TrangThai = loaiBanNew.TrangThai,
                };

                COFFEE_HOUSEEnts.LOAI_BAN.Add(loaiBan);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatLoaiBan(QuanLyLoaiBanDTO loaiBanCapNhat)
        {
            try
            {
                LOAI_BAN loaiBan = COFFEE_HOUSEEnts.LOAI_BAN.SingleOrDefault(u => u.MaLoai == loaiBanCapNhat.MaLoai);

                loaiBan.TenLoai = loaiBanCapNhat.TenLoai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaLoaiBan(int id)
        {
            try
            {
                LOAI_BAN loaiBan = COFFEE_HOUSEEnts.LOAI_BAN.SingleOrDefault(u => u.MaLoai == id);

                loaiBan.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
