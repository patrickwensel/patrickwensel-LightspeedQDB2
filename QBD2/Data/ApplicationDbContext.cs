using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QBD2.Entities;

namespace QBD2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Deviation> Deviations { get; set; }
        public DbSet<InspectionFailure> InspectionFailures { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<FailureTypePrimary> FailureTypePrimaries { get; set; }
        public DbSet<FailureType> FailureTypes { get; set; }
        public DbSet<MasterPart> MasterParts { get; set; }
        public DbSet<PartDeviation> PartDeviations { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<PartAlert> PartAlerts { get; set; }
        public DbSet<GLCode> GLCodes { get; set; }
        public DbSet<FailureCode> FailureCodes { get; set; }
        public DbSet<PartStatus> PartStatuses { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<ScarCarAttachment> ScarCarAttachments { get; set; }
        public DbSet<ScarCarImpact> ScarCarImpacts { get; set; }
        public DbSet<ScarCarResolution> ScarCarResolutions { get; set; }
        public DbSet<ScarCarNote> ScarCarNotes { get; set; }
        public DbSet<ScarCarProject> ScarCarProjects { get; set; }
        public DbSet<ScarCarCategory> ScarCarCategories { get; set; }
        public DbSet<ScarCarPriority> ScarCarPriorities { get; set; }
        public DbSet<ScarCarStatus> ScarCarStatuses { get; set; }
        public DbSet<ScarCar> ScarCar { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderType> WorkOrderTypes { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public DbSet<WorkOrderPriority> WorkOrderPriorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region ProductFamily

            modelBuilder.Entity<ProductFamily>().HasData(new ProductFamily { ProductFamilyId = 1, Name = "Delta Zulu" });

            #endregion

            #region MasterPart

            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 1, Description = "Delta Zulu GA", PartNumber = "800-00025-001.2", ProductFamilyId = 1, Itemno = "800000250012" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 2, Description = "ASSY, PCB, ANR, LEFT", PartNumber = "200-00062-000" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 3, Description = "Faceplate, Left", PartNumber = "303-00059-100" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 4, Description = "ASSY, PCB, ANR, RIGHT", PartNumber = "200-00048-000" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 5, Description = "Faceplate, Right", PartNumber = "303-00060-100" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 6, Description = "PCBA, Control Box Lower", PartNumber = "200-00060-000" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 7, Description = "CONTROL BOX UPPER BOARD", PartNumber = "200-00043-000" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 8, Description = "ANR Mic - Grooved, Aluminum", PartNumber = "120-00008-101" });
            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 9, Description = "DRIVER", PartNumber = "119-00002-100" });

            #endregion

            #region Parts

            modelBuilder.Entity<Part>().HasData(new Part { PartId = 1, MasterPartId = 1, SerialNumber = "808000406", PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 2, MasterPartId = 2, SerialNumber = "71534*000135", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 3, MasterPartId = 3, SerialNumber = "L51210055", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 4, MasterPartId = 4, SerialNumber = "71543*000080", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 5, MasterPartId = 5, SerialNumber = "R50210586", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 6, MasterPartId = 6, SerialNumber = "71528*000047", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 7, MasterPartId = 7, SerialNumber = "54658*000908", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 8, MasterPartId = 8, SerialNumber = "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 9, MasterPartId = 9, SerialNumber = "2972833301*2792-20210413013*A219101*2021-12-20*8", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 10, MasterPartId = 8, SerialNumber = "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1", ParentPartId = 1, PartStatusId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 11, MasterPartId = 9, SerialNumber = "2972833301*2792-20210413013*A219101*2021-12-20*8", ParentPartId = 1, PartStatusId = 1 });



            #endregion

            #region Station

            modelBuilder.Entity<Station>().HasData(new Station { StationId = 1, Name = "Final Inspection" });
            modelBuilder.Entity<Station>().HasData(new Station { StationId = 2, Name = "Seveco" });

            #endregion

            #region FailureTypePrimary

            modelBuilder.Entity<FailureTypePrimary>().HasData(new FailureTypePrimary { FailureTypePrimaryId = 1, Name = "Cosmetic" });
            modelBuilder.Entity<FailureTypePrimary>().HasData(new FailureTypePrimary { FailureTypePrimaryId = 2, Name = "Mechanical" });
            modelBuilder.Entity<FailureTypePrimary>().HasData(new FailureTypePrimary { FailureTypePrimaryId = 3, Name = "Power" });
            modelBuilder.Entity<FailureTypePrimary>().HasData(new FailureTypePrimary { FailureTypePrimaryId = 4, Name = "ANR" }); 
            modelBuilder.Entity<FailureTypePrimary>().HasData(new FailureTypePrimary { FailureTypePrimaryId = 5, Name = "Comms / Audio / BT" });

            #endregion

            #region FailureType

            modelBuilder.Entity<FailureType>().HasData(new FailureType { FailureTypeId = 1, Name = "Color", FailureTypePrimaryId = 1 });
            // Need to add the rest

            #endregion

            #region GLCode

            modelBuilder.Entity<GLCode>().HasData(new GLCode { GLCodeId = 1, Name = "5471 - Refurbish Parts" });
            modelBuilder.Entity<GLCode>().HasData(new GLCode { GLCodeId = 2, Name = "5490 - Cost of Service Parts" });
            modelBuilder.Entity<GLCode>().HasData(new GLCode { GLCodeId = 3, Name = "5493 - Conversion Costs" });

            #endregion

            #region FailureCode

            modelBuilder.Entity<FailureCode>().HasData(new FailureCode { FailureCodeId = 1, Name = "Battery Box" }); 
            modelBuilder.Entity<FailureCode>().HasData(new FailureCode { FailureCodeId = 2, Name = "Active, Comm Audio" });
            modelBuilder.Entity<FailureCode>().HasData(new FailureCode { FailureCodeId = 3, Name = "Cable" });
            modelBuilder.Entity<FailureCode>().HasData(new FailureCode { FailureCodeId = 4, Name = "Other Noise" });
            modelBuilder.Entity<FailureCode>().HasData(new FailureCode { FailureCodeId = 5, Name = "Headband Sliders" });

            #endregion

            #region PartStatus

            modelBuilder.Entity<PartStatus>().HasData(new PartStatus { PartStatusId = 1, Name = "Active" });
            modelBuilder.Entity<PartStatus>().HasData(new PartStatus { PartStatusId = 2, Name = "Removed" });

            #endregion

            #region Role
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "22b3bff1-cfd2-4075-a90f-827380656873", Name = "User", NormalizedName = "USER".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "e4e7188b-6ecb-4278-aeee-17271f20d7ce", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });

            #endregion

            #region ScarCarImpact
            modelBuilder.Entity<ScarCarImpact>().HasData(new ScarCarImpact { ScarCarImpactId = 1, Name = "Low" });
            modelBuilder.Entity<ScarCarImpact>().HasData(new ScarCarImpact { ScarCarImpactId = 2, Name = "Medium" });
            modelBuilder.Entity<ScarCarImpact>().HasData(new ScarCarImpact { ScarCarImpactId = 3, Name = "High" });
            #endregion

            #region ScarCarProject
            modelBuilder.Entity<ScarCarProject>().HasData(new ScarCarProject { ScarCarProjectId = 1, Name = "Process" });
            modelBuilder.Entity<ScarCarProject>().HasData(new ScarCarProject { ScarCarProjectId = 2, Name = "Performance" });
            modelBuilder.Entity<ScarCarProject>().HasData(new ScarCarProject { ScarCarProjectId = 3, Name = "Manufacturability" });
            modelBuilder.Entity<ScarCarProject>().HasData(new ScarCarProject { ScarCarProjectId = 4, Name = "Test" });
            #endregion

            #region ScarCarCategory
            modelBuilder.Entity<ScarCarCategory>().HasData(new ScarCarCategory { ScarCarCategoryId = 1, Name = "CIA" });
            modelBuilder.Entity<ScarCarCategory>().HasData(new ScarCarCategory { ScarCarCategoryId = 2, Name = "CAR - Minor" });
            modelBuilder.Entity<ScarCarCategory>().HasData(new ScarCarCategory { ScarCarCategoryId = 3, Name = "CAR - Major" });
            modelBuilder.Entity<ScarCarCategory>().HasData(new ScarCarCategory { ScarCarCategoryId = 4, Name = "SCAR" });
            modelBuilder.Entity<ScarCarCategory>().HasData(new ScarCarCategory { ScarCarCategoryId = 5, Name = "IAR" });
            #endregion

            #region ScarCarPriority
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 1, Name = "1" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 2, Name = "2" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 3, Name = "3" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 4, Name = "4" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 5, Name = "5" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 6, Name = "6" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 7, Name = "7" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 8, Name = "8" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 9, Name = "9" });
            modelBuilder.Entity<ScarCarPriority>().HasData(new ScarCarPriority { ScarCarPriorityId = 10, Name = "10" });
            #endregion

            #region ScarCarStatus
            modelBuilder.Entity<ScarCarStatus>().HasData(new ScarCarStatus { ScarCarStatusId = 1, Name = "Active" });
            modelBuilder.Entity<ScarCarStatus>().HasData(new ScarCarStatus { ScarCarStatusId = 2, Name = "New" });
            modelBuilder.Entity<ScarCarStatus>().HasData(new ScarCarStatus { ScarCarStatusId = 3, Name = "Resolved" });
            modelBuilder.Entity<ScarCarStatus>().HasData(new ScarCarStatus { ScarCarStatusId = 4, Name = "Closed" });
            modelBuilder.Entity<ScarCarStatus>().HasData(new ScarCarStatus { ScarCarStatusId = 5, Name = "Deferred" });
            #endregion

            ApplicationUser ohiduserApplicationUser = new()
            {
                Id = "2e97b939-49c0-4e1e-8376-cb98348103bb", // primary key
                UserName = "pwensel@hotmail.com",
                NormalizedUserName = "PWENSEL@HOTMAIL.COM",
                Email = "pwensel@hotmail.com",
                NormalizedEmail = "PWENSEL@HOTMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ADLogin = "DESKTOP-1HVSAG6\\pwens"
            };

            modelBuilder.Entity<MasterPart>().Property(m => m.ProductFamilyId).IsRequired(false);
            modelBuilder.Entity<Part>().Property(m => m.ParentPartId).IsRequired(false);
            //modelBuilder.Entity<Part>().Property(m => m.GLCodeId).IsRequired(false);
            //modelBuilder.Entity<Part>().Property(m => m.FailureCodeId).IsRequired(false);
            modelBuilder.Entity<MasterPart>().HasMany(x=>x.Deviations).WithOne(x => x.MasterPart).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MasterPart>().HasMany(x => x.Alerts).WithOne(x => x.MasterPart).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PartStatus>().HasMany(x => x.Parts).WithOne(x => x.PartStatus).OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                // userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }

    }
}
