using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblMobileDevice
    {
        public string Uuid { get; set; } = null!;
        public int CustId { get; set; }
        public DateTime LicEnding { get; set; }
    }
}
