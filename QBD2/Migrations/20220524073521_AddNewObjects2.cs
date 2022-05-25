using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddNewObjects2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PartStatusId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "82663a06-0018-4bc5-be83-395d58745f53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "34eebf0e-5deb-4070-a9ae-c9be51daa52c");

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 1,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 2,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 3,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 4,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 5,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 6,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 7,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 8,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 9,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 10,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Parts",
                keyColumn: "PartId",
                keyValue: 11,
                column: "PartStatusId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_FailureCodeId",
                table: "Parts",
                column: "FailureCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_GLCodeId",
                table: "Parts",
                column: "GLCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartStatusId",
                table: "Parts",
                column: "PartStatusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartStatuses_PartStatusId",
                table: "Parts",
                column: "PartStatusId",
                principalTable: "PartStatuses",
                principalColumn: "PartStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_FailureCodes_FailureCodeId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_GLCodes_GLCodeId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartStatuses_PartStatusId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_FailureCodeId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_GLCodeId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartStatusId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "FailureCodeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "GLCodeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PartStatusId",
                table: "Parts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "4453e875-b16e-4046-baff-3b335cfb5a2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "d1d2b7d6-cf83-4cf3-9d59-547a9b7c14d8");
        }
    }
}
