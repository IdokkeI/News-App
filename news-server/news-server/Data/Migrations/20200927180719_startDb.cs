using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Data.Migrations
{
    public partial class startDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_HashTags_SectionsNames_sectionsNameId",
                table: "HashTags");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HashTags_SectionsNames_sectionsNameId",
                table: "HashTags",
                column: "sectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_HashTags_SectionsNames_sectionsNameId",
                table: "HashTags");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HashTags_SectionsNames_sectionsNameId",
                table: "HashTags",
                column: "sectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
