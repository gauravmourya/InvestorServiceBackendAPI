namespace InvestorService.Business.BusinessModels.ResponseDtos
{
    public class InvestorTypeResponseDto
    {
        public int InvestorTypeID { get; set; }
        public string InvestorTypeName { get; set; } = null!;

    }

    public class GetAllInvestorTypeResponseDto
    {
        public List<InvestorTypeResponseDto> InvestorTypes { get; set; } = new List<InvestorTypeResponseDto>();
    }
}
