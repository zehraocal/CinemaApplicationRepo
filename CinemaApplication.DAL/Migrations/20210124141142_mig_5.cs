using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApplication.DAL.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTickets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    MovieHouseId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    SeatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTickets");
        }
    }
}
