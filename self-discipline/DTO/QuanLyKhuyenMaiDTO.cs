using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanLyKhuyenMaiDTO
    {
        public int MaGiamGia { get; set; }
        public string TenMaGiamGia { get; set;}
        public float PhanTram { get; set; }
        public int SL {  get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MoTa {  get; set; }
        public int TrangThai { get; set; }
    }
}
