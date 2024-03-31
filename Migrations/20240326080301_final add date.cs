using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class finaladddate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petition_Category_CategoryId",
                table: "Petition");

            migrationBuilder.DropForeignKey(
                name: "FK_Petition_User_UserId",
                table: "Petition");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Petition",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Petition",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Petition",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Petition_Category_CategoryId",
                table: "Petition",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petition_User_UserId",
                table: "Petition",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petition_Category_CategoryId",
                table: "Petition");

            migrationBuilder.DropForeignKey(
                name: "FK_Petition_User_UserId",
                table: "Petition");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Petition");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Petition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Petition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Petition_Category_CategoryId",
                table: "Petition",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Petition_User_UserId",
                table: "Petition",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
