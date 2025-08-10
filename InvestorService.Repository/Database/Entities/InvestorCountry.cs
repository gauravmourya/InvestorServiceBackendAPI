namespace InvestorService.Repository.Database.DbEntities
{
    public class InvestorCountry
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Investor> Investors { get; set; } = new List<Investor>();
    }
}
