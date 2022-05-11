using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class UpdateDeviation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartDescription",
                table: "Deviations",
                newName: "VendorWIP");

            migrationBuilder.RenameColumn(
                name: "ItemPartNumber",
                table: "Deviations",
                newName: "VendorSVPART");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Deviations",
                newName: "VendorSEVE");

            migrationBuilder.AddColumn<string>(
                name: "LSA2",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LSAFGI",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LSASEVE",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LSASVPART",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LSAWIP",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Deviations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vendor2",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Vendor3FGI",
                table: "Deviations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "6e7336f6-27a8-4bfe-9feb-a64d7e7569f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "ca4f3aae-3420-49ba-b12c-5acceb90c985");

            migrationBuilder.CreateIndex(
                name: "IX_Deviations_PartId",
                table: "Deviations",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deviations_Parts_PartId",
                table: "Deviations",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deviations_Parts_PartId",
                table: "Deviations");

            migrationBuilder.DropIndex(
                name: "IX_Deviations_PartId",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "LSA2",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "LSAFGI",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "LSASEVE",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "LSASVPART",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "LSAWIP",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "Vendor2",
                table: "Deviations");

            migrationBuilder.DropColumn(
                name: "Vendor3FGI",
                table: "Deviations");

            migrationBuilder.RenameColumn(
                name: "VendorWIP",
                table: "Deviations",
                newName: "PartDescription");

            migrationBuilder.RenameColumn(
                name: "VendorSVPART",
                table: "Deviations",
                newName: "ItemPartNumber");

            migrationBuilder.RenameColumn(
                name: "VendorSEVE",
                table: "Deviations",
                newName: "Item");

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
        }
    }
}
