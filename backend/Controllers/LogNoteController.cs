using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LogNoteController : ControllerBase
    {
        private readonly INoteLogInterface _logNoteService;

        public LogNoteController(INoteLogInterface logNoteController)
        {
            _logNoteService = logNoteController;

        }
        [HttpGet("GetCallLogNotesInfo/{id}")]
        public async Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id)
        {
            var callNotesLog = await _logNoteService.GetCallLogNotesById(id);
            if (callNotesLog == null)
            {
                return (IEnumerable<TblLogNote>)NotFound();
            }
            return callNotesLog;
        }



        [HttpPost("CreateNote")]
        public async Task<ActionResult<TblLogNote>> CreateCallLogNote(TblLogNote callLogNote)
        {
            var createdCallLogNote = await _logNoteService.CreateCallLogNote(callLogNote);
            return createdCallLogNote;
        }




    }
}
