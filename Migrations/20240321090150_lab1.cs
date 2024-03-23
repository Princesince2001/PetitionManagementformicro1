using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class lab1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PetitionHandlers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PetitionHandlers");
        }
    }
}
