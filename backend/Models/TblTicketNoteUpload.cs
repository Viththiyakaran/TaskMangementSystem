namespace TaskManagementSystem.Models
{
    public partial class TblTicketNoteUpload
    {
        public string FileNameGuid { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public int NoteId { get; set; }
    }
}
