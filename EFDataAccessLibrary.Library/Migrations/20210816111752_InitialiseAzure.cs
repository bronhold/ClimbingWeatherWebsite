using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class InitialiseAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sort_order = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    wmo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    history_product = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    local_date_time = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    local_date_time_full = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    aifstime_utc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    lon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    apparent_t = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cloud = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cloud_base_m = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cloud_oktas = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cloud_type_id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cloud_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    delta_t = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    gust_kmh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    gust_kt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    air_temp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dewpt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    press = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    press_qnh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    press_msl = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    press_tend = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    rain_trace = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    rel_hum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    sea_state = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    swell_dir_worded = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    swell_height = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    swell_period = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    vis_km = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    weather = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    wind_dir = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    wind_spd_kmh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    wind_spd_kt = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
