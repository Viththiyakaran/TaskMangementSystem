using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserInterface _userService;

        public UserController(IUserInterface userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUserInfo")]
        public async Task<IEnumerable<TblUser>> GetAllUsersDetails()
        {
            return await _userService.GetAllUsersDetails();
        }
    }
}
