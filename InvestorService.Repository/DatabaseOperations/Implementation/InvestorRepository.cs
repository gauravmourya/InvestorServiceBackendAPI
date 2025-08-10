using InvestorService.Repository.Database;
using InvestorService.Repository.DatabaseOperations.Helper;
using InvestorService.Repository.DatabaseOperations.Interface;
using InvestorService.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestorService.Repository.DatabaseOperations.Implementation
{
    public class InvestorRepository : IInvestorRepository
    {
        #region Declarations
        private readonly ApplicationDbContext _applicationDbContext;
        #endregion Declarations

        #region Public Members
        /// <summary>
        /// Initializes a instance of the InvestorRepository
        /// </summary>
        public InvestorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        /// <inheritdoc/>
        public async Task<PagedResult<InvestorDetails>> GetInvestorDetailsAsync(int pageNumber, int pageSize)
        {
            var result =  from investor in _applicationDbContext.Investors.AsNoTracking()
                          select new InvestorDetails
                          {
                              Id = investor.ID,
                              InvestorName = investor.Name,
                              InvestorType = investor.InvestorType.Name,
                              DateAdded = investor.DateAdded,
                              Address = investor.Country.Name,
                              TotalCommitment = investor.Commitments.Sum(s => s.Amount)
                          };
            var pagedResult = await QueryHelper.ToPagedResultAsync(result, pageNumber, pageSize);
            return pagedResult;
        }

        /// <inheritdoc/>
        public async Task<InvestorCommitmentModel> GetInvestorsCommitment(int investorId, string assetClass, int pageNumber, int pageSize)
        {
            var commitments = from investor in _applicationDbContext.Investors.AsNoTracking()
                              join commitment in _applicationDbContext.Commitments.AsNoTracking() on investor.ID equals commitment.InvestorID
                              join asset in _applicationDbContext.CommitmentAssetClasses.AsNoTracking() on commitment.AssetClassID equals asset.ID
                              join currency in _applicationDbContext.CommitmentCurrencies.AsNoTracking() on commitment.CurrencyID equals currency.ID
                              where investor.ID == investorId && string.IsNullOrEmpty(assetClass)? true: asset.Name == assetClass
                              select new CommitmentModel
                              {
                                  Id = commitment.ID,
                                  AssetClass = asset.Name,
                                  Amount = commitment.Amount,
                                  Date = commitment.Date,
                                  Currency = currency.CurrencyCode
                              };
            var pagedResult = await QueryHelper.ToPagedResultAsync(commitments, pageNumber, pageSize);
            var assetClassesDetails = await (from investor in _applicationDbContext.Investors.AsNoTracking()
                                            join commitment in _applicationDbContext.Commitments.AsNoTracking()
                                            on investor.ID equals commitment.InvestorID
                                            join asset in _applicationDbContext.CommitmentAssetClasses.AsNoTracking()
                                                on commitment.AssetClassID equals asset.ID
                                            where investor.ID == investorId
                                            group new { asset, commitment } by new { asset.Name, asset.ID } into assetGroup
                                            select new AssetClassModel
                                            {
                                                Name = assetGroup.Key.Name,
                                                TotalSum = assetGroup.Sum(x => x.commitment.Amount)
                                            }
                                        ).ToListAsync();
            return new InvestorCommitmentModel()
            {
                AssetClasses = assetClassesDetails,
                Commitments = pagedResult
            };
        }

        #endregion Public Members
    }
}
