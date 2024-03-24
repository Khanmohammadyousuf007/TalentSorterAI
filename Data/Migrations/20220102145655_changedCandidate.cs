using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrHelper.Data.Migrations
{
    public partial class changedCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Experience",
                table: "Candidate",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HonsCGPA",
                table: "Candidate",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MastersCGPA",
                table: "Candidate",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "McqPercentage",
                table: "Candidate",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "VivaPercentage",
                table: "Candidate",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "WrittenPercentage",
                table: "Candidate",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "HonsCGPA",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "MastersCGPA",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "McqPercentage",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "VivaPercentage",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "WrittenPercentage",
                table: "Candidate");
        }
    }
}
