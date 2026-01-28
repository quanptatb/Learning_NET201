using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai02.Models
{
    [Table("NHANVIEN")] // Tên bảng
    public class NhanVienB
    {
        [Key]
        [Column("MANV", TypeName = "char(9)")] // Khóa chính, kiểu char(9)
        public string MaNv { get; set; }

        [Column("HONV", TypeName = "nvarchar(15)")]
        public string? HoNv { get; set; }

        [Column("TENLOT", TypeName = "nvarchar(15)")]
        public string? TenLot { get; set; }

        [Required] // Not Null (Dựa trên hình có thể TenNV là bắt buộc)
        [Column("TENNV", TypeName = "nvarchar(15)")]
        public string TenNv { get; set; }

        [Column("PHAI", TypeName = "nchar(3)")]
        public string? Phai { get; set; }

        [Column("NGAYSINH", TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }

        [Column("DCHI", TypeName = "nchar(30)")]
        public string? DiaChi { get; set; }

        [Column("LUONG")]
        public double? Luong { get; set; }

        [Column("MA_NQL", TypeName = "char(9)")]
        public string? MaNql { get; set; }

        [Column("PHG")]
        public int? Phg { get; set; }

        // Quan hệ 1-N
        public virtual ICollection<ThanNhanB> ThanNhans { get; set; }
    }
}