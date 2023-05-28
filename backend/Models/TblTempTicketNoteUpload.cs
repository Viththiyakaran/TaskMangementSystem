using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblTempTicketNoteUpload
    {
        public string FileNameGuid { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string? UserName { get; set; }
    }
}
