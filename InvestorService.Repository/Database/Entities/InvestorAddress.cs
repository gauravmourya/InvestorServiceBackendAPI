namespace InvestorService.Repository.Database.Entities
{
    public class InvestorAddress
    {
        public int ID { get; set; }
        public int InvestorID { get; set; }
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
