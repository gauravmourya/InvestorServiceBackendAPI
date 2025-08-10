namespace InvestorService.Business.BusinessModels.RequestDtos
{
    public class GetInvestorsCommitmentRequestDto: GetPaginatedResultsRequestDto
    {
        public int InvestorId { get; set; }
        public string AssetClass { get; set; } = null!;
    }
}
