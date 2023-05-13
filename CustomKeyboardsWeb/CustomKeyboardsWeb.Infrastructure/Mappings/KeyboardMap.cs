using CustomKeyboardsWeb.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Infrastructure.Mappings
{
    public class KeyboardMap : IEntityTypeConfiguration<Keyboard>
    {
        public void Configure(EntityTypeBuilder<Keyboard> entity)
        {
            entity.ToTable("Keyboard");

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

            entity.Property(e => e.Active)
                .HasMaxLength(1);

            entity.HasOne<Key>()
                .WithMany()
                .HasForeignKey(e => e.IdKey)
                .OnDelete(DeleteBehavior.NoAction);
            
            entity.HasOne<Switch>()
                .WithMany()
                .HasForeignKey(e => e.IdSwitch)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
