using InvestorService.Repository.Database;
using InvestorService.Repository.DatabaseOperations.Implementation;

namespace InvestorService.Repository.Tests
{
    public class InvestorRepositoryTests : RepositoryTestBase
    {
        [Fact]
        public async Task GetInvestorDetailsAsync_ReturnsPagedResultsWithCommitmentSum()
        {
            using var context = new ApplicationDbContext(DbContextOptions);
            var repo = new InvestorRepository(context);

            var pageNumber = 1;
            var pageSize = 10;

            var result = await repo.GetInvestorDetailsAsync(pageNumber, pageSize);

            Assert.NotNull(result);
            Assert.Equal(pageNumber, result.PageNumber);
            Assert.Equal(pageSize, result.PageSize);
            Assert.Equal(2, result.TotalCount);
            Assert.Equal(1, result.TotalPages);

            Assert.Equal(2, result.Items.Count);

            var investor1 = result.Items.Single(i => i.Id == 1);
            Assert.Equal("Investor1", investor1.InvestorName);
            Assert.Equal("TypeA", investor1.InvestorType);
            Assert.Equal("USA", investor1.Address);
            Assert.Equal(150000, investor1.TotalCommitment);

            var investor2 = result.Items.Single(i => i.Id == 2);
            Assert.Equal("Investor2", investor2.InvestorName);
            Assert.Equal(75000, investor2.TotalCommitment);
        }

        [Fact]
        public async Task GetInvestorsCommitment_ReturnsFilteredCommitmentsAndGroupedAssetClasses()
        {
            using var context = new ApplicationDbContext(DbContextOptions);
            var repo = new InvestorRepository(context);

            var result = await repo.GetInvestorsCommitment(1, "Equity", 1, 10);

            Assert.NotNull(result);
            Assert.NotNull(result.AssetClasses);
            Assert.NotNull(result.Commitments);

            Assert.Contains(result.AssetClasses, ac => ac.Name == "Equity" && ac.TotalSum == 100000);
            Assert.Contains(result.AssetClasses, ac => ac.Name == "Debt" && ac.TotalSum == 50000);

            var commitment = result.Commitments.Items.First();
            Assert.Equal("Equity", commitment.AssetClass);
            Assert.Equal(100000, commitment.Amount);
        }
    }
}