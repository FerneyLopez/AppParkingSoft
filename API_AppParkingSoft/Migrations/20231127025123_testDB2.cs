using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_AppParkingSoft.Migrations
{
    public partial class testDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "dailyRate",
                table: "Rates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dailyRate",
                table: "Rates");
        }
    }
}
