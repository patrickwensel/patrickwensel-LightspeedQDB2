using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class added_History_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildStationInspectionHistories",
                columns: table => new
                {
                    BuildStationInspectionHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<bool>(type: "bit", nullable: false),
                    GeneralComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleteBuildStation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStationInspectionHistories", x => x.BuildStationInspectionHistoryId);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionHistories_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionHistories_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionHistories_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "WorkOrderId");
                });

            migrationBuilder.CreateTable(
                name: "BuildStationInspectionFailureHistories",
                columns: table => new
                {
                    BuildStationInspectionFailureHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildStationInspectionHistoryId = table.Column<int>(type: "int", nullable: false),
                    FailureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStationInspectionFailureHistories", x => x.BuildStationInspectionFailureHistoryId);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionFailureHistories_BuildStationInspectionHistories_BuildStationInspectionHistoryId",
                        column: x => x.BuildStationInspectionHistoryId,
                        principalTable: "BuildStationInspectionHistories",
                        principalColumn: "BuildStationInspectionHistoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildStationInspectionFailureHistories_FailureTypes_FailureTypeId",
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
                value: "3dd07273-c874-48b8-b81e-e97bc2edcfd8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "bb6f035b-3eb6-4a9a-99e9-fae6d36baf56");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb600ffc-0a68-4c35-8bbf-0ee56df3c139",
                column: "ConcurrencyStamp",
                value: "7a39503d-adf8-4f70-96cc-719ab64a358c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "a2e9488a-fb52-4c20-b579-d706ffe0c7e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "5f89fca1-3144-4096-8e67-c60ea3976928");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44b440ed-7710-40a4-909d-b24af60562f7", "4c1d0f64-c8a0-443e-9e2d-986286cc45ef" });

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionFailureHistories_BuildStationInspectionHistoryId",
                table: "BuildStationInspectionFailureHistories",
                column: "BuildStationInspectionHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionFailureHistories_FailureTypeId",
                table: "BuildStationInspectionFailureHistories",
                column: "FailureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionHistories_BuildStationId",
                table: "BuildStationInspectionHistories",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionHistories_PartId",
                table: "BuildStationInspectionHistories",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationInspectionHistories_WorkOrderId",
                table: "BuildStationInspectionHistories",
                column: "WorkOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildStationInspectionFailureHistories");

            migrationBuilder.DropTable(
                name: "BuildStationInspectionHistories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "2d49808a-3f71-48b6-b006-4e03f0333faf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "5c712c22-3c1a-414b-b38d-1d72b66c9d46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb600ffc-0a68-4c35-8bbf-0ee56df3c139",
                column: "ConcurrencyStamp",
                value: "db66e3a8-e66f-4f42-a8dd-f46569171e9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "af45cc42-261e-43fe-97c0-20410bd2139e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "027d3d65-45a3-4041-8fa6-ccb80b55fc7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a3e0e4f-aef6-4027-bd59-6ba6996804a4", "3d5ea4bd-8f77-45e8-96f6-613678ccc01c" });
        }
    }
}
