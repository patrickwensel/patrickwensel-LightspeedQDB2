using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBD2.Migrations
{
    public partial class AddSeedDataForScarcar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScarCarCategories",
                columns: table => new
                {
                    ScarCarCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarCategories", x => x.ScarCarCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarImpacts",
                columns: table => new
                {
                    ScarCarImpactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarImpacts", x => x.ScarCarImpactId);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarPriorities",
                columns: table => new
                {
                    ScarCarPriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarPriorities", x => x.ScarCarPriorityId);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarProjects",
                columns: table => new
                {
                    ScarCarProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarProjects", x => x.ScarCarProjectId);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarResolutions",
                columns: table => new
                {
                    ScarCarResolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarResolutions", x => x.ScarCarResolutionId);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarStatuses",
                columns: table => new
                {
                    ScarCarStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarStatuses", x => x.ScarCarStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ScarCar",
                columns: table => new
                {
                    ScarCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Containment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootCause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScarCarImpactId = table.Column<int>(type: "int", nullable: false),
                    ScarCarResolutionId = table.Column<int>(type: "int", nullable: false),
                    ScarCarStatusId = table.Column<int>(type: "int", nullable: false),
                    ScarCarPriorityId = table.Column<int>(type: "int", nullable: false),
                    ScarCarCategoryId = table.Column<int>(type: "int", nullable: false),
                    ScarCarProjectId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCar", x => x.ScarCarId);
                    table.ForeignKey(
                        name: "FK_ScarCar_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCar_ScarCarCategories_ScarCarCategoryId",
                        column: x => x.ScarCarCategoryId,
                        principalTable: "ScarCarCategories",
                        principalColumn: "ScarCarCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCar_ScarCarImpacts_ScarCarImpactId",
                        column: x => x.ScarCarImpactId,
                        principalTable: "ScarCarImpacts",
                        principalColumn: "ScarCarImpactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCar_ScarCarPriorities_ScarCarPriorityId",
                        column: x => x.ScarCarPriorityId,
                        principalTable: "ScarCarPriorities",
                        principalColumn: "ScarCarPriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCar_ScarCarProjects_ScarCarProjectId",
                        column: x => x.ScarCarProjectId,
                        principalTable: "ScarCarProjects",
                        principalColumn: "ScarCarProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCar_ScarCarResolutions_ScarCarResolutionId",
                        column: x => x.ScarCarResolutionId,
                        principalTable: "ScarCarResolutions",
                        principalColumn: "ScarCarResolutionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCar_ScarCarStatuses_ScarCarStatusId",
                        column: x => x.ScarCarStatusId,
                        principalTable: "ScarCarStatuses",
                        principalColumn: "ScarCarStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarAttachments",
                columns: table => new
                {
                    ScarCarAttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScarCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarAttachments", x => x.ScarCarAttachmentId);
                    table.ForeignKey(
                        name: "FK_ScarCarAttachments_ScarCar_ScarCarId",
                        column: x => x.ScarCarId,
                        principalTable: "ScarCar",
                        principalColumn: "ScarCarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScarCarNotes",
                columns: table => new
                {
                    ScarCarProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ScarCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScarCarNotes", x => x.ScarCarProjectId);
                    table.ForeignKey(
                        name: "FK_ScarCarNotes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScarCarNotes_ScarCar_ScarCarId",
                        column: x => x.ScarCarId,
                        principalTable: "ScarCar",
                        principalColumn: "ScarCarId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "9b388acd-e16c-4a63-ad1d-54d784465817");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "f8ef4c64-1ae8-4258-b0bf-78874fc70ba2");

            migrationBuilder.InsertData(
                table: "ScarCarCategories",
                columns: new[] { "ScarCarCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "CIA" },
                    { 2, "CAR - Minor" },
                    { 3, "CAR - Major" },
                    { 4, "SCAR" },
                    { 5, "IAR" }
                });

            migrationBuilder.InsertData(
                table: "ScarCarImpacts",
                columns: new[] { "ScarCarImpactId", "Name" },
                values: new object[,]
                {
                    { 1, "Low" },
                    { 2, "Medium" },
                    { 3, "High" }
                });

            migrationBuilder.InsertData(
                table: "ScarCarPriorities",
                columns: new[] { "ScarCarPriorityId", "Name" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" },
                    { 5, "5" },
                    { 6, "6" },
                    { 7, "7" },
                    { 8, "8" },
                    { 9, "9" },
                    { 10, "10" }
                });

            migrationBuilder.InsertData(
                table: "ScarCarProjects",
                columns: new[] { "ScarCarProjectId", "Name" },
                values: new object[,]
                {
                    { 1, "Process" },
                    { 2, "Performance" },
                    { 3, "Manufacturability" },
                    { 4, "Test" }
                });

            migrationBuilder.InsertData(
                table: "ScarCarStatuses",
                columns: new[] { "ScarCarStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "New" },
                    { 3, "Resolved" },
                    { 4, "Closed" },
                    { 5, "Deferred" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ApplicationUserId",
                table: "ScarCar",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ScarCarCategoryId",
                table: "ScarCar",
                column: "ScarCarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ScarCarImpactId",
                table: "ScarCar",
                column: "ScarCarImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ScarCarPriorityId",
                table: "ScarCar",
                column: "ScarCarPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ScarCarProjectId",
                table: "ScarCar",
                column: "ScarCarProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ScarCarResolutionId",
                table: "ScarCar",
                column: "ScarCarResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCar_ScarCarStatusId",
                table: "ScarCar",
                column: "ScarCarStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCarAttachments_ScarCarId",
                table: "ScarCarAttachments",
                column: "ScarCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCarNotes_ApplicationUserId",
                table: "ScarCarNotes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScarCarNotes_ScarCarId",
                table: "ScarCarNotes",
                column: "ScarCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScarCarAttachments");

            migrationBuilder.DropTable(
                name: "ScarCarNotes");

            migrationBuilder.DropTable(
                name: "ScarCar");

            migrationBuilder.DropTable(
                name: "ScarCarCategories");

            migrationBuilder.DropTable(
                name: "ScarCarImpacts");

            migrationBuilder.DropTable(
                name: "ScarCarPriorities");

            migrationBuilder.DropTable(
                name: "ScarCarProjects");

            migrationBuilder.DropTable(
                name: "ScarCarResolutions");

            migrationBuilder.DropTable(
                name: "ScarCarStatuses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22b3bff1-cfd2-4075-a90f-827380656873",
                column: "ConcurrencyStamp",
                value: "73d7a493-9ee9-4879-9dfa-c6d7ea4e9654");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                column: "ConcurrencyStamp",
                value: "c5c6f450-764d-40e6-a830-20f7a898d8cc");
        }
    }
}
