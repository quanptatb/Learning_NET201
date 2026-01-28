using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai02.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai02.Data
{
    public class Bai02cContext : DbContext
    {
        public Bai02cContext(DbContextOptions<Bai02cContext> options) : base(options) { }

        public DbSet<NhanVienC> NhanViens { get; set; }
        public DbSet<ThanNhanC> ThanNhans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // === Config NHANVIEN ===
            modelBuilder.Entity<NhanVienC>(entity =>
            {
                entity.ToTable("NHANVIEN");

                entity.HasKey(e => e.MaNv); // PK
                entity.Property(e => e.MaNv).HasColumnName("MANV").HasColumnType("char(9)");

                entity.Property(e => e.HoNv).HasColumnName("HONV").HasMaxLength(15);
                entity.Property(e => e.TenLot).HasColumnName("TENLOT").HasMaxLength(15);
                entity.Property(e => e.TenNv).HasColumnName("TENNV").HasMaxLength(15).IsRequired(); // Not Null
                entity.Property(e => e.Phai).HasColumnName("PHAI").HasColumnType("nchar(3)");
                entity.Property(e => e.NgaySinh).HasColumnName("NGAYSINH").HasColumnType("datetime");
                entity.Property(e => e.DiaChi).HasColumnName("DCHI").HasColumnType("nchar(30)");
                entity.Property(e => e.Luong).HasColumnName("LUONG");
                entity.Property(e => e.MaNql).HasColumnName("MA_NQL").HasColumnType("char(9)");
                entity.Property(e => e.Phg).HasColumnName("PHG");
            });

            // === Config THANNHAN ===
            modelBuilder.Entity<ThanNhanC>(entity =>
            {
                entity.ToTable("THANNHAN");

                entity.HasKey(e => new { e.MaNvien, e.TenTn });

                entity.Property(e => e.MaNvien).HasColumnName("MA_NVIEN").HasColumnType("char(9)");
                entity.Property(e => e.TenTn).HasColumnName("TENTN").HasMaxLength(15);
                entity.Property(e => e.Phai).HasColumnName("PHAI").HasColumnType("nchar(3)");
                entity.Property(e => e.NgSinh).HasColumnName("NGSINH").HasColumnType("datetime");
                entity.Property(e => e.QuanHe).HasColumnName("QUANHE").HasMaxLength(15);

                // Config Relationship (1 - Many)
                entity.HasOne(d => d.NhanVien)
                      .WithMany(p => p.ThanNhans)
                      .HasForeignKey(d => d.MaNvien)
                      .HasConstraintName("FK_THANNHAN_NHANVIEN");
            });
        }
    }
}