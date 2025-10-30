namespace SOPL.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string UserName { get; set; }
    }
}
