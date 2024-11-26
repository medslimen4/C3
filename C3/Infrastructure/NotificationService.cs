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
    public class NotificationService : INotificationService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task NotifyAPIAsync(Machine machine, CancellationToken cancellationToken)
        {
            // Make a POST request to the API endpoint
            // with the updated machine state
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                using (var content = new StringContent(JsonSerializer.Serialize(machine), Encoding.UTF8, "application/json"))
                {
                    var response = await httpClient.PostAsync("your-api-endpoint", content, cancellationToken);
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
