namespace InvestorService.Repository.Database.DbEntities
{
    public class Commitment
    {
        public int CommitmentID { get; set; }
        public int InvestorID { get; set; }
        public int AssetClassID { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyID { get; set; }

        public Investor Investor { get; set; } = null!;
        public CommitmentAssetClass AssetClass { get; set; } = null!;
        public CommitmentCurrency Currency { get; set; } = null!;
    }
}
