using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogNoteController : ControllerBase
    {
        private readonly INoteLogInterface _logNoteController;

        public LogNoteController(INoteLogInterface logNoteController)
        {
            _logNoteController = logNoteController;

        }
        [HttpGet("GetCallLogNotesInfo/{id}")]
        public async Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id)
        {
            var callNotesLog = await _logNoteController.GetCallLogNotesById(id);
            if (callNotesLog == null)
            {
                return (IEnumerable<TblLogNote>)NotFound();
            }
            return callNotesLog;
        }



        [HttpPost("CreateNote")]
        public async Task<ActionResult<TblLogNote>> CreateCallLogNote(TblLogNote callLogNote)
        {
            var createdCallLogNote = await _logNoteController.CreateCallLogNote(callLogNote);
            return createdCallLogNote;
        }
    }
}
