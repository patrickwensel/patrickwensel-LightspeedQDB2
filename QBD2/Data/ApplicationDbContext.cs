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

        public DbSet<BuildStation> BuildStations { get; set; }
        public DbSet<BuildTemplate> BuildTemplates { get; set; }
        public DbSet<BuildTemplatePart> BuildTemplateParts { get; set; }
        public DbSet<BuildStationFailureCode> BuildStationFailureCodes { get; set; }
        public DbSet<BuildTemplateStation> BuildTemplateStations { get; set; }

        public DbSet<WorkOrderPart> WorkOrderParts { get; set; }

        public DbSet<MRB> MRBs { get; set; }
        public DbSet<MRBDisposition> MRBDispositions { get; set; }

        public DbSet<BuildStationInspectionFailure> BuildStationInspectionFailures { get; set; }
        public DbSet<BuildStationInspection> BuildStationInspections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MRBDisposition

            modelBuilder.Entity<MRBDisposition>().HasData(new MRBDisposition { MRBDispositionId = 1, Name = "Review" });
            modelBuilder.Entity<MRBDisposition>().HasData(new MRBDisposition { MRBDispositionId = 2, Name = "Rework" });
            modelBuilder.Entity<MRBDisposition>().HasData(new MRBDisposition { MRBDispositionId = 3, Name = "Send to Vendor" });
            modelBuilder.Entity<MRBDisposition>().HasData(new MRBDisposition { MRBDispositionId = 4, Name = "Scrap" });
            modelBuilder.Entity<MRBDisposition>().HasData(new MRBDisposition { MRBDispositionId = 5, Name = "Eng Eval" });
            modelBuilder.Entity<MRBDisposition>().HasData(new MRBDisposition { MRBDispositionId = 6, Name = "Use As Is" });

            #endregion

            #region ProductFamily

            modelBuilder.Entity<ProductFamily>().HasData(new ProductFamily { ProductFamilyId = 1, Name = "Delta Zulu" });

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

            #region Role
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "22b3bff1-cfd2-4075-a90f-827380656873", Name = "User", NormalizedName = "USER".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "e4e7188b-6ecb-4278-aeee-17271f20d7ce", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "aec800c6-ea7e-4420-a583-91a23787a3af", Name = "CanDeleteFailureCodes", NormalizedName = "CANDELETEFAILURECODES".ToUpper() });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = "e77174e9-e942-4fc1-bdb5-20a5f318d2ed", Name = "CanDeleteRepair", NormalizedName = "CANDELETEREPAIR".ToUpper() });
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

            modelBuilder.Entity<ApplicationUser>().HasData(ohiduserApplicationUser);

            modelBuilder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole
                {
                    RoleId = "e4e7188b-6ecb-4278-aeee-17271f20d7ce",
                    UserId = "2e97b939-49c0-4e1e-8376-cb98348103bb"
                }
            );

            modelBuilder.Entity<MasterPart>().Property(m => m.ProductFamilyId).IsRequired(false);
            modelBuilder.Entity<Part>().Property(m => m.ParentPartId).IsRequired(false);
            modelBuilder.Entity<Part>().Property(m => m.BuildStationId).IsRequired(false);
            modelBuilder.Entity<MasterPart>().HasMany(x=>x.Deviations).WithOne(x => x.MasterPart).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MasterPart>().HasMany(x => x.Alerts).WithOne(x => x.MasterPart).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PartStatus>().HasMany(x => x.Parts).WithOne(x => x.PartStatus).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ScarCar>().HasMany(x => x.ScarCarNotes).WithOne(x => x.ScarCar).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MasterPart>().HasMany(x => x.BuildTemplateParts).WithOne(x => x.MasterPart).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<WorkOrder>().HasMany(x => x.WorkOrderParts).WithOne(x => x.WorkOrder).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Inspection>().Property(m => m.StationId).IsRequired(false);
            modelBuilder.Entity<Inspection>().Property(m => m.WorkOrderId).IsRequired(false);
            modelBuilder.Entity<Inspection>().Property(m => m.GeneralComments).IsRequired(false);
            modelBuilder.Entity<Repair>().Property(m => m.Description).IsRequired(false);
            modelBuilder.Entity<InspectionFailure>().Property(m => m.FailureTypeId).IsRequired(false);
            modelBuilder.Entity<InspectionFailure>().Property(m => m.BuildStationFailureCodeId).IsRequired(false);
            modelBuilder.Entity<InspectionFailure>().Property(m => m.Comment).IsRequired(false);
          //  modelBuilder.Entity<BuildStation>().HasMany(s => s.BuildTemplates).WithOne(c => c.BuildStation).OnDelete(DeleteBehavior.Restrict);

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
