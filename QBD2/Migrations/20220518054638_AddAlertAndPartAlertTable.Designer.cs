﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QBD2.Data;

#nullable disable

namespace QBD2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220518054638_AddAlertAndPartAlertTable")]
    partial class AddAlertAndPartAlertTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QBD2.Entities.Alert", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlertId"), 1L, 1);

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MasterPartId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonforManufacturingDeviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlertId");

                    b.HasIndex("MasterPartId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("QBD2.Entities.Deviation", b =>
                {
                    b.Property<int>("DeviationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviationId"), 1L, 1);

                    b.Property<string>("CommentCorrectiveAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ECONumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ECORequired")
                        .HasColumnType("bit");

                    b.Property<string>("LSA2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LSAFGI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LSASEVE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LSASVPART")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LSAWIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MasterPartId")
                        .HasColumnType("int");

                    b.Property<string>("Originator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartId")
                        .HasColumnType("int");

                    b.Property<string>("ReasonforManufacturingDeviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor3FGI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorSEVE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorSVPART")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VendorWIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeviationId");

                    b.HasIndex("MasterPartId");

                    b.HasIndex("PartId");

                    b.ToTable("Deviations");
                });

            modelBuilder.Entity("QBD2.Entities.FailureType", b =>
                {
                    b.Property<int>("FailureTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FailureTypeId"), 1L, 1);

                    b.Property<int>("FailureTypePrimaryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FailureTypeId");

                    b.HasIndex("FailureTypePrimaryId");

                    b.ToTable("FailureTypes");

                    b.HasData(
                        new
                        {
                            FailureTypeId = 1,
                            FailureTypePrimaryId = 1,
                            Name = "Color"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.FailureTypePrimary", b =>
                {
                    b.Property<int>("FailureTypePrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FailureTypePrimaryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FailureTypePrimaryId");

                    b.ToTable("FailureTypePrimaries");

                    b.HasData(
                        new
                        {
                            FailureTypePrimaryId = 1,
                            Name = "Cosmetic"
                        },
                        new
                        {
                            FailureTypePrimaryId = 2,
                            Name = "Mechanical"
                        },
                        new
                        {
                            FailureTypePrimaryId = 3,
                            Name = "Power"
                        },
                        new
                        {
                            FailureTypePrimaryId = 4,
                            Name = "ANR"
                        },
                        new
                        {
                            FailureTypePrimaryId = 5,
                            Name = "Comms / Audio / BT"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.Inspection", b =>
                {
                    b.Property<int>("InspectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InspectionId"), 1L, 1);

                    b.Property<string>("GeneralComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<bool>("Pass")
                        .HasColumnType("bit");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("InspectionId");

                    b.HasIndex("PartId");

                    b.HasIndex("StationId");

                    b.ToTable("Inspections");
                });

            modelBuilder.Entity("QBD2.Entities.InspectionFailure", b =>
                {
                    b.Property<int>("InspectionFailureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InspectionFailureId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailureTypeId")
                        .HasColumnType("int");

                    b.Property<int>("InspectionId")
                        .HasColumnType("int");

                    b.HasKey("InspectionFailureId");

                    b.HasIndex("FailureTypeId");

                    b.HasIndex("InspectionId");

                    b.ToTable("InspectionFailures");
                });

            modelBuilder.Entity("QBD2.Entities.MasterPart", b =>
                {
                    b.Property<int>("MasterPartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MasterPartId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Itemno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductFamilyId")
                        .HasColumnType("int");

                    b.HasKey("MasterPartId");

                    b.HasIndex("ProductFamilyId");

                    b.ToTable("MasterParts");

                    b.HasData(
                        new
                        {
                            MasterPartId = 1,
                            Description = "Delta Zulu GA",
                            Itemno = "800000250012",
                            PartNumber = "800-00025-001.2",
                            ProductFamilyId = 1
                        },
                        new
                        {
                            MasterPartId = 2,
                            Description = "ASSY, PCB, ANR, LEFT",
                            PartNumber = "200-00062-000"
                        },
                        new
                        {
                            MasterPartId = 3,
                            Description = "Faceplate, Left",
                            PartNumber = "303-00059-100"
                        },
                        new
                        {
                            MasterPartId = 4,
                            Description = "ASSY, PCB, ANR, RIGHT",
                            PartNumber = "200-00048-000"
                        },
                        new
                        {
                            MasterPartId = 5,
                            Description = "Faceplate, Right",
                            PartNumber = "303-00060-100"
                        },
                        new
                        {
                            MasterPartId = 6,
                            Description = "PCBA, Control Box Lower",
                            PartNumber = "200-00060-000"
                        },
                        new
                        {
                            MasterPartId = 7,
                            Description = "CONTROL BOX UPPER BOARD",
                            PartNumber = "200-00043-000"
                        },
                        new
                        {
                            MasterPartId = 8,
                            Description = "ANR Mic - Grooved, Aluminum",
                            PartNumber = "120-00008-101"
                        },
                        new
                        {
                            MasterPartId = 9,
                            Description = "DRIVER",
                            PartNumber = "119-00002-100"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.Part", b =>
                {
                    b.Property<int>("PartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartId"), 1L, 1);

                    b.Property<int>("MasterPartId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentPartId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartId");

                    b.HasIndex("MasterPartId");

                    b.HasIndex("ParentPartId");

                    b.ToTable("Parts");

                    b.HasData(
                        new
                        {
                            PartId = 1,
                            MasterPartId = 1,
                            SerialNumber = "808000406"
                        },
                        new
                        {
                            PartId = 2,
                            MasterPartId = 2,
                            ParentPartId = 1,
                            SerialNumber = "71534*000135"
                        },
                        new
                        {
                            PartId = 3,
                            MasterPartId = 3,
                            ParentPartId = 1,
                            SerialNumber = "L51210055"
                        },
                        new
                        {
                            PartId = 4,
                            MasterPartId = 4,
                            ParentPartId = 1,
                            SerialNumber = "71543*000080"
                        },
                        new
                        {
                            PartId = 5,
                            MasterPartId = 5,
                            ParentPartId = 1,
                            SerialNumber = "R50210586"
                        },
                        new
                        {
                            PartId = 6,
                            MasterPartId = 6,
                            ParentPartId = 1,
                            SerialNumber = "71528*000047"
                        },
                        new
                        {
                            PartId = 7,
                            MasterPartId = 7,
                            ParentPartId = 1,
                            SerialNumber = "54658*000908"
                        },
                        new
                        {
                            PartId = 8,
                            MasterPartId = 8,
                            ParentPartId = 1,
                            SerialNumber = "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1"
                        },
                        new
                        {
                            PartId = 9,
                            MasterPartId = 9,
                            ParentPartId = 1,
                            SerialNumber = "2972833301*2792-20210413013*A219101*2021-12-20*8"
                        },
                        new
                        {
                            PartId = 10,
                            MasterPartId = 8,
                            ParentPartId = 1,
                            SerialNumber = "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1"
                        },
                        new
                        {
                            PartId = 11,
                            MasterPartId = 9,
                            ParentPartId = 1,
                            SerialNumber = "2972833301*2792-20210413013*A219101*2021-12-20*8"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.PartAlert", b =>
                {
                    b.Property<int>("PartAlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartAlertId"), 1L, 1);

                    b.Property<int>("AlertId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("PartAlertId");

                    b.HasIndex("AlertId");

                    b.HasIndex("PartId");

                    b.ToTable("PartAlerts");
                });

            modelBuilder.Entity("QBD2.Entities.PartDeviation", b =>
                {
                    b.Property<int>("PartDeviationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartDeviationId"), 1L, 1);

                    b.Property<int>("DeviationId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.HasKey("PartDeviationId");

                    b.HasIndex("DeviationId");

                    b.HasIndex("PartId");

                    b.ToTable("PartDeviations");
                });

            modelBuilder.Entity("QBD2.Entities.ProductFamily", b =>
                {
                    b.Property<int>("ProductFamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductFamilyId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductFamilyId");

                    b.ToTable("ProductFamilies");

                    b.HasData(
                        new
                        {
                            ProductFamilyId = 1,
                            Name = "Delta Zulu"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StationId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            StationId = 1,
                            Name = "Final Inspection"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("ApplicationRole");

                    b.HasData(
                        new
                        {
                            Id = "22b3bff1-cfd2-4075-a90f-827380656873",
                            ConcurrencyStamp = "3abe996c-cff7-4edf-824a-32e1b303e73b",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                            ConcurrencyStamp = "27d5e3e9-b9db-4243-8398-22cf0f4eb2ae",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("QBD2.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ADLogin")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("QBD2.Entities.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QBD2.Entities.Alert", b =>
                {
                    b.HasOne("QBD2.Entities.MasterPart", "MasterPart")
                        .WithMany("Alerts")
                        .HasForeignKey("MasterPartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MasterPart");
                });

            modelBuilder.Entity("QBD2.Entities.Deviation", b =>
                {
                    b.HasOne("QBD2.Entities.MasterPart", "MasterPart")
                        .WithMany("Deviations")
                        .HasForeignKey("MasterPartId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.Part", null)
                        .WithMany("Deviations")
                        .HasForeignKey("PartId");

                    b.Navigation("MasterPart");
                });

            modelBuilder.Entity("QBD2.Entities.FailureType", b =>
                {
                    b.HasOne("QBD2.Entities.FailureTypePrimary", "FailureTypePrimary")
                        .WithMany()
                        .HasForeignKey("FailureTypePrimaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FailureTypePrimary");
                });

            modelBuilder.Entity("QBD2.Entities.Inspection", b =>
                {
                    b.HasOne("QBD2.Entities.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("QBD2.Entities.InspectionFailure", b =>
                {
                    b.HasOne("QBD2.Entities.FailureType", "FailureType")
                        .WithMany()
                        .HasForeignKey("FailureTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.Inspection", "Inspection")
                        .WithMany("InspectionFailures")
                        .HasForeignKey("InspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FailureType");

                    b.Navigation("Inspection");
                });

            modelBuilder.Entity("QBD2.Entities.MasterPart", b =>
                {
                    b.HasOne("QBD2.Entities.ProductFamily", "ProductFamily")
                        .WithMany()
                        .HasForeignKey("ProductFamilyId");

                    b.Navigation("ProductFamily");
                });

            modelBuilder.Entity("QBD2.Entities.Part", b =>
                {
                    b.HasOne("QBD2.Entities.MasterPart", "MasterPart")
                        .WithMany()
                        .HasForeignKey("MasterPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.Part", "ParentPart")
                        .WithMany()
                        .HasForeignKey("ParentPartId");

                    b.Navigation("MasterPart");

                    b.Navigation("ParentPart");
                });

            modelBuilder.Entity("QBD2.Entities.PartAlert", b =>
                {
                    b.HasOne("QBD2.Entities.Alert", "Alert")
                        .WithMany("PartAlerts")
                        .HasForeignKey("AlertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alert");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("QBD2.Entities.PartDeviation", b =>
                {
                    b.HasOne("QBD2.Entities.Deviation", "Deviation")
                        .WithMany("PartDeviations")
                        .HasForeignKey("DeviationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deviation");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("QBD2.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("QBD2.Entities.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QBD2.Entities.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QBD2.Entities.Alert", b =>
                {
                    b.Navigation("PartAlerts");
                });

            modelBuilder.Entity("QBD2.Entities.Deviation", b =>
                {
                    b.Navigation("PartDeviations");
                });

            modelBuilder.Entity("QBD2.Entities.Inspection", b =>
                {
                    b.Navigation("InspectionFailures");
                });

            modelBuilder.Entity("QBD2.Entities.MasterPart", b =>
                {
                    b.Navigation("Alerts");

                    b.Navigation("Deviations");
                });

            modelBuilder.Entity("QBD2.Entities.Part", b =>
                {
                    b.Navigation("Deviations");
                });

            modelBuilder.Entity("QBD2.Entities.ApplicationRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("QBD2.Entities.ApplicationUser", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
