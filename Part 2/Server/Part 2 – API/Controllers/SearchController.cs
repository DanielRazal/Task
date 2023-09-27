using Microsoft.AspNetCore.Mvc;
using Part_2___API.Models;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SearchController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> SearchAsync(string searchKeyword)
        {
            try
            {
                string apiUrl = $"https://api.github.com/search/repositories?q={searchKeyword}";

                _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourApp/1.0");

                var httpResponse = await _httpClient.GetAsync(apiUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var response = await httpResponse.Content.ReadFromJsonAsync<Rootobject>();

                    return Ok(response);
                }
                else
                {
                    return StatusCode((int)httpResponse.StatusCode, "GitHub API request failed.");
                }
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "Failed to retrieve data from the GitHub API.");
            }
        }

    }

}