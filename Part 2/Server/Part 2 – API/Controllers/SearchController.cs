using Microsoft.AspNetCore.Mvc;
using Part_2___API.Interfaces;
using Part_2___API.Models;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public SearchController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet]
        public async Task<IActionResult> SearchAsync(string searchKeyword)
        {
            try
            {
                var response = await _gitHubService.SearchRepositoriesAsync(searchKeyword);

                if (response == null || response.Items == null || response.Items.Length == 0)
                {
                    return NotFound("No search results found.");
                }

                return Ok(response);
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "Failed to retrieve data from the GitHub API.");
            }
        }

    }

}