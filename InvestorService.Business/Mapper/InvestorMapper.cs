using AutoMapper;
using InvestorService.Business.BusinessModels.ResponseDtos;
using InvestorService.Repository.Database.DbEntities;
using RepoModel = InvestorService.Repository.Models;

namespace InvestorService.Business.Mapper
{
    public class InvestorMapper : Profile
    {
        public InvestorMapper()
        {

            CreateMap<InvestorType, InvestorTypeResponseDto>();
            CreateMap<RepoModel.InvestorDetails, InvestorDetails>();
            CreateMap<RepoModel.AssetClassModel, GroupedAssetClassResponse>();
            CreateMap<RepoModel.CommitmentModel, GetInvestorsCommitmentResponse>();
        }
    }
}
