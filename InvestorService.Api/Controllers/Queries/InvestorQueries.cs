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
        private readonly IValidator<GetAllInvestorDetailRequestDto> _getAllInvestorDetailRequestValidator;
        #endregion Declarations

        #region Public Members
        public InvestorQueries(
            ILogger<InvestorQueries> logger,
            IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>> getAllInvestorDetailsQueryHandler,
            IValidator<GetAllInvestorDetailRequestDto> getAllInvestorDetailRequestValidator
            )
        {
            _logger = logger;
            _getAllInvestorDetailsQueryHandler = getAllInvestorDetailsQueryHandler;
            _getAllInvestorDetailRequestValidator = getAllInvestorDetailRequestValidator;
        }

        [HttpPost]
        [Route("allInvestorDetails")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllInvestorDetailResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<Ok<GetAllInvestorDetailResponseDto>, BadRequest>> GetAllInvestorDetails(GetAllInvestorDetailRequestDto requestDto)
        {
            _logger.LogInformation($"{nameof(GetAllInvestorDetails)} function triggered to get all investor details");

            var validationResult = await _getAllInvestorDetailRequestValidator.ValidateAsync(requestDto);
            
            if (!validationResult.IsValid) {
                throw new ValidationException(validationResult.Errors);
            }

            var response = await _getAllInvestorDetailsQueryHandler.ExecuteQuery(requestDto);
            return TypedResults.Ok(response);
        }

        #endregion Public Members
    }
}
