using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class UpdLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "StatisticComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikesId",
                table: "StatisticNews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikesId",
                table: "StatisticComments",
                type: "int",
                nullable: true);
        }
    }
}
