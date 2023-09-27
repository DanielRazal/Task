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
            // var sendGridConfig = _configuration.GetSection("SendGrid");
            // var emailSender = sendGridConfig.GetValue<string>("EmailSender");
            // var senderName = sendGridConfig.GetValue<string>("SenderName");
            var apiKey = _configuration.GetValue<string>("MyNewApiKey");

            // var apiKey = "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";

            if (apiKey == null)
            {
                throw new ArgumentNullException("API key is not found.");
            }
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("mr.danielrazal@gmail.com", "Daniel Razal"));
            msg.AddTo(new EmailAddress(email));
            msg.SetSubject(subject);
            msg.HtmlContent = content;
            var sendEmail = await client.SendEmailAsync(msg);
            return sendEmail;
        }
    }
}