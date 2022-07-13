using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddedBuildTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildTemplateId",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildStations",
                columns: table => new
                {
                    BuildStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStations", x => x.BuildStationId);
                });

            migrationBuilder.CreateTable(
                name: "BuildTemplates",
                columns: table => new
                {
                    BuildTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTemplates", x => x.BuildTemplateId);
                    table.ForeignKey(
                        name: "FK_BuildTemplates_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildTemplateParts",
                columns: table => new
                {
                    BuildTemplatePartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTemplateId = table.Column<int>(type: "int", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: false),
                    SerialNumberRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTemplateParts", x => x.BuildTemplatePartId);
                    table.ForeignKey(
                        name: "FK_BuildTemplateParts_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTemplateParts_BuildTemplates_BuildTemplateId",
                        column: x => x.BuildTemplateId,
                        principalTable: "BuildTemplates",
                        principalColumn: "BuildTemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTemplateParts_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_BuildTemplateId",
                table: "WorkOrders",
                column: "BuildTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateParts_BuildStationId",
                table: "BuildTemplateParts",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateParts_BuildTemplateId",
                table: "BuildTemplateParts",
                column: "BuildTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateParts_MasterPartId",
                table: "BuildTemplateParts",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplates_MasterPartId",
                table: "BuildTemplates",
                column: "MasterPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_BuildTemplates_BuildTemplateId",
                table: "WorkOrders",
                column: "BuildTemplateId",
                principalTable: "BuildTemplates",
                principalColumn: "BuildTemplateId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_BuildTemplates_BuildTemplateId",
                table: "WorkOrders");

            migrationBuilder.DropTable(
                name: "BuildTemplateParts");

            migrationBuilder.DropTable(
                name: "BuildStations");

            migrationBuilder.DropTable(
                name: "BuildTemplates");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_BuildTemplateId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "BuildTemplateId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "WorkOrders");

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
        }
    }
}
