using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initialfr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PentitionPetitionHandler",
                columns: table => new
                {
                    PentitionPetitionHandlerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PetitionId = table.Column<int>(type: "int", nullable: false),
                    PetitionHandlerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PentitionPetitionHandler", x => x.PentitionPetitionHandlerId);
                    table.ForeignKey(
                        name: "FK_PentitionPetitionHandler_PetitionHandlers_PetitionHandlerId",
                        column: x => x.PetitionHandlerId,
                        principalTable: "PetitionHandlers",
                        principalColumn: "PetitionHandlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PentitionPetitionHandler_Petition_PetitionId",
                        column: x => x.PetitionId,
                        principalTable: "Petition",
                        principalColumn: "PetitionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PentitionPetitionHandler_PetitionHandlerId",
                table: "PentitionPetitionHandler",
                column: "PetitionHandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_PentitionPetitionHandler_PetitionId",
                table: "PentitionPetitionHandler",
                column: "PetitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PentitionPetitionHandler");
        }
    }
}
