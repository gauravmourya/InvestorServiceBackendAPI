using InvestorService.Repository.Database;
using InvestorService.Repository.DatabaseOperations.Helper;
using InvestorService.Repository.DatabaseOperations.Interface;
using InvestorService.Repository.Models;

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
        public async Task<PagedResult<InvestorDetails>> GetInvestorDetailsAsync(int pageNumber, int pageSize)
        {
            var result =  from investor in _applicationDbContext.Investors
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

        #endregion Public Members
    }
}
