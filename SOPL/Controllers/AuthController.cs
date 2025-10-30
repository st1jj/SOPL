using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOPL.DTO;
using SOPL.Models;
using SOPL.Services.Auth;
using SOPL.Web;

namespace SOPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AccountService _accountServcice;
        
        private readonly IConfiguration _configuration;

        public AuthController( AccountService  AccountServcice, IConfiguration configuration)
        {
            _accountServcice = AccountServcice;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request )
        {
             _accountServcice.Register(request.UserName, request.Email, request.Password);
            return Ok(new { message = "Rejestracja powiodla się pomyślnie" });
        }
        [HttpPost(template: "login")]

        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok(_accountServcice.Login(request.Email, request.Password));
        }

    }
}
