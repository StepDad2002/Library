using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class GenreConverterAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Book",
                table: "Books",
                keyColumn: "Id",
                keyValue: -1,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 22, 20, 38, 46, 569, DateTimeKind.Local).AddTicks(8568));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -10,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 20, 38, 46, 585, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -1,
                column: "HireDate",
                value: new DateTime(2023, 11, 22, 20, 38, 46, 585, DateTimeKind.Local).AddTicks(3834));
        }
    }
}
