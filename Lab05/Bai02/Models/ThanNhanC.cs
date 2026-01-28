using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai02.Models
{
    public class ThanNhanC
    {
        public string MaNvien { get; set; }
        public string TenTn { get; set; }
        public string Phai { get; set; }
        public DateTime? NgSinh { get; set; }
        public string QuanHe { get; set; }

        public virtual NhanVienC NhanVien { get; set; }
    }
}