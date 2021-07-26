using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceSchoolPortal.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    instructor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experience = table.Column<int>(type: "int", nullable: false),
                    enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.instructor_id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isEnabled = table.Column<bool>(type: "bit", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "HouseGroups",
                columns: table => new
                {
                    house_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    house_group_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructorsinstructor_id = table.Column<int>(type: "int", nullable: true),
                    Studentsstudent_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseGroups", x => x.house_group_id);
                    table.ForeignKey(
                        name: "FK_HouseGroups_Instructors_Instructorsinstructor_id",
                        column: x => x.Instructorsinstructor_id,
                        principalTable: "Instructors",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseGroups_Students_Studentsstudent_id",
                        column: x => x.Studentsstudent_id,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Studentsstudent_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.subject_id);
                    table.ForeignKey(
                        name: "FK_Subjects_Students_Studentsstudent_id",
                        column: x => x.Studentsstudent_id,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassGrades",
                columns: table => new
                {
                    class_grade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_grade_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Studentsstudent_id = table.Column<int>(type: "int", nullable: true),
                    Instructorsinstructor_id = table.Column<int>(type: "int", nullable: true),
                    Subjectssubject_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGrades", x => x.class_grade_id);
                    table.ForeignKey(
                        name: "FK_ClassGrades_Instructors_Instructorsinstructor_id",
                        column: x => x.Instructorsinstructor_id,
                        principalTable: "Instructors",
                        principalColumn: "instructor_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassGrades_Students_Studentsstudent_id",
                        column: x => x.Studentsstudent_id,
                        principalTable: "Students",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassGrades_Subjects_Subjectssubject_id",
                        column: x => x.Subjectssubject_id,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassGrades_Instructorsinstructor_id",
                table: "ClassGrades",
                column: "Instructorsinstructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGrades_Studentsstudent_id",
                table: "ClassGrades",
                column: "Studentsstudent_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClassGrades_Subjectssubject_id",
                table: "ClassGrades",
                column: "Subjectssubject_id");

            migrationBuilder.CreateIndex(
                name: "IX_HouseGroups_Instructorsinstructor_id",
                table: "HouseGroups",
                column: "Instructorsinstructor_id");

            migrationBuilder.CreateIndex(
                name: "IX_HouseGroups_Studentsstudent_id",
                table: "HouseGroups",
                column: "Studentsstudent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Studentsstudent_id",
                table: "Subjects",
                column: "Studentsstudent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassGrades");

            migrationBuilder.DropTable(
                name: "HouseGroups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
