using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReviewsTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Review_Rating",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "Management",
                table: "Reviews",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Review_Rating",
                schema: "Management",
                table: "Reviews",
                sql: "Rating >= 1 AND Rating <= 10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Review_Rating",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "Management",
                table: "Reviews",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Review_Rating",
                schema: "Management",
                table: "Reviews",
                sql: "Rating >= 0 AND Rating <= 10");
        }
    }
}
