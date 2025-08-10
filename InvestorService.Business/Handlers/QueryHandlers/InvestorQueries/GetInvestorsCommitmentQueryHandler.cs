using AutoMapper;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using InvestorService.Repository.DatabaseOperations.Interface;
using InvestorService.Repository.Models;
using Microsoft.Extensions.Logging;

namespace InvestorService.Business.Handlers.QueryHandlers.InvestorQueries
{
    public class GetInvestorsCommitmentQueryHandler : IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>>
    {
        #region Declarations
        private readonly ILogger<GetInvestorsCommitmentQueryHandler> _logger;
        private readonly IInvestorRepository _investorRepository;
        private readonly IMapper _mapper;
        #endregion Declarations

        #region Public Members
        public GetInvestorsCommitmentQueryHandler(
            ILogger<GetInvestorsCommitmentQueryHandler> logger,
            IMapper mapper,
            IInvestorRepository investorRepository
            )
        {
            _mapper = mapper;
            _logger = logger;
            _investorRepository = investorRepository;
        }
        public async Task<GetInvestorsCommitmentResponseDto> ExecuteQuery(GetInvestorsCommitmentRequestDto request)
        {
            _logger.LogInformation($"{nameof(ExecuteQuery)} function triggered to get Investors commitment details");

            _logger.LogInformation("Calling investorRepository.GetInvestorsCommitment");
            var sqlResponseModel = await _investorRepository.GetInvestorsCommitment(request.InvestorId, request.AssetClass, request.PageNumber, request.PageSize);
            _logger.LogInformation("Response from investorRepository.GetInvestorsCommitment");

            return CreateResponse(sqlResponseModel);
        }
        #endregion Public Members

        #region Private Members
        private GetInvestorsCommitmentResponseDto CreateResponse(InvestorCommitmentModel sqlResponseModel)
        {
            return new GetInvestorsCommitmentResponseDto()
            {
                PageNumber = sqlResponseModel.Commitments.PageNumber,
                PageSize = sqlResponseModel.Commitments.PageSize,
                TotalCount = sqlResponseModel.Commitments.TotalCount,
                TotalPages = sqlResponseModel.Commitments.TotalPages,
                GroupedAssetClassDetails = _mapper.Map<List<GroupedAssetClassResponse>>(sqlResponseModel.AssetClasses),
                Commitments = _mapper.Map<List<GetInvestorsCommitmentResponse>>(sqlResponseModel.Commitments.Items)
            };
        }
        #endregion Private Members
    }
}
