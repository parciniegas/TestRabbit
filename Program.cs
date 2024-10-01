using Ilse.Bus.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using TestRabbit;

new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddBus()
    .AddPublisher()
    .AddConsumers();
switch (args.Length)
{
    case > 0 when args[0] == "consumers":
        builder.Services
            .AddHostedService<Consumer1>()
            .AddHostedService<Consumer2>()
            .AddHostedService<Consumer3>()
            .AddHostedService<Consumer4>();
        break;
    case > 0 when args[0] == "producer":
        builder.Services.AddHostedService<Producer>();
        break;
    default:
        builder.Services
            .AddHostedService<Consumer1>()
            .AddHostedService<Consumer2>()
            .AddHostedService<Consumer3>()
            .AddHostedService<Consumer4>();
        builder.Services.AddHostedService<Producer>();
        break;
}

var host = builder.Build();
await host.RunAsync();
Console.ReadLine();
