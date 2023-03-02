using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class WorkOrderStatuses_Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "2d49808a-3f71-48b6-b006-4e03f0333faf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "5c712c22-3c1a-414b-b38d-1d72b66c9d46");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb600ffc-0a68-4c35-8bbf-0ee56df3c139",
                column: "ConcurrencyStamp",
                value: "db66e3a8-e66f-4f42-a8dd-f46569171e9d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "af45cc42-261e-43fe-97c0-20410bd2139e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "027d3d65-45a3-4041-8fa6-ccb80b55fc7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a3e0e4f-aef6-4027-bd59-6ba6996804a4", "3d5ea4bd-8f77-45e8-96f6-613678ccc01c" });

            migrationBuilder.InsertData(
                table: "WorkOrderStatuses",
                columns: new[] { "WorkOrderStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "InProgress" },
                    { 3, "Completed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkOrderStatuses",
                keyColumn: "WorkOrderStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkOrderStatuses",
                keyColumn: "WorkOrderStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkOrderStatuses",
                keyColumn: "WorkOrderStatusId",
                keyValue: 3);

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
                keyValue: "cb600ffc-0a68-4c35-8bbf-0ee56df3c139",
                column: "ConcurrencyStamp",
                value: "c0df3907-a2d7-400f-8a23-583574cfa1d3");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2390b056-c508-42c4-9526-1dffd1d5c7e3", "a3106f28-c4d3-4d15-aba3-1b74ef44fb53" });
        }
    }
}
