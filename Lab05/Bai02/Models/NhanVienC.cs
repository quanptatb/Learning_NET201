using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai02.Models
{
    public class NhanVienC
    {
        public string MaNv { get; set; }
        public string HoNv { get; set; }
        public string TenLot { get; set; }
        public string TenNv { get; set; }
        public string Phai { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public double? Luong { get; set; }
        public string MaNql { get; set; }
        public int? Phg { get; set; }

        public virtual ICollection<ThanNhanC> ThanNhans { get; set; }
    }
}