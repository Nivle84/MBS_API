using Microsoft.EntityFrameworkCore.Migrations;

namespace MBSAPITest01.Migrations
{
    public partial class rettedeMereIDayModellen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Days",
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

            migrationBuilder.AlterColumn<int>(
                name: "InfluenceID",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasNote",
                table: "Days",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DayID",
                table: "Notes",
                column: "DayID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days",
                column: "InfluenceID",
                principalTable: "Influences",
                principalColumn: "InfluenceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days",
                column: "MoodID",
                principalTable: "Moods",
                principalColumn: "MoodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Notes_DayID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "HasNote",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Days",
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

            migrationBuilder.AlterColumn<int>(
                name: "InfluenceID",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days",
                column: "InfluenceID",
                principalTable: "Influences",
                principalColumn: "InfluenceID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Moods_MoodID",
                table: "Days",
                column: "MoodID",
                principalTable: "Moods",
                principalColumn: "MoodID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
