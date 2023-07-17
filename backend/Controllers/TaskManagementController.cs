using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagement.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CallLogController : ControllerBase
    {
        private readonly ICallLogInterface _callLogService;

        public CallLogController(ICallLogInterface callLogService)
        {
            _callLogService = callLogService;
        }

        [HttpGet]
        public async Task<IEnumerable<TblCallLog>> GetAllCallLogs()
        {
            return await _callLogService.GetAllCallLogs();
        }

        [HttpGet("GetAllCallLogTaskInfo")]
        public async Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogTaskInfo()
        {
            return await _callLogService.GetAllCallLogsTaskInfo();
        }

        [HttpGet("GetCallLogTaskInfoById/{id}")]
        public async Task<IEnumerable<TblCallLogTaskInfo>> GetCallLogById(int id)
        {
            var callLog = await _callLogService.GetCallLogById(id);
            if (callLog == null)
            {
                return (IEnumerable<TblCallLogTaskInfo>)NotFound();
            }
            return callLog;
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<TblCallLog>> CreateCallLog(TblCallLog callLog)
        {
            var createdCallLog = await _callLogService.CreateCallLog(callLog);
            return CreatedAtAction(nameof(GetCallLogById), new { id = createdCallLog.TicketId }, createdCallLog);
        }

        [HttpPut("PutCallLogTaskInfo/{id}")]
        public async Task<ActionResult<TblCallLog>> UpdateCallLog(int id, TblCallLog callLog)
        {
            var updatedCallLog = await _callLogService.UpdateCallLog(id, callLog);
            if (updatedCallLog == null)
            {
                return NotFound();
            }
            return updatedCallLog;
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<ActionResult> DeleteCallLog(int id)
        {
            var result = await _callLogService.DeleteCallLog(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("GenerateTicketId")]
        public async Task<ActionResult> GenerateTicketId()
        {
            var ticketId = await _callLogService.GenerateTicketId();

            return Ok(ticketId);
        }

        //[HttpGet("GetCallLogTaskNotesInfo/{id}")]
        //public async Task<IEnumerable<TblLogNote>> GetCallLogNotesById(int id)
        //{
        //    var callNotesLog = await _callLogService.GetCallLogNotesById(id);
        //    if (callNotesLog == null)
        //    {
        //        return (IEnumerable<TblLogNote>)NotFound();
        //    }
        //    return callNotesLog;
        //}


        [HttpGet("GetAllCallLogsByMonthly")]
        public async Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsByMonthly()
        {
            return await _callLogService.GetAllCallLogsByMonthly();
        }


        [HttpGet("GetAllCallLogsByPendings")]
        public async Task<IEnumerable<TblCallLogTaskInfo>> GetAllCallLogsByPendings()
        {
            return await _callLogService.GetAllCallLogsByPendings();
        }
    }
}
