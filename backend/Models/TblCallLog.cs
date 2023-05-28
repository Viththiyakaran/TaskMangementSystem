using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblCallLog
    {
        public int TicketId { get; set; }
        public string? CallType { get; set; }
        public string? BusinessType { get; set; }
        public int? BusinessId { get; set; }
        public string? ServiceType { get; set; }
        public DateTime? OpenDate { get; set; }
        public int? OpenBy { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? AppointmentType { get; set; }
        public string? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? ClosedBy { get; set; }
        public string? InitialNote { get; set; }
        public int? ClCustomerId { get; set; }
    }
}
