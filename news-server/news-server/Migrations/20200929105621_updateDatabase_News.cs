using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updateDatabase_News : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserOwnerId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_UserOwnerId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RatingDiscuss",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "SectionNameId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "UserOwnerId",
                table: "News");

            migrationBuilder.AddColumn<double>(
                name: "RatingComments",
                table: "profileStatistics",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "News",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SectionsNameId",
                table: "News",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "News",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News",
                column: "SectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_UserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "RatingComments",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "News");

            migrationBuilder.AddColumn<double>(
                name: "RatingDiscuss",
                table: "profileStatistics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SectionsNameId",
                table: "News",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SectionNameId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserOwnerId",
                table: "News",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_UserOwnerId",
                table: "News",
                column: "UserOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News",
                column: "SectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserOwnerId",
                table: "News",
                column: "UserOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
