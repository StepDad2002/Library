using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ReservationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Reservations_ReservationId",
                schema: "Book",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReservationId",
                schema: "Book",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                schema: "Book",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Management",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                schema: "Management",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                schema: "Management",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Book",
                table: "Books",
                keyColumn: "Id",
                keyValue: -1,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 25, 21, 31, 59, 117, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -10,
                column: "HireDate",
                value: new DateTime(2023, 11, 25, 21, 31, 59, 132, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                schema: "Management",
                table: "Staffs",
                keyColumn: "Id",
                keyValue: -1,
                column: "HireDate",
                value: new DateTime(2023, 11, 25, 21, 31, 59, 132, DateTimeKind.Local).AddTicks(2983));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookId",
                schema: "Management",
                table: "Reservations",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Books_BookId",
                schema: "Management",
                table: "Reservations",
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
                name: "FK_Reservations_Books_BookId",
                schema: "Management",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BookId",
                schema: "Management",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Management",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BookId",
                schema: "Management",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Management",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Pending");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                schema: "Book",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Book",
                table: "Books",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PublicationDate", "ReservationId" },
                values: new object[] { new DateTime(2023, 11, 25, 20, 20, 22, 743, DateTimeKind.Local).AddTicks(4904), null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReservationId",
                schema: "Book",
                table: "Books",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Reservations_ReservationId",
                schema: "Book",
                table: "Books",
                column: "ReservationId",
                principalSchema: "Management",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
