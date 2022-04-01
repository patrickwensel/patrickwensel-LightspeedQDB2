using Microsoft.EntityFrameworkCore;
using QBD2.Entities;

namespace QBD2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MasterPart> MasterParts { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }

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

            #region Station

            modelBuilder.Entity<Station>().HasData(new Station { StationId = 1, Name = "Final Inspection" });

            #endregion

            modelBuilder.Entity<MasterPart>().Property(m => m.ProductFamilyId).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
