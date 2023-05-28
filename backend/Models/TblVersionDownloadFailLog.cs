using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblVersionDownloadFailLog
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int TillNo { get; set; }
        public string ExceptionMsg { get; set; } = null!;
        public DateTime FailedDate { get; set; }
    }
}
