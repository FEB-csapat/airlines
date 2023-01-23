using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Added_Airline_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airline22",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airline_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airline_AirlineId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Flights");

            migrationBuilder.AddColumn<string>(
                name: "Airline22",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
