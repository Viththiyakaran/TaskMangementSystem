using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public class NoteLogService : INoteLogInterface
    {
        private readonly AppDBContext _db;

        public NoteLogService(AppDBContext db)
        {
            _db = db;
        }

        //public async Task<TblLogNote> CreateCallLogNote(TblLogNote callLogNote)
        //{
        //    await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.tblLogNotes ON");
        //    callLogNote.NoteId = GenerateNoteId();
        //    _db.TblLogNotes.Add(callLogNote);
        //    await _db.SaveChangesAsync();
        //    await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.tblLogNotes OFF");
        //    return callLogNote;
        //}

        public async Task<TblLogNote> CreateCallLogNote(TblLogNote callLogNote)
        {
            var ticketIdParam = new SqlParameter("@TicketId", callLogNote.TicketId);
            var logDateParam = new SqlParameter("@LogDate", callLogNote.LogDate);
            var logByParam = new SqlParameter("@LogBy", callLogNote.LogBy);
            var noteParam = new SqlParameter("@Note", callLogNote.Note);
            var statusParam = new SqlParameter("@Status", callLogNote.Status);
            var assignedToParam = new SqlParameter("@AssignedTo", callLogNote.AssignedTo);
            var appointmentTypeParam = new SqlParameter("@AppointmentType", callLogNote.AppointmentType);
            var appointmentDateParam = new SqlParameter("@AppointmentDate", callLogNote.AppointmentDate);



            await _db.Database.ExecuteSqlRawAsync(
                "EXEC SP_InsertLogNotes @TicketId, @LogBy, @Note, @Status, @AssignedTo, @AppointmentType, @AppointmentDate",
                ticketIdParam,
                logByParam,
                noteParam,
                statusParam,
                assignedToParam,
                appointmentTypeParam,
                appointmentDateParam

            );

            // Retrieve the NoteId from the output parameter



            return callLogNote;
        }



        public async Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id)
        {

            return await _db.TblLogNotes.Where(t => t.TicketId.Equals(id)).OrderByDescending(n => n.NoteId).ToListAsync();
        }

        private int GenerateNoteId()
        {
            if (_db.TblLogNotes.Count() > 0)
            {
                int lastId = _db.TblLogNotes.Max(c => c.NoteId);
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
