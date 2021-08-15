using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class AddDbSetforMoreLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherDataSet",
                table: "WeatherDataSet");

            migrationBuilder.RenameTable(
                name: "WeatherDataSet",
                newName: "WeatherData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherData",
                table: "WeatherData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherData",
                table: "WeatherData");

            migrationBuilder.RenameTable(
                name: "WeatherData",
                newName: "WeatherDataSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherDataSet",
                table: "WeatherDataSet",
                column: "Id");
        }
    }
}
