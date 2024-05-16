using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class TaiKhoanDAL
    {
        private COFFEE_HOUSEEntities COFFEE_HOUSEEnts = new COFFEE_HOUSEEntities();

        public List<TaiKhoanDTO> layDSTK()
        {
            return COFFEE_HOUSEEnts.TAIKHOAN.Select(u => new TaiKhoanDTO
            {
                MaTK = u.MaTK,
                MaNV = (int)u.MaNV,
                Username = u.Username,
                Password = u.MatKhau,
                LoaiTK = (int)u.LoaiTK,
                Quyen = (int)u.Quyen,
                TrangThai = u.TrangThai
            }).Where(v => v.TrangThai == 1).ToList();
        }

        public bool ThemTaiKhoan(TaiKhoanDTO taiKhoanNew)
        {
            try
            {
                TAIKHOAN tk = new TAIKHOAN()
                {
                    MaNV = taiKhoanNew.MaNV,
                    Username = taiKhoanNew.Username,
                    MatKhau = taiKhoanNew.Password,
                    LoaiTK = taiKhoanNew.LoaiTK,
                    Quyen = taiKhoanNew.Quyen,
                    TrangThai = taiKhoanNew.TrangThai
                };

                COFFEE_HOUSEEnts.TAIKHOAN.Add(tk);

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatTaiKhoan(TaiKhoanDTO taiKhoanCapNhat)
        {
            try
            {
                TAIKHOAN tk = COFFEE_HOUSEEnts.TAIKHOAN.SingleOrDefault(u => u.MaTK == taiKhoanCapNhat.MaTK);

                tk.MaNV = taiKhoanCapNhat.MaNV;
                tk.Username = taiKhoanCapNhat.Username;
                tk.MatKhau = taiKhoanCapNhat.Password;
                tk.LoaiTK = taiKhoanCapNhat.LoaiTK;
                tk.Quyen = taiKhoanCapNhat.Quyen;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaTaiKhoan(int id)
        {
            try
            {
                TAIKHOAN tk = COFFEE_HOUSEEnts.TAIKHOAN.SingleOrDefault(u => u.MaTK == id);

                tk.TrangThai = 0;

                return COFFEE_HOUSEEnts.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public int TimNhanVienTheoUsername(string username)
        {
            TAIKHOAN TaiKhoan = (TAIKHOAN)COFFEE_HOUSEEnts.TAIKHOANs.SingleOrDefault(u => u.Username == username);

            int id = TaiKhoan.MaNV.Value;
            return id;
        }
    }
}
