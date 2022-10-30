namespace App.Domain.Models;

public class Event
{
    public Event()
    {
    }

    public Event(string title)
    {
        Title = title;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

    public List<Ticket> Tickets { get; set; } = new();
}