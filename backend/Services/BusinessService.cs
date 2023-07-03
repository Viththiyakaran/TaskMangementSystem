using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{

    public class BusinessService : IBusinessInterface
    {
        private readonly AppDBContext _db;
        public BusinessService(AppDBContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<TblCustomerBusiness>> GetAllBusinessDetails()
        {
            return await _db.TblCustomerBusinesses.ToListAsync();
        }

        public async Task<TblCustomerBusiness> GetAllBusinessDetailsById(int businessId)
        {
            return await _db.TblCustomerBusinesses.FirstOrDefaultAsync(business => business.BusinessId == businessId);
        }

    }
}
