using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Lab8.Models;

namespace Lab8.Configurations
{
    public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.Property(e => e.Date).HasColumnType("date");

            builder.HasOne(d => d.Client)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Order_Client");
        }
    }
}
