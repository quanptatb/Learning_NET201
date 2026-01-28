using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bai02.Migrations.Bai02b
{
    /// <inheritdoc />
    public partial class InitDb_B : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    MANV = table.Column<string>(type: "char(9)", nullable: false),
                    HONV = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    TENLOT = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    TENNV = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PHAI = table.Column<string>(type: "nchar(3)", nullable: true),
                    NGAYSINH = table.Column<DateTime>(type: "datetime", nullable: true),
                    DCHI = table.Column<string>(type: "nchar(30)", nullable: true),
                    LUONG = table.Column<double>(type: "float", nullable: true),
                    MA_NQL = table.Column<string>(type: "char(9)", nullable: true),
                    PHG = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.MANV);
                });

            migrationBuilder.CreateTable(
                name: "THANNHAN",
                columns: table => new
                {
                    MA_NVIEN = table.Column<string>(type: "char(9)", nullable: false),
                    TENTN = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PHAI = table.Column<string>(type: "nchar(3)", nullable: true),
                    NGSINH = table.Column<DateTime>(type: "datetime", nullable: true),
                    QUANHE = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THANNHAN", x => new { x.MA_NVIEN, x.TENTN });
                    table.ForeignKey(
                        name: "FK_THANNHAN_NHANVIEN_MA_NVIEN",
                        column: x => x.MA_NVIEN,
                        principalTable: "NHANVIEN",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "THANNHAN");

            migrationBuilder.DropTable(
                name: "NHANVIEN");
        }
    }
}
