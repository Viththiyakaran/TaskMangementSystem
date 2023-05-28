using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        public string ProName { get; set; } = null!;
        public string? ProDescription { get; set; }
        public int DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? InstallerPrice { get; set; }
        public decimal? CostPrice { get; set; }
        public int? Stock { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
