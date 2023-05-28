using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblStockAdjustment
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Adjustment { get; set; }
        public string? Reason { get; set; }
        public DateTime? AdjustedDate { get; set; }
        public string? AdjustedBy { get; set; }
    }
}
