using Microsoft.EntityFrameworkCore;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Shared.Extensions;

namespace SneakerArt.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Shoe> Shoes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Shoes Configuration
        builder.Entity<Shoe>().ToTable("Shoes");
        builder.Entity<Shoe>().HasKey(p => p.Id);
        builder.Entity<Shoe>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Shoe>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Shoe>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Entity<Shoe>().Property(p => p.Price).IsRequired().HasMaxLength(50);
        builder.Entity<Shoe>().Property(p => p.Img).IsRequired().HasMaxLength(200);

        
        //Relatioships
        
        //Apply snake case naming convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}