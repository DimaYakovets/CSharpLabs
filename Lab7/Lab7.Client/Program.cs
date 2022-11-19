using Lab7.Client;
using Lab7.Client.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(typeof(IGenericClient<>), typeof(GenericClient<>));
builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri("https://localhost:7107/api/") 
    });

await builder.Build().RunAsync();
