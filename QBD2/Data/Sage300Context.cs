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

        public virtual DbSet<Icitem> Icitems { get; set; }

        public virtual DbSet<Icxser> Icxsers { get; set; }

        public virtual DbSet<Porcph1> Porcph1s { get; set; }

        public virtual DbSet<Porcpl> Porcpls { get; set; }

        public virtual DbSet<Porcpls> Porcplss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Icitem>(entity =>
            {
                entity.HasKey(e => e.Itemno).HasName("ICITEM_KEY_0");

                entity.ToTable("ICITEM");

                entity.Property(e => e.Itemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ITEMNO");
                entity.Property(e => e.Allowonweb).HasColumnName("ALLOWONWEB");
                entity.Property(e => e.Altset).HasColumnName("ALTSET");
                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");
                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTORG");
                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");
                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTUSER");
                entity.Property(e => e.Category)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CATEGORY");
                entity.Property(e => e.Cntlacct)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CNTLACCT");
                entity.Property(e => e.Comment1)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COMMENT1");
                entity.Property(e => e.Comment2)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COMMENT2");
                entity.Property(e => e.Comment3)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COMMENT3");
                entity.Property(e => e.Comment4)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COMMENT4");
                entity.Property(e => e.Commodim)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COMMODIM");
                entity.Property(e => e.Dateinactv)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATEINACTV");
                entity.Property(e => e.Datelastmn)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATELASTMN");
                entity.Property(e => e.Defbomno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DEFBOMNO");
                entity.Property(e => e.Defkitno)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DEFKITNO");
                entity.Property(e => e.Defpriclst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DEFPRICLST");
                entity.Property(e => e.Desc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DESC");
                entity.Property(e => e.Fmtitemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("FMTITEMNO");
                entity.Property(e => e.Inactive).HasColumnName("INACTIVE");
                entity.Property(e => e.Itembrkid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ITEMBRKID");
                entity.Property(e => e.Kitting).HasColumnName("KITTING");
                entity.Property(e => e.Lcontcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("LCONTCODE");
                entity.Property(e => e.Lcontrece).HasColumnName("LCONTRECE");
                entity.Property(e => e.Ldifqtyok).HasColumnName("LDIFQTYOK");
                entity.Property(e => e.Lexpdays).HasColumnName("LEXPDAYS");
                entity.Property(e => e.Lotitem).HasColumnName("LOTITEM");
                entity.Property(e => e.Lotmask)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("LOTMASK");
                entity.Property(e => e.Lqrndays).HasColumnName("LQRNDAYS");
                entity.Property(e => e.Luseexpday).HasColumnName("LUSEEXPDAY");
                entity.Property(e => e.Luseqrnday).HasColumnName("LUSEQRNDAY");
                entity.Property(e => e.Lvalues).HasColumnName("LVALUES");
                entity.Property(e => e.Lwarycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("LWARYCODE");
                entity.Property(e => e.Lwarysold).HasColumnName("LWARYSOLD");
                entity.Property(e => e.Nextlotfmt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("NEXTLOTFMT");
                entity.Property(e => e.Nextserfmt)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("NEXTSERFMT");
                entity.Property(e => e.Pickingseq)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("PICKINGSEQ");
                entity.Property(e => e.Prevendty).HasColumnName("PREVENDTY");
                entity.Property(e => e.Scontcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SCONTCODE");
                entity.Property(e => e.Scontrece).HasColumnName("SCONTRECE");
                entity.Property(e => e.Sdifqtyok).HasColumnName("SDIFQTYOK");
                entity.Property(e => e.Seasonal).HasColumnName("SEASONAL");
                entity.Property(e => e.Segment1)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT1");
                entity.Property(e => e.Segment10)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT10");
                entity.Property(e => e.Segment2)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT2");
                entity.Property(e => e.Segment3)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT3");
                entity.Property(e => e.Segment4)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT4");
                entity.Property(e => e.Segment5)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT5");
                entity.Property(e => e.Segment6)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT6");
                entity.Property(e => e.Segment7)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT7");
                entity.Property(e => e.Segment8)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT8");
                entity.Property(e => e.Segment9)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SEGMENT9");
                entity.Property(e => e.Sellable).HasColumnName("SELLABLE");
                entity.Property(e => e.Serialmask)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SERIALMASK");
                entity.Property(e => e.Serialno).HasColumnName("SERIALNO");
                entity.Property(e => e.Sexpdays).HasColumnName("SEXPDAYS");
                entity.Property(e => e.Stockitem).HasColumnName("STOCKITEM");
                entity.Property(e => e.Stockunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("STOCKUNIT");
                entity.Property(e => e.Suseexpday).HasColumnName("SUSEEXPDAY");
                entity.Property(e => e.Svalues).HasColumnName("SVALUES");
                entity.Property(e => e.Swarycode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SWARYCODE");
                entity.Property(e => e.Swaryreg).HasColumnName("SWARYREG");
                entity.Property(e => e.Swarysold).HasColumnName("SWARYSOLD");
                entity.Property(e => e.Tariffcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TARIFFCODE");
                entity.Property(e => e.Unitwgt)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("UNITWGT");
                entity.Property(e => e.Values).HasColumnName("VALUES");
                entity.Property(e => e.Weightunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("WEIGHTUNIT");
            });

            modelBuilder.Entity<Icxser>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("ICXSER");

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
                    .IsFixedLength()
                    .HasColumnName("AUDTORG");
                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");
                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTUSER");
                entity.Property(e => e.Contcode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CONTCODE");
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
                    .IsFixedLength()
                    .HasColumnName("ITEMNUM");
                entity.Property(e => e.Lifecont1).HasColumnName("LIFECONT1");
                entity.Property(e => e.Lifecont2).HasColumnName("LIFECONT2");
                entity.Property(e => e.Lifecont3).HasColumnName("LIFECONT3");
                entity.Property(e => e.Lifecont4).HasColumnName("LIFECONT4");
                entity.Property(e => e.Lifecont5).HasColumnName("LIFECONT5");
                entity.Property(e => e.Location)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("LOCATION");
                entity.Property(e => e.Resvforord).HasColumnName("RESVFORORD");
                entity.Property(e => e.Serialnum)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SERIALNUM");
                entity.Property(e => e.Serialnumf)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SERIALNUMF");
                entity.Property(e => e.Status).HasColumnName("STATUS");
                entity.Property(e => e.Stockdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("STOCKDATE");
                entity.Property(e => e.Values).HasColumnName("VALUES");
            });

            modelBuilder.Entity<Porcph1>(entity =>
            {
                entity.HasKey(e => e.Rcphseq).HasName("PORCPH1_KEY_0");

                entity.ToTable("PORCPH1");

                entity.Property(e => e.Rcphseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPHSEQ");
                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("AMOUNT");
                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");
                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTORG");
                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");
                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTUSER");
                entity.Property(e => e.Billlines).HasColumnName("BILLLINES");
                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COMMENT");
                entity.Property(e => e.Costs).HasColumnName("COSTS");
                entity.Property(e => e.Costsblpro).HasColumnName("COSTSBLPRO");
                entity.Property(e => e.Costscmpl).HasColumnName("COSTSCMPL");
                entity.Property(e => e.Costsprora).HasColumnName("COSTSPRORA");
                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CURRENCY");
                entity.Property(e => e.Date)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DATE");
                entity.Property(e => e.Descriptio)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DESCRIPTIO");
                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("DISCOUNT");
                entity.Property(e => e.Discpct)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("DISCPCT");
                entity.Property(e => e.Doctotal)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("DOCTOTAL");
                entity.Property(e => e.Dtcomplete)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCOMPLETE");
                entity.Property(e => e.Extended)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("EXTENDED");
                entity.Property(e => e.Extraneous).HasColumnName("EXTRANEOUS");
                entity.Property(e => e.Extweight)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("EXTWEIGHT");
                entity.Property(e => e.Fcamount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("FCAMOUNT");
                entity.Property(e => e.Fiscperiod).HasColumnName("FISCPERIOD");
                entity.Property(e => e.Fiscyear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("FISCYEAR");
                entity.Property(e => e.Fobpoint)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("FOBPOINT");
                entity.Property(e => e.Hasrtg).HasColumnName("HASRTG");
                entity.Property(e => e.Invnumber)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("INVNUMBER");
                entity.Property(e => e.Iscomplete).HasColumnName("ISCOMPLETE");
                entity.Property(e => e.Isinvoiced).HasColumnName("ISINVOICED");
                entity.Property(e => e.Isprinted).HasColumnName("ISPRINTED");
                entity.Property(e => e.Jobcosts).HasColumnName("JOBCOSTS");
                entity.Property(e => e.Joblines).HasColumnName("JOBLINES");
                entity.Property(e => e.Lines).HasColumnName("LINES");
                entity.Property(e => e.Linescmpl).HasColumnName("LINESCMPL");
                entity.Property(e => e.Linesprora).HasColumnName("LINESPRORA");
                entity.Property(e => e.Mprorated)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MPRORATED");
                entity.Property(e => e.Mtoprorate)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MTOPRORATE");
                entity.Property(e => e.Multipor).HasColumnName("MULTIPOR");
                entity.Property(e => e.Nextlseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("NEXTLSEQ");
                entity.Property(e => e.Ponumber)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("PONUMBER");
                entity.Property(e => e.Porhseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("PORHSEQ");
                entity.Property(e => e.Pors).HasColumnName("PORS");
                entity.Property(e => e.Postdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("POSTDATE");
                entity.Property(e => e.Rate)
                    .HasColumnType("decimal(15, 7)")
                    .HasColumnName("RATE");
                entity.Property(e => e.Ratedate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("RATEDATE");
                entity.Property(e => e.Ratedaterc)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("RATEDATERC");
                entity.Property(e => e.Ratematch).HasColumnName("RATEMATCH");
                entity.Property(e => e.Ratemtchrc).HasColumnName("RATEMTCHRC");
                entity.Property(e => e.Rateoper).HasColumnName("RATEOPER");
                entity.Property(e => e.Rateoperrc).HasColumnName("RATEOPERRC");
                entity.Property(e => e.Rateover).HasColumnName("RATEOVER");
                entity.Property(e => e.Raterc)
                    .HasColumnType("decimal(15, 7)")
                    .HasColumnName("RATERC");
                entity.Property(e => e.Ratercover).HasColumnName("RATERCOVER");
                entity.Property(e => e.Ratetype)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("RATETYPE");
                entity.Property(e => e.Ratetyperc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("RATETYPERC");
                entity.Property(e => e.Raxamount1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT1");
                entity.Property(e => e.Raxamount2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT2");
                entity.Property(e => e.Raxamount3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT3");
                entity.Property(e => e.Raxamount4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT4");
                entity.Property(e => e.Raxamount5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT5");
                entity.Property(e => e.Raxbase1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE1");
                entity.Property(e => e.Raxbase2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE2");
                entity.Property(e => e.Raxbase3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE3");
                entity.Property(e => e.Raxbase4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE4");
                entity.Property(e => e.Raxbase5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE5");
                entity.Property(e => e.Rcpnumber)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("RCPNUMBER");
                entity.Property(e => e.Rcurndecml).HasColumnName("RCURNDECML");
                entity.Property(e => e.Reference)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("REFERENCE");
                entity.Property(e => e.Rqreceived)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQRECEIVED");
                entity.Property(e => e.Rtgamount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RTGAMOUNT");
                entity.Property(e => e.Rtgbase).HasColumnName("RTGBASE");
                entity.Property(e => e.Rtgrate).HasColumnName("RTGRATE");
                entity.Property(e => e.Rtgtaxrep).HasColumnName("RTGTAXREP");
                entity.Property(e => e.Rtgterms)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("RTGTERMS");
                entity.Property(e => e.Rxalloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT1");
                entity.Property(e => e.Rxalloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT2");
                entity.Property(e => e.Rxalloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT3");
                entity.Property(e => e.Rxalloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT4");
                entity.Property(e => e.Rxalloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT5");
                entity.Property(e => e.Rxexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT1");
                entity.Property(e => e.Rxexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT2");
                entity.Property(e => e.Rxexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT3");
                entity.Property(e => e.Rxexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT4");
                entity.Property(e => e.Rxexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT5");
                entity.Property(e => e.Rxrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT1");
                entity.Property(e => e.Rxrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT2");
                entity.Property(e => e.Rxrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT3");
                entity.Property(e => e.Rxrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT4");
                entity.Property(e => e.Rxrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT5");
                entity.Property(e => e.Scamount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("SCAMOUNT");
                entity.Property(e => e.Scurndecml).HasColumnName("SCURNDECML");
                entity.Property(e => e.Spread)
                    .HasColumnType("decimal(15, 7)")
                    .HasColumnName("SPREAD");
                entity.Property(e => e.Spreadrc)
                    .HasColumnType("decimal(15, 7)")
                    .HasColumnName("SPREADRC");
                entity.Property(e => e.Taramount1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT1");
                entity.Property(e => e.Taramount2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT2");
                entity.Property(e => e.Taramount3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT3");
                entity.Property(e => e.Taramount4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT4");
                entity.Property(e => e.Taramount5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT5");
                entity.Property(e => e.Taxamount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT");
                entity.Property(e => e.Taxamount1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT1");
                entity.Property(e => e.Taxamount2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT2");
                entity.Property(e => e.Taxamount3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT3");
                entity.Property(e => e.Taxamount4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT4");
                entity.Property(e => e.Taxamount5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT5");
                entity.Property(e => e.Taxauth1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TAXAUTH1");
                entity.Property(e => e.Taxauth2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TAXAUTH2");
                entity.Property(e => e.Taxauth3)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TAXAUTH3");
                entity.Property(e => e.Taxauth4)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TAXAUTH4");
                entity.Property(e => e.Taxauth5)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TAXAUTH5");
                entity.Property(e => e.Taxautocal).HasColumnName("TAXAUTOCAL");
                entity.Property(e => e.Taxbase1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE1");
                entity.Property(e => e.Taxbase2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE2");
                entity.Property(e => e.Taxbase3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE3");
                entity.Property(e => e.Taxbase4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE4");
                entity.Property(e => e.Taxbase5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE5");
                entity.Property(e => e.Taxclass1).HasColumnName("TAXCLASS1");
                entity.Property(e => e.Taxclass2).HasColumnName("TAXCLASS2");
                entity.Property(e => e.Taxclass3).HasColumnName("TAXCLASS3");
                entity.Property(e => e.Taxclass4).HasColumnName("TAXCLASS4");
                entity.Property(e => e.Taxclass5).HasColumnName("TAXCLASS5");
                entity.Property(e => e.Taxgroup)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TAXGROUP");
                entity.Property(e => e.Taxlines).HasColumnName("TAXLINES");
                entity.Property(e => e.Template)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TEMPLATE");
                entity.Property(e => e.Termscode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TERMSCODE");
                entity.Property(e => e.Tralloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT1");
                entity.Property(e => e.Tralloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT2");
                entity.Property(e => e.Tralloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT3");
                entity.Property(e => e.Tralloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT4");
                entity.Property(e => e.Tralloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT5");
                entity.Property(e => e.Trcurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("TRCURRENCY");
                entity.Property(e => e.Trexclude1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXCLUDE1");
                entity.Property(e => e.Trexclude2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXCLUDE2");
                entity.Property(e => e.Trexclude3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXCLUDE3");
                entity.Property(e => e.Trexclude4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXCLUDE4");
                entity.Property(e => e.Trexclude5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXCLUDE5");
                entity.Property(e => e.Trexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT1");
                entity.Property(e => e.Trexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT2");
                entity.Property(e => e.Trexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT3");
                entity.Property(e => e.Trexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT4");
                entity.Property(e => e.Trexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT5");
                entity.Property(e => e.Trinclude1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRINCLUDE1");
                entity.Property(e => e.Trinclude2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRINCLUDE2");
                entity.Property(e => e.Trinclude3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRINCLUDE3");
                entity.Property(e => e.Trinclude4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRINCLUDE4");
                entity.Property(e => e.Trinclude5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRINCLUDE5");
                entity.Property(e => e.Trrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT1");
                entity.Property(e => e.Trrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT2");
                entity.Property(e => e.Trrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT3");
                entity.Property(e => e.Trrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT4");
                entity.Property(e => e.Trrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT5");
                entity.Property(e => e.Txalloamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT");
                entity.Property(e => e.Txalloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT1");
                entity.Property(e => e.Txalloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT2");
                entity.Property(e => e.Txalloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT3");
                entity.Property(e => e.Txalloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT4");
                entity.Property(e => e.Txalloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT5");
                entity.Property(e => e.Txbaseallo)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXBASEALLO");
                entity.Property(e => e.Txexclude1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDE1");
                entity.Property(e => e.Txexclude2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDE2");
                entity.Property(e => e.Txexclude3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDE3");
                entity.Property(e => e.Txexclude4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDE4");
                entity.Property(e => e.Txexclude5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDE5");
                entity.Property(e => e.Txexcluded)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDED");
                entity.Property(e => e.Txexpsamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT");
                entity.Property(e => e.Txexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT1");
                entity.Property(e => e.Txexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT2");
                entity.Property(e => e.Txexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT3");
                entity.Property(e => e.Txexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT4");
                entity.Property(e => e.Txexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT5");
                entity.Property(e => e.Txinclude1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDE1");
                entity.Property(e => e.Txinclude2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDE2");
                entity.Property(e => e.Txinclude3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDE3");
                entity.Property(e => e.Txinclude4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDE4");
                entity.Property(e => e.Txinclude5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDE5");
                entity.Property(e => e.Txincluded)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDED");
                entity.Property(e => e.Txrecvamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT");
                entity.Property(e => e.Txrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT1");
                entity.Property(e => e.Txrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT2");
                entity.Property(e => e.Txrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT3");
                entity.Property(e => e.Txrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT4");
                entity.Property(e => e.Txrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT5");
                entity.Property(e => e.Values).HasColumnName("VALUES");
                entity.Property(e => e.Vdaddress1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDADDRESS1");
                entity.Property(e => e.Vdaddress2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDADDRESS2");
                entity.Property(e => e.Vdaddress3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDADDRESS3");
                entity.Property(e => e.Vdaddress4)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDADDRESS4");
                entity.Property(e => e.Vdcity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDCITY");
                entity.Property(e => e.Vdcode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDCODE");
                entity.Property(e => e.Vdcontact)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDCONTACT");
                entity.Property(e => e.Vdcountry)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDCOUNTRY");
                entity.Property(e => e.Vdemail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDEMAIL");
                entity.Property(e => e.Vdemailc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDEMAILC");
                entity.Property(e => e.Vdexists).HasColumnName("VDEXISTS");
                entity.Property(e => e.Vdfax)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDFAX");
                entity.Property(e => e.Vdfaxc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDFAXC");
                entity.Property(e => e.Vdname)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDNAME");
                entity.Property(e => e.Vdphone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDPHONE");
                entity.Property(e => e.Vdphonec)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDPHONEC");
                entity.Property(e => e.Vdstate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDSTATE");
                entity.Property(e => e.Vdzip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VDZIP");
                entity.Property(e => e.Vends).HasColumnName("VENDS");
                entity.Property(e => e.Vendscmpl).HasColumnName("VENDSCMPL");
                entity.Property(e => e.Vendsinvc).HasColumnName("VENDSINVC");
                entity.Property(e => e.Verprorate).HasColumnName("VERPRORATE");
                entity.Property(e => e.Viacode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VIACODE");
                entity.Property(e => e.Vianame)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VIANAME");
            });

            modelBuilder.Entity<Porcpl>(entity =>
            {
                entity.HasKey(e => new { e.Rcphseq, e.Rcplrev }).HasName("PORCPL_KEY_0");

                entity.ToTable("PORCPL");

                entity.Property(e => e.Rcphseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPHSEQ");
                entity.Property(e => e.Rcplrev)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPLREV");
                entity.Property(e => e.Address1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ADDRESS1");
                entity.Property(e => e.Address2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ADDRESS2");
                entity.Property(e => e.Address3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ADDRESS3");
                entity.Property(e => e.Address4)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ADDRESS4");
                entity.Property(e => e.Aritemno)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ARITEMNO");
                entity.Property(e => e.Arunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ARUNIT");
                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");
                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTORG");
                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");
                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTUSER");
                entity.Property(e => e.Billcurr)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("BILLCURR");
                entity.Property(e => e.Billrate)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("BILLRATE");
                entity.Property(e => e.Billtype).HasColumnName("BILLTYPE");
                entity.Property(e => e.Caxable1).HasColumnName("CAXABLE1");
                entity.Property(e => e.Caxable2).HasColumnName("CAXABLE2");
                entity.Property(e => e.Caxable3).HasColumnName("CAXABLE3");
                entity.Property(e => e.Caxable4).HasColumnName("CAXABLE4");
                entity.Property(e => e.Caxable5).HasColumnName("CAXABLE5");
                entity.Property(e => e.Ccategory)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CCATEGORY");
                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CITY");
                entity.Property(e => e.Completion).HasColumnName("COMPLETION");
                entity.Property(e => e.Contact)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CONTACT");
                entity.Property(e => e.Contract)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("CONTRACT");
                entity.Property(e => e.Costclass).HasColumnName("COSTCLASS");
                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("COUNTRY");
                entity.Property(e => e.Defextwght)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("DEFEXTWGHT");
                entity.Property(e => e.Defuweight)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("DEFUWEIGHT");
                entity.Property(e => e.Desc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DESC");
                entity.Property(e => e.Detailnum).HasColumnName("DETAILNUM");
                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("DISCOUNT");
                entity.Property(e => e.Discountf)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("DISCOUNTF");
                entity.Property(e => e.Discpct)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("DISCPCT");
                entity.Property(e => e.Dlocation)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("DLOCATION");
                entity.Property(e => e.Droptype).HasColumnName("DROPTYPE");
                entity.Property(e => e.Dtarrival)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTARRIVAL");
                entity.Property(e => e.Dtcomplete)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("DTCOMPLETE");
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("EMAIL");
                entity.Property(e => e.Emailc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("EMAILC");
                entity.Property(e => e.Extended)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("EXTENDED");
                entity.Property(e => e.Extweight)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("EXTWEIGHT");
                entity.Property(e => e.Fasdetail).HasColumnName("FASDETAIL");
                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("FAX");
                entity.Property(e => e.Faxc)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("FAXC");
                entity.Property(e => e.Glacexpens)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("GLACEXPENS");
                entity.Property(e => e.Glnonstkcr)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("GLNONSTKCR");
                entity.Property(e => e.Hascomment).HasColumnName("HASCOMMENT");
                entity.Property(e => e.Hasdropshi).HasColumnName("HASDROPSHI");
                entity.Property(e => e.Idcust)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("IDCUST");
                entity.Property(e => e.Idcustshpt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("IDCUSTSHPT");
                entity.Property(e => e.Indbtable).HasColumnName("INDBTABLE");
                entity.Property(e => e.Invlines).HasColumnName("INVLINES");
                entity.Property(e => e.Itemdesc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ITEMDESC");
                entity.Property(e => e.Itemexists).HasColumnName("ITEMEXISTS");
                entity.Property(e => e.Itemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ITEMNO");
                entity.Property(e => e.Labelcount).HasColumnName("LABELCOUNT");
                entity.Property(e => e.Location)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("LOCATION");
                entity.Property(e => e.Lotqty)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("LOTQTY");
                entity.Property(e => e.Manitemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("MANITEMNO");
                entity.Property(e => e.Mprorated)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("MPRORATED");
                entity.Property(e => e.Oeonumber)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("OEONUMBER");
                entity.Property(e => e.Oqcanceled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQCANCELED");
                entity.Property(e => e.Oqinadjust)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQINADJUST");
                entity.Property(e => e.Oqordered)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQORDERED");
                entity.Property(e => e.Oqoutstand)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQOUTSTAND");
                entity.Property(e => e.Oqoutstpo)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQOUTSTPO");
                entity.Property(e => e.Oqpofilled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQPOFILLED");
                entity.Property(e => e.Oqprevrecv)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQPREVRECV");
                entity.Property(e => e.Oqrcpextra)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQRCPEXTRA");
                entity.Property(e => e.Oqreceived)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQRECEIVED");
                entity.Property(e => e.Oqreturned)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQRETURNED");
                entity.Property(e => e.Oqsettled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQSETTLED");
                entity.Property(e => e.Oqstocked)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQSTOCKED");
                entity.Property(e => e.Oqustocked)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("OQUSTOCKED");
                entity.Property(e => e.Orderconv)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("ORDERCONV");
                entity.Property(e => e.Orderdecml).HasColumnName("ORDERDECML");
                entity.Property(e => e.Orderunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ORDERUNIT");
                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("PHONE");
                entity.Property(e => e.Phonec)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("PHONEC");
                entity.Property(e => e.Pocomplete).HasColumnName("POCOMPLETE");
                entity.Property(e => e.Ponumber)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("PONUMBER");
                entity.Property(e => e.Porhseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("PORHSEQ");
                entity.Property(e => e.Porlseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("PORLSEQ");
                entity.Property(e => e.Postedtoic).HasColumnName("POSTEDTOIC");
                entity.Property(e => e.Project)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("PROJECT");
                entity.Property(e => e.Raxamount1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT1");
                entity.Property(e => e.Raxamount2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT2");
                entity.Property(e => e.Raxamount3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT3");
                entity.Property(e => e.Raxamount4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT4");
                entity.Property(e => e.Raxamount5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXAMOUNT5");
                entity.Property(e => e.Raxbase1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE1");
                entity.Property(e => e.Raxbase2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE2");
                entity.Property(e => e.Raxbase3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE3");
                entity.Property(e => e.Raxbase4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE4");
                entity.Property(e => e.Raxbase5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RAXBASE5");
                entity.Property(e => e.Rcpconv)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("RCPCONV");
                entity.Property(e => e.Rcpcseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPCSEQ");
                entity.Property(e => e.Rcpdecml).HasColumnName("RCPDECML");
                entity.Property(e => e.Rcplseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPLSEQ");
                entity.Property(e => e.Rcpunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("RCPUNIT");
                entity.Property(e => e.Rqcanceled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQCANCELED");
                entity.Property(e => e.Rqinadjust)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQINADJUST");
                entity.Property(e => e.Rqordered)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQORDERED");
                entity.Property(e => e.Rqoutstand)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQOUTSTAND");
                entity.Property(e => e.Rqoutstpo)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQOUTSTPO");
                entity.Property(e => e.Rqpofilled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQPOFILLED");
                entity.Property(e => e.Rqprevrecv)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQPREVRECV");
                entity.Property(e => e.Rqrcpextra)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQRCPEXTRA");
                entity.Property(e => e.Rqreceived)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQRECEIVED");
                entity.Property(e => e.Rqreturned)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQRETURNED");
                entity.Property(e => e.Rqsettled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQSETTLED");
                entity.Property(e => e.Rqstocked)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQSTOCKED");
                entity.Property(e => e.Rqustocked)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("RQUSTOCKED");
                entity.Property(e => e.Rtgamount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RTGAMOUNT");
                entity.Property(e => e.Rtgamtover).HasColumnName("RTGAMTOVER");
                entity.Property(e => e.Rtgdays).HasColumnName("RTGDAYS");
                entity.Property(e => e.Rtgpercent)
                    .HasColumnType("decimal(9, 5)")
                    .HasColumnName("RTGPERCENT");
                entity.Property(e => e.Rxalloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT1");
                entity.Property(e => e.Rxalloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT2");
                entity.Property(e => e.Rxalloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT3");
                entity.Property(e => e.Rxalloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT4");
                entity.Property(e => e.Rxalloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXALLOAMT5");
                entity.Property(e => e.Rxexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT1");
                entity.Property(e => e.Rxexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT2");
                entity.Property(e => e.Rxexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT3");
                entity.Property(e => e.Rxexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT4");
                entity.Property(e => e.Rxexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXEXPSAMT5");
                entity.Property(e => e.Rxrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT1");
                entity.Property(e => e.Rxrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT2");
                entity.Property(e => e.Rxrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT3");
                entity.Property(e => e.Rxrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT4");
                entity.Property(e => e.Rxrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("RXRECVAMT5");
                entity.Property(e => e.Serialqty).HasColumnName("SERIALQTY");
                entity.Property(e => e.Slitem).HasColumnName("SLITEM");
                entity.Property(e => e.Sqcanceled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQCANCELED");
                entity.Property(e => e.Sqinadjust)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQINADJUST");
                entity.Property(e => e.Sqordered)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQORDERED");
                entity.Property(e => e.Sqoutstand)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQOUTSTAND");
                entity.Property(e => e.Sqoutstpo)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQOUTSTPO");
                entity.Property(e => e.Sqpofilled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQPOFILLED");
                entity.Property(e => e.Sqprevrecv)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQPREVRECV");
                entity.Property(e => e.Sqrcpextra)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQRCPEXTRA");
                entity.Property(e => e.Sqreceived)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQRECEIVED");
                entity.Property(e => e.Sqreturned)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQRETURNED");
                entity.Property(e => e.Sqsettled)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQSETTLED");
                entity.Property(e => e.Sqstocked)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQSTOCKED");
                entity.Property(e => e.Squstocked)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("SQUSTOCKED");
                entity.Property(e => e.State)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("STATE");
                entity.Property(e => e.Stockdecml).HasColumnName("STOCKDECML");
                entity.Property(e => e.Stockitem).HasColumnName("STOCKITEM");
                entity.Property(e => e.Taramount1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT1");
                entity.Property(e => e.Taramount2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT2");
                entity.Property(e => e.Taramount3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT3");
                entity.Property(e => e.Taramount4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT4");
                entity.Property(e => e.Taramount5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TARAMOUNT5");
                entity.Property(e => e.Taxamount)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT");
                entity.Property(e => e.Taxamount1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT1");
                entity.Property(e => e.Taxamount2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT2");
                entity.Property(e => e.Taxamount3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT3");
                entity.Property(e => e.Taxamount4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT4");
                entity.Property(e => e.Taxamount5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXAMOUNT5");
                entity.Property(e => e.Taxbase1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE1");
                entity.Property(e => e.Taxbase2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE2");
                entity.Property(e => e.Taxbase3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE3");
                entity.Property(e => e.Taxbase4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE4");
                entity.Property(e => e.Taxbase5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TAXBASE5");
                entity.Property(e => e.Taxclass1).HasColumnName("TAXCLASS1");
                entity.Property(e => e.Taxclass2).HasColumnName("TAXCLASS2");
                entity.Property(e => e.Taxclass3).HasColumnName("TAXCLASS3");
                entity.Property(e => e.Taxclass4).HasColumnName("TAXCLASS4");
                entity.Property(e => e.Taxclass5).HasColumnName("TAXCLASS5");
                entity.Property(e => e.Taxinclud1).HasColumnName("TAXINCLUD1");
                entity.Property(e => e.Taxinclud2).HasColumnName("TAXINCLUD2");
                entity.Property(e => e.Taxinclud3).HasColumnName("TAXINCLUD3");
                entity.Property(e => e.Taxinclud4).HasColumnName("TAXINCLUD4");
                entity.Property(e => e.Taxinclud5).HasColumnName("TAXINCLUD5");
                entity.Property(e => e.Taxrate1)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("TAXRATE1");
                entity.Property(e => e.Taxrate2)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("TAXRATE2");
                entity.Property(e => e.Taxrate3)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("TAXRATE3");
                entity.Property(e => e.Taxrate4)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("TAXRATE4");
                entity.Property(e => e.Taxrate5)
                    .HasColumnType("decimal(15, 5)")
                    .HasColumnName("TAXRATE5");
                entity.Property(e => e.Tfalloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFALLOAMT1");
                entity.Property(e => e.Tfalloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFALLOAMT2");
                entity.Property(e => e.Tfalloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFALLOAMT3");
                entity.Property(e => e.Tfalloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFALLOAMT4");
                entity.Property(e => e.Tfalloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFALLOAMT5");
                entity.Property(e => e.Tfbaseallo)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFBASEALLO");
                entity.Property(e => e.Tfexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFEXPSAMT1");
                entity.Property(e => e.Tfexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFEXPSAMT2");
                entity.Property(e => e.Tfexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFEXPSAMT3");
                entity.Property(e => e.Tfexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFEXPSAMT4");
                entity.Property(e => e.Tfexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFEXPSAMT5");
                entity.Property(e => e.Tfinclude1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFINCLUDE1");
                entity.Property(e => e.Tfinclude2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFINCLUDE2");
                entity.Property(e => e.Tfinclude3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFINCLUDE3");
                entity.Property(e => e.Tfinclude4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFINCLUDE4");
                entity.Property(e => e.Tfinclude5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFINCLUDE5");
                entity.Property(e => e.Tfrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFRECVAMT1");
                entity.Property(e => e.Tfrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFRECVAMT2");
                entity.Property(e => e.Tfrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFRECVAMT3");
                entity.Property(e => e.Tfrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFRECVAMT4");
                entity.Property(e => e.Tfrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TFRECVAMT5");
                entity.Property(e => e.Tralloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT1");
                entity.Property(e => e.Tralloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT2");
                entity.Property(e => e.Tralloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT3");
                entity.Property(e => e.Tralloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT4");
                entity.Property(e => e.Tralloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRALLOAMT5");
                entity.Property(e => e.Trexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT1");
                entity.Property(e => e.Trexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT2");
                entity.Property(e => e.Trexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT3");
                entity.Property(e => e.Trexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT4");
                entity.Property(e => e.Trexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TREXPSAMT5");
                entity.Property(e => e.Trrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT1");
                entity.Property(e => e.Trrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT2");
                entity.Property(e => e.Trrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT3");
                entity.Property(e => e.Trrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT4");
                entity.Property(e => e.Trrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TRRECVAMT5");
                entity.Property(e => e.Txalloamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT");
                entity.Property(e => e.Txalloamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT1");
                entity.Property(e => e.Txalloamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT2");
                entity.Property(e => e.Txalloamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT3");
                entity.Property(e => e.Txalloamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT4");
                entity.Property(e => e.Txalloamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXALLOAMT5");
                entity.Property(e => e.Txbaseallo)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXBASEALLO");
                entity.Property(e => e.Txexcluded)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXCLUDED");
                entity.Property(e => e.Txexpsamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT");
                entity.Property(e => e.Txexpsamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT1");
                entity.Property(e => e.Txexpsamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT2");
                entity.Property(e => e.Txexpsamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT3");
                entity.Property(e => e.Txexpsamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT4");
                entity.Property(e => e.Txexpsamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXEXPSAMT5");
                entity.Property(e => e.Txincluded)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXINCLUDED");
                entity.Property(e => e.Txrecvamt)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT");
                entity.Property(e => e.Txrecvamt1)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT1");
                entity.Property(e => e.Txrecvamt2)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT2");
                entity.Property(e => e.Txrecvamt3)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT3");
                entity.Property(e => e.Txrecvamt4)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT4");
                entity.Property(e => e.Txrecvamt5)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("TXRECVAMT5");
                entity.Property(e => e.Ucismanual).HasColumnName("UCISMANUAL");
                entity.Property(e => e.Unitcost)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("UNITCOST");
                entity.Property(e => e.Unitweight)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("UNITWEIGHT");
                entity.Property(e => e.Values).HasColumnName("VALUES");
                entity.Property(e => e.Venditemno)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("VENDITEMNO");
                entity.Property(e => e.Weightconv)
                    .HasColumnType("decimal(19, 6)")
                    .HasColumnName("WEIGHTCONV");
                entity.Property(e => e.Weightunit)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("WEIGHTUNIT");
                entity.Property(e => e.Xidefextwt)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("XIDEFEXTWT");
                entity.Property(e => e.Xiextwght)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("XIEXTWGHT");
                entity.Property(e => e.Xinetxtend)
                    .HasColumnType("decimal(19, 3)")
                    .HasColumnName("XINETXTEND");
                entity.Property(e => e.Xirqrecevd)
                    .HasColumnType("decimal(19, 4)")
                    .HasColumnName("XIRQRECEVD");
                entity.Property(e => e.Zip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("ZIP");
            });

            modelBuilder.Entity<Porcpls>(entity =>
            {
                entity.HasKey(e => new { e.Rcphseq, e.Rcplrev, e.Serialnumf }).HasName("PORCPLS_KEY_0");

                entity.ToTable("PORCPLS");

                entity.Property(e => e.Rcphseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPHSEQ");
                entity.Property(e => e.Rcplrev)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPLREV");
                entity.Property(e => e.Serialnumf)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("SERIALNUMF");
                entity.Property(e => e.Audtdate)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTDATE");
                entity.Property(e => e.Audtorg)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTORG");
                entity.Property(e => e.Audttime)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("AUDTTIME");
                entity.Property(e => e.Audtuser)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("AUDTUSER");
                entity.Property(e => e.Rcplseq)
                    .HasColumnType("decimal(19, 0)")
                    .HasColumnName("RCPLSEQ");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
