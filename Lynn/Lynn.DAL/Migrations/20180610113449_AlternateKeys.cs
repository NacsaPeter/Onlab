using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lynn.DAL.Migrations
{
    public partial class AlternateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tryings_TestID",
                table: "Tryings");

            migrationBuilder.DropIndex(
                name: "IX_Enrollment_UserID",
                table: "Enrollment");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_Username",
                table: "User",
                column: "Username");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tryings_TestID_UserID",
                table: "Tryings",
                columns: new[] { "TestID", "UserID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Territory_Code",
                table: "Territory",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Language_Code",
                table: "Language",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Enrollment_UserID_CourseID",
                table: "Enrollment",
                columns: new[] { "UserID", "CourseID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CourseLevel_LevelCode",
                table: "CourseLevel",
                column: "LevelCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_Username",
                table: "User");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tryings_TestID_UserID",
                table: "Tryings");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Territory_Code",
                table: "Territory");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Language_Code",
                table: "Language");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Enrollment_UserID_CourseID",
                table: "Enrollment");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CourseLevel_LevelCode",
                table: "CourseLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Tryings_TestID",
                table: "Tryings",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_UserID",
                table: "Enrollment",
                column: "UserID");
        }
    }
}
