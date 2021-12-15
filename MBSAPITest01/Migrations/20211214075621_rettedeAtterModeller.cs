using Microsoft.EntityFrameworkCore.Migrations;

namespace MBSAPITest01.Migrations
{
    public partial class rettedeAtterModeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_DayID",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoodID",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days",
                column: "MoodID",
                principalTable: "Moods",
                principalColumn: "MoodID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Days_DayID",
                table: "Notes",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_DayID",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoodID",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days",
                column: "MoodID",
                principalTable: "Moods",
                principalColumn: "MoodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Days_DayID",
                table: "Notes",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "DayID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
