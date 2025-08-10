using FluentValidation;
using InvestorService.Business.BusinessModels.RequestDtos;

namespace InvestorService.Api.Validators
{
    public class GetInvestorsCommitmentRequestDtoValidator : AbstractValidator<GetInvestorsCommitmentRequestDto>
    {
        public GetInvestorsCommitmentRequestDtoValidator()
        {
            Include(new GetPaginatedResultsRequestDtoValidator());
            RuleFor(s => s.InvestorId)
                .GreaterThan(0);
        }
    }
}
