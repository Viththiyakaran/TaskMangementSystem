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
            existingCallLog.ClosedBy = callLog.ClosedBy;
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




        public async Task<IEnumerable<TblCallLogTaskInfo>> GetCallLogTaskInfoByUser(string assignedTo)
        {
            var result = await (
                from callLogs in _db.TblCallLogs
                join businesses in _db.TblCustomerBusinesses on callLogs.BusinessId equals businesses.BusinessId
                join users in _db.TblUsers on callLogs.AssignedTo equals users.UserId
                where users.UserName.Equals(assignedTo) && !callLogs.Status.Contains("Completed      ")
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

        public async Task<IEnumerable<TblCallLogTaskInfoCount>> GetAllCallLogsWeeklyPerformance()
        {
            DateTime now = DateTime.Now;
            DateTime startOfWeek = now.AddDays(-(int)now.DayOfWeek); // Start of the current week (Sunday)
            DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1); // End of the current week (Saturday at 23:59:59)

            //var result = await (
            //    from callLogs in _db.TblCallLogs
            //    join users in _db.TblUsers on callLogs.ClosedBy equals users.UserId
            //    where users.IsActive == true && callLogs.ClosedDate >= startOfWeek && callLogs.ClosedDate <= endOfWeek
            //    && callLogs.Status.Contains("Completed")
            //    orderby callLogs.OpenDate descending
            //    select new TblCallLogTaskInfoCount
            //    {
            //        AssignedName = _db.TblUsers.Where(x => x.IsActive == true && x.UserId == callLogs.ClosedBy).Select(x => x.Name).ToList(),
            //        StatusCount = _db.TblCallLogs.Where(x => x.ClosedBy == users.UserId).Count(c => c.Status.Contains("Completed") && c.ClosedDate >= startOfWeek && c.ClosedDate <= endOfWeek),
            //        startOfWeek = startOfWeek,
            //        endOfWeek = endOfWeek,
            //        Status = callLogs.Status
            //    })
            //    .ToListAsync();

            var result = _db.TblCallLogs
                 .Where(callLogs => callLogs.Status.Contains("Completed") && callLogs.ClosedDate >= startOfWeek && callLogs.ClosedDate <= endOfWeek) // Add any other filter conditions for 'TblCallLogs' if needed
                 .Join(_db.TblUsers.Where(users => users.IsActive == true), // Join 'TblCallLogs' with 'TblUsers' based on 'ClosedBy' and 'UserId'
                     callLogs => callLogs.ClosedBy,
                     user => user.UserId,
                     (callLogs, user) => new TblCallLogTaskInfoCount
                     {
                         Status = callLogs.Status,
                         AssignedName = user.Name
                     })
                 .GroupBy(entry => new { entry.Status, entry.AssignedName }) // Group the data based on Status and AssignedName
                 .Select(group => new TblCallLogTaskInfoCount
                 {
                     Status = group.Key.Status,
                     AssignedName = group.Key.AssignedName,
                     StatusCount = group.Count(),
                     startOfWeek = startOfWeek,// Calculate the count for each group (status)
                     endOfWeek = endOfWeek
                 })
                 .ToList();



            //// Count the status occurrences
            //var statusCounts = result.GroupBy(x => x.Status)
            //                         .Select(g => new { Status = g.Key, Count = g.Count() })
            //                         .ToList();

            //// Get unique AssignedName values
            //var uniqueAssignedNames = result.Select(x => x.AssignedName).Distinct().ToList();


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
