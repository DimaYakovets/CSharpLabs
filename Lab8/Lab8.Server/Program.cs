using Microsoft.EntityFrameworkCore;
using Lab8.Services;
using Lab8.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<PizzaDeliveryContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(st =>
    st.AddPolicy("CORSmain", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    }));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSmain");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
