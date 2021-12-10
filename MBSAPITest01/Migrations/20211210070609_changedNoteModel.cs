using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MBSAPITest01.Migrations
{
    public partial class changedNoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Influences",
                columns: table => new
                {
                    InfluenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluenceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Influences", x => x.InfluenceID);
                });

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    MoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.MoodID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MoodID = table.Column<int>(type: "int", nullable: false),
                    InfluenceID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayID);
                    table.ForeignKey(
                        name: "FK_Days_Influences_InfluenceID",
                        column: x => x.InfluenceID,
                        principalTable: "Influences",
                        principalColumn: "InfluenceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Days_Moods_MoodID",
                        column: x => x.MoodID,
                        principalTable: "Moods",
                        principalColumn: "MoodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Days_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    DayID = table.Column<int>(type: "int", nullable: false),
                    NoteString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.DayID);
                    table.ForeignKey(
                        name: "FK_Notes_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "DayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_InfluenceID",
                table: "Days",
                column: "InfluenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Days_MoodID",
                table: "Days",
                column: "MoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Days_UserID",
                table: "Days",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Influences");

            migrationBuilder.DropTable(
                name: "Moods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
