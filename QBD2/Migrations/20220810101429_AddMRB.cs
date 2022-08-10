using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddMRB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MRBDispositions",
                columns: table => new
                {
                    MRBDispositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRBDispositions", x => x.MRBDispositionId);
                });

            migrationBuilder.CreateTable(
                name: "MRBs",
                columns: table => new
                {
                    MRBId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MRBDispositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRBs", x => x.MRBId);
                    table.ForeignKey(
                        name: "FK_MRBs_MRBDispositions_MRBDispositionId",
                        column: x => x.MRBDispositionId,
                        principalTable: "MRBDispositions",
                        principalColumn: "MRBDispositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "73f40a2e-6f47-458c-b759-d6b757d25839");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "d2dfa465-0282-4d12-8850-58d92de49d2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38bab316-32e7-46da-969e-c61d5cd06620", "1fa2abc4-e44b-4e84-a689-74c29b9561a3" });

            migrationBuilder.InsertData(
                table: "MRBDispositions",
                columns: new[] { "MRBDispositionId", "Name" },
                values: new object[,]
                {
                    { 1, "Review" },
                    { 2, "Rework" },
                    { 3, "Send to Vendor" },
                    { 4, "Scrap" },
                    { 5, "Eng Eval" },
                    { 6, "Use As Is" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MRBs_MRBDispositionId",
                table: "MRBs",
                column: "MRBDispositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MRBs");

            migrationBuilder.DropTable(
                name: "MRBDispositions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "315524be-76b6-4f5a-8b7a-984d1c7c5173");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "a66120c8-cad3-4bed-9cc8-b8be83758813");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a38ea1e2-2b9b-4e98-86b5-c82772a103bc", "277b511b-7a8a-4c44-83bf-6afaedaf2b90" });
        }
    }
}
