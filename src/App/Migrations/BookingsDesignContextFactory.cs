using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Migrations;

public class BookingsDesignContextFactory : IDesignTimeDbContextFactory<BookingsContext>
{
    public BookingsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookingsContext>();
        var version = new MySqlServerVersion("8.0");
        var connectionString = "Server=127.0.0.1;Port=3306;Database=bookings;Uid=root;Pwd=testdbpass;";
        optionsBuilder.UseMySql(connectionString, version);

        return new BookingsContext(optionsBuilder.Options);
    }
}