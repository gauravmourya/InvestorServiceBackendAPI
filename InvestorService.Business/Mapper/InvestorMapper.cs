using AutoMapper;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Business.Helper;
using InvestorService.Repository.Database.DbEntities;
using RepoModel = InvestorService.Repository.Models;

namespace InvestorService.Business.Mapper
{
    public class InvestorMapper : Profile
    {
        public InvestorMapper()
        {

            CreateMap<InvestorType, InvestorTypeResponseDto>();
            CreateMap<RepoModel.InvestorDetails, InvestorDetails>()
                .ForMember(s=>s.DateAdded, opt => opt.MapFrom(s =>DateTimeHelper.FormatDateWithOrdinal(s.DateAdded)));
            CreateMap<RepoModel.AssetClassModel, GroupedAssetClassResponse>();
            CreateMap<RepoModel.CommitmentModel, GetInvestorsCommitmentResponse>();
        }
    }
}
