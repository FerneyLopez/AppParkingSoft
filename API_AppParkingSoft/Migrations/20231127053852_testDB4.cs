using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    public partial class testDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryVehicle",
                table: "Vehicles",
                newName: "CategoryName");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryVehicleId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Rates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdRate",
                table: "CategoryVehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryVehicleId",
                table: "Vehicles",
                column: "CategoryVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_CategoryVehicles_CategoryVehicleId",
                table: "Vehicles",
                column: "CategoryVehicleId",
                principalTable: "CategoryVehicles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_CategoryVehicles_CategoryVehicleId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CategoryVehicleId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CategoryVehicleId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "IdRate",
                table: "CategoryVehicles");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Vehicles",
                newName: "CategoryVehicle");
        }
    }
}
