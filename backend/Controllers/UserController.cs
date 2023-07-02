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

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(string UserName, string UserPassword)
        {
            try
            {
                var users = await _userService.LoginAsync(UserName, UserPassword);

                if (users != null)
                {
                    // Login successful
                    return Ok(users);
                }
                else
                {
                    // Invalid credentials
                    return BadRequest("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception and return an error message
                Console.WriteLine($"An error occurred during login: {ex.Message}");
                return StatusCode(500, "An error occurred during login. Please try again later.");
            }
        }


    }
}
