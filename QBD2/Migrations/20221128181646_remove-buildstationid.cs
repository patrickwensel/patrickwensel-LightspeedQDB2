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

            migrationBuilder.AlterColumn<int>(
                name: "BuildStationId",
                table: "BuildTemplates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "6bebf5d4-13f5-4fb2-bbc7-c360a329dc8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "f40e1df0-f2bb-407a-ab32-18c678a0b18e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "9172c649-ba60-486d-a5ac-6613be849f17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "04836a74-c0bd-4c58-b12b-5273b4dff2d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1c1bbf8b-1c30-4b86-af6b-784b731adad7", "13edaafc-34d1-42a4-b4f9-7c8df2c3992e" });

            migrationBuilder.AddForeignKey(
                name: "FK_BuildTemplates_BuildStations_BuildStationId",
                table: "BuildTemplates",
                column: "BuildStationId",
                principalTable: "BuildStations",
                principalColumn: "BuildStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildTemplates_BuildStations_BuildStationId",
                table: "BuildTemplates");

            migrationBuilder.AlterColumn<int>(
                name: "BuildStationId",
                table: "BuildTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
