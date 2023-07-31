using BDOLife.Application.Configurations.IoC;
using BDOLife.Application.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfiguration configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", false)
      .Build();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        IocConfiguration.ConfigureServices(services, configuration);
    }).Build();


var scraper = host.Services.GetService<ScraperTask>();

await scraper!.Extract();

await host.RunAsync();