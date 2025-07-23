using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedCastMovienew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastMovie_Casts_CastId",
                table: "CastMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CastMovie_Movies_MovieId",
                table: "CastMovie");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
