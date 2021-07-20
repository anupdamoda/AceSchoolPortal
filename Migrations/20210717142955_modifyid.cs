using Microsoft.EntityFrameworkCore.Migrations;

namespace AceSchoolPortal.Migrations
{
    public partial class modifyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "ID");
        }
    }
}
