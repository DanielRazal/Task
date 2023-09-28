using SendGrid;

namespace Part_2___API.Interfaces
{
    public interface IEmailSender
    {
        Task<Response> SendEmail(string email, string subject, string content);
    }
}