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