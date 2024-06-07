using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2024, 6, 7, 19, 19, 19, 433, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2024, 6, 7, 19, 19, 19, 433, DateTimeKind.Local).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateIssued",
                value: new DateTime(2024, 6, 7, 19, 19, 19, 433, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2024, 5, 14, 18, 12, 53, 503, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2024, 5, 14, 18, 12, 53, 503, DateTimeKind.Local).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateIssued",
                value: new DateTime(2024, 5, 14, 18, 12, 53, 503, DateTimeKind.Local).AddTicks(938));
        }
    }
}
