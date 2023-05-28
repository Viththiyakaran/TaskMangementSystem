using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public class CallLogService : ICallLogInterface
    {
        private readonly AppDBContext _db;

        public CallLogService(AppDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TblCallLog>> GetAllCallLogs()
        {
            return await _db.TblCallLogs.ToListAsync();
        }

        public async Task<TblCallLog> GetCallLogById(int id)
        {
            return await _db.TblCallLogs.FirstOrDefaultAsync(c => c.TicketId == id);
        }

        public async Task<TblCallLog> CreateCallLog(TblCallLog callLog)
        {
            callLog.TicketId = GenerateTicketId();
            _db.TblCallLogs.Add(callLog);
            await _db.SaveChangesAsync();
            return callLog;
        }

        public async Task<TblCallLog> UpdateCallLog(int id, TblCallLog callLog)
        {
            var existingCallLog = await _db.TblCallLogs.FirstOrDefaultAsync(c => c.TicketId == id);
            if (existingCallLog == null)
            {
                return null;
            }

            existingCallLog.CallType = callLog.CallType;
            existingCallLog.BusinessType = callLog.BusinessType;
            existingCallLog.BusinessId = callLog.BusinessId;
            existingCallLog.ServiceType = callLog.ServiceType;
            existingCallLog.OpenDate = callLog.OpenDate;
            existingCallLog.OpenBy = callLog.OpenBy;
            existingCallLog.AssignedTo = callLog.AssignedTo;
            existingCallLog.AppointmentDate = callLog.AppointmentDate;
            existingCallLog.AppointmentType = callLog.AppointmentType;
            existingCallLog.Status = callLog.Status;
            existingCallLog.LastUpdate = DateTime.Now;

            await _db.SaveChangesAsync();

            return existingCallLog;
        }

        public async Task<bool> DeleteCallLog(int id)
        {
            var callLog = await _db.TblCallLogs.FirstOrDefaultAsync(c => c.TicketId == id);
            if (callLog == null)
            {
                return false;
            }

            _db.TblCallLogs.Remove(callLog);
            await _db.SaveChangesAsync();

            return true;
        }

        private int GenerateTicketId()
        {
            if (_db.TblCallLogs.Count() > 0)
            {
                int lastId = _db.TblCallLogs.Max(c => c.TicketId);
                return lastId + 1;
            }
            else
            {
                // If there are no existing call logs, start with a default ID
                return 1;
            }
        }
    }
}
