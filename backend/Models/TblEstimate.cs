using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblEstimate
    {
        public int EstimateNumber { get; set; }
        public int? BusinessId { get; set; }
        public DateTime? InvDate { get; set; }
        public string? InvoiceBy { get; set; }
        public string? InvStatus { get; set; }
        public string? InvNote { get; set; }
        public DateTime? LastModified { get; set; }
        public string? ModifiedBy { get; set; }
        public int? ConvertedInvoice { get; set; }
    }
}
