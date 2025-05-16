using FluentValidation;
using System.Reflection;
using YummyRestaurant.WebApi.Contexts;
using YummyRestaurant.WebApi.Entities;
using YummyRestaurant.WebApi.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<YummyRestaurantApiContext>(); // Register the database context with the dependency injection container

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Register AutoMapper with the current assembly

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
