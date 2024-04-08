using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeDataTypeOfoneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Passports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2024, 4, 4, 17, 17, 35, 478, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2024, 4, 4, 17, 17, 35, 478, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateIssued",
                value: new DateTime(2024, 4, 4, 17, 17, 35, 478, DateTimeKind.Local).AddTicks(4257));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PhoneNumber",
                table: "Passports",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateIssued",
                value: new DateTime(2024, 4, 4, 13, 39, 6, 768, DateTimeKind.Local).AddTicks(7858));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateIssued",
                value: new DateTime(2024, 4, 4, 13, 39, 6, 768, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateIssued",
                value: new DateTime(2024, 4, 4, 13, 39, 6, 768, DateTimeKind.Local).AddTicks(7983));
        }
    }
}
