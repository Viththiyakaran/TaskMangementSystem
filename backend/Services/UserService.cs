using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public class UserService : IUserInterface
    {
        private readonly AppDBContext _db;
        public UserService(AppDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TblUser>> GetAllUsersDetails()
        {
            return await _db.TblUsers.ToListAsync();
        }
    }
}
