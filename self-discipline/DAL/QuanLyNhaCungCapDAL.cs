using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyNhaCungCapDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<QuanLyNhaCungCapDTO> layDSNCC()
        {
            return COFFEE_HOUSEEnts.NCCs.Select(u => new QuanLyNhaCungCapDTO
            {
                MaNCC = u.MaNCC,
                TenNCC = u.TenNCC,
                XuatXu = u.XuatXu,
                DiaChi = u.DiaChi,
                TrangThai =u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemNhaCungCap(QuanLyNhaCungCapDTO NCCNew)
        {
            try
            {
                NCC ncc = new NCC()
                {
                    TenNCC = NCCNew.TenNCC,
                    XuatXu = NCCNew.XuatXu,
                    DiaChi = NCCNew.DiaChi,
                    TrangThai = NCCNew.TrangThai
                };

                COFFEE_HOUSEEnts.NCCs.Add(ncc);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatNhaCungCap(QuanLyNhaCungCapDTO NCCCapNhat)
        {
            try
            {
                NCC ncc = COFFEE_HOUSEEnts.NCCs.SingleOrDefault(u => u.MaNCC == NCCCapNhat.MaNCC);

                ncc.TenNCC = NCCCapNhat.TenNCC;
                ncc.XuatXu = NCCCapNhat.XuatXu;
                ncc.DiaChi = NCCCapNhat.DiaChi;
                ncc.TrangThai = NCCCapNhat.TrangThai;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaNhaCungCap(int id)
        {
            try
            {
                NCC ncc = COFFEE_HOUSEEnts.NCCs.SingleOrDefault(u => u.MaNCC == id);
                
                ncc.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
