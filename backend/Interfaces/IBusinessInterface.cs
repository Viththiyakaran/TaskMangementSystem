using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces
{

    public interface IBusinessInterface
    {
        Task<IEnumerable<TblCustomerBusiness>> GetAllBusinessDetails();
        Task<TblCustomerBusiness> GetAllBusinessDetailsById(int businessId);
        //Task<TblCustomerBusiness> CreateCallLog(TblCallLog callLog);
        //Task<TblCustomerBusiness> UpdateCallLog(int id, TblCallLog callLog);
        //Task<bool> DeleteCallLog(int id);
        // Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsTaskInfo();
    }
}
