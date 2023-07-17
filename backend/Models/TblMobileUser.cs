namespace TaskManagementSystem.Models
{
    public partial class TblMobileUser
    {
        public string UserName { get; set; } = null!;
        public string? UserPassword { get; set; }
        public int CustId { get; set; }
        public DateTime LicEnding { get; set; }
        public string? UserEmailaddress { get; set; }
        public int UserStatus { get; set; }
        public string? UserStatusKey { get; set; }
        public string BusId { get; set; } = null!;
    }
}
