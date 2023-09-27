namespace Part_2___API.Interfaces
{
    public interface IGitHubApiService
    {
        Task<string> SearchRepositoriesAsync(string searchKeyword);
        void Dispose();
    }
}
