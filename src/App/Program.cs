using App.Domain.Models;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var optionsBuilder = new DbContextOptionsBuilder<BookingsContext>();
var version = new MySqlServerVersion("8.0");
var connectionString = "Server=127.0.0.1;Port=3306;Database=bookings;Uid=root;Pwd=testdbpass;";
optionsBuilder.UseMySql(connectionString, version)
    .LogTo(Console.WriteLine, LogLevel.Information);

var context = new BookingsContext(optionsBuilder.Options);

// Create
var @event = new Event("Ted Heeran Concert");
context.Events.Add(@event);
await context.SaveChangesAsync();

// Read
var readEvent = await context.Events.FindAsync(@event.Id);
Console.WriteLine(readEvent == @event);

// Update
readEvent.Title = "Taylor Slow Conecert";
await context.SaveChangesAsync();

// Delete
context.Remove(readEvent);
await context.SaveChangesAsync();

//a sync
//var eventsQuery = await context.Events.Where(e => e.Title.Contains("Concert")).ToListAsync();
//context.Events.RemoveRange(eventsQuery);

//await Task.WhenAll(new []
//{
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//    context.Events.FirstAsync(it => it.Id == @event.Id),
//});

//await context.Database.ExecuteSqlInterpolatedAsync($"delete from events where title = {"''; drop table events;"}");

@event = new Event("Ted Heeran concert");
var ticket = new Ticket()
{
    Client = "Dora the Destroyer",
    Event = @event,
    EventId = @event.Id
};
@event.Tickets.Add(ticket);

context.Events.Add(@event);

await context.SaveChangesAsync();

Console.WriteLine($"EventId: {@event.Id}");

ticket.Client = "Dora the Explorer";

await context.SaveChangesAsync();

await context.DisposeAsync();
context = new BookingsContext(optionsBuilder.Options);
readEvent = await context.Events.Where(it => it.Id == @event.Id)
    .Include(it => it.Tickets)
    .FirstAsync();
Console.WriteLine(readEvent.Id);
Console.WriteLine(readEvent.Tickets.Count);