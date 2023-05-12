﻿using CustomKeyboardsWeb.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Infrastructure.Mappings
{
    public class KeyMap : IEntityTypeConfiguration<Key>
    {
        public void Configure(EntityTypeBuilder<Key> entity)
        {
            entity.ToTable("Key");

            entity.HasKey(e => e.Id);

            entity.OwnsOne(e => e.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(20);

            entity.OwnsOne(e => e.Price)
                .Property(p => p.Value)
                .HasColumnName("Price")
                .HasPrecision(15, 4);

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20);

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime");

            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20);

        }
    }
}
