using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCallLog>> GetCallLogById(int id)
        {
            var callLog = await _callLogService.GetCallLogById(id);
            if (callLog == null)
            {
                return NotFound();
            }
            return callLog;
        }

        [HttpPost]
        public async Task<ActionResult<TblCallLog>> CreateCallLog(TblCallLog callLog)
        {
            var createdCallLog = await _callLogService.CreateCallLog(callLog);
            return CreatedAtAction(nameof(GetCallLogById), new { id = createdCallLog.TicketId }, createdCallLog);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TblCallLog>> UpdateCallLog(int id, TblCallLog callLog)
        {
            var updatedCallLog = await _callLogService.UpdateCallLog(id, callLog);
            if (updatedCallLog == null)
            {
                return NotFound();
            }
            return updatedCallLog;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCallLog(int id)
        {
            var result = await _callLogService.DeleteCallLog(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
