using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces
{
    public interface ICallLogInterface
    {
        Task<IEnumerable<TblCallLog>> GetAllCallLogs();
        Task<IEnumerable<TblCallLogTaskInfo>> GetCallLogById(int id);
        Task<TblCallLog> CreateCallLog(TblCallLog callLog);
        Task<TblCallLog> UpdateCallLog(int id, TblCallLog callLog);
        Task<bool> DeleteCallLog(int id);
        Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsTaskInfo();
        Task<string> GenerateTicketId();
        Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsByMonthly();
        Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsByPendings();
        Task<IEnumerable<TblCallLogTaskInfo>> GetCallLogTaskInfoByUser(string assignedTo);

        Task<IEnumerable<TblCallLogTaskInfoCount>> GetAllCallLogsWeeklyPerformance();
    }
}
