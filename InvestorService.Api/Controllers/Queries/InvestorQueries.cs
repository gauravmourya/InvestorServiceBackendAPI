using FluentValidation;
using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InvestorService.Api.Controllers.Queries
{

    [Route("investor")]
    [ApiController]
    public class InvestorQueries : ControllerBase
    {
        #region Declarations
        private readonly ILogger<InvestorQueries> _logger;

        private readonly IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>> _getAllInvestorDetailsQueryHandler;
        private readonly IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>> _getInvestorsCommitmentDetailsQueryHandler;

        private readonly IValidator<GetAllInvestorDetailRequestDto> _getAllInvestorDetailRequestValidator;
        private readonly IValidator<GetInvestorsCommitmentRequestDto> _getInvestorsCommitmentRequestValidator;
        #endregion Declarations

        #region Public Members
        public InvestorQueries(
            ILogger<InvestorQueries> logger,
            IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>> getAllInvestorDetailsQueryHandler,
            IValidator<GetAllInvestorDetailRequestDto> getAllInvestorDetailRequestValidator,
            IGetAllQueryHandler<GetInvestorsCommitmentRequestDto, Task<GetInvestorsCommitmentResponseDto>> getInvestorsCommitmentDetailsQueryHandler,
            IValidator<GetInvestorsCommitmentRequestDto> getInvestorsCommitmentRequestValidator
            )
        {
            _logger = logger;
            _getAllInvestorDetailsQueryHandler = getAllInvestorDetailsQueryHandler;
            _getAllInvestorDetailRequestValidator = getAllInvestorDetailRequestValidator;
            _getInvestorsCommitmentRequestValidator = getInvestorsCommitmentRequestValidator;
            _getInvestorsCommitmentDetailsQueryHandler = getInvestorsCommitmentDetailsQueryHandler;
        }

        [HttpPost]
        [Route("allInvestorDetails")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllInvestorDetailResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<Ok<GetAllInvestorDetailResponseDto>, BadRequest>> GetAllInvestorDetails(GetAllInvestorDetailRequestDto requestDto)
        {
            _logger.LogInformation($"{nameof(GetAllInvestorDetails)} function triggered to get all investor details");

            var validationResult = await _getAllInvestorDetailRequestValidator.ValidateAsync(requestDto);
            
            if (!validationResult.IsValid) 
            {
                _logger.LogError("Invalid request");
                throw new ValidationException(validationResult.Errors);
            }

            _logger.LogInformation("Calling getAllInvestorDetailsQueryHandler.ExecuteQuery");
            var response = await _getAllInvestorDetailsQueryHandler.ExecuteQuery(requestDto);
            _logger.LogInformation("Response from getAllInvestorDetailsQueryHandler.ExecuteQuery");
            return TypedResults.Ok(response);
        }

        [HttpPost]
        [Route("investorCommitment")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetInvestorsCommitmentResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<Ok<GetInvestorsCommitmentResponseDto>, BadRequest>> GetInvestorsCommitments(GetInvestorsCommitmentRequestDto requestDto)
        {

            _logger.LogInformation($"{nameof(GetInvestorsCommitments)} function triggered to get all investors commitments");

            var validationResult = await _getInvestorsCommitmentRequestValidator.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Invalid request");
                throw new ValidationException(validationResult.Errors);
            }
            _logger.LogInformation("Calling getInvestorsCommitmentDetailsQueryHandler.ExecuteQuery");
            var response = await _getInvestorsCommitmentDetailsQueryHandler.ExecuteQuery(requestDto);
            _logger.LogInformation("Response from getInvestorsCommitmentDetailsQueryHandler.ExecuteQuery");
            return TypedResults.Ok(response);
        }   
        #endregion Public Members
    }
}
