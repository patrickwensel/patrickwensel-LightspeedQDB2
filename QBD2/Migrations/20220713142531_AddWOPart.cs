using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddWOPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildStationId",
                table: "Parts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SerialNumberRequired",
                table: "Parts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "WorkOrderParts",
                columns: table => new
                {
                    WorkOrderPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderParts", x => x.WorkOrderPartId);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "0fee12c9-02c2-4c13-a2b2-fe487835c2a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "738c58f2-2b60-4218-883e-14f39337c201");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_BuildStationId",
                table: "Parts",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_PartId",
                table: "WorkOrderParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_WorkOrderId",
                table: "WorkOrderParts",
                column: "WorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_BuildStations_BuildStationId",
                table: "Parts",
                column: "BuildStationId",
                principalTable: "BuildStations",
                principalColumn: "BuildStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_BuildStations_BuildStationId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "WorkOrderParts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_BuildStationId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "BuildStationId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "SerialNumberRequired",
                table: "Parts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "41c7a2cb-f69e-4e66-a9fc-5429ee5d12b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "ac95acb4-4af1-4ea2-bb5e-3673df752116");
        }
    }
}
