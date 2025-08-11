using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExamSystem.Migrations
{
    /// <inheritdoc />
    public partial class PendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_optionID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_ExamSessions_SessionID",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_SessionID",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "OptionID",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "optionID",
                table: "Answers",
                newName: "OptionID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_optionID",
                table: "Answers",
                newName: "IX_Answers_OptionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Result",
                column: "ResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_OptionID",
                table: "Answers",
                column: "OptionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_OptionID",
                table: "Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "Answers",
                newName: "optionID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_OptionID",
                table: "Answers",
                newName: "IX_Answers_optionID");

            migrationBuilder.AddColumn<int>(
                name: "OptionID",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionID",
                table: "Result",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "ResultID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_SessionID",
                table: "Result",
                column: "SessionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_optionID",
                table: "Answers",
                column: "optionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_ExamSessions_SessionID",
                table: "Result",
                column: "SessionID",
                principalTable: "ExamSessions",
                principalColumn: "SessionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
