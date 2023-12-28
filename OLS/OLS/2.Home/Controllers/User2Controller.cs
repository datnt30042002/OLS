using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Users.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User2Controller : ControllerBase
    {
        private readonly IUser2Repository user2Repo;
        public User2Controller(IUser2Repository user2Repo)
        {
            this.user2Repo = user2Repo;
        }

        // Login 
        [HttpPost("/login2")]
        public async Task<IActionResult> Login2([FromBody] UserLoginHomeDTO loginDto)
        {
            try
            {
                // Validate the request payload
                if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                {
                    return BadRequest("Invalid request payload");
                }

                // Perform login
                var loggedInUser = await user2Repo.Login2(loginDto.Email, loginDto.Password);

                if (loggedInUser != null)
                {
                    // Login successful, return success response
                    return Ok(new { Message = "Login successful", User = loggedInUser });
                }
                else
                {
                    // Login failed, return unauthorized
                    return Unauthorized("Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Get user by userId
        [HttpGet("/getUserByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<UserReadHomeDTO>>> GetUserByUserId(int userId)
        {
            try
            {
                var user = await user2Repo.GetUserByUserId(userId);
                return Ok(user);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
