using CustomKeyboardsWeb.Domain.Primitives.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomKeyboardsWeb.Data.Mappings
{
    public class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> entity)
        {
            entity.ToTable("Member");

            entity.HasKey(e => e.Id);

            entity.OwnsOne(e => e.Name)
                .Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(20);

            entity.OwnsOne(e => e.Email)
                .Property(p => p.Value)
                .HasColumnName("Email")
                .HasMaxLength(40);

            entity.OwnsOne(e => e.Address)
                .Property(a => a.Value)
                .HasColumnName("AddressValue");

            entity.OwnsOne(e => e.Phone)
                .Property(p => p.Value)
                .HasColumnName("Phone")
                .HasMaxLength(20);

            entity.OwnsOne(e => e.Password)
                .Property(p => p.Value)
                .HasColumnName("Password")
                .HasMaxLength(60);

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
