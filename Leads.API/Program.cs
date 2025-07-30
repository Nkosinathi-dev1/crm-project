using Leads.Core.Interfaces;
using Leads.DataAccess.Data;
using Leads.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Getting the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Register ofr DataContext with SQL Server provider 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));  // or UseNpgsql() if using PostgreSQL in future

//Register of generic repository for IRepository<T>
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
