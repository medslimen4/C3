using C3.Domain.Services;
using LaverieEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C3.Infrastructure
{
    public class DataService : IDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Proprietaire>> GetProprietairesAsync(CancellationToken cancellationToken)
        {
            // Make the HTTP request to the endpoint
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.GetAsync("your-endpoint-url", cancellationToken);
                response.EnsureSuccessStatusCode();

                // Deserialize the JSON response into a list of Proprietaires
                var proprietaires = await JsonSerializer.DeserializeAsync<List<Proprietaire>>(
                    await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return proprietaires;
            }
        }
    }
}

