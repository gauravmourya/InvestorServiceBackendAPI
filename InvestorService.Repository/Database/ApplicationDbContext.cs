using InvestorService.Repository.Database.DbEntities;
using InvestorService.Repository.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestorService.Repository.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<InvestorType> InvestorTypes { get; set; }
        public DbSet<InvestorCountry> InvestorCountries { get; set; }
        public DbSet<CommitmentAssetClass> CommitmentAssetClasses { get; set; }
        public DbSet<CommitmentCurrency> CommitmentCurrencies { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<InvestorAddress> InvestorAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // InvestorType
            modelBuilder.Entity<InvestorType>()
                .ToTable("InvestorType")
                .HasKey(it => it.ID);

            // InvestorCountry
            modelBuilder.Entity<InvestorCountry>()
                .ToTable("InvestorCountry")
                .HasKey(ic => ic.ID);

            // CommitmentAssetClass
            modelBuilder.Entity<CommitmentAssetClass>()
                .ToTable("CommitmentAssetClass")
                .HasKey(ac => ac.ID);

            // CommitmentCurrency
            modelBuilder.Entity<CommitmentCurrency>()
                .ToTable("CommitmentCurrency")
                .HasKey(cc => cc.ID);

            // Investor
            modelBuilder.Entity<Investor>()
                .ToTable("Investor")
                .HasKey(i => i.ID);
            modelBuilder.Entity<Investor>()
                .HasOne(i => i.InvestorType)
                .WithMany(it => it.Investors)
                .HasForeignKey(i => i.InvestorTypeID);
            modelBuilder.Entity<Investor>()
                .HasOne(i => i.Country)
                .WithMany(c => c.Investors)
                .HasForeignKey(i => i.CountryID);

            // Commitment
            modelBuilder.Entity<Commitment>()
                .ToTable("Commitment")
                .HasKey(c => c.ID);
            modelBuilder.Entity<Commitment>()
                .HasOne(c => c.Investor)
                .WithMany(i => i.Commitments)
                .HasForeignKey(c => c.InvestorID);
            modelBuilder.Entity<Commitment>()
                .HasOne(c => c.AssetClass)
                .WithMany(ac => ac.Commitments)
                .HasForeignKey(c => c.AssetClassID);
            modelBuilder.Entity<Commitment>()
                .HasOne(c => c.Currency)
                .WithMany(cc => cc.Commitments)
                .HasForeignKey(c => c.CurrencyID);

            // InvestorAddress
            modelBuilder.Entity<InvestorAddress>()
                .ToTable("InvestorAddress")
                .HasOne<Investor>()
                .WithMany()
                .HasForeignKey(a => a.InvestorID);
        }
    }
}
