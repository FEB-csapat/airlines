using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Seed_Completed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Airlines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "British Airways" },
                    { 4, "Air Serbia" },
                    { 5, "SCAT Airlines" },
                    { 6, "Belavia" },
                    { 7, "Wingo" },
                    { 8, "Iberia" },
                    { 9, "Air France" },
                    { 10, "Philippine Airlines" },
                    { 11, "Luxair" },
                    { 12, "Air China" },
                    { 13, "AVIANCA" },
                    { 14, "Aero4M" },
                    { 15, "Aeromexico" }
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Population" },
                values: new object[] { "Budapest", 1800000 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[,]
                {
                    { 2, "London", 8800000 },
                    { 3, "Szarajevó", 3500000 },
                    { 4, "Sao Paulo", 12325232 },
                    { 5, "Minszk", 9400000 },
                    { 6, "Asztana", 16700000 },
                    { 7, "Párizs", 2165423 },
                    { 8, "Belgrád", 1378682 },
                    { 9, "Bogotá", 7743955 },
                    { 10, "Dakar", 1438725 },
                    { 11, "Havanna", 2141652 },
                    { 12, "Libreville", 797003 },
                    { 13, "Luxembourg", 132780 },
                    { 14, "Madrid", 3280782 },
                    { 15, "Manila", 1846513 },
                    { 16, "Mexikóváros", 8851080 },
                    { 17, "Moszkva", 12455682 },
                    { 18, "Peking", 21893095 },
                    { 19, "Pozsony", 475503 },
                    { 20, "Prága", 1275406 }
                });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DestinationId", "Distance", "FlightDuration", "KmPrice" },
                values: new object[] { 2, 1450, 145, 6 });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirlineId", "DestinationId", "Distance", "FlightDuration", "FromId", "KmPrice" },
                values: new object[,]
                {
                    { 2, 3, 2, 1450, 155, 1, 7 },
                    { 3, 4, 8, 318, 54, 1, 5 },
                    { 4, 4, 3, 198, 45, 8, 5 },
                    { 5, 3, 14, 1252, 155, 2, 7 },
                    { 6, 3, 2, 1252, 155, 14, 7 },
                    { 7, 5, 17, 2304, 235, 6, 5 },
                    { 8, 5, 6, 2304, 235, 17, 5 },
                    { 9, 6, 5, 2961, 240, 6, 8 },
                    { 10, 6, 6, 2961, 240, 5, 8 },
                    { 11, 7, 11, 2230, 273, 9, 4 },
                    { 12, 7, 9, 2230, 260, 11, 4 },
                    { 13, 8, 14, 3170, 265, 10, 8 },
                    { 14, 8, 10, 3170, 345, 14, 8 },
                    { 15, 9, 12, 5467, 425, 7, 6 },
                    { 16, 15, 16, 1780, 245, 11, 5 },
                    { 17, 2, 1, 471, 70, 20, 5 },
                    { 18, 2, 20, 471, 75, 1, 5 },
                    { 19, 6, 5, 689, 85, 17, 7 },
                    { 20, 15, 16, 7472, 655, 4, 8 },
                    { 21, 15, 4, 7472, 595, 16, 7 },
                    { 22, 10, 18, 2890, 305, 15, 6 },
                    { 23, 1, 2, 1657, 180, 3, 5 },
                    { 24, 1, 3, 1657, 155, 2, 5 },
                    { 25, 11, 13, 4446, 425, 10, 10 },
                    { 26, 9, 7, 1252, 145, 1, 8 },
                    { 27, 9, 1, 1252, 135, 7, 8 },
                    { 28, 1, 6, 3754, 305, 1, 6 },
                    { 29, 1, 1, 3754, 380, 6, 6 },
                    { 30, 11, 13, 993, 130, 1, 5 },
                    { 31, 11, 1, 993, 130, 13, 5 },
                    { 32, 2, 14, 1982, 210, 1, 6 },
                    { 33, 2, 1, 1982, 210, 14, 6 },
                    { 34, 12, 1, 7371, 625, 18, 9 },
                    { 35, 12, 2, 8196, 660, 18, 10 },
                    { 36, 12, 18, 8196, 660, 2, 10 },
                    { 37, 12, 5, 6502, 555, 18, 9 },
                    { 38, 12, 7, 8233, 670, 18, 11 },
                    { 39, 12, 18, 8233, 670, 7, 11 },
                    { 40, 12, 14, 9255, 705, 18, 12 },
                    { 41, 13, 9, 8518, 675, 2, 11 },
                    { 42, 13, 2, 8518, 625, 9, 11 }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirlineId", "DestinationId", "Distance", "FlightDuration", "FromId", "KmPrice" },
                values: new object[,]
                {
                    { 43, 9, 7, 348, 85, 2, 10 },
                    { 44, 9, 2, 348, 85, 7, 10 },
                    { 45, 3, 19, 1556, 180, 2, 9 },
                    { 46, 3, 2, 1556, 180, 19, 10 },
                    { 47, 12, 19, 7845, 645, 18, 9 },
                    { 48, 12, 18, 7845, 635, 19, 9 },
                    { 49, 14, 9, 9713, 715, 19, 11 },
                    { 50, 14, 19, 9713, 715, 9, 11 },
                    { 51, 1, 12, 4910, 540, 3, 12 },
                    { 52, 1, 3, 4910, 510, 12, 12 },
                    { 53, 15, 16, 3169, 340, 9, 10 },
                    { 54, 15, 9, 3169, 360, 16, 10 },
                    { 55, 2, 10, 4860, 415, 20, 15 },
                    { 56, 2, 20, 4860, 425, 10, 15 },
                    { 57, 10, 4, 4996, 390, 15, 6 },
                    { 58, 10, 15, 4996, 390, 4, 6 },
                    { 59, 2, 20, 742, 200, 8, 10 },
                    { 60, 2, 8, 742, 200, 20, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Airlines",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Population" },
                values: new object[] { "Luxembourg", 100000 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DestinationId", "Distance", "FlightDuration", "KmPrice" },
                values: new object[] { 1, 100, 10, 2 });
        }
    }
}
