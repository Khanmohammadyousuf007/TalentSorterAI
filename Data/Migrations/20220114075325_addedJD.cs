using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrHelper.Data.Migrations
{
    public partial class addedJD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "Recruitment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "Recruitment");
        }
    }
}
