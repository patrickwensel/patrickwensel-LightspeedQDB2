using Microsoft.EntityFrameworkCore;
using QBD2.Entities;

namespace QBD2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AlertDeviation> AlertDeviations { get; set; }
        public DbSet<InspectionFailure> InspectionFailures { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<FailureTypePrimary> FailureTypePrimaries { get; set; }
        public DbSet<FailureType> FailureTypes { get; set; }
        public DbSet<MasterPart> MasterParts { get; set; }
        public DbSet<PartAlertDeviation> PartAlertDeviations { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<Station> Stations { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region ProductFamily

            modelBuilder.Entity<ProductFamily>().HasData(new ProductFamily { ProductFamilyId = 1, Name = "Delta Zulu" });

            #endregion

            #region MasterPart

            modelBuilder.Entity<MasterPart>().HasData(new MasterPart { MasterPartId = 1, Description = "Delta Zulu GA", PartNumber = "800-00025-001.2", ProductFamilyId = 1 });
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

            modelBuilder.Entity<Part>().HasData(new Part { PartId = 1, MasterPartId = 1, SerialNumber = "808000406" });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 2, MasterPartId = 2, SerialNumber = "71534*000135", ParentPartId = 1});
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 3, MasterPartId = 3, SerialNumber = "L51210055", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 4, MasterPartId = 4, SerialNumber = "71543*000080", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 5, MasterPartId = 5, SerialNumber = "R50210586", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 6, MasterPartId = 6, SerialNumber = "71528*000047", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 7, MasterPartId = 7, SerialNumber = "54658*000908", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 8, MasterPartId = 8, SerialNumber = "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 9, MasterPartId = 9, SerialNumber = "2972833301*2792-20210413013*A219101*2021-12-20*8", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 10, MasterPartId = 8, SerialNumber = "2976833306*20210731037*A209601*2021-12-09*2Y*1*S*++*2801-20211207142***1", ParentPartId = 1 });
            modelBuilder.Entity<Part>().HasData(new Part { PartId = 11, MasterPartId = 9, SerialNumber = "2972833301*2792-20210413013*A219101*2021-12-20*8", ParentPartId = 1 });



            #endregion

            #region Station

            modelBuilder.Entity<Station>().HasData(new Station { StationId = 1, Name = "Final Inspection" });

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

            #region FailurAlertDeviationeType

            modelBuilder.Entity<AlertDeviation>().HasData(new AlertDeviation { AlertDeviationId = 1, Name = "Some Alert"});
            modelBuilder.Entity<AlertDeviation>().HasData(new AlertDeviation { AlertDeviationId = 2, Name = "Some Deviation" });
            // Need to add the rest

            #endregion

            modelBuilder.Entity<MasterPart>().Property(m => m.ProductFamilyId).IsRequired(false);
            modelBuilder.Entity<Part>().Property(m => m.ParentPartId).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
