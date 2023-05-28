using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces
{
    public interface ICallLogInterface
    {
        Task<IEnumerable<TblCallLog>> GetAllCallLogs();
        Task<TblCallLog> GetCallLogById(int id);
        Task<TblCallLog> CreateCallLog(TblCallLog callLog);
        Task<TblCallLog> UpdateCallLog(int id, TblCallLog callLog);
        Task<bool> DeleteCallLog(int id);
    }
}
