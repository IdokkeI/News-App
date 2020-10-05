using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class addViewById : Migration
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
                name: "ViewsId",
                table: "StatisticNews");

            migrationBuilder.AddColumn<int>(
                name: "ViewById",
                table: "StatisticNews",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_ViewById",
                table: "StatisticNews",
                column: "ViewById");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_Profiles_ViewById",
                table: "StatisticNews",
                column: "ViewById",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_ViewById",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_ViewById",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "ViewById",
                table: "StatisticNews");

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
