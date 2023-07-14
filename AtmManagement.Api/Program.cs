using AtmManagement.Api.Data;
using AtmManagement.Api.Data.Repositories;
using AtmManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection of DbContext Class
builder.Services.AddDbContext<AtmDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adding the repository to the DI container
builder.Services.AddScoped<AtmManagement.Api.Data.Repository>();
builder.Services.AddScoped<IRepository<City>, CityRepository>();
builder.Services.AddScoped<IRepository<District>, DistrictRepository>();
builder.Services.AddScoped<IAtmRepository, AtmRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();




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
