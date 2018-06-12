using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lynn.DAL.Migrations
{
    public partial class OwnedType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestResult_Points",
                table: "Tryings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BestResult_RightAnswers",
                table: "Tryings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BestResult_WrongAnswers",
                table: "Tryings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastResult_Points",
                table: "Tryings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastResult_RightAnswers",
                table: "Tryings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastResult_WrongAnswers",
                table: "Tryings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseName",
                table: "Course",
                column: "CourseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_CourseName",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "BestResult_Points",
                table: "Tryings");

            migrationBuilder.DropColumn(
                name: "BestResult_RightAnswers",
                table: "Tryings");

            migrationBuilder.DropColumn(
                name: "BestResult_WrongAnswers",
                table: "Tryings");

            migrationBuilder.DropColumn(
                name: "LastResult_Points",
                table: "Tryings");

            migrationBuilder.DropColumn(
                name: "LastResult_RightAnswers",
                table: "Tryings");

            migrationBuilder.DropColumn(
                name: "LastResult_WrongAnswers",
                table: "Tryings");
        }
    }
}
