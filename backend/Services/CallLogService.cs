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

        public async Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsTaskInfo()
        {
            //return await _db.TblCallLogs.ToListAsync();

            var result = await (from callLogs in _db.TblCallLogs
                                join businesses in _db.TblCustomerBusinesses on callLogs.BusinessId equals businesses.BusinessId
                                join users in _db.TblUsers on callLogs.AssignedTo equals users.UserId
                                where (businesses.IsActive == true)
                                select new TblCallLogTaskInfo
                                {
                                    Status = callLogs.Status,
                                    TicketId = callLogs.TicketId,
                                    CallType = callLogs.CallType,
                                    BusinessId = callLogs.BusinessId,
                                    ServiceType = callLogs.ServiceType,
                                    OpenDate = callLogs.OpenDate,
                                    OpenBy = callLogs.OpenBy,
                                    AssignedTo = callLogs.AssignedTo,
                                    AppointmentDate = callLogs.AppointmentDate,
                                    AppointmentType = callLogs.AppointmentType,
                                    LastUpdate = callLogs.LastUpdate,
                                    ClosedDate = callLogs.ClosedDate,
                                    ClosedBy = callLogs.ClosedBy,
                                    InitialNote = callLogs.InitialNote,
                                    ClCustomerId = callLogs.ClCustomerId,
                                    BusinessName = businesses.BusName,
                                    AssignedName = users.Name
                                })
                                .OrderByDescending(t => t.OpenDate)
                                .Take(100)
                                .ToListAsync();

            return (result);




        }

        public async Task<IEnumerable<TblCallLogTaskInfo>> GetCallLogById(int id)
        {
            //return await _db.TblCallLogs.FirstOrDefaultAsync(c => c.TicketId == id);

            var result = await (from callLogs in _db.TblCallLogs
                                join businesses in _db.TblCustomerBusinesses on callLogs.BusinessId equals businesses.BusinessId
                                join users in _db.TblUsers on callLogs.AssignedTo equals users.UserId
                                where (businesses.IsActive == true)
                                select new TblCallLogTaskInfo
                                {
                                    Status = callLogs.Status,
                                    TicketId = callLogs.TicketId,
                                    CallType = callLogs.CallType,
                                    BusinessId = callLogs.BusinessId,
                                    ServiceType = callLogs.ServiceType,
                                    OpenDate = callLogs.OpenDate,
                                    OpenBy = callLogs.OpenBy,
                                    AssignedTo = callLogs.AssignedTo,
                                    AppointmentDate = callLogs.AppointmentDate,
                                    AppointmentType = callLogs.AppointmentType,
                                    LastUpdate = callLogs.LastUpdate,
                                    ClosedDate = callLogs.ClosedDate,
                                    ClosedBy = callLogs.ClosedBy,
                                    InitialNote = callLogs.InitialNote,
                                    ClCustomerId = callLogs.ClCustomerId,
                                    BusinessName = businesses.BusName,
                                    AssignedName = users.Name
                                })
                                .Where(t => t.TicketId == id)
                                .ToListAsync();

            return (result);
        }

        public async Task<TblCallLog> CreateCallLog(TblCallLog callLog)
        {
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
            var callLog = await _db.TblCallLogs.FindAsync(id);
            if (callLog == null)
            {
                return false;
            }

            _db.TblCallLogs.Remove(callLog);
            await _db.SaveChangesAsync();

            return true;
        }

        private int GenerateTicketIdd()
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

        public async Task<string> GenerateTicketId()
        {
            if (await _db.TblCallLogs.AnyAsync())
            {
                int lastId = await _db.TblCallLogs.MaxAsync(c => c.TicketId);
                return (lastId).ToString();
            }
            else
            {
                // If there are no existing call logs, start with a default ID
                return "1";
            }
        }

        public Task<IEnumerable<TblCallLog>> GetAllCallLogs()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsByMonthly()
        {
            DateTime now = DateTime.Now;
            DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var result = await (
                from callLogs in _db.TblCallLogs
                join businesses in _db.TblCustomerBusinesses on callLogs.BusinessId equals businesses.BusinessId
                join users in _db.TblUsers on callLogs.AssignedTo equals users.UserId
                where businesses.IsActive == true && callLogs.OpenDate >= startOfMonth && callLogs.OpenDate <= endOfMonth
                orderby callLogs.OpenDate descending
                select new TblCallLogTaskInfo
                {
                    Status = callLogs.Status,
                    TicketId = callLogs.TicketId,
                    CallType = callLogs.CallType,
                    BusinessId = callLogs.BusinessId,
                    ServiceType = callLogs.ServiceType,
                    OpenDate = callLogs.OpenDate,
                    OpenBy = callLogs.OpenBy,
                    AssignedTo = callLogs.AssignedTo,
                    AppointmentDate = callLogs.AppointmentDate,
                    AppointmentType = callLogs.AppointmentType,
                    LastUpdate = callLogs.LastUpdate,
                    ClosedDate = callLogs.ClosedDate,
                    ClosedBy = callLogs.ClosedBy,
                    InitialNote = callLogs.InitialNote,
                    ClCustomerId = callLogs.ClCustomerId,
                    BusinessName = businesses.BusName,
                    AssignedName = users.Name
                })
                .ToListAsync();

            return result;


        }

        public async Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsByPendings()
        {
            DateTime now = DateTime.Now;
            DateTime startOfYear = new DateTime(now.Year - 1, 1, 1);
            DateTime endOfYear = new DateTime(now.Year, 1, 1).AddDays(-1);

            var result = await (
                from callLogs in _db.TblCallLogs
                join businesses in _db.TblCustomerBusinesses on callLogs.BusinessId equals businesses.BusinessId
                join users in _db.TblUsers on callLogs.AssignedTo equals users.UserId
                where businesses.IsActive == true && callLogs.Status.Contains("Pending")
                orderby callLogs.OpenDate descending
                select new TblCallLogTaskInfo
                {
                    Status = callLogs.Status,
                    TicketId = callLogs.TicketId,
                    CallType = callLogs.CallType,
                    BusinessId = callLogs.BusinessId,
                    ServiceType = callLogs.ServiceType,
                    OpenDate = callLogs.OpenDate,
                    OpenBy = callLogs.OpenBy,
                    AssignedTo = callLogs.AssignedTo,
                    AppointmentDate = callLogs.AppointmentDate,
                    AppointmentType = callLogs.AppointmentType,
                    LastUpdate = callLogs.LastUpdate,
                    ClosedDate = callLogs.ClosedDate,
                    ClosedBy = callLogs.ClosedBy,
                    InitialNote = callLogs.InitialNote,
                    ClCustomerId = callLogs.ClCustomerId,
                    BusinessName = businesses.BusName,
                    AssignedName = users.Name
                })
                .ToListAsync();

            return result;



        }

        //public async Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id)
        //{
        //    //var result = await (from callLogs in _db.TblCallLogs
        //    //                    join notes in _db.TblLogNotes on callLogs.TicketId equals notes.TicketId
        //    //                    select new TblLogNote
        //    //                    {
        //    //                        NoteId = notes.NoteId,
        //    //                        TicketId = notes.TicketId,
        //    //                        LogDate = notes.LogDate,
        //    //                        LogBy = notes.LogBy,
        //    //                        Note = notes.Note,
        //    //                        Status = notes.Status,
        //    //                        AssignedTo = notes.AssignedTo,
        //    //                        AppointmentType = notes.AppointmentType,
        //    //                        AppointmentDate = notes.AppointmentDate,

        //    //                    })
        //    //                    .Where(t => t.TicketId == id)
        //    //                    .ToListAsync();

        //    return await _db.TblLogNotes.Where(t => t.TicketId.Equals(id)).OrderByDescending(n => n.NoteId).ToListAsync();

        //    //return (result);
        //}
    }
}
