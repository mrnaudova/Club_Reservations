using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Club_Reservations.Data.Migrations
{
    public partial class ScaffStatisticsModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatisticsModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfTables = table.Column<int>(type: "int", nullable: false),
                    NumberOfCustomers = table.Column<int>(type: "int", nullable: false),
                    NumberOfPastReservations = table.Column<int>(type: "int", nullable: false),
                    NumberOfUpcomingReservations = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsModule", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatisticsModule");
        }
    }
}
