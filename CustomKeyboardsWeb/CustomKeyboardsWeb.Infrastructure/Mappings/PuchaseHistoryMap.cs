using CustomKeyboardsWeb.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Infrastructure.Mappings
{
    public class PuchaseHistoryMap : IEntityTypeConfiguration<PuchaseHistory>
    {
        public void Configure(EntityTypeBuilder<PuchaseHistory> entity)
        {
            entity.ToTable("PuchaseHistory");

            entity.HasKey(e => e.Id);

            entity.OwnsOne(e => e.Price)
                .Property(p => p.Value)
                .HasColumnName("Price")
                .HasPrecision(15, 4);

            entity.Property(e => e.PuchaseDate)
                .HasColumnType("datetime");

            entity.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(e => e.IdCustomer)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne<Keyboard>()
                .WithMany()
                .HasForeignKey(e => e.IdKeyboard)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne<Supplier>()
                .WithMany()
                .HasForeignKey(e => e.IdSupplier)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
