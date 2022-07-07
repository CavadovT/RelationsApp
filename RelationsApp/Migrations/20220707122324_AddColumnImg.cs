using Microsoft.EntityFrameworkCore.Migrations;

namespace RelationsApp.Migrations
{
    public partial class AddColumnImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "bookImgs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "bookImgs");
        }
    }
}
