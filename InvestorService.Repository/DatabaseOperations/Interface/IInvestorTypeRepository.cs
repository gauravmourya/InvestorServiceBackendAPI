using InvestorService.Repository.Database.DbEntities;

namespace InvestorService.Repository.DatabaseOperations.Interface
{
    public interface IInvestorTypeRepository
    {
        Task<IEnumerable<InvestorType>> GetAllInvestorTypesAsync();
    }
}
