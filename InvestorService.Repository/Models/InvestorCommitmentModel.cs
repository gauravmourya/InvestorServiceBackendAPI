namespace InvestorService.Repository.Models
{
    public class InvestorCommitmentModel
    {
        public PagedResult<CommitmentModel> Commitments { get; set; } = new PagedResult<CommitmentModel>();
        public List<AssetClassModel> AssetClasses { get; set; } = new List<AssetClassModel>();
    }
    public class CommitmentModel
    {
        public int Id { get; set; }
        public string AssetClass { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
    public class AssetClassModel
    {
        public string Name { get; set; } = null!;
        public decimal TotalSum { get; set; }
    }
}