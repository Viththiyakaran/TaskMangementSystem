using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblServiceType
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = null!;
    }
}
