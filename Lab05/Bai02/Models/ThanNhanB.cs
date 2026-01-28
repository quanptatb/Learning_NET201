using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bai02.Models
{
    [Table("THANNHAN")]
    // Thiết lập Composite Key (Khóa tổ hợp) gồm MA_NVIEN và TENTN
    [PrimaryKey(nameof(MaNvien), nameof(TenTn))]
    public class ThanNhanB
    {
        [Column("MA_NVIEN", TypeName = "char(9)")]
        [ForeignKey("NhanVien")] // Khóa ngoại trỏ đến NhanVien
        public string MaNvien { get; set; }

        [Column("TENTN", TypeName = "nvarchar(15)")]
        public string TenTn { get; set; }

        [Column("PHAI", TypeName = "nchar(3)")]
        public string? Phai { get; set; } // Hình vẽ: không check Allow Null -> Not Null? Nhưng code mẫu để ? cho an toàn, bạn có thể bỏ ?

        [Column("NGSINH", TypeName = "datetime")]
        public DateTime? NgSinh { get; set; }

        [Column("QUANHE", TypeName = "nvarchar(15)")]
        public string? QuanHe { get; set; }

        // Navigation Property
        public virtual NhanVienB NhanVien { get; set; }
    }
}