using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            // Serialize the object to a JSON string
            string jsonContent = JsonConvert.SerializeObject(item);

            var x = await _emailSender.SendEmail(email, "Subject", jsonContent);

            return Ok(new { Message = "The details have been successfully sent to your email", StatusCode = 200, x });
        }

    }

}