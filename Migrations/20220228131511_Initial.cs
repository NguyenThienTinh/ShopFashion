using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopFashion.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fashion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatHang = table.Column<string>(nullable: true),
                    NgayDatHang = table.Column<DateTime>(nullable: false),
                    NgayGiaoHang = table.Column<DateTime>(nullable: false),
                    LoaiHang = table.Column<string>(nullable: true),
                    Gia = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fashion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fashion");
        }
    }
}
