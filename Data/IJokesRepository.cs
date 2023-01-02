using DadJokes.Models;

namespace DadJokes.Data
{
    public interface IJokesRepository
    {
        public Task<JokesViewModel> GetJokesAsync();        
    }
}
