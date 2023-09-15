using Microsoft.Extensions.DependencyInjection;
using System.Data;
using TicketManagementSystem.BusinessLogic;
using TicketManagementSystem.Models;
using TicketManagementSystem.Profiles;
using TicketManagementSystem.Repositories;
using TicketManagementSystem.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IVenueRepository, VenueRepository>();
builder.Services.AddTransient<IEventTypeRepository, EventTypeRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<OrderServices>();
builder.Services.AddCors(
    o => {
        o.AddPolicy("_specifiOrigin", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("_specifiOrigin");
app.MapControllers();

app.Run();
