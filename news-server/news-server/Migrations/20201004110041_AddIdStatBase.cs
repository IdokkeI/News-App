using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class AddIdStatBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Profiles_LikesId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_LikesId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_LikesId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticComments_LikesId",
                table: "StatisticComments");

            migrationBuilder.AddColumn<int>(
                name: "LikeId",
                table: "StatisticNews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikeId",
                table: "StatisticComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_LikeId",
                table: "StatisticNews",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticComments_LikeId",
                table: "StatisticComments",
                column: "LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Profiles_LikeId",
                table: "StatisticComments",
                column: "LikeId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_Profiles_LikeId",
                table: "StatisticNews",
                column: "LikeId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Profiles_LikeId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_LikeId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_LikeId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticComments_LikeId",
                table: "StatisticComments");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "StatisticComments");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_LikesId",
                table: "StatisticNews",
                column: "LikesId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticComments_LikesId",
                table: "StatisticComments",
                column: "LikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Profiles_LikesId",
                table: "StatisticComments",
                column: "LikesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_Profiles_LikesId",
                table: "StatisticNews",
                column: "LikesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
