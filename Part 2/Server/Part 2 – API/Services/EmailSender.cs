using Part_2___API.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Part_2___API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response> SendEmail(string email, string subject, string content)
        {

            var emailSender = "mr.danielrazal@gmail.com";
            var senderName = "Daniel Razal";
            var apiKey = _configuration.GetValue<string>("MyNewApiKey") ?? throw new ArgumentNullException("API key is not found.");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress(emailSender, senderName));
            msg.AddTo(new EmailAddress(email));
            msg.SetSubject(subject);
            msg.HtmlContent = content;
            var sendEmail = await client.SendEmailAsync(msg);
            return sendEmail;
        }
    }
}