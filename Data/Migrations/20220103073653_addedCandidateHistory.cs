using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrHelper.Data.Migrations
{
    public partial class addedCandidateHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateHistory",
                columns: table => new
                {
                    CandidateHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HonsCGPA = table.Column<float>(type: "real", nullable: false),
                    MastersCGPA = table.Column<float>(type: "real", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    McqPercentage = table.Column<float>(type: "real", nullable: false),
                    WrittenPercentage = table.Column<float>(type: "real", nullable: false),
                    VivaPercentage = table.Column<float>(type: "real", nullable: false),
                    AiRecommendationScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateHistory", x => x.CandidateHistoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateHistory");
        }
    }
}
