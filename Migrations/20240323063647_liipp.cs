using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class liipp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PetitionStatus",
                table: "Petition",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetitionStatus",
                table: "Petition");
        }
    }
}
