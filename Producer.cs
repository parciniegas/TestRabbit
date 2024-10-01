using Ilse.Bus.Publisher;
using Microsoft.Extensions.Hosting;

namespace TestRabbit;

public class Producer(IBusPublisher busPublisher) : BackgroundService
{
    private readonly Random _random = new();


    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested == false)
        {
            Console.WriteLine("Sending message...");
            var msg = new Message("Hello, World!", "This is a test message");
            busPublisher.PublishAsync(msg, "TestMessage");
            Thread.Sleep(_random.Next(50, 100));
        }
        return Task.CompletedTask;
    }
}
