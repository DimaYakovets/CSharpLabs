using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Lab4.Models;

namespace Lab4.Configurations
{
    public sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.Property(e => e.Firstname).HasMaxLength(50);
            builder.Property(e => e.Patronymic).HasMaxLength(50);
            builder.Property(e => e.Phone).HasMaxLength(15);
            builder.Property(e => e.Surname).HasMaxLength(50);
            builder.HasOne(d => d.Address)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_Client_Address");
        }
    }
}
