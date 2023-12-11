using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviourUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                schema: "Book",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "Book",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                schema: "Book",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_BookId",
                schema: "Management",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                schema: "Book",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Genres",
                schema: "Book",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Book",
                table: "Books",
                keyColumn: "Id",
                keyValue: -1,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 25, 20, 20, 22, 743, DateTimeKind.Local).AddTicks(4904));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -10,
                column: "HireDate",
                value: new DateTime(2023, 11, 25, 20, 20, 22, 757, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -1,
                column: "HireDate",
                value: new DateTime(2023, 11, 25, 20, 20, 22, 757, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                schema: "Book",
                table: "AuthorBook",
                column: "AuthorsId",
                principalSchema: "Book",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "Book",
                table: "Books",
                column: "PublisherId",
                principalSchema: "Book",
                principalTable: "Publishers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                schema: "Book",
                table: "Books",
                column: "ShelfId",
                principalSchema: "Book",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments",
                column: "CustomerId",
                principalSchema: "Management",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_BookId",
                schema: "Management",
                table: "Loans",
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
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                schema: "Book",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "Book",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                schema: "Book",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_FinePayments_Customers_CustomerId",
                schema: "Management",
                table: "FinePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_BookId",
                schema: "Management",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                schema: "Book",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genres",
                schema: "Book",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                schema: "Book",
                table: "Books",
                keyColumn: "Id",
                keyValue: -1,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 22, 22, 25, 54, 770, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -10,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 22, 25, 54, 830, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -1,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 22, 25, 54, 830, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Authors_AuthorsId",
                schema: "Book",
                table: "AuthorBook",
                column: "AuthorsId",
                principalSchema: "Book",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                schema: "Book",
                table: "Books",
                column: "PublisherId",
                principalSchema: "Book",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfId",
                schema: "Book",
                table: "Books",
                column: "ShelfId",
                principalSchema: "Book",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Loans_Books_BookId",
                schema: "Management",
                table: "Loans",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
