using Microsoft.EntityFrameworkCore.Migrations;

namespace AceSchoolPortal.Migrations
{
    public partial class isEnabledCoulmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isEnabled",
                table: "AspNetUsers");
        }
    }
}
