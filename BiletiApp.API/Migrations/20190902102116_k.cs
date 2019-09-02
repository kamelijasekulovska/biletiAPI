using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiletiApp.API.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Bileti",
                table: "Contact",
                newName: "Telephone");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Bileti",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "Bileti",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Forname",
                schema: "Bileti",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                schema: "Bileti",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                schema: "Bileti",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId",
                schema: "Bileti",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Max_tickets_per_account",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId1",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId1",
                schema: "Bileti",
                table: "BiletiEvent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    BiletiEventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_BiletiEvent_BiletiEventId",
                        column: x => x.BiletiEventId,
                        principalSchema: "Bileti",
                        principalTable: "BiletiEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    BiletiEventId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_BiletiEvent_BiletiEventId",
                        column: x => x.BiletiEventId,
                        principalSchema: "Bileti",
                        principalTable: "BiletiEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Seated = table.Column<bool>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Rows = table.Column<int>(nullable: false),
                    VenueId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sector_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    SectorId1 = table.Column<Guid>(nullable: true),
                    SectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Sector_SectorId1",
                        column: x => x.SectorId1,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_OrganizationId",
                schema: "Bileti",
                table: "Contact",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_VenueId",
                schema: "Bileti",
                table: "Contact",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_BiletiEvent_OrganizationId1",
                schema: "Bileti",
                table: "BiletiEvent",
                column: "OrganizationId1");

            migrationBuilder.CreateIndex(
                name: "IX_BiletiEvent_VenueId1",
                schema: "Bileti",
                table: "BiletiEvent",
                column: "VenueId1");

            migrationBuilder.CreateIndex(
                name: "IX_Image_BiletiEventId",
                table: "Image",
                column: "BiletiEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_OrganizationId",
                table: "Image",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SectorId1",
                table: "Seat",
                column: "SectorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sector_VenueId",
                table: "Sector",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_BiletiEventId",
                table: "Tag",
                column: "BiletiEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletiEvent_Organization_OrganizationId1",
                schema: "Bileti",
                table: "BiletiEvent",
                column: "OrganizationId1",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletiEvent_Venue_VenueId1",
                schema: "Bileti",
                table: "BiletiEvent",
                column: "VenueId1",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Organization_OrganizationId",
                schema: "Bileti",
                table: "Contact",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Venue_VenueId",
                schema: "Bileti",
                table: "Contact",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletiEvent_Organization_OrganizationId1",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletiEvent_Venue_VenueId1",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Organization_OrganizationId",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Venue_VenueId",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropIndex(
                name: "IX_Contact_OrganizationId",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_VenueId",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_BiletiEvent_OrganizationId1",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropIndex(
                name: "IX_BiletiEvent_VenueId1",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Forname",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Surname",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "VenueId",
                schema: "Bileti",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Cover",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "Max_tickets_per_account",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "OrganizationId1",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "VenueId",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.DropColumn(
                name: "VenueId1",
                schema: "Bileti",
                table: "BiletiEvent");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                schema: "Bileti",
                table: "Contact",
                newName: "Name");
        }
    }
}
