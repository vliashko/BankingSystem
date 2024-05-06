using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumerAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderAccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StripeId",
                table: "ClientAccounts");

            migrationBuilder.AddColumn<double>(
                name: "ConsumerNumberAccount",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SenderNumberAccount",
                table: "Transactions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AccountNumber",
                table: "ClientAccounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumerNumberAccount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SenderNumberAccount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "ClientAccounts");

            migrationBuilder.AddColumn<string>(
                name: "ConsumerAccountId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderAccountId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StripeId",
                table: "ClientAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
