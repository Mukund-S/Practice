using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_MovieId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieCasts_MovieId",
                table: "MovieCasts");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_MovieId",
                table: "Favorites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                columns: new[] { "MovieId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCasts",
                table: "MovieCasts",
                columns: new[] { "MovieId", "CastId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                columns: new[] { "MovieId", "UserId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenres",
                table: "MovieGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCasts",
                table: "MovieCasts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MovieId",
                table: "Purchases",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCasts_MovieId",
                table: "MovieCasts",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_MovieId",
                table: "Favorites",
                column: "MovieId");
        }
    }
}
