using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAddressFromPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "Book",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "Book",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Home",
                schema: "Book",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "Book",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Zip",
                schema: "Book",
                table: "Publishers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "Book",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "Book",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home",
                schema: "Book",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "Book",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                schema: "Book",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
