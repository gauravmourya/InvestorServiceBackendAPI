namespace InvestorService.Repository.Database.DbEntities
{
    public class CommitmentAssetClass
    {
        public int AssetClassID { get; set; }
        public string AssetClassName { get; set; } = null!;

        public ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();
    }
}
