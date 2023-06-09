using Microsoft.EntityFrameworkCore;
using SneakerArt.API.Collection.Domain.Models;
using SneakerArt.API.Shared.Extensions;
using SneakerArt.API.User.Domain.Models;

namespace SneakerArt.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    
    public DbSet<Design> Designs { get; set; }


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

        
        //Profiles Configuration
        builder.Entity<Profile>().ToTable("Profiles");
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Profile>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Profile>().Property(p => p.Password).IsRequired().HasMaxLength(50);
        
        //Designs Configuration
        builder.Entity<Design>().ToTable("Designs");
        builder.Entity<Design>().HasKey(p => p.Id);
        builder.Entity<Design>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Design>().Property(p => p.Brand).IsRequired().HasMaxLength(50);
        builder.Entity<Design>().Property(p => p.Model).IsRequired().HasMaxLength(50);
        builder.Entity<Design>().Property(p => p.Color).IsRequired().HasMaxLength(50);
        builder.Entity<Design>().Property(p => p.Size).IsRequired().HasMaxLength(50);
        builder.Entity<Design>().Property(p => p.Img).IsRequired().HasMaxLength(200);

        
        //Relatioships
        
        //Apply snake case naming convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}