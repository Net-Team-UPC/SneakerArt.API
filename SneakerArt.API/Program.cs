using Microsoft.EntityFrameworkCore;
using SneakerArt.API.Analytics.Domain.Services;
using SneakerArt.API.Analytics.Services;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Collection.Domain.Repositories;
using SneakerArt.API.Collection.Domain.Services;
using SneakerArt.API.Collection.Interfaces.Internal;
using SneakerArt.API.Collection.Persistence.Repositories;
using SneakerArt.API.Collection.Services;
using SneakerArt.API.Shared.Domain.Repositories;
using SneakerArt.API.Shared.Persistence.Contexts;
using SneakerArt.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

//Lowercase URLs configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Dependency Injection Configuration

//Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Collection Bounded Context Injection Configuration
builder.Services.AddScoped<IShoeRepository, ShoeRepository>();
builder.Services.AddScoped<IShoeService, ShoeService>();
builder.Services.AddScoped<ICollectionContextFacade, CollectionContextFacade>();


//Analytics Bounded Context Injection Configuration
builder.Services.AddScoped<ICollectionAnalyticsService, CollectionAnalyticsService>();

//AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(SneakerArt.API.Collection.Mapping.ModelToResourceProfile),
    typeof(SneakerArt.API.Collection.Mapping.ResourceToModelProfile));

//Application build
var app = builder.Build();

//Validation for ensuring Database Objects are created

using (var scope=app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


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