using FluentValidation;
using InvestorService.Business.BusinessModels.RequestDtos;

namespace InvestorService.Api.Validators
{
    public class GetPaginatedResultsRequestDtoValidator : AbstractValidator<GetPaginatedResultsRequestDto>
    {
        public GetPaginatedResultsRequestDtoValidator()
        {

            RuleFor(x => x.PageNumber)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Page size must be greater than 0.");
        }
    }
}
