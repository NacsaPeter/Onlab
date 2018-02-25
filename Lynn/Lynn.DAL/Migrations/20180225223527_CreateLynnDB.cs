using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lynn.DAL.Migrations
{
    public partial class CreateLynnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Explanation = table.Column<string>(maxLength: 200, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TranslatedExplanation = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 80, nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(maxLength: 20, nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: true),
                    KnownLanguage = table.Column<string>(maxLength: 2, nullable: false),
                    KnownLanguageTerritory = table.Column<string>(maxLength: 2, nullable: true),
                    LearningLanguage = table.Column<string>(maxLength: 2, nullable: false),
                    LearningLanguageTerritory = table.Column<string>(maxLength: 2, nullable: true),
                    LevelID = table.Column<int>(nullable: true),
                    Editor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_CourseLevel_LevelID",
                        column: x => x.LevelID,
                        principalTable: "CourseLevel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_User_Editor",
                        column: x => x.Editor,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    MaxPoints = table.Column<int>(nullable: false),
                    NumberOfQuestions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Test_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Test_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    TestID = table.Column<int>(nullable: false),
                    WrongAnswer1 = table.Column<string>(maxLength: 50, nullable: false),
                    WrongAnswer2 = table.Column<string>(maxLength: 50, nullable: true),
                    WrongAnswer3 = table.Column<string>(maxLength: 50, nullable: true),
                    CorrectAnswer = table.Column<string>(maxLength: 50, nullable: true),
                    Question = table.Column<string>(maxLength: 100, nullable: true),
                    RuleID = table.Column<int>(nullable: true),
                    Audio = table.Column<string>(maxLength: 100, nullable: true),
                    Expression = table.Column<string>(maxLength: 50, nullable: true),
                    Picture = table.Column<string>(maxLength: 100, nullable: true),
                    Sentence = table.Column<string>(maxLength: 100, nullable: true),
                    TranslatedExpression = table.Column<string>(maxLength: 50, nullable: true),
                    TranslatedSentence = table.Column<string>(maxLength: 100, nullable: true),
                    TranslatedWrongAnswer1 = table.Column<string>(maxLength: 50, nullable: true),
                    TranslatedWrongAnswer2 = table.Column<string>(maxLength: 50, nullable: true),
                    TranslatedWrongAnswer3 = table.Column<string>(maxLength: 50, nullable: true),
                    Video = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exercises_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Rule_RuleID",
                        column: x => x.RuleID,
                        principalTable: "Rule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tryings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attempts = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    TestID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tryings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tryings_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tryings_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelID",
                table: "Course",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Editor",
                table: "Course",
                column: "Editor");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_UserID",
                table: "Enrollment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TestID",
                table: "Exercises",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_RuleID",
                table: "Exercises",
                column: "RuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Test_CategoryID",
                table: "Test",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Test_CourseID",
                table: "Test",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Tryings_TestID",
                table: "Tryings",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Tryings_UserID",
                table: "Tryings",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Tryings");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "CourseLevel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
