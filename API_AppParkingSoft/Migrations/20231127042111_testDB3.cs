using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    public partial class testDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_CategoryVehicles_CategoryVehicleId",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_CategoryVehicleId",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "CategoryVehicleId",
                table: "Rates");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_idCategoryVehicle",
                table: "Rates",
                column: "idCategoryVehicle",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_CategoryVehicles_idCategoryVehicle",
                table: "Rates",
                column: "idCategoryVehicle",
                principalTable: "CategoryVehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_CategoryVehicles_idCategoryVehicle",
                table: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_Rates_idCategoryVehicle",
                table: "Rates");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryVehicleId",
                table: "Rates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rates_CategoryVehicleId",
                table: "Rates",
                column: "CategoryVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_CategoryVehicles_CategoryVehicleId",
                table: "Rates",
                column: "CategoryVehicleId",
                principalTable: "CategoryVehicles",
                principalColumn: "Id");
        }
    }
}
