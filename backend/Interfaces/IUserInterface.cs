using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces
{
    public interface IUserInterface
    {
        Task<IEnumerable<TblUser>> GetAllUsersDetails();
        //Task<TblUser> GetAllBusinessDetailsById(int businessId);
        //Task<TblUser> CreateCallLog(TblCallLog callLog);
        //Task<TblUser> UpdateCallLog(int id, TblCallLog callLog);
        //Task<bool> DeleteCallLog(int id);
        // Task<IEnumerable<TblUser>> GetAllCallLogsTaskInfo();
    }
}
