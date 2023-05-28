using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblDailyTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public DateTime? LastRunDate { get; set; }
    }
}
