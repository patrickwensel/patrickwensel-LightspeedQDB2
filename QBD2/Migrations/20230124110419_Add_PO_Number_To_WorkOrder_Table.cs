using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Add_PO_Number_To_WorkOrder_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PONumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "0e9f368b-3a92-40da-bba5-8c5a9472a572");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "7e7a2183-425c-4ea7-8d08-83da6ad0921f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "cd3ffffd-994e-4b19-a788-5c95285142c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "767086c1-6474-43df-b987-bad11433d392");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "cb600ffc-0a68-4c35-8bbf-0ee56df3c139", "c0df3907-a2d7-400f-8a23-583574cfa1d3", "ApplicationRole", "WorkOrderAdmin", "WORKORDERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2390b056-c508-42c4-9526-1dffd1d5c7e3", "a3106f28-c4d3-4d15-aba3-1b74ef44fb53" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb600ffc-0a68-4c35-8bbf-0ee56df3c139");

            migrationBuilder.DropColumn(
                name: "PONumber",
                table: "WorkOrders");

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
    }
}
