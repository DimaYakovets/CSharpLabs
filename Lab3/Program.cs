using Lab3.Models;
using Lab3.Services;
using Microsoft.Extensions.Primitives;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton<DeliveryService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapGet(pattern: "/", async (ctx) =>
{
    ctx.Response.Headers["Content-Type"] = new StringValues("text/html; charset=UTF-8");

    DeliveryService service = app.Services.GetRequiredService<DeliveryService>();

    var builder = new StringBuilder();
    builder.Append(@"<html>
<head>
    <style>
        .order { 
            border-radius: 4px; 
            background-color: #ddd; 
            padding: 8px; 
            margin-top: 16px; 
        }
        .icon { 
            width: 128px; 
            height: 128px; 
        }
    </style>
</head>");

    builder.Append(@"<img class=""icon"" src=""/img/pizza.svg""></img>");

    foreach (var order in await service.GetAllOrders())
    {
        builder.Append(@"<div class=""order"">");
        Address address = order.Client.Address;

        builder.Append("<div>");
        builder.Append($"Order by {order.Client.Firstname} {order.Client.Surname} at: {order.Date}");
        builder.Append("</div>");

        builder.Append("<div>");
        builder.Append($"Address {address.City} {address.Street} street {address.HouseNumber}:{address.FlatNumber}");
        builder.Append("</div>");

        builder.Append("<div>Pizzas</div>");

        builder.Append("<ol>");
        foreach (var part in order.OrderParts)
        {
            Pizza pizza = part.Pizza;

            builder.Append("<li>");
            builder.Append($"Pizza {pizza.Description} {pizza.Price}$ x {part.Count} -{part.Discount}%");
            builder.Append("</li>");
        }
        builder.Append("</ol>");

        builder.Append("</div>");
        builder.Append("</body></html>");
    }

    await ctx.Response.WriteAsync(builder.ToString());
});

app.Run();
