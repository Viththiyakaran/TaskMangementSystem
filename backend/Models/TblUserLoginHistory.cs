namespace TaskManagementSystem.Models
{
    public partial class TblUserLoginHistory
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime LoginTime { get; set; }
        public bool Attempt { get; set; }
    }
}
