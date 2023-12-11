using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RatingConvertedToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                schema: "Management",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddCheckConstraint(
                name: "CK_Review_Rating",
                schema: "Management",
                table: "Reviews",
                sql: "Rating >= 0 AND Rating <= 10");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Review_Rating",
                schema: "Management",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                schema: "Management",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
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
    }
}
