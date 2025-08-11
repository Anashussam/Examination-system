using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExamSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddExamID_UserID_ToAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Answers_ExamSessions_ExamSessionSessionID",
            //    table: "Answers");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Answers_ExamSessions_SessionID",
            //    table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_OptionID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Exam_ExamID",
                table: "ExamSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Result_ResultID",
                table: "ExamSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionID1",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exam_ExamID",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuestionID1",
                table: "Options");

            //migrationBuilder.DropIndex(
            //    name: "IX_ExamSessions_ResultID",
            //    table: "ExamSessions");

            //migrationBuilder.DropIndex(
            //    name: "IX_Answers_ExamSessionSessionID",
            //    table: "Answers");

            //migrationBuilder.DropIndex(
            //    name: "IX_Answers_SessionID",
            //    table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionID1",
                table: "Options");

            //migrationBuilder.DropColumn(
            //    name: "ResultID",
            //    table: "ExamSessions");

            //migrationBuilder.DropColumn(
            //    name: "ExamSessionSessionID",
            //    table: "Answers");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "Answers",
                newName: "optionID");

            migrationBuilder.RenameColumn(
                name: "SessionID",
                table: "Answers",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_OptionID",
                table: "Answers",
                newName: "IX_Answers_optionID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ExamSessions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ExamID",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptionID",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Diffficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_Exams_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exams_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CreatedBy",
                table: "Exams",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectID",
                table: "Exams",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_optionID",
                table: "Answers",
                column: "optionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Exams_ExamID",
                table: "ExamSessions",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamID",
                table: "Questions",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Options_optionID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSessions_Exams_ExamID",
                table: "ExamSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamID",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamID",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "OptionID",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "optionID",
                table: "Answers",
                newName: "OptionID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Answers",
                newName: "SessionID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_optionID",
                table: "Answers",
                newName: "IX_Answers_OptionID");

            migrationBuilder.AddColumn<int>(
                name: "QuestionID1",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ExamSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultID",
                table: "ExamSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExamSessionSessionID",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diffficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_Exam_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exam_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionID1",
                table: "Options",
                column: "QuestionID1");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSessions_ResultID",
                table: "ExamSessions",
                column: "ResultID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Answers_ExamSessionSessionID",
            //    table: "Answers",
            //    column: "ExamSessionSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SessionID",
                table: "Answers",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_CreatedBy",
                table: "Exam",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SubjectID",
                table: "Exam",
                column: "SubjectID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Answers_ExamSessions_ExamSessionSessionID",
            //    table: "Answers",
            //    column: "ExamSessionSessionID",
            //    principalTable: "ExamSessions",
            //    principalColumn: "SessionID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Answers_ExamSessions_SessionID",
            //    table: "Answers",
            //    column: "SessionID",
            //    principalTable: "ExamSessions",
            //    principalColumn: "SessionID",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Options_OptionID",
                table: "Answers",
                column: "OptionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Exam_ExamID",
                table: "ExamSessions",
                column: "ExamID",
                principalTable: "Exam",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSessions_Result_ResultID",
                table: "ExamSessions",
                column: "ResultID",
                principalTable: "Result",
                principalColumn: "ResultID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionID1",
                table: "Options",
                column: "QuestionID1",
                principalTable: "Questions",
                principalColumn: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exam_ExamID",
                table: "Questions",
                column: "ExamID",
                principalTable: "Exam",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
