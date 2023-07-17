namespace TaskManagementSystem.Models
{
    public partial class TblHoWebLicence
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime LicIssued { get; set; }
        public DateTime LicEnding { get; set; }
        public string IssuedBy { get; set; } = null!;
    }
}
