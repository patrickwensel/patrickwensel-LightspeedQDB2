using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Inspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertDeviations",
                columns: table => new
                {
                    AlertDeviationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertDeviations", x => x.AlertDeviationId);
                });

            migrationBuilder.CreateTable(
                name: "FailureTypePrimaries",
                columns: table => new
                {
                    FailureTypePrimaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureTypePrimaries", x => x.FailureTypePrimaryId);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<bool>(type: "bit", nullable: false),
                    GeneralComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.InspectionId);
                    table.ForeignKey(
                        name: "FK_Inspections_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspections_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartAlertDeviations",
                columns: table => new
                {
                    PartAlertDeviationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    AlertDeviationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartAlertDeviations", x => x.PartAlertDeviationId);
                    table.ForeignKey(
                        name: "FK_PartAlertDeviations_AlertDeviations_AlertDeviationId",
                        column: x => x.AlertDeviationId,
                        principalTable: "AlertDeviations",
                        principalColumn: "AlertDeviationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartAlertDeviations_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailureTypes",
                columns: table => new
                {
                    FailureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureTypePrimaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureTypes", x => x.FailureTypeId);
                    table.ForeignKey(
                        name: "FK_FailureTypes_FailureTypePrimaries_FailureTypePrimaryId",
                        column: x => x.FailureTypePrimaryId,
                        principalTable: "FailureTypePrimaries",
                        principalColumn: "FailureTypePrimaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionFailures",
                columns: table => new
                {
                    InspectionFailureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    FailureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionFailures", x => x.InspectionFailureId);
                    table.ForeignKey(
                        name: "FK_InspectionFailures_FailureTypes_FailureTypeId",
                        column: x => x.FailureTypeId,
                        principalTable: "FailureTypes",
                        principalColumn: "FailureTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionFailures_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "InspectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlertDeviations",
                columns: new[] { "AlertDeviationId", "Name" },
                values: new object[,]
                {
                    { 1, "Some Alert" },
                    { 2, "Some Deviation" }
                });

            migrationBuilder.InsertData(
                table: "FailureTypePrimaries",
                columns: new[] { "FailureTypePrimaryId", "Name" },
                values: new object[,]
                {
                    { 1, "Cosmetic" },
                    { 2, "Mechanical" },
                    { 3, "Power" },
                    { 4, "ANR" },
                    { 5, "Comms / Audio / BT" }
                });

            migrationBuilder.InsertData(
                table: "FailureTypes",
                columns: new[] { "FailureTypeId", "FailureTypePrimaryId", "Name" },
                values: new object[] { 1, 1, "Color" });

            migrationBuilder.CreateIndex(
                name: "IX_FailureTypes_FailureTypePrimaryId",
                table: "FailureTypes",
                column: "FailureTypePrimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionFailures_FailureTypeId",
                table: "InspectionFailures",
                column: "FailureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionFailures_InspectionId",
                table: "InspectionFailures",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_PartId",
                table: "Inspections",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_StationId",
                table: "Inspections",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAlertDeviations_AlertDeviationId",
                table: "PartAlertDeviations",
                column: "AlertDeviationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAlertDeviations_PartId",
                table: "PartAlertDeviations",
                column: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionFailures");

            migrationBuilder.DropTable(
                name: "PartAlertDeviations");

            migrationBuilder.DropTable(
                name: "FailureTypes");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "AlertDeviations");

            migrationBuilder.DropTable(
                name: "FailureTypePrimaries");
        }
    }
}
