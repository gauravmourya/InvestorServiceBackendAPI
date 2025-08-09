namespace InvestorService.Repository.Database.DbEntities
{
    public class InvestorCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; } = null!;

        public ICollection<Investor> Investors { get; set; } = new List<Investor>();
    }
}
