using CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Data.Mappings
{
    public class KeyboardMap : IEntityTypeConfiguration<Keyboard>
    {
        public void Configure(EntityTypeBuilder<Keyboard> entity)
        {
            entity.ToTable("Keyboard");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.IdKey);

            entity.Property(e => e.IdSwitch);

            entity.OwnsOne(e => e.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(20);

            entity.OwnsOne(e => e.Price)
                .Property(p => p.Value)
                .HasColumnName("Price")
                .HasPrecision(15, 4);

            entity.Property(e => e.InsertionDate)
                .HasColumnType("datetime");

            entity.Property(e => e.InsertionBy)
                .HasMaxLength(20);

            entity.Property(e => e.LastModification)
                .HasColumnType("datetime");

            entity.Property(e => e.ModificationBy)
                .HasMaxLength(20);

            entity.Property(e => e.Active)
                .HasMaxLength(1);

            entity.HasOne(e => e.Key)
                .WithMany()
                .HasForeignKey(e => e.IdKey)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(e => e.Switch)
                .WithMany()
                .HasForeignKey(e => e.IdSwitch)
                .OnDelete(DeleteBehavior.NoAction);

            entity.Ignore(e => e.ValidationResult);
        }
    }
}
