using InvestorService.Business.BusinessModels.RequestDtos;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Handlers.Interfaces;
using InvestorService.Business.Handlers.QueryHandlers.InvestorQueries;
using InvestorService.Business.Handlers.QueryHandlers.InvestorTypeQueries;
using InvestorService.Business.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace InvestorService.Business
{
    public static class ConfigureExtension
    {
        public static IServiceCollection AddInvestorServiceBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(InvestorMapper));

            services.AddScoped<IGetAllQueryHandler<GetInvestorTypeRequestDto, Task<GetAllInvestorTypeResponseDto>>, GetAllInvestorTypeQueryHandler>();
            services.AddScoped<IGetAllQueryHandler<GetAllInvestorDetailRequestDto, Task<GetAllInvestorDetailResponseDto>>, GetAllInvestorDetailQueryHandler>();
            
            return services;
        }
    }
}
