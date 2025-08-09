using AutoMapper;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Repository.Database.DbEntities;

namespace InvestorService.Business.Mapper
{
    public class InvestorMapper : Profile
    {
        public InvestorMapper()
        {

            CreateMap<InvestorType, InvestorTypeResponseDto>();
            
        }
    }
}
