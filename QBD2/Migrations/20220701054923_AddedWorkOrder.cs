using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddedWorkOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkOrderPriorities",
                columns: table => new
                {
                    WorkOrderPriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderPriorities", x => x.WorkOrderPriorityId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatuses",
                columns: table => new
                {
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatuses", x => x.WorkOrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTypes",
                columns: table => new
                {
                    WorkOrderTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTypes", x => x.WorkOrderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkOrderTypeId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderPriorityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.WorkOrderId);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderPriorities_WorkOrderPriorityID",
                        column: x => x.WorkOrderPriorityID,
                        principalTable: "WorkOrderPriorities",
                        principalColumn: "WorkOrderPriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderStatuses_WorkOrderStatusId",
                        column: x => x.WorkOrderStatusId,
                        principalTable: "WorkOrderStatuses",
                        principalColumn: "WorkOrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId",
                        column: x => x.WorkOrderTypeId,
                        principalTable: "WorkOrderTypes",
                        principalColumn: "WorkOrderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "9ee610c9-d5e1-4a1f-8d59-a350a1742463");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "6c8da5a2-9429-427b-82d8-950f00e998ae");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderPriorityID",
                table: "WorkOrders",
                column: "WorkOrderPriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderStatusId",
                table: "WorkOrders",
                column: "WorkOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderTypeId",
                table: "WorkOrders",
                column: "WorkOrderTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "WorkOrderPriorities");

            migrationBuilder.DropTable(
                name: "WorkOrderStatuses");

            migrationBuilder.DropTable(
                name: "WorkOrderTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "9b388acd-e16c-4a63-ad1d-54d784465817");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f8ef4c64-1ae8-4258-b0bf-78874fc70ba2");
        }
    }
}
