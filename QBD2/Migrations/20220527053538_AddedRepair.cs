using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddedRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_FailureCodes_FailureCodeId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_GLCodes_GLCodeId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_FailureCodeId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_GLCodeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "FailureCodeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "GLCodeId",
                table: "Parts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "e5613d17-b2f4-4719-a8c9-e421a37a63c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "09d6368f-a416-4dce-a3d3-80cb525dc9fb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailureCodeId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GLCodeId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "146d99ac-1fe6-4c29-b59f-d64c88eae224");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "4d110aca-c88b-47a6-b798-ba5488c97366");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_FailureCodeId",
                table: "Parts",
                column: "FailureCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_GLCodeId",
                table: "Parts",
                column: "GLCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_FailureCodes_FailureCodeId",
                table: "Parts",
                column: "FailureCodeId",
                principalTable: "FailureCodes",
                principalColumn: "FailureCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_GLCodes_GLCodeId",
                table: "Parts",
                column: "GLCodeId",
                principalTable: "GLCodes",
                principalColumn: "GLCodeId");
        }
    }
}
