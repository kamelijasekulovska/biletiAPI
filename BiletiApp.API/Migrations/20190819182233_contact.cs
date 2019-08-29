using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiletiApp.API.Migrations
{
    public partial class contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "Bileti",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact",
                schema: "Bileti");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Bileti",
                table: "BiletiEvent",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
