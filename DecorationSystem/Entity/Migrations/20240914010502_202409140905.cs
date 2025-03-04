using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class _202409140905 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    OldFileName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    NewFileName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    HtmlPath = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleteTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileInfos");
        }
    }
}
