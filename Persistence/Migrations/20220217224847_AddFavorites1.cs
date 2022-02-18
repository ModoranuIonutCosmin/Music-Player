using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddFavorites1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFavoriteAlbums",
                table: "UsersFavoriteAlbums");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UsersFavoriteAlbums_AlbumId_ApplicationUserId",
                table: "UsersFavoriteAlbums",
                columns: new[] { "AlbumId", "ApplicationUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFavoriteAlbums",
                table: "UsersFavoriteAlbums",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_UsersFavoriteAlbums_AlbumId_ApplicationUserId",
                table: "UsersFavoriteAlbums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersFavoriteAlbums",
                table: "UsersFavoriteAlbums");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersFavoriteAlbums",
                table: "UsersFavoriteAlbums",
                columns: new[] { "AlbumId", "ApplicationUserId" });
        }
    }
}
