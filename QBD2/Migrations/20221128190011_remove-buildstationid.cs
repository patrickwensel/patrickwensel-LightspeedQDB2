using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class removebuildstationid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildTemplates_BuildStations_BuildStationId",
                table: "BuildTemplates");

            migrationBuilder.DropIndex(
                name: "IX_BuildTemplates_BuildStationId",
                table: "BuildTemplates");

            migrationBuilder.DropColumn(
                name: "BuildStationId",
                table: "BuildTemplates");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "4f47da87-6ae4-4fbe-9f8a-27de37d74ce9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "556dad75-a05f-436f-acf9-624fecff9591");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f191361f-bd4a-411b-8e0c-fdab67e1c06f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "4ca306b8-10f0-431e-9b57-374a683faaf8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1bbdd6c-a86f-4759-8f2c-cc56f5480e9f", "bcbbfb77-980c-4eed-8637-05aa4b80dc0c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildStationId",
                table: "BuildTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_BuildTemplates_BuildStationId",
                table: "BuildTemplates",
                column: "BuildStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildTemplates_BuildStations_BuildStationId",
                table: "BuildTemplates",
                column: "BuildStationId",
                principalTable: "BuildStations",
                principalColumn: "BuildStationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
