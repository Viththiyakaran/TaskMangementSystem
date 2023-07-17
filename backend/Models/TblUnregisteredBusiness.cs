namespace TaskManagementSystem.Models
{
    public partial class TblUnregisteredBusiness
    {
        public int UrBusinessId { get; set; }
        public string UrCusName { get; set; } = null!;
        public string? UrBusName { get; set; }
        public string? UrCusPhone { get; set; }
        public string? UrCusMobile { get; set; }
        public string? UrCusEmail { get; set; }
        public string? UrCusAddress { get; set; }
        public string? UrPostcode { get; set; }
        public string? UrCusNote { get; set; }
        public int? PropertyNo { get; set; }
        public int UrBusCustomerId { get; set; }
        public bool IsRegistered { get; set; }
        public string? UrCusGroup { get; set; }
    }
}
