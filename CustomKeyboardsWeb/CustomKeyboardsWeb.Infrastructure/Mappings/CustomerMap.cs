using CustomKeyboardsWeb.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Infrastructure.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("Customer");

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
                .HasColumnName("AddressValue");

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
