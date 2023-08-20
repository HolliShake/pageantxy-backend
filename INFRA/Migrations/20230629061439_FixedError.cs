using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRA.Migrations
{
    public partial class FixedError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Events_EventId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_EventId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ContestantNumber",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Candidates",
                newName: "CandidateNumber");

            migrationBuilder.AddColumn<int>(
                name: "ContestOrder",
                table: "Contests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Representation",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContestOrder",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Representation",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "CandidateNumber",
                table: "Candidates",
                newName: "EventId");

            migrationBuilder.AddColumn<int>(
                name: "ContestantNumber",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_EventId",
                table: "Candidates",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Events_EventId",
                table: "Candidates",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
