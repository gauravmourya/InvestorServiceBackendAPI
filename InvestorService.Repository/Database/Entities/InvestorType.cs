namespace InvestorService.Repository.Database.DbEntities
{
    public class InvestorType
    {
        public int InvestorTypeID { get; set; }
        public string InvestorTypeName { get; set; } = null!;

        public ICollection<Investor> Investors { get; set; } = new List<Investor>();
    }
}
