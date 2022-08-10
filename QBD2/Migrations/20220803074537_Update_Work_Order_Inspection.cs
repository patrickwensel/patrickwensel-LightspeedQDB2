using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Update_Work_Order_Inspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionFailures_BuildStationFailureCodes_BuildStationFailureCodeId",
                table: "InspectionFailures");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Stations_StationId",
                table: "Inspections");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Inspections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkOrderId",
                table: "Inspections",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildStationFailureCodeId",
                table: "InspectionFailures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FailureTypeId",
                table: "InspectionFailures",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "f3c55f20-9e41-44be-9ef1-1842ceaebd9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "03d2a433-98b1-4e2f-8036-cbfc9603db5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bfb3419-77a9-48a6-b234-8e132e48c638", "43a92ab8-dfcd-43e0-9462-a1940b8cfb49" });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_WorkOrderId",
                table: "Inspections",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionFailures_FailureTypeId",
                table: "InspectionFailures",
                column: "FailureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionFailures_BuildStationFailureCodes_BuildStationFailureCodeId",
                table: "InspectionFailures",
                column: "BuildStationFailureCodeId",
                principalTable: "BuildStationFailureCodes",
                principalColumn: "BuildStationFailureCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionFailures_FailureTypes_FailureTypeId",
                table: "InspectionFailures",
                column: "FailureTypeId",
                principalTable: "FailureTypes",
                principalColumn: "FailureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Stations_StationId",
                table: "Inspections",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_WorkOrders_WorkOrderId",
                table: "Inspections",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "WorkOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionFailures_BuildStationFailureCodes_BuildStationFailureCodeId",
                table: "InspectionFailures");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionFailures_FailureTypes_FailureTypeId",
                table: "InspectionFailures");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_Stations_StationId",
                table: "Inspections");

            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_WorkOrders_WorkOrderId",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_Inspections_WorkOrderId",
                table: "Inspections");

            migrationBuilder.DropIndex(
                name: "IX_InspectionFailures_FailureTypeId",
                table: "InspectionFailures");

            migrationBuilder.DropColumn(
                name: "WorkOrderId",
                table: "Inspections");

            migrationBuilder.DropColumn(
                name: "FailureTypeId",
                table: "InspectionFailures");

            migrationBuilder.AlterColumn<int>(
                name: "StationId",
                table: "Inspections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildStationFailureCodeId",
                table: "InspectionFailures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_Stations_StationId",
                table: "Inspections",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
