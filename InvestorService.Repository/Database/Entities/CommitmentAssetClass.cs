namespace InvestorService.Repository.Database.DbEntities
{
    public class CommitmentAssetClass
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();
    }
}
