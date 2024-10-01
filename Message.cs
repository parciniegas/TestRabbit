namespace TestRabbit;

public class Message
{
    public Message(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}";
    }
}
