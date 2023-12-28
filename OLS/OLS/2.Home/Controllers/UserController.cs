using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Users;
using OLS.DTO.Users.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
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
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Invalid request payload");
            }
            var loggedInUser = await _userRepository.LoginByEmail(request.Email, request.Password);

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

        [HttpPost("registerbyemail")]
        public async Task<IActionResult> RegisterByEmail([FromBody] RegisterByEmailRequest request)
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
            return Ok(new { Message = "Register success !!" });

        }

        [HttpPost("forgotbyemail")]
        public async Task<IActionResult> ForgotByEmail([FromBody] ForgotByEmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userRepository.ForgotByEmail(request);
            if (!result)
            {
                return BadRequest("Email is not valid or Not Connect !!");
            }
            return Ok(new { Message = "Send Mail success !!" });
        }

        [HttpPost("verifycode")]
        public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userRepository.VerifyCode(request))
            {
                return Ok(new { Message = "Mã xác thực hợp lệ" });
            }
            else
            {
                return BadRequest("Mã xác thực không hợp lệ");
            }


        }

        [HttpPost("resetbyemail")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPassByEmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userRepository.ResetPassword(request);

            if (result)
            {
                return Ok(new { Message = "Mật khẩu đã được cập nhật" });
            }
            else
            {
                return BadRequest("Không thể cập nhật mật khẩu");
            }
        }
    }
}
