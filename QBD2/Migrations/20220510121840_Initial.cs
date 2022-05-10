using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADLogin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FailureTypePrimaries",
                columns: table => new
                {
                    FailureTypePrimaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureTypePrimaries", x => x.FailureTypePrimaryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductFamilies",
                columns: table => new
                {
                    ProductFamilyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.ProductFamilyId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FailureTypes",
                columns: table => new
                {
                    FailureTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FailureTypePrimaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FailureTypes", x => x.FailureTypeId);
                    table.ForeignKey(
                        name: "FK_FailureTypes_FailureTypePrimaries_FailureTypePrimaryId",
                        column: x => x.FailureTypePrimaryId,
                        principalTable: "FailureTypePrimaries",
                        principalColumn: "FailureTypePrimaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterParts",
                columns: table => new
                {
                    MasterPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Itemno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductFamilyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterParts", x => x.MasterPartId);
                    table.ForeignKey(
                        name: "FK_MasterParts_ProductFamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "ProductFamilies",
                        principalColumn: "ProductFamilyId");
                });

            migrationBuilder.CreateTable(
                name: "Deviations",
                columns: table => new
                {
                    DeviationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Originator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonforManufacturingDeviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ECORequired = table.Column<bool>(type: "bit", nullable: false),
                    ECONumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentCorrectiveAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deviations", x => x.DeviationId);
                    table.ForeignKey(
                        name: "FK_Deviations_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false),
                    ParentPartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_Parts_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Parts_ParentPartId",
                        column: x => x.ParentPartId,
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pass = table.Column<bool>(type: "bit", nullable: false),
                    GeneralComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.InspectionId);
                    table.ForeignKey(
                        name: "FK_Inspections_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspections_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartDeviations",
                columns: table => new
                {
                    PartDeviationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    DeviationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartDeviations", x => x.PartDeviationId);
                    table.ForeignKey(
                        name: "FK_PartDeviations_Deviations_DeviationId",
                        column: x => x.DeviationId,
                        principalTable: "Deviations",
                        principalColumn: "DeviationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartDeviations_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionFailures",
                columns: table => new
                {
                    InspectionFailureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    FailureTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionFailures", x => x.InspectionFailureId);
                    table.ForeignKey(
                        name: "FK_InspectionFailures_FailureTypes_FailureTypeId",
                        column: x => x.FailureTypeId,
                        principalTable: "FailureTypes",
                        principalColumn: "FailureTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionFailures_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "InspectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22b3bff1-cfd2-4075-a90f-827380656873", "74af231e-a933-43a3-a4db-ba2e6f8a1264", "ApplicationRole", "User", "USER" },
                    { "e4e7188b-6ecb-4278-aeee-17271f20d7ce", "236ca829-0745-4803-a77d-512c0e25a53e", "ApplicationRole", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "FailureTypePrimaries",
                columns: new[] { "FailureTypePrimaryId", "Name" },
                values: new object[,]
                {
                    { 1, "Cosmetic" },
                    { 2, "Mechanical" },
                    { 3, "Power" },
                    { 4, "ANR" },
                    { 5, "Comms / Audio / BT" }
                });

            migrationBuilder.InsertData(
                table: "MasterParts",
                columns: new[] { "MasterPartId", "Description", "Itemno", "PartNumber", "ProductFamilyId" },
                values: new object[,]
                {
                    { 2, "ASSY, PCB, ANR, LEFT", null, "200-00062-000", null },
                    { 3, "Faceplate, Left", null, "303-00059-100", null },
                    { 4, "ASSY, PCB, ANR, RIGHT", null, "200-00048-000", null },
                    { 5, "Faceplate, Right", null, "303-00060-100", null },
                    { 6, "PCBA, Control Box Lower", null, "200-00060-000", null },
                    { 7, "CONTROL BOX UPPER BOARD", null, "200-00043-000", null },
                    { 8, "ANR Mic - Grooved, Aluminum", null, "120-00008-101", null },
                    { 9, "DRIVER", null, "119-00002-100", null }
                });

            migrationBuilder.InsertData(
                table: "ProductFamilies",
                columns: new[] { "ProductFamilyId", "Name" },
                values: new object[] { 1, "Delta Zulu" });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "Name" },
                values: new object[] { 1, "Final Inspection" });

            migrationBuilder.InsertData(
                table: "FailureTypes",
                columns: new[] { "FailureTypeId", "FailureTypePrimaryId", "Name" },
                values: new object[] { 1, 1, "Color" });

            migrationBuilder.InsertData(
                table: "MasterParts",
                columns: new[] { "MasterPartId", "Description", "Itemno", "PartNumber", "ProductFamilyId" },
                values: new object[] { 1, "Delta Zulu GA", null, "800-00025-001.2", 1 });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "MasterPartId", "ParentPartId", "SerialNumber" },
                values: new object[] { 1, 1, null, "808000406" });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "PartId", "MasterPartId", "ParentPartId", "SerialNumber" },
                values: new object[,]
                {
                    { 2, 2, 1, "71534*000135" },
                    { 3, 3, 1, "L51210055" },
                    { 4, 4, 1, "71543*000080" },
                    { 5, 5, 1, "R50210586" },
                    { 6, 6, 1, "71528*000047" },
                    { 7, 7, 1, "54658*000908" },
                    { 8, 8, 1, "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1" },
                    { 9, 9, 1, "2972833301*2792-20210413013*A219101*2021-12-20*8" },
                    { 10, 8, 1, "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1" },
                    { 11, 9, 1, "2972833301*2792-20210413013*A219101*2021-12-20*8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deviations_MasterPartId",
                table: "Deviations",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_FailureTypes_FailureTypePrimaryId",
                table: "FailureTypes",
                column: "FailureTypePrimaryId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionFailures_FailureTypeId",
                table: "InspectionFailures",
                column: "FailureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionFailures_InspectionId",
                table: "InspectionFailures",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_PartId",
                table: "Inspections",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_StationId",
                table: "Inspections",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterParts_ProductFamilyId",
                table: "MasterParts",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PartDeviations_DeviationId",
                table: "PartDeviations",
                column: "DeviationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartDeviations_PartId",
                table: "PartDeviations",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MasterPartId",
                table: "Parts",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ParentPartId",
                table: "Parts",
                column: "ParentPartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "InspectionFailures");

            migrationBuilder.DropTable(
                name: "PartDeviations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FailureTypes");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Deviations");

            migrationBuilder.DropTable(
                name: "FailureTypePrimaries");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "MasterParts");

            migrationBuilder.DropTable(
                name: "ProductFamilies");
        }
    }
}
