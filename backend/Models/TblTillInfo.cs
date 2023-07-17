namespace TaskManagementSystem.Models
{
    public partial class TblTillInfo
    {
        public string TillName { get; set; } = null!;
        public int BusinessId { get; set; }
        public DateTime? InstalledDate { get; set; }
        public string? InstalledBy { get; set; }
        public string? LogmeinName { get; set; }
        public string? LicenceKey { get; set; }
        public DateTime? LicenceIssuedDate { get; set; }
        public DateTime? LicenceExpiryDate { get; set; }
        public int SupportId { get; set; }
        public DateTime? SupportRenewedDate { get; set; }
        public DateTime? SupportExpiryDate { get; set; }
        public string? Computer { get; set; }
        public string? BarcodeScanner { get; set; }
        public string? Printer { get; set; }
        public string? CustomerDisplay { get; set; }
        public string? OtherHardwareInfo { get; set; }
        public string? TillNote { get; set; }
        public DateTime LastUpdate { get; set; }
        public string? UpdatedBy { get; set; }
        public string Version { get; set; } = null!;
    }
}
