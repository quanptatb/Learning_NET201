using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai02.Models
{
    public class ThanNhanA
    {
        public int Id { get; set; } // PK
        public string TenTn { get; set; }
        public string QuanHe { get; set; }

        // Foreign Key (Convention: ClassNameId)
        public int NhanVienAId { get; set; }
        public virtual NhanVienA NhanVienA { get; set; }
    }
}