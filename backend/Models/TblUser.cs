using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserPassword { get; set; }
        public string? UserGroup { get; set; }
        public Guid? UserGuid { get; set; }
        public bool? IsActive { get; set; }
    }
}
