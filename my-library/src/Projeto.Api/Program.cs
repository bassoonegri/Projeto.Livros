using Microsoft.EntityFrameworkCore;
using Projeto.Api.Extencions;
using Projeto.Application;
using Projeto.Data;
using Projeto.Data.Context;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDataApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();

// Configure the DbContext with the SQL Server connection string
builder.Services.AddDbContext<ContextoBd>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LivroDb")));

// Add controllers and other services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();
 
