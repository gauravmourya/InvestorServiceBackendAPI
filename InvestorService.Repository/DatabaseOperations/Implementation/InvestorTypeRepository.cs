using InvestorService.Repository.Database;
using InvestorService.Repository.Database.DbEntities;
using InvestorService.Repository.DatabaseOperations.Interface;
using Microsoft.EntityFrameworkCore;

namespace InvestorService.Repository.DatabaseOperations.Implementation
{
    public class InvestorTypeRepository : IInvestorTypeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public InvestorTypeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<InvestorType>> GetAllInvestorTypesAsync()
        {
            var result = await _applicationDbContext.InvestorTypes.ToListAsync();
            return result;
        }
    }
}
