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
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
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

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false),
                    ParentPartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_Parts_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Parts_ParentPartId",
                        column: x => x.ParentPartId,
                        principalTable: "Parts",
                        principalColumn: "PartId");
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
                table: "Stations",
                columns: new[] { "StationId", "Name" },
                values: new object[] { 1, "Final Inspection" });

            migrationBuilder.InsertData(
                table: "MasterParts",
                columns: new[] { "MasterPartId", "Description", "PartNumber", "ProductFamilyId" },
                values: new object[] { 1, "Delta Zulu GA", "800-00025-001.2", 1 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "MasterPartId", "ParentPartId", "SerialNumber" },
                values: new object[] { 1, 1, null, "808000406" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "MasterPartId", "ParentPartId", "SerialNumber" },
                values: new object[,]
                {
                    { 2, 2, 1, "71534*000135" },
                    { 3, 3, 1, "L51210055" },
                    { 4, 4, 1, "71543*000080" },
                    { 5, 5, 1, "R50210586" },
                    { 6, 6, 1, "71528*000047" },
                    { 7, 7, 1, "54658*000908" },
                    { 8, 8, 1, "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1" },
                    { 9, 9, 1, "2972833301*2792-20210413013*A219101*2021-12-20*8" },
                    { 10, 8, 1, "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1" },
                    { 11, 9, 1, "2972833301*2792-20210413013*A219101*2021-12-20*8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasterParts_ProductFamilyId",
                table: "MasterParts",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MasterPartId",
                table: "Parts",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ParentPartId",
                table: "Parts",
                column: "ParentPartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "MasterParts");

            migrationBuilder.DropTable(
                name: "ProductFamilies");
        }
    }
}
