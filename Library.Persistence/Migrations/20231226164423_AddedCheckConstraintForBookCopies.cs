using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedCheckConstraintForBookCopies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Book_CopiesAvailable",
                schema: "Book",
                table: "Books",
                sql: "CopiesAvailable >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Book_CopiesAvailable",
                schema: "Book",
                table: "Books");
        }
    }
}
