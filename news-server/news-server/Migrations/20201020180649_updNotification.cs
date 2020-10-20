using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class updNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isViewed",
                table: "Notifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isViewed",
                table: "Notifications");
        }
    }
}
