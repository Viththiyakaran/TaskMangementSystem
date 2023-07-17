namespace TaskManagementSystem.Models
{
    public partial class TblCanceledReason
    {
        public int? TicketId { get; set; }
        public string? CanceledReasons { get; set; }
        public DateTime? CanceledDate { get; set; }
    }
}
