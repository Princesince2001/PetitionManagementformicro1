using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initialk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PentitionPetitionHandler_PetitionHandlers_PetitionHandlerId",
                table: "PentitionPetitionHandler");

            migrationBuilder.DropForeignKey(
                name: "FK_PentitionPetitionHandler_Petition_PetitionId",
                table: "PentitionPetitionHandler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PentitionPetitionHandler",
                table: "PentitionPetitionHandler");

            migrationBuilder.RenameTable(
                name: "PentitionPetitionHandler",
                newName: "pentitionPetitionHandlers");

            migrationBuilder.RenameIndex(
                name: "IX_PentitionPetitionHandler_PetitionId",
                table: "pentitionPetitionHandlers",
                newName: "IX_pentitionPetitionHandlers_PetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_PentitionPetitionHandler_PetitionHandlerId",
                table: "pentitionPetitionHandlers",
                newName: "IX_pentitionPetitionHandlers_PetitionHandlerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pentitionPetitionHandlers",
                table: "pentitionPetitionHandlers",
                column: "PentitionPetitionHandlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_pentitionPetitionHandlers_PetitionHandlers_PetitionHandlerId",
                table: "pentitionPetitionHandlers",
                column: "PetitionHandlerId",
                principalTable: "PetitionHandlers",
                principalColumn: "PetitionHandlerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pentitionPetitionHandlers_Petition_PetitionId",
                table: "pentitionPetitionHandlers",
                column: "PetitionId",
                principalTable: "Petition",
                principalColumn: "PetitionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pentitionPetitionHandlers_PetitionHandlers_PetitionHandlerId",
                table: "pentitionPetitionHandlers");

            migrationBuilder.DropForeignKey(
                name: "FK_pentitionPetitionHandlers_Petition_PetitionId",
                table: "pentitionPetitionHandlers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pentitionPetitionHandlers",
                table: "pentitionPetitionHandlers");

            migrationBuilder.RenameTable(
                name: "pentitionPetitionHandlers",
                newName: "PentitionPetitionHandler");

            migrationBuilder.RenameIndex(
                name: "IX_pentitionPetitionHandlers_PetitionId",
                table: "PentitionPetitionHandler",
                newName: "IX_PentitionPetitionHandler_PetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_pentitionPetitionHandlers_PetitionHandlerId",
                table: "PentitionPetitionHandler",
                newName: "IX_PentitionPetitionHandler_PetitionHandlerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PentitionPetitionHandler",
                table: "PentitionPetitionHandler",
                column: "PentitionPetitionHandlerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PentitionPetitionHandler_PetitionHandlers_PetitionHandlerId",
                table: "PentitionPetitionHandler",
                column: "PetitionHandlerId",
                principalTable: "PetitionHandlers",
                principalColumn: "PetitionHandlerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PentitionPetitionHandler_Petition_PetitionId",
                table: "PentitionPetitionHandler",
                column: "PetitionId",
                principalTable: "Petition",
                principalColumn: "PetitionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
