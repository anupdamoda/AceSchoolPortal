using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceSchoolPortal.Migrations
{
    public partial class Initial_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassGrades",
                columns: table => new
                {
                    class_grade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_grade_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassGrades", x => x.class_grade_id);
                });

            migrationBuilder.CreateTable(
                name: "HouseGroups",
                columns: table => new
                {
                    house_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    house_group_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseGroups", x => x.house_group_id);
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
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassGradesclass_grade_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.subject_id);
                    table.ForeignKey(
                        name: "FK_Subjects_ClassGrades_ClassGradesclass_grade_id",
                        column: x => x.ClassGradesclass_grade_id,
                        principalTable: "ClassGrades",
                        principalColumn: "class_grade_id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassGradesclass_grade_id = table.Column<int>(type: "int", nullable: true),
                    HouseGroupshouse_group_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.instructor_id);
                    table.ForeignKey(
                        name: "FK_Instructors_ClassGrades_ClassGradesclass_grade_id",
                        column: x => x.ClassGradesclass_grade_id,
                        principalTable: "ClassGrades",
                        principalColumn: "class_grade_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_HouseGroups_HouseGroupshouse_group_id",
                        column: x => x.HouseGroupshouse_group_id,
                        principalTable: "HouseGroups",
                        principalColumn: "house_group_id",
                        onDelete: ReferentialAction.Restrict);
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
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassGradesclass_grade_id = table.Column<int>(type: "int", nullable: true),
                    HouseGroupshouse_group_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.student_id);
                    table.ForeignKey(
                        name: "FK_Students_ClassGrades_ClassGradesclass_grade_id",
                        column: x => x.ClassGradesclass_grade_id,
                        principalTable: "ClassGrades",
                        principalColumn: "class_grade_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_HouseGroups_HouseGroupshouse_group_id",
                        column: x => x.HouseGroupshouse_group_id,
                        principalTable: "HouseGroups",
                        principalColumn: "house_group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ClassGradesclass_grade_id",
                table: "Instructors",
                column: "ClassGradesclass_grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_HouseGroupshouse_group_id",
                table: "Instructors",
                column: "HouseGroupshouse_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassGradesclass_grade_id",
                table: "Students",
                column: "ClassGradesclass_grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_HouseGroupshouse_group_id",
                table: "Students",
                column: "HouseGroupshouse_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassGradesclass_grade_id",
                table: "Subjects",
                column: "ClassGradesclass_grade_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "HouseGroups");

            migrationBuilder.DropTable(
                name: "ClassGrades");
        }
    }
}
