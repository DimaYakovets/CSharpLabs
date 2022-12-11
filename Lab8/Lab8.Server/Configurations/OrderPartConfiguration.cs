using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Lab8.Models;

namespace Lab8.Configurations
{
    public sealed class OrderPartConfiguration : IEntityTypeConfiguration<OrderPart>
    {
        public void Configure(EntityTypeBuilder<OrderPart> builder)
        {
            builder.ToTable("OrderPart");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderParts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPart_Order");

            builder.HasOne(d => d.Pizza)
                .WithMany(p => p.OrderParts)
                .HasForeignKey(d => d.PizzaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPart_Pizza");
        }
    }
}
