using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Added_BuildStationId_In_BuildTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "1485872a-45a9-4e93-9a48-cecbe2e4a612");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "d17239d3-b23b-4279-91a9-bc7e9e4f5130");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fe323b3-225e-4317-8e78-2705881595de", "a119500b-1e9e-4b2e-9a84-f60f9a0d460f" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "f3c55f20-9e41-44be-9ef1-1842ceaebd9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "03d2a433-98b1-4e2f-8036-cbfc9603db5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e97b939-49c0-4e1e-8376-cb98348103bb",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bfb3419-77a9-48a6-b234-8e132e48c638", "43a92ab8-dfcd-43e0-9462-a1940b8cfb49" });
        }
    }
}
