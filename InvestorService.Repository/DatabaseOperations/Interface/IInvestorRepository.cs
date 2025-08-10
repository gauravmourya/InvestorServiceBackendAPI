using InvestorService.Repository.Models;

namespace InvestorService.Repository.DatabaseOperations.Interface
{
    public interface IInvestorRepository
    {
        /// <summary>
        /// Gets all investor details from the database.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Paginated investor details</returns>
        Task<PagedResult<InvestorDetails>> GetInvestorDetailsAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Get investor's commitment details based on investor ID and asset class.
        /// </summary>
        /// <param name="investorId"></param>
        /// <param name="assetClass"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>Paginated investor's commitment</returns>
        Task<InvestorCommitmentModel> GetInvestorsCommitment(int investorId, string assetClass, int pageNumber, int pageSize);
    }
}
