using InvestorService.Repository.Models;

namespace InvestorService.Repository.DatabaseOperations.Interface
{
    public interface IInvestorRepository
    {
        /// <summary>
        /// Gets all investor details from the database.
        /// </summary>
        /// <returns>Paginated investor details</returns>
        Task<PagedResult<InvestorDetails>> GetInvestorDetailsAsync(int pageNumber, int pageSize);
    }
}
