using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addedFileMappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Songs");

            migrationBuilder.AddColumn<Guid>(
                name: "StorageId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Albums",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StorageInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_StorageId",
                table: "Songs",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_OwnerId",
                table: "Albums",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Users_OwnerId",
                table: "Albums",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_StorageInfo_StorageId",
                table: "Songs",
                column: "StorageId",
                principalTable: "StorageInfo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Users_OwnerId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_StorageInfo_StorageId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "StorageInfo");

            migrationBuilder.DropIndex(
                name: "IX_Songs_StorageId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Albums_OwnerId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "StorageId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Albums");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Songs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ReleaseDate",
                table: "Songs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
