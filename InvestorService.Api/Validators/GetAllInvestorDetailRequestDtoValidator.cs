using FluentValidation;
using InvestorService.Business.BusinessModels.RequestDtos;

namespace InvestorService.Api.Validators
{
    public class GetAllInvestorDetailRequestDtoValidator : AbstractValidator<GetAllInvestorDetailRequestDto>
    {
        public GetAllInvestorDetailRequestDtoValidator()
        {
            Include(new GetPaginatedResultsRequestDtoValidator());
        }
    }
}
