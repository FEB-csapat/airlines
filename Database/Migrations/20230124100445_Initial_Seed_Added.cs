using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Initial_Seed_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "WizzAir" });

            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "RyanAir" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[] { 1, "Luxembourg", 100000 });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirlineId", "DestinationId", "Distance", "FlightDuration", "FromId", "KmPrice" },
                values: new object[] { 1, 1, 1, 100, 10, 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
