using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddItemno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "728b902f-675b-4f42-aa8f-7d5953cb2332");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "03c7d9e2-891d-4722-9876-32d391dbc216");

            migrationBuilder.UpdateData(
                table: "MasterParts",
                keyColumn: "MasterPartId",
                keyValue: 1,
                column: "Itemno",
                value: "800000250012");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "74af231e-a933-43a3-a4db-ba2e6f8a1264");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "236ca829-0745-4803-a77d-512c0e25a53e");

            migrationBuilder.UpdateData(
                table: "MasterParts",
                keyColumn: "MasterPartId",
                keyValue: 1,
                column: "Itemno",
                value: null);
        }
    }
}
