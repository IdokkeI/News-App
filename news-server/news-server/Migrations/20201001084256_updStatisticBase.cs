using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updStatisticBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "Dislike",
                table: "StatisticComments");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "StatisticComments");

            migrationBuilder.AddColumn<int>(
                name: "StatisticCommentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticCommentId1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticCommentId",
                table: "AspNetUsers",
                column: "StatisticCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticCommentId1",
                table: "AspNetUsers",
                column: "StatisticCommentId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticNewsId",
                table: "AspNetUsers",
                column: "StatisticNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticNewsId1",
                table: "AspNetUsers",
                column: "StatisticNewsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StatisticComments_StatisticCommentId",
                table: "AspNetUsers",
                column: "StatisticCommentId",
                principalTable: "StatisticComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StatisticComments_StatisticCommentId1",
                table: "AspNetUsers",
                column: "StatisticCommentId1",
                principalTable: "StatisticComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId",
                table: "AspNetUsers",
                column: "StatisticNewsId",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId1",
                table: "AspNetUsers",
                column: "StatisticNewsId1",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StatisticComments_StatisticCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StatisticComments_StatisticCommentId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatisticCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatisticCommentId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatisticNewsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatisticNewsId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatisticCommentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatisticCommentId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StatisticNewsId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "StatisticNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "StatisticNews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dislike",
                table: "StatisticComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "StatisticComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
