using FluentValidation;
using InvestorService.Api.Validators;
using InvestorService.Business.BusinessModels.RequestDtos;

namespace InvestorService.Api
{
    public static class ConfigureExtension
    {
        public static IServiceCollection AddRequestValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetAllInvestorDetailRequestDto>, GetAllInvestorDetailRequestDtoValidator>();

            return services;
        }
    }
}
