namespace TaskManagementSystem.Models
{
    public partial class TblCustomerInfo
    {
        public int CustomerId { get; set; }
        public string CusName { get; set; } = null!;
        public string? CusMobile { get; set; }
        public string? CusEmail { get; set; }
        public string? CusNote { get; set; }
        public int CusGroupId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
