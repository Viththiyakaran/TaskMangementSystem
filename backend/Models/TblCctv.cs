namespace TaskManagementSystem.Models
{
    public partial class TblCctv
    {
        public int BusinessId { get; set; }
        public string? HardwareInfo { get; set; }
        public string? CctvNote { get; set; }
        public DateTime? InstalledDate { get; set; }
        public string? InstalledBy { get; set; }
        public int Id { get; set; }
    }
}
