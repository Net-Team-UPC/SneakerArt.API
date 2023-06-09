using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
using SneakerArt.API.User.Domain.Responsitories;
using SneakerArt.API.User.Domain.Services;
using SneakerArt.API.User.Interfaces.Internal;
using SneakerArt.API.User.Persistence.Repositories;
using SneakerArt.API.User.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Net Team SneakerArt API",
        Description = "Net Team SneakerArt RESTful API",
        TermsOfService = new Uri("https://net-team-upc.github.io/Landing-Page-NetTeam/terms-of-service/index.html"),
        Contact = new OpenApiContact
        {
            Name = "Net Team",
            Url = new Uri("https://frontend-sneakerart-e85e0.web.app")
        },
        License = new OpenApiLicense
        {
            Name = "Net Team SneakerArt Resources License",
            Url = new Uri("https://net-team-upc.github.io/Landing-Page-NetTeam/")
        }
    });
    options.EnableAnnotations();
});


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

//User Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

//Design Bounded Context Injection Configuration
builder.Services.AddScoped<IDesignRepository, DesignRepository>();
builder.Services.AddScoped<IDesignService, DesignService>();

//Comment Bounded Context Injection Configuration
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();

/*
builder.Services.AddScoped<ICollectionContextFacade, CollectionContextFacade>();
builder.Services.AddScoped<IUserContextFacade, UserContextFacade>();
*/



//Analytics Bounded Context Injection Configuration
/*
builder.Services.AddScoped<ICollectionAnalyticsService, CollectionAnalyticsService>();
builder.Services.AddScoped<IUserAnalyticsService, UserAnalyticsService>();
*/

//AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(SneakerArt.API.Collection.Mapping.ModelToResourceProfile),
    typeof(SneakerArt.API.Collection.Mapping.ResourceToModelProfile),
    typeof(SneakerArt.API.User.Mapping.ModelToResourceProfile),
    typeof(SneakerArt.API.User.Mapping.ResourceToModelProfile));

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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json","v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Required for Tests
public partial class Program {}