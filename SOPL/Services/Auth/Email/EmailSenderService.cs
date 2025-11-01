using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using Azure.Core;

namespace SOPL.Services.Auth.Email
{
    public class EmailSenderService: IEmailSender
    {
        private readonly ILogger _logger;
        public AuthMessageSenderSettings Settings { get; }
        public EmailSenderService(ILogger <EmailSenderService>logger, IOptions<AuthMessageSenderSettings> settings )
        {
            Settings = settings.Value;
            _logger = logger;
            _logger.LogInformation($"[DEBUG] SendGrid key loaded: {(string.IsNullOrEmpty(Settings.ApiKey) ? "NULL" : "OK")}");
        }
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Settings.ApiKey))
            {
                _logger.LogInformation("=== EMAIL SENT (Development Mode) ===");
                _logger.LogInformation("To: {Email}", toEmail);
                _logger.LogInformation("Subject: {Subject}", subject);
                _logger.LogInformation("Message: {Message}", message);
                _logger.LogInformation("=====================================");
                return;
            }
            await Execute(Settings.ApiKey, subject, message, toEmail);
        }
        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("iskragame43@gmail.com", "Password Recovery"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
            var responseBody = await response.Body.ReadAsStringAsync();
            _logger.LogInformation($"SendGrid response status: {response.StatusCode}");
            _logger.LogInformation($"SendGrid response body: {responseBody}");

            
        }


    }
}
