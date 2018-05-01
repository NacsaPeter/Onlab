using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lynn.DAL.Migrations
{
    public partial class SeparateExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Test_TestID",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Rule_RuleID",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_RuleID",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "RuleID",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "VocabularyExercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_TestID",
                table: "VocabularyExercise",
                newName: "IX_VocabularyExercise_TestID");

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedWrongAnswer3",
                table: "VocabularyExercise",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedWrongAnswer2",
                table: "VocabularyExercise",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedWrongAnswer1",
                table: "VocabularyExercise",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedExpression",
                table: "VocabularyExercise",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Expression",
                table: "VocabularyExercise",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VocabularyExercise",
                table: "VocabularyExercise",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "GrammarExercise",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorrectAnswer = table.Column<string>(maxLength: 50, nullable: false),
                    Question = table.Column<string>(maxLength: 100, nullable: false),
                    RuleID = table.Column<int>(nullable: true),
                    TestID = table.Column<int>(nullable: false),
                    WrongAnswer1 = table.Column<string>(maxLength: 50, nullable: false),
                    WrongAnswer2 = table.Column<string>(maxLength: 50, nullable: false),
                    WrongAnswer3 = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammarExercise", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GrammarExercise_Rule_RuleID",
                        column: x => x.RuleID,
                        principalTable: "Rule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrammarExercise_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrammarExercise_RuleID",
                table: "GrammarExercise",
                column: "RuleID");

            migrationBuilder.CreateIndex(
                name: "IX_GrammarExercise_TestID",
                table: "GrammarExercise",
                column: "TestID");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyExercise_Test_TestID",
                table: "VocabularyExercise",
                column: "TestID",
                principalTable: "Test",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyExercise_Test_TestID",
                table: "VocabularyExercise");

            migrationBuilder.DropTable(
                name: "GrammarExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VocabularyExercise",
                table: "VocabularyExercise");

            migrationBuilder.RenameTable(
                name: "VocabularyExercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_VocabularyExercise_TestID",
                table: "Exercises",
                newName: "IX_Exercises_TestID");

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedWrongAnswer3",
                table: "Exercises",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedWrongAnswer2",
                table: "Exercises",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedWrongAnswer1",
                table: "Exercises",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TranslatedExpression",
                table: "Exercises",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Expression",
                table: "Exercises",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Exercises",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Exercises",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Exercises",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RuleID",
                table: "Exercises",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_RuleID",
                table: "Exercises",
                column: "RuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Test_TestID",
                table: "Exercises",
                column: "TestID",
                principalTable: "Test",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Rule_RuleID",
                table: "Exercises",
                column: "RuleID",
                principalTable: "Rule",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
