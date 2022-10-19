using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Lab4.Models;

namespace Lab4.Configurations
{
    public sealed class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizza");

            builder.Property(e => e.Description).HasMaxLength(500);

            builder.Property(e => e.Price).HasColumnType("money");
        }
    }
}
