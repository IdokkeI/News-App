using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class delBaneProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBanned",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBanned",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
