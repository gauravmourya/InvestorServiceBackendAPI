using InvestorService.Repository.Database;
using InvestorService.Repository.Database.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace InvestorService.Repository.Tests
{
    public abstract class RepositoryTestBase : IDisposable
    {
        protected readonly DbContextOptions<ApplicationDbContext> DbContextOptions;

        protected RepositoryTestBase()
        {
            // Unique database name per test run
            DbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Seed initial data synchronously because constructor can't be async
            using var context = new ApplicationDbContext(DbContextOptions);
            SeedData(context).GetAwaiter().GetResult();
        }

        protected virtual async Task SeedData(ApplicationDbContext context)
        {
            var investorType = new InvestorType { ID = 1, Name = "TypeA"};
            var country = new InvestorCountry { ID = 1, Name = "USA" };
            var assetClass1 = new CommitmentAssetClass { ID = 1, Name = "Equity" };
            var assetClass2 = new CommitmentAssetClass { ID = 2, Name = "Debt" };
            var currencyUsd = new CommitmentCurrency { ID = 1, CurrencyCode = "USD" };

            await context.InvestorTypes.AddAsync(investorType);
            await context.InvestorCountries.AddAsync(country);
            await context.CommitmentAssetClasses.AddRangeAsync(assetClass1, assetClass2);
            await context.CommitmentCurrencies.AddAsync(currencyUsd);

            var investors = new List<Investor>
        {
            new Investor
            {
                ID = 1,
                Name = "Investor1",
                DateAdded = DateTime.UtcNow.AddMonths(-3),
                CountryID = country.ID,
                InvestorTypeID = investorType.ID,
                Email = "test@gamas.com",
                Commitments = new List<Commitment>
                {
                    new Commitment
                    {
                        ID = 1,
                        AssetClassID = 1,
                        Amount = 100000,
                        CurrencyID = 1,
                        Date = DateTime.UtcNow.AddMonths(-2)
                    },
                    new Commitment
                    {
                        ID = 2,
                        AssetClassID = 2,
                        Amount = 50000,
                        CurrencyID = 1,
                        Date = DateTime.UtcNow.AddMonths(-1)
                    }
                }
            },
            new Investor
            {
                ID = 2,
                Name = "Investor2",
                DateAdded = DateTime.UtcNow.AddMonths(-1),
                CountryID = country.ID,
                InvestorTypeID = investorType.ID,
                Email = "test@gamas.com",
                Commitments = new List<Commitment>
                {
                    new Commitment
                    {
                        ID = 3,
                        AssetClassID = 1,
                        Amount = 75000,
                        CurrencyID = 1,
                        Date = DateTime.UtcNow.AddMonths(-1)
                    }
                }
            }
        };

            await context.Investors.AddRangeAsync(investors);

            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // Cleanup if needed
        }
    }
}