using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updStatisticNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId2",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticNewsId2",
                table: "AspNetUsers",
                column: "StatisticNewsId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId2",
                table: "AspNetUsers",
                column: "StatisticNewsId2",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId2",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatisticNewsId2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId2",
                table: "AspNetUsers");
        }
    }
}
