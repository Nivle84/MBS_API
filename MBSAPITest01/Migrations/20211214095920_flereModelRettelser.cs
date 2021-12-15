using Microsoft.EntityFrameworkCore.Migrations;

namespace MBSAPITest01.Migrations
{
    public partial class flereModelRettelser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserID",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
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
                name: "FK_Days_Users_UserID",
                table: "Days",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Notes",
                type: "int",
                nullable: true);

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
                name: "InfluenceID",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserID",
                table: "Notes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Influences_InfluenceID",
                table: "Days",
                column: "InfluenceID",
                principalTable: "Influences",
                principalColumn: "InfluenceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Users_UserID",
                table: "Days",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserID",
                table: "Notes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
