namespace InvestorService.Business.BusinessModels.ResponseDtos
{
    public class GetAllInvestorDetailResponseDto : GetPaginatedResultsResponseDto
    {
        public List<InvestorDetails> InvestorDetails { get; set; } = new List<InvestorDetails>();
    }
    public class InvestorDetails
    {
        public int Id { get; set; }
        public string InvestorName { get; set; } = null!;
        public string InvestorType { get; set; } = null!;
        public string DateAdded { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal TotalCommitment { get; set; }
    }
}
