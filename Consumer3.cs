using Ilse.Bus.Subscriber;

namespace TestRabbit;

public class Consumer3(IBusSubscriber busSubscriber) : BaseConsumer<Message>(busSubscriber)
{
    private readonly Random _random = new Random();

    public override Task<bool> Consume(Message message)
    {
        Console.WriteLine($"Consumer 3 - receive message: {message}");
        Thread.Sleep(_random.Next(0, 50));
        return Task.FromResult(true);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await SubscribeAsync("TestMessage", GetType().Name);
    }
}
