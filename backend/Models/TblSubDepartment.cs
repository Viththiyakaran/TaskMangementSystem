namespace TaskManagementSystem.Models
{
    public partial class TblSubDepartment
    {
        public int SubDepartmentId { get; set; }
        public int? DepartmentId { get; set; }
        public string SubDepName { get; set; } = null!;
        public string? SubDepDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}
