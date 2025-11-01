using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SOPL.DTO;
using SOPL.DTO.Auth;
using SOPL.Models;
using SOPL.Services.Auth;


namespace SOPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AuthController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid request" });

            try
            {
                await _accountService.Register(request.UserName, request.Email, request.Password);
                return Ok(new { message = "Rejestracja powiodła się pomyślnie" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid request" });

            try
            {
                var token = await _accountService.Login(request.UserName, request.Password);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] DTO.Auth.ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid request" });

            await _accountService.SendResetTokenAsync(request.Email);
            return Ok(new { message = "Jeżeli konto istnieje, to będzie wysłany link do resetu hasła" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] DTO.Auth.ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid request" });

            var success = await _accountService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
            if (!success)
                return BadRequest(new { message = "Invalid token or email." });

            return Ok(new { message = "Hasło zresetowane pomyślnie." });
        }
    }
}
