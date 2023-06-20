using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces
{
    public interface INoteLogInterface
    {
        Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id);

        Task<TblLogNote> CreateCallLogNote(TblLogNote callLogNote);
    }
}
