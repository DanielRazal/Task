using Part_2___API.Interfaces;

namespace Part_2___API.Services
{

public class GitHubApiService : IGitHubApiService
{
        private readonly HttpClient httpClient;
        private readonly string gitHubAccessToken;


        public GitHubApiService(IConfiguration configuration)
        {
            gitHubAccessToken = configuration.GetSection("GitHubApi")["AccessToken"];

            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com")
            };

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {gitHubAccessToken}");
        }

        public async Task<string> SearchRepositoriesAsync(string searchKeyword)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"/search/repositories?q={searchKeyword}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Error: " + response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}