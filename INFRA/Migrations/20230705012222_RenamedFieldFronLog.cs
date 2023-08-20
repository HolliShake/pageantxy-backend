using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFRA.Migrations
{
    public partial class RenamedFieldFronLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Contests_ContestId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ConstestId",
                table: "Logs");

            migrationBuilder.AlterColumn<int>(
                name: "ContestId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Contests_ContestId",
                table: "Logs",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Contests_ContestId",
                table: "Logs");

            migrationBuilder.AlterColumn<int>(
                name: "ContestId",
                table: "Logs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConstestId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Contests_ContestId",
                table: "Logs",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id");
        }
    }
}
