using Lab2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
IConfigurationRoot configuration = builder.Build();

DbContextOptionsBuilder<PizzaDeliveryContext> builderOptions = new();
builderOptions.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

using PizzaDeliveryContext context = new(builderOptions.Options);

var clientQuery = from client in context.Set<Client>()
                  where client.Orders.Count > 1
                  select new
                  {
                      client,
                      address = client.Address,
                      orders = from order in client.Orders
                               select new
                               {
                                   order = order,
                                   parts = from part in order.OrderParts
                                           select new
                                           {
                                               pizza = part.Pizza,
                                               count = part.Count,
                                               discount = part.Discount
                                           }
                               }
                  };

foreach (var clientMeta in clientQuery)
{
    Client client = clientMeta.client;
    Address address = clientMeta.address;

    foreach (var order in clientMeta.orders)
    {
        Console.WriteLine("Order by {0} {1} at: {2}", client.Firstname, client.Surname, order.order.Date);
        Console.WriteLine("Address {0} {1} street {2}:{3}", address.City, address.Street, address.HouseNumber, address.FlatNumber);

        Pizza pizza = null!;

        foreach (var part in order.parts)
        {
            pizza = part.pizza;

            Console.WriteLine(" Pizza {0, -20} {1, -5}$ x {2, -2} -{3:G3}%", pizza.Description, pizza.Price, part.count, part.discount);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.ReadLine();
