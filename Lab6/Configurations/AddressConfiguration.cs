using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Lab6.Models;

namespace Lab6.Configurations
{
    public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.Property(e => e.City)
                .HasMaxLength(50)
                .HasDefaultValue("");
            builder.Property(e => e.Street)
                .HasMaxLength(50)
                .HasDefaultValue("");
        }
    }
}
