using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event> {
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("events");

        builder.HasKey(it => it.Id);

        builder.Property(it => it.Id)
            .HasColumnName("id");

        builder.Property(it => it.Title)
            .HasMaxLength(255)
            .HasColumnName("title");
        builder.HasIndex(it => it.Title)
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