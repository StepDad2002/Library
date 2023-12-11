using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NoMoreAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "Management",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "Management",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Home",
                schema: "Management",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "Management",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Zip",
                schema: "Management",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "Management",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "Management",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Home",
                schema: "Management",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "Management",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Zip",
                schema: "Management",
                table: "Customers");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "Management",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "Management",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home",
                schema: "Management",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "Management",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                schema: "Management",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "Management",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "Management",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Home",
                schema: "Management",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "Management",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                schema: "Management",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
