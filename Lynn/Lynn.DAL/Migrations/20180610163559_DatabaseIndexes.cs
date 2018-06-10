using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lynn.DAL.Migrations
{
    public partial class DatabaseIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rule",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Rule_Name",
                table: "Rule",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLevel_LevelName",
                table: "CourseLevel",
                column: "LevelName");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "Category",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Rule_Name",
                table: "Rule");

            migrationBuilder.DropIndex(
                name: "IX_CourseLevel_LevelName",
                table: "CourseLevel");

            migrationBuilder.DropIndex(
                name: "IX_Category_Name",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rule",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
