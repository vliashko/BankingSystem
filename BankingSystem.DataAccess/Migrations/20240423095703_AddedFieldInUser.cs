using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AgreeToGetEmail",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
    
        }
    }
}
