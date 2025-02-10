using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddValidFromAndValidTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidityPeriod",
                table: "Discounts",
                newName: "ValidFrom");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Discounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "ValidTo",
                table: "Discounts",
                newName: "ValidityPeriod");
        }
    }
}
