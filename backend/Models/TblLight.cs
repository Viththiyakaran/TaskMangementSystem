using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblLight
    {
        public int BusinessId { get; set; }
        public string? HardwareInfo { get; set; }
        public string? LightNote { get; set; }
        public DateTime? InstalledDate { get; set; }
        public string? InstalledBy { get; set; }
        public int Id { get; set; }
    }
}
