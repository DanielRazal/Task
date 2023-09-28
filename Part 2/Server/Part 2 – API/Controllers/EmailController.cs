using Microsoft.AspNetCore.Mvc;
using Part_2___API.Interfaces;
using Part_2___API.Models;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(string email, Item item)
        {
            string subject = "The details about the item";

            string content = $@"
            <p>Name: {item.Name}</p>
            <img src='{item.Owner.Avatar_url}' alt='Owner Avatar' width='100' height='100'>";


            await _emailSender.SendEmail(email, subject, content);

            var response = new
            {
                Message = "The details have been successfully sent to your email",
                StatusCode = 200
            };

            return Ok(response);
        }

    }
}