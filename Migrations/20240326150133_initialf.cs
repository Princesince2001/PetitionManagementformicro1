using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initialf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petition_PetitionHandlers_PetitionHandlerId",
                table: "Petition");

            migrationBuilder.DropIndex(
                name: "IX_Petition_PetitionHandlerId",
                table: "Petition");

            migrationBuilder.DropColumn(
                name: "PetitionHandlerId",
                table: "Petition");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetitionHandlerId",
                table: "Petition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Petition_PetitionHandlerId",
                table: "Petition",
                column: "PetitionHandlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Petition_PetitionHandlers_PetitionHandlerId",
                table: "Petition",
                column: "PetitionHandlerId",
                principalTable: "PetitionHandlers",
                principalColumn: "PetitionHandlerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
