using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Models;

public partial class PizzaDeliveryContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPart> OrderParts { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }

    public PizzaDeliveryContext(DbContextOptions<PizzaDeliveryContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
