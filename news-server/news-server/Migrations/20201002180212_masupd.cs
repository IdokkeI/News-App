using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class masupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserOwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_sectionsNameId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Profiles_ProfileOwnerId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_profileStatistics_ProfileStatisticId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments");

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
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_AspNetUsers_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropTable(
                name: "HashTags");

            migrationBuilder.DropTable(
                name: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileStatisticId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ProfileOwnerId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_News_UserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserOwnerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileStatisticId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileOwnerId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SectionNameId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "UserOwnerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "sectionsNameId",
                table: "News",
                newName: "SectionsNameId");

            migrationBuilder.RenameIndex(
                name: "IX_News_sectionsNameId",
                table: "News",
                newName: "IX_News_SectionsNameId");

            migrationBuilder.AlterColumn<int>(
                name: "ViewsId",
                table: "StatisticNews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "StatisticNews",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LikesId",
                table: "StatisticNews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DislikeId",
                table: "StatisticNews",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LikesId",
                table: "StatisticComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DislikeId",
                table: "StatisticComments",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "StatisticComments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActiveOn",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterOn",
                table: "Profiles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "News",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerId",
                table: "Notifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_News_OwnerId",
                table: "News",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Profiles_OwnerId",
                table: "Comments",
                column: "OwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Profiles_OwnerId",
                table: "News",
                column: "OwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News",
                column: "SectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Profiles_OwnerId",
                table: "Notifications",
                column: "OwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Profiles_DislikeId",
                table: "StatisticComments",
                column: "DislikeId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Profiles_LikesId",
                table: "StatisticComments",
                column: "LikesId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_Profiles_DislikeId",
                table: "StatisticNews",
                column: "DislikeId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Profiles_OwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Profiles_OwnerId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_SectionsNames_SectionsNameId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Profiles_OwnerId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Profiles_DislikeId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticComments_Profiles_LikesId",
                table: "StatisticComments");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_DislikeId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_LikesId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticNews_Profiles_ViewsId",
                table: "StatisticNews");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_OwnerId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_News_OwnerId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Comments_OwnerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LastActiveOn",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "RegisterOn",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "SectionsNameId",
                table: "News",
                newName: "sectionsNameId");

            migrationBuilder.RenameIndex(
                name: "IX_News_SectionsNameId",
                table: "News",
                newName: "IX_News_sectionsNameId");

            migrationBuilder.AlterColumn<string>(
                name: "ViewsId",
                table: "StatisticNews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "StatisticNews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LikesId",
                table: "StatisticNews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DislikeId",
                table: "StatisticNews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LikesId",
                table: "StatisticComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DislikeId",
                table: "StatisticComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "StatisticComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileStatisticId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileOwnerId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionNameId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "News",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewsId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserOwnerId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HashTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sectionsNameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HashTags_SectionsNames_sectionsNameId",
                        column: x => x.sectionsNameId,
                        principalTable: "SectionsNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profileStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastActiveOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegisterOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatisticCommentId = table.Column<int>(type: "int", nullable: false),
                    StatisticNewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profileStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profileStatistics_StatisticComments_StatisticCommentId",
                        column: x => x.StatisticCommentId,
                        principalTable: "StatisticComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profileStatistics_StatisticNews_StatisticNewsId",
                        column: x => x.StatisticNewsId,
                        principalTable: "StatisticNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileStatisticId",
                table: "Profiles",
                column: "ProfileStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ProfileOwnerId",
                table: "Notifications",
                column: "ProfileOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserOwnerId",
                table: "Comments",
                column: "UserOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HashTags_sectionsNameId",
                table: "HashTags",
                column: "sectionsNameId");

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_StatisticCommentId",
                table: "profileStatistics",
                column: "StatisticCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_StatisticNewsId",
                table: "profileStatistics",
                column: "StatisticNewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserOwnerId",
                table: "Comments",
                column: "UserOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_SectionsNames_sectionsNameId",
                table: "News",
                column: "sectionsNameId",
                principalTable: "SectionsNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Profiles_ProfileOwnerId",
                table: "Notifications",
                column: "ProfileOwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_profileStatistics_ProfileStatisticId",
                table: "Profiles",
                column: "ProfileStatisticId",
                principalTable: "profileStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticComments_Comments_CommentId",
                table: "StatisticComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_StatisticNews_News_NewsId",
                table: "StatisticNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticNews_AspNetUsers_ViewsId",
                table: "StatisticNews",
                column: "ViewsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
