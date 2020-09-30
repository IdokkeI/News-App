using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class newsDelSecName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "SectionsNameId",
                table: "News",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News",
                column: "SectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "SectionsNameId",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News",
                column: "SectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
