using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bai02.Migrations
{
    /// <inheritdoc />
    public partial class InitDb_A : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoNv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenLot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Luong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanNhans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhanVienAId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanNhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanNhans_NhanViens_NhanVienAId",
                        column: x => x.NhanVienAId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThanNhans_NhanVienAId",
                table: "ThanNhans",
                column: "NhanVienAId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThanNhans");

            migrationBuilder.DropTable(
                name: "NhanViens");
        }
    }
}
