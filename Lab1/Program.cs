using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Lab1;

internal record Address(int Id, string City, string Street, int HouseNumber, int FlatNumber);
internal record OrderPart(int Id, int Order, int Pizza, double Discount, int Count);
internal record Client(int Id, string Name, string Surname, string Patronymic, string Phone, int Addres);
internal record Order(int Id, DateTime Date, int Client);
internal record Pizza(int Id, decimal Price, string Description);

internal static class Program
{
    private static async Task<Dictionary<int, TModel>> FetchModel<TModel>(SqlConnection connection) where TModel : class
    {
        Dictionary<int, TModel> items = new();

        SqlCommand getClients = new($"SELECT * FROM [{typeof(TModel).Name}]", connection);

        using (var reader = await getClients.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                object[] args = new object[reader.FieldCount];

                reader.GetValues(args);

                items.Add((int)args[0], Activator.CreateInstance(typeof(TModel), args) as TModel);
            }
        }

        return items;
    }

    static Dictionary<int, List<int>> MapOneToMany<TModel>(Dictionary<int, TModel> table, Func<TModel, int> getIdFunc)
    {
        Dictionary<int, List<int>> map = new();

        foreach (var item in table)
        {
            var id = getIdFunc(item.Value);

            if (!map.ContainsKey(id))
            {
                map.Add(id, new List<int>
                {
                    item.Key
                });
            }
            else
            {
                map[id].Add(item.Key);
            }
        }

        return map;
    }

    static async Task Main(string[] args)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfigurationRoot configuration = builder.Build();

        using SqlConnection connection = new(configuration.GetConnectionString("DefaultConnection"));
        await connection.OpenAsync();

        var addresses = await FetchModel<Address>(connection);
        var clients = await FetchModel<Client>(connection);
        var pizzas = await FetchModel<Pizza>(connection);
        var orders = await FetchModel<Order>(connection);
        var orderParts = await FetchModel<OrderPart>(connection);

        Dictionary<int, List<int>> OrderToOrderParts = MapOneToMany(orderParts, (o) => o.Order);
        Dictionary<int, List<int>> clientOrders = MapOneToMany(orders, (o) => o.Client);

        foreach (var clientId in clientOrders)
        {
            if (clientId.Value.Count >= 2)
            {
                Client client = clients[clientId.Key];

                foreach (var orderId in clientId.Value)
                {
                    Order order = orders[orderId];
                    Address address = addresses[client.Addres];
                    
                    Console.WriteLine("Order by {0} {1} at: {2}", client.Name, client.Surname, order.Date);
                    Console.WriteLine("Address {0} {1} street {2}:{3}", address.City, address.Street, address.HouseNumber, address.FlatNumber);

                    foreach (var partId in OrderToOrderParts[orderId])
                    {
                        OrderPart part = orderParts[partId];
                        Pizza pizza = pizzas[part.Pizza];

                        Console.WriteLine(" Pizza {0, -20} {1, -5}$ x {2, -2} -{3:G3}%", pizza.Description, pizza.Price, part.Count, part.Discount);
                    }

                    Console.WriteLine();
                }
            }
        }

        await connection.CloseAsync();

        Console.ReadLine();
    }
}
