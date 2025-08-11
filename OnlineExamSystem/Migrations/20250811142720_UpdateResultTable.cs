using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExamSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Exams_ExamID",
                table: "ExamSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Users_UserID",
                table: "ExamSessions");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Exams_ExamID",
                table: "ExamSessions",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Users_UserID",
                table: "ExamSessions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Exams_ExamID",
                table: "ExamSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Users_UserID",
                table: "ExamSessions");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Exams_ExamID",
                table: "ExamSessions",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Users_UserID",
                table: "ExamSessions",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
