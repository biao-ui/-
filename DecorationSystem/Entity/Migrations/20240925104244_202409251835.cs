using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class _202409251835 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    Unit = table.Column<string>(type: "varchar(8)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    PriceMain = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    PriceArtificial = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    CustomPhone = table.Column<string>(type: "varchar(32)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Ares = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesignerId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersMaterial",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Materialld = table.Column<string>(type: "varchar(36)", nullable: false),
                    OrdersId = table.Column<string>(type: "varchar(36)", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersMaterial", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrdersMaterial");
        }
    }
}
