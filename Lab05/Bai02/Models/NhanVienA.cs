using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai02.Models
{
    public class NhanVienA
    {
        public int Id { get; set; } // EF tự hiểu là PK
        public string TenNv { get; set; }
        public string HoNv { get; set; }
        public string TenLot { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Phai { get; set; }
        public double? Luong { get; set; }

        // Navigation Property (Quan hệ 1-N)
        public virtual ICollection<ThanNhanA> ThanNhans { get; set; }
    }
}