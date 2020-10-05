using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class addList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "CountViews",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "DislikeCount",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "ViewsId",
                table: "StatisticNews");

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StatisticNewsId",
                table: "Profiles",
                column: "StatisticNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_StatisticNews_StatisticNewsId",
                table: "Profiles",
                column: "StatisticNewsId",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_StatisticNews_StatisticNewsId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_StatisticNewsId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "CountViews",
                table: "StatisticNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DislikeCount",
                table: "StatisticNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "StatisticNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewsId",
                table: "StatisticNews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_ViewsId",
                table: "StatisticNews",
                column: "ViewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_Profiles_ViewsId",
                table: "StatisticNews",
                column: "ViewsId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
