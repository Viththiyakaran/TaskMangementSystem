using Microsoft.EntityFrameworkCore;
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

        public async Task<TblLogNote> CreateCallLogNote(TblLogNote callLogNote)
        {
            _db.TblLogNotes.Add(callLogNote);
            await _db.SaveChangesAsync();
            return callLogNote;
        }

        public async Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id)
        {

            return await _db.TblLogNotes.Where(t => t.TicketId.Equals(id)).OrderByDescending(n => n.NoteId).ToListAsync();
        }
    }
}
