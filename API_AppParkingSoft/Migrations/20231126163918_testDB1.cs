using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    public partial class testDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CategoryVehicle",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RateName",
                table: "Rates",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RateName",
                table: "Rates",
                column: "RateName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rates_RateName",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CategoryVehicle",
                table: "Vehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryVehicleId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RateName",
                table: "Rates",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
