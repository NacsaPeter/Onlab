using Microsoft.EntityFrameworkCore.Migrations;

namespace Lynn.DAL.Migrations
{
    public partial class Rule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Rules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rules_TestId",
                table: "Rules",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Tests_TestId",
                table: "Rules",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Tests_TestId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Rules_TestId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Rules");
        }
    }
}
