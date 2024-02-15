using CustomKeyboardsWeb.Domain.Primitives.Entities.Keys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Data.Mappings
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

            entity.Property(e => e.Active)
                .HasMaxLength(1);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.InsertionBy)
                .HasMaxLength(70);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");

            entity.Property(e => e.ModificationBy)
                .HasMaxLength(70);
        }
    }
}
