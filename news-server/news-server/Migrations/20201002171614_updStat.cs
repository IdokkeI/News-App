using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updStat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_StatisticComments_StatisticCommentId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_StatisticNews_StatisticNewsId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_profileStatistics_ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_StatisticCommentId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_StatisticNewsId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "RatingComments",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "RatingNews",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "StatisticCommentId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "StatisticCommentId",
                table: "profileStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId",
                table: "profileStatistics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileStatisticId",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_StatisticCommentId",
                table: "profileStatistics",
                column: "StatisticCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_StatisticNewsId",
                table: "profileStatistics",
                column: "StatisticNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileStatisticId",
                table: "Profiles",
                column: "ProfileStatisticId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_profileStatistics_ProfileStatisticId",
                table: "Profiles",
                column: "ProfileStatisticId",
                principalTable: "profileStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_StatisticComments_StatisticCommentId",
                table: "profileStatistics",
                column: "StatisticCommentId",
                principalTable: "StatisticComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_StatisticNews_StatisticNewsId",
                table: "profileStatistics",
                column: "StatisticNewsId",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_profileStatistics_ProfileStatisticId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_StatisticComments_StatisticCommentId",
                table: "profileStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_StatisticNews_StatisticNewsId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_profileStatistics_StatisticCommentId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_profileStatistics_StatisticNewsId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileStatisticId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "StatisticCommentId",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "ProfileStatisticId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "profileStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "RatingComments",
                table: "profileStatistics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RatingNews",
                table: "profileStatistics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StatisticCommentId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_ProfileId",
                table: "profileStatistics",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StatisticCommentId",
                table: "Profiles",
                column: "StatisticCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StatisticNewsId",
                table: "Profiles",
                column: "StatisticNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_StatisticComments_StatisticCommentId",
                table: "Profiles",
                column: "StatisticCommentId",
                principalTable: "StatisticComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_StatisticNews_StatisticNewsId",
                table: "Profiles",
                column: "StatisticNewsId",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
