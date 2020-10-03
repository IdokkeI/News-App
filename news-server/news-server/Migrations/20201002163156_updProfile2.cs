using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updProfile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileUserId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_profileStatistics_ProfileUserId",
                table: "profileStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileUserId",
                table: "profileStatistics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Profiles",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_ProfileId",
                table: "profileStatistics",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropIndex(
                name: "IX_profileStatistics_ProfileId",
                table: "profileStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUserId",
                table: "profileStatistics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Profiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_profileStatistics_ProfileUserId",
                table: "profileStatistics",
                column: "ProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileUserId",
                table: "AspNetUsers",
                column: "ProfileUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profiles_ProfileUserId",
                table: "AspNetUsers",
                column: "ProfileUserId",
                principalTable: "Profiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_profileStatistics_Profiles_ProfileUserId",
                table: "profileStatistics",
                column: "ProfileUserId",
                principalTable: "Profiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
