using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class sectionNameadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "SectionsNameId",
                table: "News",
                newName: "sectionsNameId");

            migrationBuilder.RenameIndex(
                name: "IX_News_SectionsNameId",
                table: "News",
                newName: "IX_News_sectionsNameId");

            migrationBuilder.AddColumn<int>(
                name: "SectionNameId",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_sectionsNameId",
                table: "News",
                column: "sectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_sectionsNameId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SectionNameId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "sectionsNameId",
                table: "News",
                newName: "SectionsNameId");

            migrationBuilder.RenameIndex(
                name: "IX_News_sectionsNameId",
                table: "News",
                newName: "IX_News_SectionsNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News",
                column: "SectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
