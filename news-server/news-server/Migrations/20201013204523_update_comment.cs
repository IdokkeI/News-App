using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class update_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentIdTo",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentIdTo",
                table: "Comments");
        }
    }
}
