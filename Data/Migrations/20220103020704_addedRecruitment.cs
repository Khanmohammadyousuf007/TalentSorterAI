using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrHelper.Data.Migrations
{
    public partial class addedRecruitment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recruitment",
                columns: table => new
                {
                    RecruitmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    SrartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfApplication = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitment", x => x.RecruitmentID);
                    table.ForeignKey(
                        name: "FK_Recruitment_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_CompanyID",
                table: "Recruitment",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_PostID",
                table: "Recruitment",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recruitment");
        }
    }
}
