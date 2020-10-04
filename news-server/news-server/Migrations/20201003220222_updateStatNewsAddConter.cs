using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updateStatNewsAddConter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountViews",
                table: "StatisticNews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DislikeCount",
                table: "StatisticNews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "StatisticNews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountViews",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "DislikeCount",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "StatisticNews");
        }
    }
}
