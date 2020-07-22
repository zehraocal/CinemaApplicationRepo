using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaApplication.DAL.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Castings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCastings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CastingId = table.Column<long>(nullable: false),
                    MovieId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCastings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCastings_Castings_CastingId",
                        column: x => x.CastingId,
                        principalTable: "Castings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCastings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCastings_CastingId",
                table: "MovieCastings",
                column: "CastingId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCastings_MovieId",
                table: "MovieCastings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCastings");

            migrationBuilder.DropTable(
                name: "Castings");
        }
    }
}
