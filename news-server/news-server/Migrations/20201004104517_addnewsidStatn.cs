using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class addnewsidStatn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_StatisticNews_StatisticNewsId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_StatisticNewsId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "StatisticNews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewsId",
                table: "StatisticNews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_ViewsId",
                table: "StatisticNews",
                column: "ViewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_Profiles_ViewsId",
                table: "StatisticNews",
                column: "ViewsId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "ViewsId",
                table: "StatisticNews");

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "StatisticNews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId",
                table: "Profiles",
                type: "int",
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
