using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using SOPL.Models;
using SOPL.Services.Auth.Email;
using SOPL.Web;
using System.Net;

namespace SOPL.Services.Auth
{
    public class AccountService
    {
        private readonly UserManager<Account> _userManager;
        private readonly JwtService _jwtService;
        private readonly EmailSenderService _emailService;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        public AccountService(UserManager<Account> userManager, JwtService jwtService,
            EmailSenderService emailService, IConfiguration config, ILogger<AccountService>logger)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _emailService = emailService;
            _config = config;
            _logger = logger;
        }

        public async Task Register(string username, string email, string password)
        {
            var account = new Account
            {
                UserName = username,
                Email = email
            };

            var result = await _userManager.CreateAsync(account, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Nie udało się zarejestrować użytkownika: {errors}");
            }
        }

        public async Task<string> Login(string username, string password)
        {
            var account = await _userManager.FindByNameAsync(username);
            if (account == null)
                throw new Exception("Nie znaleziono użytkownika");

            var result = await _userManager.CheckPasswordAsync(account, password);
            if (!result)
                throw new Exception("Niepoprawne hasło");

            return _jwtService.GenerateToken(account);
        }

        public async Task SendResetTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return; 

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(token);

            var callbackUrl = $"{_config["FrontendUrl"]}/reset-password?email={email}&token={encodedToken}";

            await _emailService.SendEmailAsync(
                email,
                "Reset your password",
                $"Click <a href='{callbackUrl}'>here</a> to reset your password."
            );
            _logger.LogInformation(encodedToken);
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var decodedToken = WebUtility.UrlDecode(token);
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, newPassword);
            return result.Succeeded;
        }
    }
}
