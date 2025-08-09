using AutoMapper;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using InvestorService.Repository.DatabaseOperations.Interface;
using Microsoft.Extensions.Logging;

namespace InvestorService.Business.Handlers.QueryHandlers.InvestorQueries
{
    public class GetAllInvestorDetailQueryHandler : IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>>
    {
        #region Declarations
        private readonly ILogger<GetAllInvestorDetailQueryHandler> _logger;
        private readonly IInvestorRepository _investorRepository;
        private readonly IMapper _mapper;
        #endregion Declarations

        #region Public Members
        public GetAllInvestorDetailQueryHandler(
            ILogger<GetAllInvestorDetailQueryHandler> logger,
            IInvestorRepository investorRepository,
            IMapper mapper
            )
        {
            _logger = logger;
            _investorRepository = investorRepository;
            _mapper = mapper;
        }
        public async Task<GetAllInvestorDetailResponseDto> ExecuteQuery(GetAllInvestorDetailRequestDto request)
        {
            _logger.LogInformation($"{nameof(ExecuteQuery)} function triggered to get Investor Details");

            var investorDetails = await _investorRepository.GetInvestorDetailsAsync(request.PageNumber, request.PageSize);
            
            
            var response = new GetAllInvestorDetailResponseDto()
            {
                PageNumber = investorDetails.PageNumber,
                PageSize = investorDetails.PageSize,
                TotalCount = investorDetails.TotalCount,
                TotalPages = investorDetails.TotalPages,
                InvestorDetails = _mapper.Map<List<InvestorDetails>>(investorDetails.Items)
            };
            return response;
        }

        #endregion Public Members

    }
}
