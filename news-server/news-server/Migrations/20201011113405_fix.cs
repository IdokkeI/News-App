using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Subscriptions_SubscriptionsId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SubscriptionsId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "SubscriptionsId",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileIdSub",
                table: "Subscriptions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileIdSub",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionsId",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SubscriptionsId",
                table: "Profiles",
                column: "SubscriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Subscriptions_SubscriptionsId",
                table: "Profiles",
                column: "SubscriptionsId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
