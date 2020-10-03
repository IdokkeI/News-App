using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId2",
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

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StatisticNewsId2",
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

            migrationBuilder.DropColumn(
                name: "StatisticNewsId2",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "DislikeId",
                table: "StatisticNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesId",
                table: "StatisticNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ViewsId",
                table: "StatisticNews",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DislikeId",
                table: "StatisticComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesId",
                table: "StatisticComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_DislikeId",
                table: "StatisticNews",
                column: "DislikeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_LikesId",
                table: "StatisticNews",
                column: "LikesId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticNews_ViewsId",
                table: "StatisticNews",
                column: "ViewsId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticComments_DislikeId",
                table: "StatisticComments",
                column: "DislikeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticComments_LikesId",
                table: "StatisticComments",
                column: "LikesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_AspNetUsers_DislikeId",
                table: "StatisticComments",
                column: "DislikeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_AspNetUsers_LikesId",
                table: "StatisticComments",
                column: "LikesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_AspNetUsers_DislikeId",
                table: "StatisticNews",
                column: "DislikeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_AspNetUsers_LikesId",
                table: "StatisticNews",
                column: "LikesId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_AspNetUsers_ViewsId",
                table: "StatisticNews",
                column: "ViewsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_AspNetUsers_DislikeId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_AspNetUsers_LikesId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_AspNetUsers_DislikeId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_AspNetUsers_LikesId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_AspNetUsers_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_DislikeId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_LikesId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticNews_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_StatisticComments_DislikeId",
                table: "StatisticComments");

            migrationBuilder.DropIndex(
                name: "IX_StatisticComments_LikesId",
                table: "StatisticComments");

            migrationBuilder.DropColumn(
                name: "DislikeId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropColumn(
                name: "DislikeId",
                table: "StatisticComments");

            migrationBuilder.DropColumn(
                name: "LikesId",
                table: "StatisticComments");

            migrationBuilder.AddColumn<int>(
                name: "StatisticCommentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticCommentId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticNewsId2",
                table: "AspNetUsers",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StatisticNewsId2",
                table: "AspNetUsers",
                column: "StatisticNewsId2");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StatisticNews_StatisticNewsId2",
                table: "AspNetUsers",
                column: "StatisticNewsId2",
                principalTable: "StatisticNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
