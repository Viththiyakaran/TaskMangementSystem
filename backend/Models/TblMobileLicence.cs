namespace TaskManagementSystem.Models
{
    public partial class TblMobileLicence
    {
        public int Id { get; set; }
        public string Uuid { get; set; } = null!;
        public DateTime LicIssued { get; set; }
        public DateTime LicEnding { get; set; }
        public string IssuedBy { get; set; } = null!;
    }
}
