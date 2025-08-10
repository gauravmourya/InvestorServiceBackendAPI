namespace InvestorService.Repository.Models
{
    public class InvestorDetails
    {
        public int Id { get; set; }
        public string InvestorName { get; set; } = null!;
        public string InvestorType { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public string Address { get; set; } = null!;
        public decimal TotalCommitment { get; set; }
    }
}
