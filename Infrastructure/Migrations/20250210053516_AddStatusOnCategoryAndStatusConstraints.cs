using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusOnCategoryAndStatusConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_User_Status",
                table: "Users",
                sql: "\"Status\" IN ('ACTIVE', 'INACTIVE')");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Organizer_Status",
                table: "Organizers",
                sql: "\"Status\" IN ('ACTIVE', 'INACTIVE')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_User_Status",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Organizer_Status",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");
        }
    }
}
