using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddUpdateDateColumnInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Inspections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "8d4e7248-d1ff-40b1-9121-d81a2c609abe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f1aa1ea3-f0c8-44a3-8b7f-284a276b13c3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Inspections");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "477bc6db-ffae-4e27-97e8-6eba75c300ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "7ab30284-3dd3-4317-8c66-2b07d5e1435c");
        }
    }
}
