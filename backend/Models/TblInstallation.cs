using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblInstallation
    {
        public int? TicketId { get; set; }
        public DateTime? InstallationDate { get; set; }
        public string? Installer { get; set; }
        public string? JobRef { get; set; }
        public string? EquipmentsDetails { get; set; }
    }
}
