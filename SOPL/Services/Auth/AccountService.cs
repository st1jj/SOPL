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
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebUtility.UrlEncode(token);

           
            var frontendUrl = _config["Frontend:BaseUrl"]; 
            var callbackUrl = $"{frontendUrl}/reset-password?email={email}&token={encodedToken}";

            await _emailService.SendEmailAsync(
                email,
                "Resetowanie hasła",
                $"Kliknij <a href='{callbackUrl}'>tutaj</a>, aby zresetować hasło."
            );
            _logger.LogInformation(encodedToken);

        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
    }
}
