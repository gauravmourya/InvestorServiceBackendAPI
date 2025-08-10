namespace InvestorService.Business.BusinessModels.ResponseDtos
{
    public class GetInvestorsCommitmentResponseDto : GetPaginatedResultsResponseDto
    {
        public List<GetInvestorsCommitmentResponse> Commitments { get; set; } = new List<GetInvestorsCommitmentResponse>();
        public List<GroupedAssetClassResponse> GroupedAssetClassDetails { get; set; } = new List<GroupedAssetClassResponse>();
    }

    public class GetInvestorsCommitmentResponse
    {
        public int Id { get; set; }
        public string AssetClass { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class GroupedAssetClassResponse
    {
        public string Name { get; set; } = null!;
        public decimal TotalSum { get; set; }
    }
}
