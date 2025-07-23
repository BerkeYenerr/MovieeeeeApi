using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastMovies_Casts_CastId",
                table: "CastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CastMovies_Movies_MovieId",
                table: "CastMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CastMovies",
                table: "CastMovies");

            migrationBuilder.RenameTable(
                name: "CastMovies",
                newName: "CastMovie");

            migrationBuilder.RenameIndex(
                name: "IX_CastMovies_CastId",
                table: "CastMovie",
                newName: "IX_CastMovie_CastId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastMovie",
                table: "CastMovie",
                columns: new[] { "MovieId", "CastId" });

            migrationBuilder.CreateTable(
                name: "CategoryMovie",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovie", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_CategoryId",
                table: "CategoryMovie",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CastMovie_Casts_CastId",
                table: "CastMovie",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "CastId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastMovie_Movies_MovieId",
                table: "CastMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastMovie_Casts_CastId",
                table: "CastMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CastMovie_Movies_MovieId",
                table: "CastMovie");

            migrationBuilder.DropTable(
                name: "CategoryMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CastMovie",
                table: "CastMovie");

            migrationBuilder.RenameTable(
                name: "CastMovie",
                newName: "CastMovies");

            migrationBuilder.RenameIndex(
                name: "IX_CastMovie_CastId",
                table: "CastMovies",
                newName: "IX_CastMovies_CastId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastMovies",
                table: "CastMovies",
                columns: new[] { "MovieId", "CastId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CastMovies_Casts_CastId",
                table: "CastMovies",
                column: "CastId",
                principalTable: "Casts",
                principalColumn: "CastId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastMovies_Movies_MovieId",
                table: "CastMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
