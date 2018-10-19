using Microsoft.EntityFrameworkCore.Migrations;

namespace SPortal.Data.Migrations
{
    public partial class upadte_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_AppUsers_StaffID",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AppUsers_StaffID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_StaffID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Sections_StaffID",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Student_Image",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "Student_Password",
                table: "AppUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Image",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Password",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_StaffID",
                table: "Subjects",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_StaffID",
                table: "Sections",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_AppUsers_StaffID",
                table: "Sections",
                column: "StaffID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AppUsers_StaffID",
                table: "Subjects",
                column: "StaffID",
                principalTable: "AppUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
