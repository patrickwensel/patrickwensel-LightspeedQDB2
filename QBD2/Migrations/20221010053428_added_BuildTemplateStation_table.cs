using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class added_BuildTemplateStation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildTemplateStations",
                columns: table => new
                {
                    BuildTemplateStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTemplateId = table.Column<int>(type: "int", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTemplateStations", x => x.BuildTemplateStationId);
                    table.ForeignKey(
                        name: "FK_BuildTemplateStations_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTemplateStations_BuildTemplates_BuildTemplateId",
                        column: x => x.BuildTemplateId,
                        principalTable: "BuildTemplates",
                        principalColumn: "BuildTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "cb56905c-9c7f-471d-98ac-8fcd2eb5b44e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "c66baa22-8d9b-4c76-953e-e0afeb8d15e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "1aaa172d-e2ef-4a84-bf9a-cbb2b44e53be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "0d4012d1-de01-4276-8f08-0289e34c5f83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2769fb3a-0d06-4f82-902d-74f6a32e665e", "a2571dea-9223-47f7-8f4d-0ab534286fa9" });

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateStations_BuildStationId",
                table: "BuildTemplateStations",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateStations_BuildTemplateId",
                table: "BuildTemplateStations",
                column: "BuildTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildTemplateStations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "24c4ff91-cea7-4e2a-84b8-7dc8fd957857");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "eff63e33-38db-458b-88e6-62bc83d9b02a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f8e37d5c-36f0-4adb-8173-8b2593d70dac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "640bf461-784a-40a8-9361-f3764833c00e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d0f5e216-9abd-469e-8161-96b622eb58d1", "910383c5-4fb0-418d-9bfa-f24a1c8b78b1" });
        }
    }
}
