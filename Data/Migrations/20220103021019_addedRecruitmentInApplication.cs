using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrHelper.Data.Migrations
{
    public partial class addedRecruitmentInApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruitmentID",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Application_RecruitmentID",
                table: "Application",
                column: "RecruitmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Recruitment_RecruitmentID",
                table: "Application",
                column: "RecruitmentID",
                principalTable: "Recruitment",
                principalColumn: "RecruitmentID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Recruitment_RecruitmentID",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_RecruitmentID",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "RecruitmentID",
                table: "Application");
        }
    }
}
