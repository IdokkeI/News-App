using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class subs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionsProfileId",
                table: "Profiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Profiles_ProfileId1",
                        column: x => x.ProfileId1,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SubscriptionsProfileId",
                table: "Profiles",
                column: "SubscriptionsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ProfileId1",
                table: "Subscriptions",
                column: "ProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Subscriptions_SubscriptionsProfileId",
                table: "Profiles",
                column: "SubscriptionsProfileId",
                principalTable: "Subscriptions",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Subscriptions_SubscriptionsProfileId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SubscriptionsProfileId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "SubscriptionsProfileId",
                table: "Profiles");
        }
    }
}
