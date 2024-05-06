using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoanDTO
    {
        public int MaTK { get; set; }
        public int MaNV { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int LoaiTK { get; set; }
        public int Quyen { get; set; }
        public int TrangThai { get; set; }
    }

}
