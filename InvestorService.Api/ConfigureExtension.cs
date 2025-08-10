using FluentValidation;
using InvestorService.Api.Validators;
using InvestorService.Business.BusinessModels.RequestDtos;

namespace InvestorService.Api
{
    public static class ConfigureExtension
    {
        public static IServiceCollection AddRequestValidators(this IServiceCollection services)
        {
            //services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<GetPaginatedResultsRequestDto>();
            services.AddScoped<IValidator<GetAllInvestorDetailRequestDto>, GetAllInvestorDetailRequestDtoValidator>();
            services.AddScoped<IValidator<GetPaginatedResultsRequestDto>, GetPaginatedResultsRequestDtoValidator>();
            services.AddScoped<IValidator<GetInvestorsCommitmentRequestDto>, GetInvestorsCommitmentRequestDtoValidator>();
            return services;
        }
    }
}
