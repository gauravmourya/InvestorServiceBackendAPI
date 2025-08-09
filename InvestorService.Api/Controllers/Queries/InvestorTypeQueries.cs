using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InvestorService.Api.Controllers.Queries
{
    [Route("investorType")]
    [ApiController]
    public class InvestorTypeQueries : ControllerBase
    {
        private readonly IGetAllQueryHandler<GetInvestorTypeRequestDto, Task<GetAllInvestorTypeResponseDto>> _getAllQueryHandler;
        public InvestorTypeQueries(
            IGetAllQueryHandler<GetInvestorTypeRequestDto, Task<GetAllInvestorTypeResponseDto>> getAllQueryHandler
            )
        {
            _getAllQueryHandler = getAllQueryHandler;
        }

        [HttpGet]
        [Route("investorTypes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllInvestorTypeResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<Ok<GetAllInvestorTypeResponseDto>, BadRequest>> GetAllInvestorTypesAsync()
        {
            var request = new GetInvestorTypeRequestDto();
            var response = await _getAllQueryHandler.ExecuteQuery(request);
            return TypedResults.Ok(response);
        }
    }
}
