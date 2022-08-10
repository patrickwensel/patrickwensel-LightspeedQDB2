using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Add_Build_Station_Failure_Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildStationFailureCodes",
                columns: table => new
                {
                    BuildStationFailureCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStationFailureCodes", x => x.BuildStationFailureCodeId);
                    table.ForeignKey(
                        name: "FK_BuildStationFailureCodes_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "12936357-7ce4-4b98-acf1-7d56301a3c14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "5b467704-f348-48c0-9efd-04b6f786d3e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "917b6ad9-34c4-4731-ae30-4f8f074359f5", "f4f2f6ff-5565-4ef2-ac52-29336d1f6b1a" });

            migrationBuilder.CreateIndex(
                name: "IX_BuildStationFailureCodes_BuildStationId",
                table: "BuildStationFailureCodes",
                column: "BuildStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildStationFailureCodes");

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
