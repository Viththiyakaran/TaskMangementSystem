using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblLicence
    {
        public int Id { get; set; }
        public string? Computer { get; set; }
        public string? LicenceKey { get; set; }
        public DateTime LicenceIssuedDate { get; set; }
        public DateTime LicenceExpiryDate { get; set; }
        public string IssuedBy { get; set; } = null!;
        public int BusinessId { get; set; }
        public string TillName { get; set; } = null!;
    }
}
