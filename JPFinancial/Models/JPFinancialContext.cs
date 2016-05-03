namespace JPFinancial.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JPFinancialContext : DbContext
    {
        public JPFinancialContext()
            : base("name=JPFinancialContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<StockInfo> StockInfoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .Property(e => e.Zipcode)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .HasMany(e => e.StockInfoes)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Industry>()
                .HasMany(e => e.Companies)
                .WithRequired(e => e.Industry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.Companies)
                .WithRequired(e => e.Sector)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.Industries)
                .WithRequired(e => e.Sector)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.CloseYest)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.OpenPrice)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.High)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Low)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Volume)
                .HasPrecision(9, 0);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.AverageVolume)
                .HasPrecision(9, 0);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.MarketCap)
                .HasPrecision(12, 0);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.PE)
                .HasPrecision(5, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.EPS)
                .HasPrecision(5, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.High52)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Low52)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Change)
                .HasPrecision(6, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.ChangePct)
                .HasPrecision(3, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Beta)
                .HasPrecision(3, 2);

            modelBuilder.Entity<StockInfo>()
                .Property(e => e.Shares)
                .HasPrecision(12, 0);
        }
    }
}
