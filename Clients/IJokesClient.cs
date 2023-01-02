using DadJokes.Models;

namespace DadJokes.Clients
{
    public interface IJokesClient
    {
        Task<ApiDto> GetJokesResponseAsync();
    }
}
