using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductFamilies",
                columns: table => new
                {
                    ProductFamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.ProductFamilyId);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "MasterParts",
                columns: table => new
                {
                    MasterPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFamilyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterParts", x => x.MasterPartId);
                    table.ForeignKey(
                        name: "FK_MasterParts_ProductFamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "ProductFamilies",
                        principalColumn: "ProductFamilyId");
                });

            migrationBuilder.InsertData(
                table: "MasterParts",
                columns: new[] { "MasterPartId", "Description", "PartNumber", "ProductFamilyId" },
                values: new object[,]
                {
                    { 2, "ASSY, PCB, ANR, LEFT", "200-00062-000", null },
                    { 3, "Faceplate, Left", "303-00059-100", null },
                    { 4, "ASSY, PCB, ANR, RIGHT", "200-00048-000", null },
                    { 5, "Faceplate, Right", "303-00060-100", null },
                    { 6, "PCBA, Control Box Lower", "200-00060-000", null },
                    { 7, "CONTROL BOX UPPER BOARD", "200-00043-000", null },
                    { 8, "ANR Mic - Grooved, Aluminum", "120-00008-101", null },
                    { 9, "DRIVER", "119-00002-100", null }
                });

            migrationBuilder.InsertData(
                table: "ProductFamilies",
                columns: new[] { "ProductFamilyId", "Name" },
                values: new object[] { 1, "Delta Zulu" });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "StationId", "Name" },
                values: new object[] { 1, "Final Inspection" });

            migrationBuilder.InsertData(
                table: "MasterParts",
                columns: new[] { "MasterPartId", "Description", "PartNumber", "ProductFamilyId" },
                values: new object[] { 1, "Delta Zulu GA", "800-00025-001.2", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MasterParts_ProductFamilyId",
                table: "MasterParts",
                column: "ProductFamilyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterParts");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "ProductFamilies");
        }
    }
}
