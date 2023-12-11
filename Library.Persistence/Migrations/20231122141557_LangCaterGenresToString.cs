using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class LangCaterGenresToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "Book",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categorie",
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
                value: new DateTime(2023, 11, 22, 16, 15, 57, 371, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -10,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 16, 15, 57, 388, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -1,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 16, 15, 57, 388, DateTimeKind.Local).AddTicks(4378));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "Book",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Categorie",
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
                value: new DateTime(2023, 11, 22, 13, 19, 17, 234, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -10,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 13, 19, 17, 251, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -1,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 13, 19, 17, 251, DateTimeKind.Local).AddTicks(3123));
        }
    }
}
