using AutoMapper;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using InvestorService.Repository.DatabaseOperations.Interface;

namespace InvestorService.Business.Handlers.QueryHandlers
{
    public class GetAllInvestorTypeQueryHandler : IGetAllQueryHandler<GetInvestorTypeRequestDto, Task<GetAllInvestorTypeResponseDto>>
    {
        private readonly IInvestorTypeRepository _investorTypeRepository;
        private readonly IMapper _mapper;
        public GetAllInvestorTypeQueryHandler(
            IInvestorTypeRepository investorTypeRepository,
            IMapper mapper
            )
        {
            _investorTypeRepository = investorTypeRepository;
            _mapper = mapper;
        }
        public async Task<GetAllInvestorTypeResponseDto> ExecuteQuery(GetInvestorTypeRequestDto request)
        {
            var response = await _investorTypeRepository.GetAllInvestorTypesAsync();
            var mappedResults = _mapper.Map<List<InvestorTypeResponseDto>>(response);
            return new GetAllInvestorTypeResponseDto() { InvestorTypes = mappedResults };
        }
    }
}
