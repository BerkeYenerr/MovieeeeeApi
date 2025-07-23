using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCastMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastMovie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastMovie", x => new { x.MovieId, x.CastId });
                    table.ForeignKey(
                        name: "FK_CastMovie_Casts_CastId",
                        column: x => x.CastId,
                        principalTable: "Casts",
                        principalColumn: "CastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CastMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastMovie_CastId",
                table: "CastMovie",
                column: "CastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CastMovie");
        }
    }
}
