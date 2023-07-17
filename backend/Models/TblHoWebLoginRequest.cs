namespace TaskManagementSystem.Models
{
    public partial class TblHoWebLoginRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime RequestDate { get; set; }
        public string Customer { get; set; } = null!;
    }
}
