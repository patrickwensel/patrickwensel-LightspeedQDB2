using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class addBuildStationInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleteBuildStation",
                table: "WorkOrderParts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BuildStationInspections",
                columns: table => new
                {
                    BuildStationInspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<bool>(type: "bit", nullable: false),
                    GeneralComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStationInspections", x => x.BuildStationInspectionId);
                    table.ForeignKey(
                        name: "FK_BuildStationInspections_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildStationInspections_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildStationInspections_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BuildStationInspectionFailures",
                columns: table => new
                {
                    BuildStationInspectionFailureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildStationInspectionId = table.Column<int>(type: "int", nullable: false),
                    FailureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStationInspectionFailures", x => x.BuildStationInspectionFailureId);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionFailures_BuildStationInspections_BuildStationInspectionId",
                        column: x => x.BuildStationInspectionId,
                        principalTable: "BuildStationInspections",
                        principalColumn: "BuildStationInspectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionFailures_FailureTypes_FailureTypeId",
                        column: x => x.FailureTypeId,
                        principalTable: "FailureTypes",
                        principalColumn: "FailureTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "0c206ba2-a7ef-4c6b-a718-8fb8504562e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "a22c6ac3-92e9-4421-8c78-f81d3efa0b2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "e837af98-3dc0-4e6b-bb65-c4a2ec3fe9fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "e972b40b-b9a0-4c3a-8c43-a7c287876d9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca905fc3-ae8a-434e-8739-030a083ef7cd", "e8eff8a7-da5d-4ea0-b6fc-c4d313b57b74" });

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionFailures_BuildStationInspectionId",
                table: "BuildStationInspectionFailures",
                column: "BuildStationInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionFailures_FailureTypeId",
                table: "BuildStationInspectionFailures",
                column: "FailureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspections_BuildStationId",
                table: "BuildStationInspections",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspections_PartId",
                table: "BuildStationInspections",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspections_WorkOrderId",
                table: "BuildStationInspections",
                column: "WorkOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildStationInspectionFailures");

            migrationBuilder.DropTable(
                name: "BuildStationInspections");

            migrationBuilder.DropColumn(
                name: "IsCompleteBuildStation",
                table: "WorkOrderParts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "4f47da87-6ae4-4fbe-9f8a-27de37d74ce9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "556dad75-a05f-436f-acf9-624fecff9591");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f191361f-bd4a-411b-8e0c-fdab67e1c06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "4ca306b8-10f0-431e-9b57-374a683faaf8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1bbdd6c-a86f-4759-8f2c-cc56f5480e9f", "bcbbfb77-980c-4eed-8637-05aa4b80dc0c" });
        }
    }
}
