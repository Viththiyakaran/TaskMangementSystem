using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblDepartment
    {
        public int DepartmentId { get; set; }
        public string DepName { get; set; } = null!;
        public string? DepDescription { get; set; }
        public int Vat { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
