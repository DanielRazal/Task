
using Part_2___API.Interfaces;
using Part_2___API.Models;

namespace Part_2___API.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Rootobject> SearchRepositoriesAsync(string searchKeyword)
        {
            try
            {
                string apiUrl = $"https://api.github.com/search/repositories?q={searchKeyword}";

                _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourApp/1.0");

                var httpResponse = await _httpClient.GetAsync(apiUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadFromJsonAsync<Rootobject>();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        throw new Exception("Failed to deserialize the JSON response.");
                    }
                }
                else
                {
                    throw new HttpRequestException("GitHub API request failed.");
                }
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException("Failed to retrieve data from the GitHub API.");
            }
        }
    }

}