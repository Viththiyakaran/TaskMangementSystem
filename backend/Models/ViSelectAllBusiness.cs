namespace TaskManagementSystem.Models
{
    public partial class ViSelectAllBusiness
    {
        public int BusinessId { get; set; }
        public int? CustomerId { get; set; }
        public string BType { get; set; } = null!;
        public string? CusName { get; set; }
        public string? BusName { get; set; }
        public string? BusTelephone { get; set; }
        public string? CusMobile { get; set; }
        public string? BusAddress { get; set; }
        public string? Postcode { get; set; }
    }
}
