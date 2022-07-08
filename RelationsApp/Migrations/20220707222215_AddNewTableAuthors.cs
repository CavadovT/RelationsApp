using Microsoft.EntityFrameworkCore.Migrations;

namespace RelationsApp.Migrations
{
    public partial class AddNewTableAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookImgs_Books_BookId",
                table: "bookImgs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookImgs",
                table: "bookImgs");

            migrationBuilder.RenameTable(
                name: "bookImgs",
                newName: "BookImgs");

            migrationBuilder.RenameIndex(
                name: "IX_bookImgs_BookId",
                table: "BookImgs",
                newName: "IX_BookImgs_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookImgs",
                table: "BookImgs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookImgs_Books_BookId",
                table: "BookImgs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookImgs_Books_BookId",
                table: "BookImgs");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookImgs",
                table: "BookImgs");

            migrationBuilder.RenameTable(
                name: "BookImgs",
                newName: "bookImgs");

            migrationBuilder.RenameIndex(
                name: "IX_BookImgs_BookId",
                table: "bookImgs",
                newName: "IX_bookImgs_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookImgs",
                table: "bookImgs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookImgs_Books_BookId",
                table: "bookImgs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
