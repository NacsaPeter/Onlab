using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lynn.DAL.Migrations
{
    public partial class RelationsWithAlternateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KnownLanguageFullID",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KnownLanguageTerritoryFullID",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearnigLanguageTerritoryFullID",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LearningLanguageFullID",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_KnownLanguageFullID",
                table: "Course",
                column: "KnownLanguageFullID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_KnownLanguageTerritoryFullID",
                table: "Course",
                column: "KnownLanguageTerritoryFullID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LearnigLanguageTerritoryFullID",
                table: "Course",
                column: "LearnigLanguageTerritoryFullID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LearningLanguageFullID",
                table: "Course",
                column: "LearningLanguageFullID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Language_KnownLanguageFullID",
                table: "Course",
                column: "KnownLanguageFullID",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Territory_KnownLanguageTerritoryFullID",
                table: "Course",
                column: "KnownLanguageTerritoryFullID",
                principalTable: "Territory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Territory_LearnigLanguageTerritoryFullID",
                table: "Course",
                column: "LearnigLanguageTerritoryFullID",
                principalTable: "Territory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Language_LearningLanguageFullID",
                table: "Course",
                column: "LearningLanguageFullID",
                principalTable: "Language",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Language_KnownLanguageFullID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Territory_KnownLanguageTerritoryFullID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Territory_LearnigLanguageTerritoryFullID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Language_LearningLanguageFullID",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_KnownLanguageFullID",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_KnownLanguageTerritoryFullID",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_LearnigLanguageTerritoryFullID",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_LearningLanguageFullID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "KnownLanguageFullID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "KnownLanguageTerritoryFullID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LearnigLanguageTerritoryFullID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LearningLanguageFullID",
                table: "Course");
        }
    }
}
