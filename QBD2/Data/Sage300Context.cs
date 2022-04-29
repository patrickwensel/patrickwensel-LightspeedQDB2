using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QBD2.Entities;

namespace QBD2.Data
{
    public partial class Sage300Context : DbContext
    {
        public Sage300Context()
        {
        }

        public Sage300Context(DbContextOptions<Sage300Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Icitem> Icitems { get; set; } = null!;
        public virtual DbSet<Icxser> Icxsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=sage300;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Icitem>(entity =>
            {
                entity.HasKey(e => e.Itemno)
                    .HasName("ICITEM_KEY_0");

                entity.ToTable("ICITEM");

                entity.Property(e => e.Itemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("ITEMNO")
                    .IsFixedLength();

                entity.Property(e => e.Allowonweb).HasColumnName("ALLOWONWEB");

                entity.Property(e => e.Altset).HasColumnName("ALTSET");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Category)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY")
                    .IsFixedLength();

                entity.Property(e => e.Cntlacct)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CNTLACCT")
                    .IsFixedLength();

                entity.Property(e => e.Comment1)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT1")
                    .IsFixedLength();

                entity.Property(e => e.Comment2)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT2")
                    .IsFixedLength();

                entity.Property(e => e.Comment3)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT3")
                    .IsFixedLength();

                entity.Property(e => e.Comment4)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT4")
                    .IsFixedLength();

                entity.Property(e => e.Commodim)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("COMMODIM")
                    .IsFixedLength();

                entity.Property(e => e.Dateinactv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATEINACTV");

                entity.Property(e => e.Datelastmn)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATELASTMN");

                entity.Property(e => e.Defbomno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DEFBOMNO")
                    .IsFixedLength();

                entity.Property(e => e.Defkitno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DEFKITNO")
                    .IsFixedLength();

                entity.Property(e => e.Defpriclst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("DEFPRICLST")
                    .IsFixedLength();

                entity.Property(e => e.Desc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESC")
                    .IsFixedLength();

                entity.Property(e => e.Fmtitemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("FMTITEMNO")
                    .IsFixedLength();

                entity.Property(e => e.Inactive).HasColumnName("INACTIVE");

                entity.Property(e => e.Itembrkid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ITEMBRKID")
                    .IsFixedLength();

                entity.Property(e => e.Kitting).HasColumnName("KITTING");

                entity.Property(e => e.Lcontcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LCONTCODE")
                    .IsFixedLength();

                entity.Property(e => e.Lcontrece).HasColumnName("LCONTRECE");

                entity.Property(e => e.Ldifqtyok).HasColumnName("LDIFQTYOK");

                entity.Property(e => e.Lexpdays).HasColumnName("LEXPDAYS");

                entity.Property(e => e.Lotitem).HasColumnName("LOTITEM");

                entity.Property(e => e.Lotmask)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LOTMASK")
                    .IsFixedLength();

                entity.Property(e => e.Lqrndays).HasColumnName("LQRNDAYS");

                entity.Property(e => e.Luseexpday).HasColumnName("LUSEEXPDAY");

                entity.Property(e => e.Luseqrnday).HasColumnName("LUSEQRNDAY");

                entity.Property(e => e.Lvalues).HasColumnName("LVALUES");

                entity.Property(e => e.Lwarycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LWARYCODE")
                    .IsFixedLength();

                entity.Property(e => e.Lwarysold).HasColumnName("LWARYSOLD");

                entity.Property(e => e.Nextlotfmt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NEXTLOTFMT")
                    .IsFixedLength();

                entity.Property(e => e.Nextserfmt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NEXTSERFMT")
                    .IsFixedLength();

                entity.Property(e => e.Pickingseq)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PICKINGSEQ")
                    .IsFixedLength();

                entity.Property(e => e.Prevendty).HasColumnName("PREVENDTY");

                entity.Property(e => e.Scontcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SCONTCODE")
                    .IsFixedLength();

                entity.Property(e => e.Scontrece).HasColumnName("SCONTRECE");

                entity.Property(e => e.Sdifqtyok).HasColumnName("SDIFQTYOK");

                entity.Property(e => e.Seasonal).HasColumnName("SEASONAL");

                entity.Property(e => e.Segment1)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT1")
                    .IsFixedLength();

                entity.Property(e => e.Segment10)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT10")
                    .IsFixedLength();

                entity.Property(e => e.Segment2)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT2")
                    .IsFixedLength();

                entity.Property(e => e.Segment3)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT3")
                    .IsFixedLength();

                entity.Property(e => e.Segment4)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT4")
                    .IsFixedLength();

                entity.Property(e => e.Segment5)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT5")
                    .IsFixedLength();

                entity.Property(e => e.Segment6)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT6")
                    .IsFixedLength();

                entity.Property(e => e.Segment7)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT7")
                    .IsFixedLength();

                entity.Property(e => e.Segment8)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT8")
                    .IsFixedLength();

                entity.Property(e => e.Segment9)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("SEGMENT9")
                    .IsFixedLength();

                entity.Property(e => e.Sellable).HasColumnName("SELLABLE");

                entity.Property(e => e.Serialmask)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SERIALMASK")
                    .IsFixedLength();

                entity.Property(e => e.Serialno).HasColumnName("SERIALNO");

                entity.Property(e => e.Sexpdays).HasColumnName("SEXPDAYS");

                entity.Property(e => e.Stockitem).HasColumnName("STOCKITEM");

                entity.Property(e => e.Stockunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STOCKUNIT")
                    .IsFixedLength();

                entity.Property(e => e.Suseexpday).HasColumnName("SUSEEXPDAY");

                entity.Property(e => e.Svalues).HasColumnName("SVALUES");

                entity.Property(e => e.Swarycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SWARYCODE")
                    .IsFixedLength();

                entity.Property(e => e.Swaryreg).HasColumnName("SWARYREG");

                entity.Property(e => e.Swarysold).HasColumnName("SWARYSOLD");

                entity.Property(e => e.Tariffcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TARIFFCODE")
                    .IsFixedLength();

                entity.Property(e => e.Unitwgt)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("UNITWGT");

                entity.Property(e => e.Values).HasColumnName("VALUES");

                entity.Property(e => e.Weightunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("WEIGHTUNIT")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Icxser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ICXSER");

                entity.Property(e => e.Assetcost)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("ASSETCOST");

                entity.Property(e => e.Assetstock).HasColumnName("ASSETSTOCK");

                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");

                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AUDTORG")
                    .IsFixedLength();

                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");

                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("AUDTUSER")
                    .IsFixedLength();

                entity.Property(e => e.Contcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CONTCODE")
                    .IsFixedLength();

                entity.Property(e => e.Date1)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATE1");

                entity.Property(e => e.Date2)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATE2");

                entity.Property(e => e.Date3)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATE3");

                entity.Property(e => e.Date4)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATE4");

                entity.Property(e => e.Date5)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATE5");

                entity.Property(e => e.Effdate1)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("EFFDATE1");

                entity.Property(e => e.Effdate2)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("EFFDATE2");

                entity.Property(e => e.Effdate3)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("EFFDATE3");

                entity.Property(e => e.Effdate4)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("EFFDATE4");

                entity.Property(e => e.Effdate5)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("EFFDATE5");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("EXPIRYDATE");

                entity.Property(e => e.Inuse1).HasColumnName("INUSE1");

                entity.Property(e => e.Inuse2).HasColumnName("INUSE2");

                entity.Property(e => e.Inuse3).HasColumnName("INUSE3");

                entity.Property(e => e.Inuse4).HasColumnName("INUSE4");

                entity.Property(e => e.Inuse5).HasColumnName("INUSE5");

                entity.Property(e => e.Itemnum)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("ITEMNUM")
                    .IsFixedLength();

                entity.Property(e => e.Lifecont1).HasColumnName("LIFECONT1");

                entity.Property(e => e.Lifecont2).HasColumnName("LIFECONT2");

                entity.Property(e => e.Lifecont3).HasColumnName("LIFECONT3");

                entity.Property(e => e.Lifecont4).HasColumnName("LIFECONT4");

                entity.Property(e => e.Lifecont5).HasColumnName("LIFECONT5");

                entity.Property(e => e.Location)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION")
                    .IsFixedLength();

                entity.Property(e => e.Resvforord).HasColumnName("RESVFORORD");

                entity.Property(e => e.Serialnum)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SERIALNUM")
                    .IsFixedLength();

                entity.Property(e => e.Serialnumf)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SERIALNUMF")
                    .IsFixedLength();

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.Stockdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("STOCKDATE");

                entity.Property(e => e.Values).HasColumnName("VALUES");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
