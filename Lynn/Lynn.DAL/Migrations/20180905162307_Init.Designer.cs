﻿// <auto-generated />
using System;
using Lynn.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lynn.DAL.Migrations
{
    [DbContext(typeof(LynnDb))]
    [Migration("20180905162307_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lynn.DAL.DbCategory", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .IsRequired();

                b.HasKey("Id");

                b.ToTable("Categories");
            });

            modelBuilder.Entity("Lynn.DAL.DbCourse", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("CourseName")
                    .IsRequired();

                b.Property<string>("Details");

                b.Property<int?>("EditorId");

                b.Property<string>("LearningLanguage")
                    .IsRequired()
                    .HasMaxLength(2);

                b.Property<string>("LearningLanguageTerritory")
                    .HasMaxLength(2);

                b.Property<int?>("LevelId");

                b.Property<string>("TeachingLanguage")
                    .IsRequired()
                    .HasMaxLength(2);

                b.Property<string>("TeachingLanguageTerritory")
                    .HasMaxLength(2);

                b.HasKey("Id");

                b.HasAlternateKey("CourseName");

                b.HasIndex("EditorId");

                b.HasIndex("LevelId");

                b.ToTable("Courses");
            });

            modelBuilder.Entity("Lynn.DAL.DbCourseLevel", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("LevelCode")
                    .IsRequired()
                    .HasMaxLength(2);

                b.Property<string>("LevelName");

                b.HasKey("Id");

                b.HasAlternateKey("LevelCode");

                b.ToTable("CourseLevels");
            });

            modelBuilder.Entity("Lynn.DAL.DbEnrollment", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("CourseId");

                b.Property<int>("Level");

                b.Property<int>("Points");

                b.Property<int>("UserId");

                b.HasKey("Id");

                b.HasAlternateKey("UserId", "CourseId");

                b.HasIndex("CourseId");

                b.ToTable("Enrollments");
            });

            modelBuilder.Entity("Lynn.DAL.DbGrammarExercise", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("CorrectAnswer")
                    .IsRequired();

                b.Property<string>("Question")
                    .IsRequired();

                b.Property<int?>("RuleId");

                b.Property<int>("TestId");

                b.Property<string>("WrongAnswer1")
                    .IsRequired();

                b.Property<string>("WrongAnswer2")
                    .IsRequired();

                b.Property<string>("WrongAnswer3")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("RuleId");

                b.HasIndex("TestId");

                b.ToTable("GrammarExercises");
            });

            modelBuilder.Entity("Lynn.DAL.DbLanguage", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Code")
                    .IsRequired()
                    .HasMaxLength(2);

                b.Property<string>("Name")
                    .IsRequired();

                b.HasKey("Id");

                b.HasAlternateKey("Code");

                b.ToTable("Languages");
            });

            modelBuilder.Entity("Lynn.DAL.DbRule", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Explanation");

                b.Property<string>("Name");

                b.Property<string>("TranslatedExplanation")
                    .IsRequired();

                b.HasKey("Id");

                b.ToTable("Rules");
            });

            modelBuilder.Entity("Lynn.DAL.DbTerritory", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Code")
                    .IsRequired()
                    .HasMaxLength(2);

                b.Property<string>("Name")
                    .IsRequired();

                b.HasKey("Id");

                b.HasAlternateKey("Code");

                b.ToTable("Territories");
            });

            modelBuilder.Entity("Lynn.DAL.DbTest", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int?>("CategoryId");

                b.Property<int>("CourseId");

                b.Property<int>("Level");

                b.Property<int?>("MaxPoints");

                b.Property<int?>("NumberOfQuestions");

                b.HasKey("Id");

                b.HasIndex("CategoryId");

                b.HasIndex("CourseId");

                b.ToTable("Tests");
            });

            modelBuilder.Entity("Lynn.DAL.DbTestUser", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("Attempts");

                b.Property<bool>("IsCorrect");

                b.Property<int>("TestId");

                b.Property<int>("UserId");

                b.HasKey("Id");

                b.HasAlternateKey("TestId", "UserId");

                b.HasIndex("UserId");

                b.ToTable("Tryings");
            });

            modelBuilder.Entity("Lynn.DAL.DbVocabularyExercise", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Audio");

                b.Property<string>("CorrectAnswer")
                    .IsRequired();

                b.Property<string>("Picture");

                b.Property<string>("Sentence");

                b.Property<int>("TestId");

                b.Property<string>("TranslatedCorrectAnswer")
                    .IsRequired();

                b.Property<string>("TranslatedSentence");

                b.Property<string>("TranslatedWrongAnswer1")
                    .IsRequired();

                b.Property<string>("TranslatedWrongAnswer2")
                    .IsRequired();

                b.Property<string>("TranslatedWrongAnswer3")
                    .IsRequired();

                b.Property<string>("Video");

                b.Property<string>("WrongAnswer1")
                    .IsRequired();

                b.Property<string>("WrongAnswer2")
                    .IsRequired();

                b.Property<string>("WrongAnswer3")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("TestId");

                b.ToTable("VocabularyExercises");
            });

            modelBuilder.Entity("Lynn.DAL.Identity.ApplicationRole", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Name")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("Lynn.DAL.Identity.ApplicationUser", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Email")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed");

                b.Property<bool>("LockoutEnabled");

                b.Property<DateTimeOffset?>("LockoutEnd");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash");

                b.Property<string>("PhoneNumber");

                b.Property<bool>("PhoneNumberConfirmed");

                b.Property<int>("Points");

                b.Property<string>("SecurityStamp");

                b.Property<bool>("TwoFactorEnabled");

                b.Property<string>("UserName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex")
                    .HasFilter("[NormalizedUserName] IS NOT NULL");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<int>("RoleId");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<int>("UserId");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
            {
                b.Property<string>("LoginProvider");

                b.Property<string>("ProviderKey");

                b.Property<string>("ProviderDisplayName");

                b.Property<int>("UserId");

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
            {
                b.Property<int>("UserId");

                b.Property<int>("RoleId");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
            {
                b.Property<int>("UserId");

                b.Property<string>("LoginProvider");

                b.Property<string>("Name");

                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("Lynn.DAL.DbCourse", b =>
            {
                b.HasOne("Lynn.DAL.Identity.ApplicationUser", "Editor")
                    .WithMany("CreatedCourses")
                    .HasForeignKey("EditorId");

                b.HasOne("Lynn.DAL.DbCourseLevel", "Level")
                    .WithMany("Courses")
                    .HasForeignKey("LevelId");
            });

            modelBuilder.Entity("Lynn.DAL.DbEnrollment", b =>
            {
                b.HasOne("Lynn.DAL.DbCourse", "Course")
                    .WithMany("Enrollments")
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Lynn.DAL.Identity.ApplicationUser", "User")
                    .WithMany("Enrollments")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Lynn.DAL.DbGrammarExercise", b =>
            {
                b.HasOne("Lynn.DAL.DbRule", "Rule")
                    .WithMany("GrammarExercises")
                    .HasForeignKey("RuleId");

                b.HasOne("Lynn.DAL.DbTest", "Test")
                    .WithMany("GrammarExercises")
                    .HasForeignKey("TestId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Lynn.DAL.DbTest", b =>
            {
                b.HasOne("Lynn.DAL.DbCategory", "Category")
                    .WithMany("Tests")
                    .HasForeignKey("CategoryId");

                b.HasOne("Lynn.DAL.DbCourse", "Course")
                    .WithMany("Tests")
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Lynn.DAL.DbTestUser", b =>
            {
                b.HasOne("Lynn.DAL.DbTest", "Test")
                    .WithMany("UserTests")
                    .HasForeignKey("TestId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Lynn.DAL.Identity.ApplicationUser", "User")
                    .WithMany("TestTryings")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.OwnsOne("Lynn.DAL.DbTestResult", "BestResult", b1 =>
                {
                    b1.Property<int>("DbTestUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b1.Property<int>("Points");

                    b1.Property<int>("RightAnswers");

                    b1.Property<int>("WrongAnswers");

                    b1.ToTable("Tryings");

                    b1.HasOne("Lynn.DAL.DbTestUser")
                        .WithOne("BestResult")
                        .HasForeignKey("Lynn.DAL.DbTestResult", "DbTestUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

                b.OwnsOne("Lynn.DAL.DbTestResult", "LastResult", b1 =>
                {
                    b1.Property<int>("DbTestUserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b1.Property<int>("Points");

                    b1.Property<int>("RightAnswers");

                    b1.Property<int>("WrongAnswers");

                    b1.ToTable("Tryings");

                    b1.HasOne("Lynn.DAL.DbTestUser")
                        .WithOne("LastResult")
                        .HasForeignKey("Lynn.DAL.DbTestResult", "DbTestUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
            });

            modelBuilder.Entity("Lynn.DAL.DbVocabularyExercise", b =>
            {
                b.HasOne("Lynn.DAL.DbTest", "Test")
                    .WithMany("VocabularyExercises")
                    .HasForeignKey("TestId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
            {
                b.HasOne("Lynn.DAL.Identity.ApplicationRole")
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
            {
                b.HasOne("Lynn.DAL.Identity.ApplicationUser")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
            {
                b.HasOne("Lynn.DAL.Identity.ApplicationUser")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
            {
                b.HasOne("Lynn.DAL.Identity.ApplicationRole")
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Lynn.DAL.Identity.ApplicationUser")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
            {
                b.HasOne("Lynn.DAL.Identity.ApplicationUser")
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}