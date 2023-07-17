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

    public partial class TblUserJWT
    {

        public string? UserName { get; set; }
        public string? UserToken { get; set; }
        public int UserId { get; set; }

    }
}
