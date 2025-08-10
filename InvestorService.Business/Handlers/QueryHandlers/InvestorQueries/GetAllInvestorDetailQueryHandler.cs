using AutoMapper;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using InvestorService.Repository.DatabaseOperations.Interface;
using Microsoft.Extensions.Logging;
using RepoModel = InvestorService.Repository.Models;

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

            _logger.LogInformation("Calling investorRepository.GetInvestorDetailsAsync");
            var investorDetails = await _investorRepository.GetInvestorDetailsAsync(request.PageNumber, request.PageSize);
            _logger.LogInformation("Response from investorRepository.GetInvestorDetailsAsync");

            return CreateResponse(investorDetails);
        }

        #endregion Public Members

        #region Private Members
        private GetAllInvestorDetailResponseDto CreateResponse(RepoModel.PagedResult<RepoModel.InvestorDetails> sqlResultModel)
        {
            return new GetAllInvestorDetailResponseDto()
            {
                PageNumber = sqlResultModel.PageNumber,
                PageSize = sqlResultModel.PageSize,
                TotalCount = sqlResultModel.TotalCount,
                TotalPages = sqlResultModel.TotalPages,
                InvestorDetails = _mapper.Map<List<InvestorDetails>>(sqlResultModel.Items)
            };
        }
        #endregion Private Members

    }
}
