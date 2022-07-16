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
                name: "BuildStations",
                columns: table => new
                {
                    BuildStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStations", x => x.BuildStationId);
                });

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
                name: "GLCodes",
                columns: table => new
                {
                    GLCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLCodes", x => x.GLCodeId);
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
                name: "WorkOrderPriorities",
                columns: table => new
                {
                    WorkOrderPriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderPriorities", x => x.WorkOrderPriorityId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatuses",
                columns: table => new
                {
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatuses", x => x.WorkOrderStatusId);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTypes",
                columns: table => new
                {
                    WorkOrderTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTypes", x => x.WorkOrderTypeId);
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
                name: "Alerts",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonforManufacturingDeviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MasterPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_Alerts_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId");
                });

            migrationBuilder.CreateTable(
                name: "BuildTemplates",
                columns: table => new
                {
                    BuildTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTemplates", x => x.BuildTemplateId);
                    table.ForeignKey(
                        name: "FK_BuildTemplates_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false),
                    ParentPartId = table.Column<int>(type: "int", nullable: true),
                    PartStatusId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: true),
                    SerialNumberRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_Parts_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId");
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
                    table.ForeignKey(
                        name: "FK_Parts_PartStatuses_PartStatusId",
                        column: x => x.PartStatusId,
                        principalTable: "PartStatuses",
                        principalColumn: "PartStatusId");
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
                        principalColumn: "ScarCarId");
                });

            migrationBuilder.CreateTable(
                name: "BuildTemplateParts",
                columns: table => new
                {
                    BuildTemplatePartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTemplateId = table.Column<int>(type: "int", nullable: false),
                    MasterPartId = table.Column<int>(type: "int", nullable: false),
                    BuildStationId = table.Column<int>(type: "int", nullable: false),
                    SerialNumberRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTemplateParts", x => x.BuildTemplatePartId);
                    table.ForeignKey(
                        name: "FK_BuildTemplateParts_BuildStations_BuildStationId",
                        column: x => x.BuildStationId,
                        principalTable: "BuildStations",
                        principalColumn: "BuildStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTemplateParts_BuildTemplates_BuildTemplateId",
                        column: x => x.BuildTemplateId,
                        principalTable: "BuildTemplates",
                        principalColumn: "BuildTemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTemplateParts_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId");
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkOrderTypeId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderStatusId = table.Column<int>(type: "int", nullable: false),
                    WorkOrderPriorityID = table.Column<int>(type: "int", nullable: false),
                    BuildTemplateId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.WorkOrderId);
                    table.ForeignKey(
                        name: "FK_WorkOrders_BuildTemplates_BuildTemplateId",
                        column: x => x.BuildTemplateId,
                        principalTable: "BuildTemplates",
                        principalColumn: "BuildTemplateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderPriorities_WorkOrderPriorityID",
                        column: x => x.WorkOrderPriorityID,
                        principalTable: "WorkOrderPriorities",
                        principalColumn: "WorkOrderPriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderStatuses_WorkOrderStatusId",
                        column: x => x.WorkOrderStatusId,
                        principalTable: "WorkOrderStatuses",
                        principalColumn: "WorkOrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId",
                        column: x => x.WorkOrderTypeId,
                        principalTable: "WorkOrderTypes",
                        principalColumn: "WorkOrderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deviations",
                columns: table => new
                {
                    DeviationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Originator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonforManufacturingDeviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECORequired = table.Column<bool>(type: "bit", nullable: false),
                    ECONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentCorrectiveAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorSVPART = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorSEVE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorWIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor3FGI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSASVPART = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSASEVE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSA2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSAWIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LSAFGI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deviations", x => x.DeviationId);
                    table.ForeignKey(
                        name: "FK_Deviations_MasterParts_MasterPartId",
                        column: x => x.MasterPartId,
                        principalTable: "MasterParts",
                        principalColumn: "MasterPartId");
                    table.ForeignKey(
                        name: "FK_Deviations_Parts_PartId",
                        column: x => x.PartId,
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
                name: "PartAlerts",
                columns: table => new
                {
                    PartAlertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartAlerts", x => x.PartAlertId);
                    table.ForeignKey(
                        name: "FK_PartAlerts_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "AlertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartAlerts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GLCodeId = table.Column<int>(type: "int", nullable: false),
                    FailureCodeId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_Repairs_FailureCodes_FailureCodeId",
                        column: x => x.FailureCodeId,
                        principalTable: "FailureCodes",
                        principalColumn: "FailureCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_GLCodes_GLCodeId",
                        column: x => x.GLCodeId,
                        principalTable: "GLCodes",
                        principalColumn: "GLCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderParts",
                columns: table => new
                {
                    WorkOrderPartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrderId = table.Column<int>(type: "int", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderParts", x => x.WorkOrderPartId);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderParts_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "WorkOrderId");
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
                    { "22b3bff1-cfd2-4075-a90f-827380656873", "315524be-76b6-4f5a-8b7a-984d1c7c5173", "ApplicationRole", "User", "USER" },
                    { "e4e7188b-6ecb-4278-aeee-17271f20d7ce", "a66120c8-cad3-4bed-9cc8-b8be83758813", "ApplicationRole", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "ADLogin", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2e97b939-49c0-4e1e-8376-cb98348103bb", "DESKTOP-1HVSAG6\\pwens", 0, "a38ea1e2-2b9b-4e98-86b5-c82772a103bc", "ApplicationUser", "pwensel@hotmail.com", true, false, null, "PWENSEL@HOTMAIL.COM", "PWENSEL@HOTMAIL.COM", null, null, false, "277b511b-7a8a-4c44-83bf-6afaedaf2b90", false, "pwensel@hotmail.com" });

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

            migrationBuilder.InsertData(
                table: "ProductFamilies",
                columns: new[] { "ProductFamilyId", "Name" },
                values: new object[] { 1, "Delta Zulu" });

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
                values: new object[] { 1, "Active" });

            migrationBuilder.InsertData(
                table: "ScarCarStatuses",
                columns: new[] { "ScarCarStatusId", "Name" },
                values: new object[,]
                {
                    { 2, "New" },
                    { 3, "Resolved" },
                    { 4, "Closed" },
                    { 5, "Deferred" }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "Name" },
                values: new object[,]
                {
                    { 1, "Final Inspection" },
                    { 2, "Seveco" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { "e4e7188b-6ecb-4278-aeee-17271f20d7ce", "2e97b939-49c0-4e1e-8376-cb98348103bb", "ApplicationUserRole" });

            migrationBuilder.InsertData(
                table: "FailureTypes",
                columns: new[] { "FailureTypeId", "FailureTypePrimaryId", "Name" },
                values: new object[] { 1, 1, "Color" });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_MasterPartId",
                table: "Alerts",
                column: "MasterPartId");

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
                name: "IX_BuildTemplateParts_BuildStationId",
                table: "BuildTemplateParts",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateParts_BuildTemplateId",
                table: "BuildTemplateParts",
                column: "BuildTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplateParts_MasterPartId",
                table: "BuildTemplateParts",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTemplates_MasterPartId",
                table: "BuildTemplates",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviations_MasterPartId",
                table: "Deviations",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviations_PartId",
                table: "Deviations",
                column: "PartId");

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
                name: "IX_PartAlerts_AlertId",
                table: "PartAlerts",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_PartAlerts_PartId",
                table: "PartAlerts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartDeviations_DeviationId",
                table: "PartDeviations",
                column: "DeviationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartDeviations_PartId",
                table: "PartDeviations",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_BuildStationId",
                table: "Parts",
                column: "BuildStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MasterPartId",
                table: "Parts",
                column: "MasterPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ParentPartId",
                table: "Parts",
                column: "ParentPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartStatusId",
                table: "Parts",
                column: "PartStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_FailureCodeId",
                table: "Repairs",
                column: "FailureCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_GLCodeId",
                table: "Repairs",
                column: "GLCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_PartId",
                table: "Repairs",
                column: "PartId");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_PartId",
                table: "WorkOrderParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderParts_WorkOrderId",
                table: "WorkOrderParts",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_BuildTemplateId",
                table: "WorkOrders",
                column: "BuildTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderPriorityID",
                table: "WorkOrders",
                column: "WorkOrderPriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderStatusId",
                table: "WorkOrders",
                column: "WorkOrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_WorkOrderTypeId",
                table: "WorkOrders",
                column: "WorkOrderTypeId");
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
                name: "BuildTemplateParts");

            migrationBuilder.DropTable(
                name: "InspectionFailures");

            migrationBuilder.DropTable(
                name: "PartAlerts");

            migrationBuilder.DropTable(
                name: "PartDeviations");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "ScarCarAttachments");

            migrationBuilder.DropTable(
                name: "ScarCarNotes");

            migrationBuilder.DropTable(
                name: "WorkOrderParts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FailureTypes");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Deviations");

            migrationBuilder.DropTable(
                name: "FailureCodes");

            migrationBuilder.DropTable(
                name: "GLCodes");

            migrationBuilder.DropTable(
                name: "ScarCar");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "FailureTypePrimaries");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

            migrationBuilder.DropTable(
                name: "BuildTemplates");

            migrationBuilder.DropTable(
                name: "WorkOrderPriorities");

            migrationBuilder.DropTable(
                name: "WorkOrderStatuses");

            migrationBuilder.DropTable(
                name: "WorkOrderTypes");

            migrationBuilder.DropTable(
                name: "BuildStations");

            migrationBuilder.DropTable(
                name: "PartStatuses");

            migrationBuilder.DropTable(
                name: "MasterParts");

            migrationBuilder.DropTable(
                name: "ProductFamilies");
        }
    }
}
