using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tickets");

        builder.HasKey(it => it.Id);

        builder.Property(it => it.Id)
            .HasColumnName("id");

        builder.Property(it => it.EventId)
            .HasColumnName("event_id");
        builder.HasOne<Event>(it => it.Event)
            .WithMany(@event => @event.Tickets)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(it => it.Client)
            .HasMaxLength(255)
            .HasColumnName("client");
        builder.HasIndex(it => it.Client)
            .IsFullText();

        builder.Property(it => it.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("current_timestamp");

        builder.Property(it => it.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("current_timestamp on update current_timestamp");
    }
}