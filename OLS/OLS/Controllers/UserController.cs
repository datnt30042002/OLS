using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Users;
using OLS.Repositories.Interface;

namespace OLS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("loginbyemail")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByEmail([FromForm] LoginByEmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userRepository.LoginByEmail(request);
            if (resultToken == null)
            {
                return BadRequest("Email and Password is not valid !!");
            }
            return Ok(new { token = resultToken });

        }

        [HttpPost("registerbyemail")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterByEmail([FromForm] RegisterByEmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userRepository.RegisterByEmail(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful !!");
            }
            return Ok();

        }
    }
}