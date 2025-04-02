using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RootedBack.Migrations
{
    /// <inheritdoc />
    public partial class Updadtetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FarmName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmName",
                table: "Product");
        }
    }
}
