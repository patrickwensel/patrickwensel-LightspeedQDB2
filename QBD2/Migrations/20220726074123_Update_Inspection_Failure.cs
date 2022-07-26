using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Update_Inspection_Failure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionFailures_FailureTypes_FailureTypeId",
                table: "InspectionFailures");

            migrationBuilder.RenameColumn(
                name: "FailureTypeId",
                table: "InspectionFailures",
                newName: "BuildStationFailureCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionFailures_FailureTypeId",
                table: "InspectionFailures",
                newName: "IX_InspectionFailures_BuildStationFailureCodeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "132d6063-5011-49cf-8500-170b4c3478d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f7536f8a-bd2d-4e01-94f9-3d8689644c32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2791411d-600b-4c2e-a6f0-1174bf8db6a4", "3e15cf2e-a1af-467d-8e75-f7978d83327d" });

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionFailures_BuildStationFailureCodes_BuildStationFailureCodeId",
                table: "InspectionFailures",
                column: "BuildStationFailureCodeId",
                principalTable: "BuildStationFailureCodes",
                principalColumn: "BuildStationFailureCodeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionFailures_BuildStationFailureCodes_BuildStationFailureCodeId",
                table: "InspectionFailures");

            migrationBuilder.RenameColumn(
                name: "BuildStationFailureCodeId",
                table: "InspectionFailures",
                newName: "FailureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionFailures_BuildStationFailureCodeId",
                table: "InspectionFailures",
                newName: "IX_InspectionFailures_FailureTypeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "12936357-7ce4-4b98-acf1-7d56301a3c14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "5b467704-f348-48c0-9efd-04b6f786d3e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "917b6ad9-34c4-4731-ae30-4f8f074359f5", "f4f2f6ff-5565-4ef2-ac52-29336d1f6b1a" });

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionFailures_FailureTypes_FailureTypeId",
                table: "InspectionFailures",
                column: "FailureTypeId",
                principalTable: "FailureTypes",
                principalColumn: "FailureTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
