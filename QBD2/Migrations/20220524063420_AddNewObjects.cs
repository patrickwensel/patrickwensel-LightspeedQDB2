using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddNewObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FailureCodes",
                columns: table => new
                {
                    FailureCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureCodes", x => x.FailureCodeId);
                });

            migrationBuilder.CreateTable(
                name: "PartStatuses",
                columns: table => new
                {
                    PartStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartStatuses", x => x.PartStatusId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "4453e875-b16e-4046-baff-3b335cfb5a2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "d1d2b7d6-cf83-4cf3-9d59-547a9b7c14d8");

            migrationBuilder.InsertData(
                table: "FailureCodes",
                columns: new[] { "FailureCodeId", "Name" },
                values: new object[,]
                {
                    { 1, "Battery Box" },
                    { 2, "Active, Comm Audio" },
                    { 3, "Cable" },
                    { 4, "Other Noise" },
                    { 5, "Headband Sliders" }
                });

            migrationBuilder.InsertData(
                table: "GLCodes",
                columns: new[] { "GLCodeId", "Name" },
                values: new object[,]
                {
                    { 1, "5471 - Refurbish Parts" },
                    { 2, "5490 - Cost of Service Parts" },
                    { 3, "5493 - Conversion Costs" }
                });

            migrationBuilder.InsertData(
                table: "PartStatuses",
                columns: new[] { "PartStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Removed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FailureCodes");

            migrationBuilder.DropTable(
                name: "PartStatuses");

            migrationBuilder.DeleteData(
                table: "GLCodes",
                keyColumn: "GLCodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GLCodes",
                keyColumn: "GLCodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GLCodes",
                keyColumn: "GLCodeId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "c68d5dcd-6c4b-41fc-8665-64fd37e2a91a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "0ef0520f-d14b-4cb9-ada1-bdb9612a5ed2");
        }
    }
}
