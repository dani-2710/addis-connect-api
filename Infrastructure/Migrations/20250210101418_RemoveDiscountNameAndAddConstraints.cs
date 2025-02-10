using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDiscountNameAndAddConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Discounts");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Discount_ValidDate",
                table: "Discounts",
                sql: "\"ValidFrom\" < \"ValidTo\"");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Discount_ValidFrom_Future",
                table: "Discounts",
                sql: "\"ValidFrom\" > CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Discount_ValidDate",
                table: "Discounts");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Discount_ValidFrom_Future",
                table: "Discounts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Discounts",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
