using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace news_server.Migrations
{
    public partial class delModifyedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifyedOn",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyedOn",
                table: "News",
                type: "datetime2",
                nullable: true);
        }
    }
}
