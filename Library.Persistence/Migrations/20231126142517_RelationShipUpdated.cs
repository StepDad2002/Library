using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RelationShipUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                schema: "Management",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                schema: "Management",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments",
                column: "CustomerId",
                principalSchema: "Management",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                schema: "Management",
                table: "Reviews",
                column: "CustomerId",
                principalSchema: "Management",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                schema: "Management",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                schema: "Management",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments",
                column: "CustomerId",
                principalSchema: "Management",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "Management",
                table: "Reviews",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                schema: "Management",
                table: "Reviews",
                column: "CustomerId",
                principalSchema: "Management",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
