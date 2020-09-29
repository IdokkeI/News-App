using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class deleteSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Sections_SectionId",
                table: "News");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_News_SectionId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_SectionsNames_SectionNameId",
                        column: x => x.SectionNameId,
                        principalTable: "SectionsNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_SectionId",
                table: "News",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionNameId",
                table: "Sections",
                column: "SectionNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Sections_SectionId",
                table: "News",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
