using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Add_IsCompleteBuildStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleteBuildStation",
                table: "BuildStationInspections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "1f80c3ab-86d6-44b2-ae99-5c21baa25922");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "3f3c26a7-88de-47c7-aaf8-6244ed199abe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "8bc95e58-c511-47f7-93ac-b35e7991c773");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "633d930b-cd6c-4647-87d1-369f35560a56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66b65be8-a765-4fdf-9d9b-9c550f2246fb", "27da4677-8530-4ae7-b90c-f2812a37ad24" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleteBuildStation",
                table: "BuildStationInspections");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "0c206ba2-a7ef-4c6b-a718-8fb8504562e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "a22c6ac3-92e9-4421-8c78-f81d3efa0b2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "e837af98-3dc0-4e6b-bb65-c4a2ec3fe9fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "e972b40b-b9a0-4c3a-8c43-a7c287876d9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca905fc3-ae8a-434e-8739-030a083ef7cd", "e8eff8a7-da5d-4ea0-b6fc-c4d313b57b74" });
        }
    }
}
