using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class resetProf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBaned",
                table: "Profiles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBaned",
                table: "Profiles");
        }
    }
}
