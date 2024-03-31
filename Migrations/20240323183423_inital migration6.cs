using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initalmigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_PetitionStatus_PetitionStatusId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_PetitionHandlers_PetitionStatus_PetitionStatusId",
                table: "PetitionHandlers");

            migrationBuilder.DropTable(
                name: "PetitionStatus");

            migrationBuilder.DropIndex(
                name: "IX_PetitionHandlers_PetitionStatusId",
                table: "PetitionHandlers");

            migrationBuilder.DropIndex(
                name: "IX_Admin_PetitionStatusId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "PetitionStatusId",
                table: "PetitionHandlers");

            migrationBuilder.DropColumn(
                name: "StatusType",
                table: "PetitionHandlers");

            migrationBuilder.DropColumn(
                name: "PetitionStatusId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "StatusType",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "StatusType",
                table: "Petition",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusType",
                table: "Petition");

            migrationBuilder.AddColumn<int>(
                name: "PetitionStatusId",
                table: "PetitionHandlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusType",
                table: "PetitionHandlers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "PetitionStatusId",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatusType",
                table: "Admin",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PetitionStatus",
                columns: table => new
                {
                    PetitionStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PetitionId = table.Column<int>(type: "int", nullable: false),
                    StatusType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionStatus", x => x.PetitionStatusId);
                    table.ForeignKey(
                        name: "FK_PetitionStatus_Petition_PetitionId",
                        column: x => x.PetitionId,
                        principalTable: "Petition",
                        principalColumn: "PetitionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PetitionHandlers_PetitionStatusId",
                table: "PetitionHandlers",
                column: "PetitionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_PetitionStatusId",
                table: "Admin",
                column: "PetitionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PetitionStatus_PetitionId",
                table: "PetitionStatus",
                column: "PetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_PetitionStatus_PetitionStatusId",
                table: "Admin",
                column: "PetitionStatusId",
                principalTable: "PetitionStatus",
                principalColumn: "PetitionStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetitionHandlers_PetitionStatus_PetitionStatusId",
                table: "PetitionHandlers",
                column: "PetitionStatusId",
                principalTable: "PetitionStatus",
                principalColumn: "PetitionStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
