using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RelationShipUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
