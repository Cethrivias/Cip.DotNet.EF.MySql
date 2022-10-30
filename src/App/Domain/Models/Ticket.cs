namespace App.Domain.Models;

public class Ticket
{
    public Ticket()
    {
    }

    public Ticket(Event @event, string client)
    {
        EventId = @event.Id;
        Event = @event;
        Client = client;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Client { get; set; }
    public int EventId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public Event Event { get; set; }
}