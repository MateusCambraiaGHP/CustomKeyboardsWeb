﻿using CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Data.Mappings
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.ToTable("Supplier");

            entity.HasKey(e => e.Id);

            entity.OwnsOne(e => e.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(20);

            entity.OwnsOne(e => e.FantasyName)
                .Property(n => n.Value)
                .HasColumnName("FantasyName")
                .HasMaxLength(40);

            entity.OwnsOne(e => e.Cep)
                .Property(c => c.Value)
                .HasColumnName("Cep")
                .HasMaxLength(15);

            entity.OwnsOne(e => e.Address)
                .Property(a => a.Value)
                .HasColumnName("Address")
                .HasMaxLength(40); ;

            entity.OwnsOne(e => e.FederativeUnit)
                .Property(fu => fu.Value)
                .HasColumnName("FederativeUnit")
                .HasMaxLength(5);

            entity.OwnsOne(e => e.Phone)
                .Property(p => p.Value)
                .HasColumnName("Phone")
                .HasMaxLength(20);

            entity.Property(e => e.Active)
                .HasMaxLength(1);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");

            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(20);
        }
    }
}
