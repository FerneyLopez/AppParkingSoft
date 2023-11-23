using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    public partial class updateDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVehicle_Vehicles_VehicleId",
                table: "CategoryVehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryVehicle",
                table: "CategoryVehicle");

            migrationBuilder.DropColumn(
                name: "vehicleOwner",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "CategoryVehicle",
                newName: "CategoryVehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "CategoryVehicles",
                newName: "RateId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryVehicle_VehicleId",
                table: "CategoryVehicles",
                newName: "IX_CategoryVehicles_RateId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryVehicleId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReserveId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReserveId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryVehicles",
                table: "CategoryVehicles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hourlyRate = table.Column<double>(type: "float", nullable: false),
                    weeklyRate = table.Column<double>(type: "float", nullable: false),
                    monthlyRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalHour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    stateReserve = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryVehicleId",
                table: "Vehicles",
                column: "CategoryVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClientId",
                table: "Vehicles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ReserveId",
                table: "Vehicles",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ReserveId",
                table: "Users",
                column: "ReserveId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVehicles_Rates_RateId",
                table: "CategoryVehicles",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Reserves_ReserveId",
                table: "Users",
                column: "ReserveId",
                principalTable: "Reserves",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_CategoryVehicles_CategoryVehicleId",
                table: "Vehicles",
                column: "CategoryVehicleId",
                principalTable: "CategoryVehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Reserves_ReserveId",
                table: "Vehicles",
                column: "ReserveId",
                principalTable: "Reserves",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVehicles_Rates_RateId",
                table: "CategoryVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Reserves_ReserveId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_CategoryVehicles_CategoryVehicleId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Reserves_ReserveId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CategoryVehicleId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ClientId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ReserveId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Users_ReserveId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryVehicles",
                table: "CategoryVehicles");

            migrationBuilder.DropColumn(
                name: "CategoryVehicleId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReserveId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReserveId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "CategoryVehicles",
                newName: "CategoryVehicle");

            migrationBuilder.RenameColumn(
                name: "RateId",
                table: "CategoryVehicle",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryVehicles_RateId",
                table: "CategoryVehicle",
                newName: "IX_CategoryVehicle_VehicleId");

            migrationBuilder.AddColumn<string>(
                name: "vehicleOwner",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryVehicle",
                table: "CategoryVehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVehicle_Vehicles_VehicleId",
                table: "CategoryVehicle",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
