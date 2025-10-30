using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using SOPL.Models;
using SOPL.Web;

namespace SOPL.Services.Auth
{
    public class AccountService
    {
        private readonly SdOPLDbContext _context;
        private readonly JwtService _jwtService;
        public void Register(string username, string email, string password)
        {
            var account = new Account
            {
                Id = Guid.NewGuid(),
                Email = email,
                UserName = username
            };

            var HashedPassword = new PasswordHasher<Account>().HashPassword(account, password);
            account.PasswordHash = HashedPassword;
            _context.AddAsync(account);
        }

        public string Login(string username, string password)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.UserName == username);

            var result = new PasswordHasher<Account>()
                .VerifyHashedPassword(account, account.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                return _jwtService.GenerateToken(account);
            }
            else
            {
                throw new Exception("Nie załogowałeś się!"); 
            }
        }
    }
}
