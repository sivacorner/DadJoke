using AutoMapper;
using DadJokes.Clients;
using DadJokes.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DadJokes.Data
{
    public class JokesRepository : IJokesRepository
    {
        private readonly IJokesClient _jokesClient;
        private readonly IMapper _map;

        public JokesRepository(IJokesClient jokesClient, IMapper map)
        {
            this._jokesClient = jokesClient;
            this._map = map;
        }

        public async Task<JokesViewModel> GetJokesAsync()
        {           

            ApiDto apiResult = await _jokesClient.GetJokesResponseAsync();
            JokesViewModel? result = null;

            if(apiResult.success == true)
            {                
                result = _map.Map<JokesViewModel>(apiResult.body[0]);
            }

            return result;
        }
    }
}
