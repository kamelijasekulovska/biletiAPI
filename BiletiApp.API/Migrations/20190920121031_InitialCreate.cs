using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiletiApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Sectors_SectorId1",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Venues_VenueId",
                table: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SectorId1",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "SectorId1",
                table: "Seats");

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Venues_VenueId",
                table: "Sectors",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Venues_VenueId",
                table: "Sectors");

            migrationBuilder.AddColumn<Guid>(
                name: "SectorId1",
                table: "Seats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SectorId1",
                table: "Seats",
                column: "SectorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Sectors_SectorId1",
                table: "Seats",
                column: "SectorId1",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Venues_VenueId",
                table: "Sectors",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
