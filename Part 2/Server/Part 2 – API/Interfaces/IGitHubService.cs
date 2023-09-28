
using Part_2___API.Models;

namespace Part_2___API.Interfaces
{
    public interface IGitHubService
    {
        Task<Rootobject> SearchRepositoriesAsync(string searchKeyword);
    }
}