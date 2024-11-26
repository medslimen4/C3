using C3.Business;
using C3.Domain.Services;
using C3.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

var serviceProvider = new ServiceCollection()
    .AddHttpClient()
    .AddScoped<IDataService, DataService>()
    .AddScoped<INotificationService, NotificationService>()
    .AddScoped<SimulationService>()
    .BuildServiceProvider();

var simulationService = serviceProvider.GetService<SimulationService>();
await simulationService.SimulateLaundromatAsync(CancellationToken.None);
