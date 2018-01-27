using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ferret.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HousingUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Area = table.Column<double>(nullable: false),
                    BalconiesNumber = table.Column<int>(nullable: false),
                    BathroomNumber = table.Column<int>(nullable: false),
                    BedroomNumber = table.Column<int>(nullable: false),
                    BoxNumber = table.Column<int>(nullable: false),
                    ConstructionYear = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HousingType = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    ParkingNumber = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    RefreshDate = table.Column<DateTime>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    SwimmingPool = table.Column<bool>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    WCNumber = table.Column<int>(nullable: false),
                    sourceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingUnits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HousingUnits");
        }
    }
}
