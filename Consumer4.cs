using Ilse.Bus.Subscriber;

namespace TestRabbit;

public class Consumer4(IBusSubscriber busSubscriber) : BaseConsumer<Message>(busSubscriber)
{
    private readonly Random _random = new Random();

    public override Task<bool> Consume(Message message)
    {
        Console.WriteLine($"Consumer 4 - receive message: {message}");
        Thread.Sleep(_random.Next(0, 50));
        return Task.FromResult(true);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return SubscribeAsync("TestMessage", GetType().Name);
    }
}
