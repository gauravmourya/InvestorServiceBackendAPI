namespace InvestorService.Repository.Database.DbEntities
{
    public class CommitmentCurrency
    {
        public int CurrencyID { get; set; }
        public string CurrencyCode { get; set; } = null!;

        public ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();
    }
}
