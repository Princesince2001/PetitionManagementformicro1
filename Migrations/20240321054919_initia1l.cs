using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initia1l : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDocument",
                table: "Petition");

            migrationBuilder.AddColumn<string>(
                name: "UploadDocumentname",
                table: "Petition",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDocumentname",
                table: "Petition");

            migrationBuilder.AddColumn<byte[]>(
                name: "UploadDocument",
                table: "Petition",
                type: "longblob",
                nullable: false);
        }
    }
}
