using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    public partial class updateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Users_userId",
                table: "Reserves");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Reserves",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "licensePlate",
                table: "Reserves",
                newName: "LicensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_userId",
                table: "Reserves",
                newName: "IX_Reserves_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Reserves",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "NameUser",
                table: "Reserves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Users_UserId",
                table: "Reserves",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Users_UserId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "NameUser",
                table: "Reserves");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reserves",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "LicensePlate",
                table: "Reserves",
                newName: "licensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_Reserves_UserId",
                table: "Reserves",
                newName: "IX_Reserves_userId");

            migrationBuilder.AlterColumn<Guid>(
                name: "userId",
                table: "Reserves",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Users_userId",
                table: "Reserves",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
