namespace TaskManagementSystem.Models
{
    public partial class TblMobileLoginRequest
    {
        public int Id { get; set; }
        public string Uuid { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime RequestDate { get; set; }
        public string Customer { get; set; } = null!;
    }
}
