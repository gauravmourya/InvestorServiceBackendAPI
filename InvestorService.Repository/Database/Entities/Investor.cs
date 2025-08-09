using InvestorService.Repository.Database.Entities;

namespace InvestorService.Repository.Database.DbEntities
{
    public class Investor
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public int InvestorTypeID { get; set; }
        public int CountryID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }

        public InvestorType InvestorType { get; set; } = null!;
        public InvestorCountry Country { get; set; } = null!;
        public ICollection<Commitment> Commitments { get; set; } = new List<Commitment>();
        public ICollection<InvestorAddress> InvestorAddresses { get; set; } = new List<InvestorAddress>();
    }
}
