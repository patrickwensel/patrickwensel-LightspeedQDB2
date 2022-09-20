using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class UpdateRepairTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_FailureCodes_FailureCodeId",
                table: "Repairs");

            migrationBuilder.RenameColumn(
                name: "FailureCodeId",
                table: "Repairs",
                newName: "FailureTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_FailureCodeId",
                table: "Repairs",
                newName: "IX_Repairs_FailureTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_FailureTypes_FailureTypeId",
                table: "Repairs",
                column: "FailureTypeId",
                principalTable: "FailureTypes",
                principalColumn: "FailureTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_FailureTypes_FailureTypeId",
                table: "Repairs");

            migrationBuilder.RenameColumn(
                name: "FailureTypeId",
                table: "Repairs",
                newName: "FailureCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Repairs_FailureTypeId",
                table: "Repairs",
                newName: "IX_Repairs_FailureCodeId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "d303b4c3-9f9c-4c62-ba41-9766e574da6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec800c6-ea7e-4420-a583-91a23787a3af",
                column: "ConcurrencyStamp",
                value: "3d36c74d-994a-48d2-b7bd-bde431639a64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "0da56dc2-8362-477e-b4e8-842298cb6594");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77174e9-e942-4fc1-bdb5-20a5f318d2ed",
                column: "ConcurrencyStamp",
                value: "b774cb40-8490-4051-8f04-7a04ffa2ee76");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c13c1ecb-243c-4c29-be0e-fd24c139d1d8", "999b1988-98c0-40b9-9425-f03ddac51619" });

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_FailureCodes_FailureCodeId",
                table: "Repairs",
                column: "FailureCodeId",
                principalTable: "FailureCodes",
                principalColumn: "FailureCodeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
