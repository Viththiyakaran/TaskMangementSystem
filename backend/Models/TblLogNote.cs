using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public partial class TblLogNote
    {
        [Key]
        public int NoteId { get; set; }
        public int TicketId { get; set; }
        public DateTime? LogDate { get; set; }
        public int? LogBy { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public int? AssignedTo { get; set; }
        public string? AppointmentType { get; set; }
        public DateTime? AppointmentDate { get; set; }
    }
}
