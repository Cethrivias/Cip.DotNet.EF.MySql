using App.Domain.Models;
using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure;

public class BookingsContext : DbContext
{
    public BookingsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventConfiguration).Assembly);
    }

    public DbSet<Event> Events { get; set; }
}