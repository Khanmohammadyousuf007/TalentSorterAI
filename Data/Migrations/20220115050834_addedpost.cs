using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrHelper.Data.Migrations
{
    public partial class addedpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Candidate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_PostId",
                table: "Candidate",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Post_PostId",
                table: "Candidate",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Post_PostId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_PostId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Candidate");
        }
    }
}
